using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WarnockAlgorithm {
	public partial class MainForm : Form {

		int WIN_SIZE = 512;
		int SLEEP_TIME;

		Color BG_EMPTY = Color.Gray;
		Color BG_COLOR = Color.White;
		Color SPLIT_COLOR = Color.Black;

		List<Polygon> polygons;
		int num_iter;
		String message;

		Graphics graphics;
		Bitmap bitmap;

		public MainForm() {
			SLEEP_TIME = 0;

			bitmap = new Bitmap(WIN_SIZE, WIN_SIZE);
			graphics = Graphics.FromImage(bitmap);

			DoubleBuffered = true;
			InitializeComponent();

			pictureBox.Image = bitmap;
			Draw(0, 0, WIN_SIZE, BG_EMPTY);
		}

		private void button_start_Click(object sender, EventArgs e) {
			/* Функция старта потока */

			polygons = Warnock.GetPolygons(
				checkBox_poly1.Checked,
				checkBox_poly2.Checked,
				checkBox_poly3.Checked,
				checkBox_poly4.Checked,
				checkBox_poly5.Checked,
				checkBox_poly6.Checked
				);

			// если поток не включен
			//
			if (MyBGWorker.IsBusy != true) {
				reset();

				// запускаем поток
				//
				MyBGWorker.RunWorkerAsync();
			}
		}

		private void button_cancel_Click(object sender, EventArgs e) {
			/* Функция отмены потока*/

			// если поток поддерживает отмену
			//
			if (MyBGWorker.WorkerSupportsCancellation == true) {
				
				// отменяем поток
				//
				MyBGWorker.CancelAsync();
			}
		}

		void Draw(int x, int y, int size, Color color) {
			/* Функция рисования квадрата по координатам X, Y размером SIZE, цвета color*/
			graphics.FillRectangle(new SolidBrush(color), x, y, size, size);
		}

		void DrawRect(int x, int y, int size, Color color) {
			/* Функция рисования квадрата по координатам X, Y размером SIZE, цвета color*/
			graphics.DrawRectangle(new Pen(color), x, y, size, size);
		}

		private void TrackBarSleepChanged(object sender, EventArgs e) {
			/* Эвент изменения значения на слайдере - время задержки отрисовки */
			SLEEP_TIME = trackBar_sleep.Value;
		}

		private void TextBoxLogChanged(object sender, EventArgs e) {
			/* Эвент сдвига каретки в текстбоксе на последний символ*/
			textBox_log.SelectionStart = textBox_log.Text.Length;
			textBox_log.ScrollToCaret();
		}

		private void button_reset_Click(object sender, EventArgs e) {
			/* Вызов функции очистки элементов при нажатии на кнопку */
			reset(); 
			pictureBox.Image = bitmap;
		}

		void reset() {
			/* Функция очистки элементов */
			Draw(0, 0, WIN_SIZE, BG_EMPTY);
			textBox_log.Text = "";
			label_num_iter.Text = "";
		}

		private void MyBGWorker_DoWork(object sender, DoWorkEventArgs e) {
			/* Работа потока */

			// стек окон
			//
			List<int[]> windows = new List<int[]>();

			// добавляем в стек фулл окно
			//
			int[] a = { 0, 0, WIN_SIZE };
			windows.Add(a);

			// кол-во итераций
			//
			num_iter = 0;

			// пока стек не пуст
			// выполняем цикл обработки окна из стека
			//
			while (windows.Count != 0) {

				// если отменили выполнение потока - выходим из цикла
				// иначе выполняем обработку очередного окна из стека
				//
				if (MyBGWorker.CancellationPending == true) { e.Cancel = true; break; }
				else {
					// инкриментируем кол-во итераций
					//
					num_iter++;

					// берем из стека очередное окно, удаляя его из стека
					// 
					int[] win = windows[0];
					windows.RemoveAt(0);

					// данные окна, используемые во время цикла обработки
					//
					int x = win[0], y = win[1], size = win[2];

					// если окно размером в 1 пиксель
					//
					if (size == 1) {

						// необходимо понять каким цветом покрасить этот пиксель
						// для этого необходимо понять какой многоугольник экранирует
						// т.е. у какого многоугольника Z в данной точке ближе к наблюдателю
						// если вообще есть многоугольник в этом пискеле
						// иначе покрасить фоном

						float max_z = -1000;
						Polygon max_polygon = null;

						// для каждого многоугольника вычисляем Z в данной точке
						// и запоминаем наибольшее (ближайшее) к наблюдателю
						//
						foreach (var polygon in polygons) {

							if (Warnock.IsPointInside(new MyPoint(x, y, 0), polygon)) {
								float z = Warnock.FindCoordZ(new MyPoint(x, y, 0), polygon);

								if (z > max_z) {
									max_polygon = polygon;
									max_z = z;
								}
							}
						}

						// если не нашли многоугольник красим в цвет фона
						// иначе красим цветом многоугольника
						//
						Color color;
						if (max_polygon == null) color = BG_COLOR; else color = max_polygon.color;

						// отрисовка
						//
						Draw(x, y, size, color);
						//message = "Pixel " + color.ToString() + " at ( " + x.ToString() + " , " + y.ToString() + " )";
						message = "";
						Thread.Sleep(SLEEP_TIME);
						MyBGWorker.ReportProgress(num_iter);

						// возвращаемся в начало цикла while
						//
						continue;
					}

					// создаем многоугольник "квадрат" - текущее окно
					//
					List<MyPoint> temp = new List<MyPoint>();
					temp.Add(new MyPoint(x, y, 0));
					temp.Add(new MyPoint(x, y + size, 0));
					temp.Add(new MyPoint(x + size, y + size, 0));
					temp.Add(new MyPoint(x + size, y, 0));
					Polygon rectangle = new Polygon(temp, Color.White);

					// если опция включена
					// нарисовать текущий квадрат
					//
					if (checkBox_splitting.Checked)
						if (size - 1 != 1) {
							DrawRect(x, y, size - 1, SPLIT_COLOR);
							message = "";
							Thread.Sleep(SLEEP_TIME);
							MyBGWorker.ReportProgress(num_iter);
						}

					// посчитаем кол-во многоугольников, которые пересекаются с окном
					//
					List<bool> is_intersec_poly = new List<bool>();
					foreach (var polygon in polygons) 
						is_intersec_poly.Add(Warnock.IsIntersected(rectangle, polygon));

					int num_intersec_poly = 0;
					foreach (var value in is_intersec_poly) 
						if (value) num_intersec_poly++;

					// -- Имеется единственный охватывающий многоугольник. В этом случае окно закрашивается его цветом. --
					//
					// если квадрат расположен полностью в многоугольнике и такой многоугольник один
					// т.е. многоугольник экранирует
					//
					// считаем для каждого многоугольника след.параметр:
					// кол-во вершин квадрата, которые входят в каждый многоугольник
					//
					List<int> rec_in_poly = new List<int>();
					foreach (var polygon in polygons) 
						rec_in_poly.Add(Warnock.PointsInPolygon(rectangle.points, polygon));

					List<int> indices_covering = new List<int>();
					for (int i = 0; i < rec_in_poly.Count; i++) 
						if (rec_in_poly[i] == 4) indices_covering.Add(i);

					if (indices_covering.Count == 1 && num_intersec_poly == 1) {
						// отрисовка
						//
						Draw(x, y, size, polygons[indices_covering[0]].color);
						message = "Poly " + polygons[indices_covering[0]].color.ToString() + " at ( " + x.ToString() + " , " + y.ToString() + " ) Size = " + size.ToString();
						Thread.Sleep(SLEEP_TIME);
						MyBGWorker.ReportProgress(num_iter);

						// возвращаемся в начало цикла while
						//
						continue;
					}

					// считаем для каждого многоугольника след.параметры:
					// 1. кол-во вершин квадрата, которые входят в каждый многоугольник
					// 2. кол-во вершин каждого многоугольника, которые входят в квадрат
					//
					bool split = false;
					if (is_intersec_poly.Contains(true)) split = true;

					// -- Все многоугольники сцены - внешние по отношению к окну. В этом случае окно закрашивается фоном --
					//
					// если квадрат не внутри никакого многоугольника 
					// и внутри квадрата нет многоугольника
					// то закрашиваем квадрат фоном
					//
					if (!split) {
						// отрисовка
						//
						Draw(x, y, size, BG_COLOR);
						message = "Whitebox at ( " + x.ToString() + " , " + y.ToString() + " ) Size = " + size.ToString();
						Thread.Sleep(SLEEP_TIME);
						MyBGWorker.ReportProgress(num_iter);

						// возвращаемся в начало цикла while
						//
						continue;
					}

					// -- Пересекающий многоугольник --
					//
					// если внутри квадрата есть хотя бы одна вершина многоугольника - разбиваем квадрат
					//
					else {
						windows.AddRange(Warnock.SplitWindow(x, y, size));

						// возвращаемся в начало цикла while
						//
						continue;
					}

					
				}
			} //end while
		}

		private void MyBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			/* Функция обновления элементов на форме во время работы потока */

			// если нет задержки
			// выводим сообщение в лог и делаем отрисовку
			// иначе выведем картинку при завершении потока
			//
			if (SLEEP_TIME != 0) {
				label_num_iter.Text = num_iter.ToString();
				if (message != "" && checkBox_Messages.Checked) textBox_log.Text += message + "\r\n";
				pictureBox.Image = bitmap; 
			}
		}

		private void MyBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			/* Функция выполнения действий при завершении потока */

			void display_message(String msg) {
				/* Функция вывода сообщения */
				MessageBox.Show(msg);
			}

			// если отменили выполнение потока
			// выводим соответствующее сообщение
			//
			if (e.Cancelled == true) {
				display_message("Cancelled");
			}
			// иначе если была ошибка - сообщение об ошибке
			//
			else if (e.Error != null) {
				display_message("Error: " + e.Error.Message);
			}
			// иначе выводим конечное изображение
			// и кол-во обработанных окон
			//
			else {
				
				label_num_iter.Text = num_iter.ToString();
				pictureBox.Image = bitmap;

				display_message("Done");
			}
		}

		
	}
}
