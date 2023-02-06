using System;
using System.Collections.Generic;
using System.Drawing;

namespace WarnockAlgorithm {
	class Warnock {


		public static List<Polygon> GetPolygons(bool add1, bool add2, bool add3, bool add4, bool add5, bool add6) {
			List<Polygon> polys = new List<Polygon>();
			List<MyPoint> points = new List<MyPoint>();

			// 1.
			//
			if (add1) {
				points.Clear();
				points.Add(new MyPoint(20, 150, 10));
				points.Add(new MyPoint(20, 100, 10));
				points.Add(new MyPoint(350, 100, 10));
				points.Add(new MyPoint(350, 150, 10));
				polys.Add(new Polygon(points, Color.DarkSeaGreen));
			}

			// 2.
			//
			if (add2) {
				points.Clear();
				points.Add(new MyPoint(50, 20, 50));
				points.Add(new MyPoint(120, 20, 50));
				points.Add(new MyPoint(120, 200, 50));
				points.Add(new MyPoint(50, 200, 50));
				polys.Add(new Polygon(points, Color.Chocolate));
			}

			// 3.
			//
			if (add3) {
				points.Clear();
				points.Add(new MyPoint(70, 50, 80));
				points.Add(new MyPoint(300, 10, -10));
				points.Add(new MyPoint(280, 300, -50));
				polys.Add(new Polygon(points, Color.Purple));
			}

			// 4.
			//
			int x = 200, y = 200;
			if (add4) {
				points.Clear();
				points.Add(new MyPoint(x + 50, y + 150, 0));
				points.Add(new MyPoint(x + 150, y + 200, 0));
				points.Add(new MyPoint(x + 150, y + 100, 60));
				polys.Add(new Polygon(points, Color.DarkOrange));
			}

			// 5.
			if (add5) {
				points.Clear();
				points.Add(new MyPoint(x + 50, y + 100, 0));
				points.Add(new MyPoint(x + 10, y + 200, 100));
				points.Add(new MyPoint(x + 200, y + 150, 0));
				polys.Add(new Polygon(points, Color.DarkViolet));
			}

			// 6.
			if (add6) {
				points.Clear();
				points.Add(new MyPoint(x + 50, y + 100, 8));
				points.Add(new MyPoint(x + 100, y + 256, 100));
				points.Add(new MyPoint(x + 150, y + 150, 6));
				polys.Add(new Polygon(points, Color.HotPink));
			}

			return polys;
		}

		public static List<int[]> SplitWindow(int x, int y, int size) {
			/* Функция разбиения окна на 4 подокна */

			List<int[]> res = new List<int[]>();

			// уменьшаем размер в два раза
			size /= 2;

			// если 0,0 - это верхний левый угол
			// и 512, 512 - это нижний правый угол
			// 1. нижнее правое окно
			// 2. нижнее левое окно
			// 3. верхнее правое окно
			// 4. верхнее левое окно
			//
			int[] win1 = { x + size, y + size, size };
			int[] win2 = { x, y + size, size };
			int[] win3 = { x + size, y, size };
			int[] win4 = { x, y, size };

			res.Add(win1);
			res.Add(win2);
			res.Add(win3);
			res.Add(win4);

			return res;
		}

		public static bool IsPointInside(MyPoint point, Polygon polygon) {
			/* Функция для определения, лежит ли точка внутри многоугольника */

			float x = point.x;
			float y = point.y;

			List<MyPoint> points = polygon.points;
			int num_points = points.Count;

			bool is_inside = false;

			float polygon_x = points[0].x;
			float polygon_y = points[0].y;

			for (int i = 1; i < num_points + 1; i++) {

				float point2x = points[i % num_points].x;
				float point2y = points[i % num_points].y;

				if (y > Math.Min(polygon_y, point2y))
					if (y <= Math.Max(polygon_y, point2y))
						if (x <= Math.Max(polygon_x, point2x)) {
							float x_inters = 0;

							if (polygon_y != point2y)
								x_inters = (y - polygon_y) * (point2x - polygon_x) / (point2y - polygon_y) + polygon_x;

							if (polygon_x == point2x || x <= x_inters)
								is_inside = !is_inside;
						}
				polygon_x = point2x;
				polygon_y = point2y;
			}
			return is_inside;
		}

		public static float FindCoordZ(MyPoint point, Polygon polygon) {
			/* Функция для определения Z координаты, зная X и Y */

			// берем три точки
			//
			MyPoint m1 = polygon.points[0];
			MyPoint m2 = polygon.points[1];
			MyPoint m3 = polygon.points[2];

			// вычисляем координаты двух векторов
			//
			float[] m1m2 = { m2.x - m1.x, m2.y - m1.y, m2.z - m1.z };
			float[] m1m3 = { m3.x - m1.x, m3.y - m1.y, m3.z - m1.z };

			// векторное произведение этих двух векторов
			//
			float[] vec_n = {   m1m2[1] * m1m3[2] - m1m2[2] * m1m3[1],
								m1m2[2] * m1m3[0] - m1m2[0] * m1m3[2],
								m1m2[0] * m1m3[1] - m1m2[1] * m1m3[0] };

			// 
			float d = -m1.x * vec_n[0] - m1.y * vec_n[1] - m1.z * vec_n[2];

			float[,] vec = {
				{vec_n[0], point.x },
				{vec_n[1], point.y },
				{vec_n[2], 0 }
			};

			float[] sums = { 0, 0 };

			for (int i = 0; i < 3; i++) {
				sums[0] += vec[i, 0] * vec_n[i];
				sums[1] += vec[i, 1] * vec_n[i];
			}

			sums[1] += d;

			float t = -sums[1] / sums[0];

			float x = vec_n[0] * t + point.x;
			float y = vec_n[1] * t + point.y;
			float z = vec_n[2] * t + 0;

			return z;
		}

		public static int PointsInPolygon(List<MyPoint> points, Polygon polygon) {
			/* Функция для вычисления кол-ва точек в многоугольнике */

			int res = 0;
			foreach (var point in points) if (IsPointInside(point, polygon)) res += 1;
			return res;
		}

		public static bool IsIntersected(Polygon poly1, Polygon poly2) {
			bool is_intersected = false;

			for (int i = 0; i < poly1.points.Count; i++)
				if (IsPointInsidePoly(poly1.points[i], poly2)) return true;

			for (int i = 0; i < poly2.points.Count; i++)
				if (IsPointInsidePoly(poly2.points[i], poly1)) return true;

			for (int i = 0, next = 1; i < poly1.points.Count; i++, next = (i + 1 == poly1.points.Count) ? 0 : i + 1)
				if (GetIntersectionPoints(poly1.points[i], poly1.points[next], poly2).Count > 0) return true;

			return is_intersected;
		}

		static bool IsPointInsidePoly(MyPoint test, Polygon poly) {
			int i;
			int j;
			bool result = false;
			for (i = 0, j = poly.points.Count - 1; i < poly.points.Count; j = i++) {
				if ((poly.points[i].y > test.y) != (poly.points[j].y > test.y) &&
					(test.x < (poly.points[j].x - poly.points[i].x) * (test.y - poly.points[i].y) / (poly.points[j].y - poly.points[i].y) + poly.points[i].x)) {
					result = !result;
				}
			}
			return result;
		}

		static List<MyPoint> GetIntersectionPoints(MyPoint l1p1, MyPoint l1p2, Polygon poly) {
			List<MyPoint> intersectionPoints = new List<MyPoint>();
			for (int i = 0; i < poly.points.Count; i++) {

				int next = (i + 1 == poly.points.Count) ? 0 : i + 1;

				MyPoint ip = GetIntersectionPoint(l1p1, l1p2, poly.points[i], poly.points[next]);

				if (ip != null) intersectionPoints.Add(ip);

			}

			return intersectionPoints;
		}

		static MyPoint GetIntersectionPoint(MyPoint l1p1, MyPoint l1p2, MyPoint l2p1, MyPoint l2p2) {
			bool IsEqual(double d1, double d2) {
				return Math.Abs(d1 - d2) <= 0.0000001;
			}

			double A1 = l1p2.y - l1p1.y;
			double B1 = l1p1.x - l1p2.x;
			double C1 = A1 * l1p1.x + B1 * l1p1.y;
			
			double A2 = l2p2.y - l2p1.y;
			double B2 = l2p1.x - l2p2.x;
			double C2 = A2 * l2p1.x + B2 * l2p1.y;

			//lines are parallel
			double det = A1 * B2 - A2 * B1;
			if (IsEqual(det, 0d)) {
				return null; //parallel lines
			}
			else {
				double x = (B2 * C1 - B1 * C2) / det;
				double y = (A1 * C2 - A2 * C1) / det;
				bool online1 = ((Math.Min(l1p1.x, l1p2.x) < x || IsEqual(Math.Min(l1p1.x, l1p2.x), x))
					&& (Math.Max(l1p1.x, l1p2.x) > x || IsEqual(Math.Max(l1p1.x, l1p2.x), x))
					&& (Math.Min(l1p1.y, l1p2.y) < y || IsEqual(Math.Min(l1p1.y, l1p2.y), y))
					&& (Math.Max(l1p1.y, l1p2.y) > y || IsEqual(Math.Max(l1p1.y, l1p2.y), y))
					);
				bool online2 = ((Math.Min(l2p1.x, l2p2.x) < x || IsEqual(Math.Min(l2p1.x, l2p2.x), x))
					&& (Math.Max(l2p1.x, l2p2.x) > x || IsEqual(Math.Max(l2p1.x, l2p2.x), x))
					&& (Math.Min(l2p1.y, l2p2.y) < y || IsEqual(Math.Min(l2p1.y, l2p2.y), y))
					&& (Math.Max(l2p1.y, l2p2.y) > y || IsEqual(Math.Max(l2p1.y, l2p2.y), y))
					);

				if (online1 && online2)
					return new MyPoint((float)x, (float)y, 0);
			}
			return null; //intersection is at out of at least one segment.
		}
	}
}
