namespace WarnockAlgorithm {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.button_start = new System.Windows.Forms.Button();
			this.label_num_iter = new System.Windows.Forms.Label();
			this.textBox_log = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.trackBar_sleep = new System.Windows.Forms.TrackBar();
			this.button_reset = new System.Windows.Forms.Button();
			this.MyBGWorker = new System.ComponentModel.BackgroundWorker();
			this.button_cancel = new System.Windows.Forms.Button();
			this.checkBox_Messages = new System.Windows.Forms.CheckBox();
			this.checkBox_splitting = new System.Windows.Forms.CheckBox();
			this.checkBox_poly1 = new System.Windows.Forms.CheckBox();
			this.checkBox_poly2 = new System.Windows.Forms.CheckBox();
			this.checkBox_poly6 = new System.Windows.Forms.CheckBox();
			this.checkBox_poly5 = new System.Windows.Forms.CheckBox();
			this.checkBox_poly4 = new System.Windows.Forms.CheckBox();
			this.checkBox_poly3 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_sleep)).BeginInit();
			this.SuspendLayout();
			// 
			// button_start
			// 
			this.button_start.Location = new System.Drawing.Point(530, 399);
			this.button_start.Name = "button_start";
			this.button_start.Size = new System.Drawing.Size(87, 39);
			this.button_start.TabIndex = 0;
			this.button_start.Text = "Start";
			this.button_start.UseVisualStyleBackColor = true;
			this.button_start.Click += new System.EventHandler(this.button_start_Click);
			// 
			// label_num_iter
			// 
			this.label_num_iter.AutoSize = true;
			this.label_num_iter.Location = new System.Drawing.Point(530, 12);
			this.label_num_iter.Name = "label_num_iter";
			this.label_num_iter.Size = new System.Drawing.Size(22, 25);
			this.label_num_iter.TabIndex = 1;
			this.label_num_iter.Text = "0";
			// 
			// textBox_log
			// 
			this.textBox_log.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox_log.Location = new System.Drawing.Point(530, 40);
			this.textBox_log.MaxLength = 3276700;
			this.textBox_log.Multiline = true;
			this.textBox_log.Name = "textBox_log";
			this.textBox_log.ReadOnly = true;
			this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_log.Size = new System.Drawing.Size(353, 353);
			this.textBox_log.TabIndex = 2;
			this.textBox_log.TextChanged += new System.EventHandler(this.TextBoxLogChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(512, 512);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// trackBar_sleep
			// 
			this.trackBar_sleep.Location = new System.Drawing.Point(535, 485);
			this.trackBar_sleep.Maximum = 3000;
			this.trackBar_sleep.Name = "trackBar_sleep";
			this.trackBar_sleep.Size = new System.Drawing.Size(395, 45);
			this.trackBar_sleep.TabIndex = 4;
			this.trackBar_sleep.ValueChanged += new System.EventHandler(this.TrackBarSleepChanged);
			// 
			// button_reset
			// 
			this.button_reset.Location = new System.Drawing.Point(716, 399);
			this.button_reset.Name = "button_reset";
			this.button_reset.Size = new System.Drawing.Size(87, 39);
			this.button_reset.TabIndex = 5;
			this.button_reset.Text = "Reset";
			this.button_reset.UseVisualStyleBackColor = true;
			this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
			// 
			// MyBGWorker
			// 
			this.MyBGWorker.WorkerReportsProgress = true;
			this.MyBGWorker.WorkerSupportsCancellation = true;
			this.MyBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MyBGWorker_DoWork);
			this.MyBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MyBGWorker_ProgressChanged);
			this.MyBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MyBGWorker_RunWorkerCompleted);
			// 
			// button_cancel
			// 
			this.button_cancel.Location = new System.Drawing.Point(623, 399);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(87, 39);
			this.button_cancel.TabIndex = 6;
			this.button_cancel.Text = "Cancel";
			this.button_cancel.UseVisualStyleBackColor = true;
			this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
			// 
			// checkBox_Messages
			// 
			this.checkBox_Messages.AutoSize = true;
			this.checkBox_Messages.Location = new System.Drawing.Point(809, 399);
			this.checkBox_Messages.Name = "checkBox_Messages";
			this.checkBox_Messages.Size = new System.Drawing.Size(113, 29);
			this.checkBox_Messages.TabIndex = 7;
			this.checkBox_Messages.Text = "Messages";
			this.checkBox_Messages.UseVisualStyleBackColor = true;
			// 
			// checkBox_splitting
			// 
			this.checkBox_splitting.AutoSize = true;
			this.checkBox_splitting.Location = new System.Drawing.Point(809, 434);
			this.checkBox_splitting.Name = "checkBox_splitting";
			this.checkBox_splitting.Size = new System.Drawing.Size(101, 29);
			this.checkBox_splitting.TabIndex = 8;
			this.checkBox_splitting.Text = "Splitting";
			this.checkBox_splitting.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly1
			// 
			this.checkBox_poly1.AutoSize = true;
			this.checkBox_poly1.Checked = true;
			this.checkBox_poly1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly1.Location = new System.Drawing.Point(889, 40);
			this.checkBox_poly1.Name = "checkBox_poly1";
			this.checkBox_poly1.Size = new System.Drawing.Size(38, 29);
			this.checkBox_poly1.TabIndex = 9;
			this.checkBox_poly1.Text = "1";
			this.checkBox_poly1.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly2
			// 
			this.checkBox_poly2.AutoSize = true;
			this.checkBox_poly2.Checked = true;
			this.checkBox_poly2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly2.Location = new System.Drawing.Point(889, 75);
			this.checkBox_poly2.Name = "checkBox_poly2";
			this.checkBox_poly2.Size = new System.Drawing.Size(41, 29);
			this.checkBox_poly2.TabIndex = 10;
			this.checkBox_poly2.Text = "2";
			this.checkBox_poly2.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly6
			// 
			this.checkBox_poly6.AutoSize = true;
			this.checkBox_poly6.Checked = true;
			this.checkBox_poly6.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly6.Location = new System.Drawing.Point(889, 215);
			this.checkBox_poly6.Name = "checkBox_poly6";
			this.checkBox_poly6.Size = new System.Drawing.Size(41, 29);
			this.checkBox_poly6.TabIndex = 12;
			this.checkBox_poly6.Text = "6";
			this.checkBox_poly6.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly5
			// 
			this.checkBox_poly5.AutoSize = true;
			this.checkBox_poly5.Checked = true;
			this.checkBox_poly5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly5.Location = new System.Drawing.Point(889, 180);
			this.checkBox_poly5.Name = "checkBox_poly5";
			this.checkBox_poly5.Size = new System.Drawing.Size(41, 29);
			this.checkBox_poly5.TabIndex = 11;
			this.checkBox_poly5.Text = "5";
			this.checkBox_poly5.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly4
			// 
			this.checkBox_poly4.AutoSize = true;
			this.checkBox_poly4.Checked = true;
			this.checkBox_poly4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly4.Location = new System.Drawing.Point(889, 145);
			this.checkBox_poly4.Name = "checkBox_poly4";
			this.checkBox_poly4.Size = new System.Drawing.Size(42, 29);
			this.checkBox_poly4.TabIndex = 14;
			this.checkBox_poly4.Text = "4";
			this.checkBox_poly4.UseVisualStyleBackColor = true;
			// 
			// checkBox_poly3
			// 
			this.checkBox_poly3.AutoSize = true;
			this.checkBox_poly3.Checked = true;
			this.checkBox_poly3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_poly3.Location = new System.Drawing.Point(889, 110);
			this.checkBox_poly3.Name = "checkBox_poly3";
			this.checkBox_poly3.Size = new System.Drawing.Size(41, 29);
			this.checkBox_poly3.TabIndex = 13;
			this.checkBox_poly3.Text = "3";
			this.checkBox_poly3.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(942, 538);
			this.Controls.Add(this.checkBox_poly4);
			this.Controls.Add(this.checkBox_poly3);
			this.Controls.Add(this.checkBox_poly6);
			this.Controls.Add(this.checkBox_poly5);
			this.Controls.Add(this.checkBox_poly2);
			this.Controls.Add(this.checkBox_poly1);
			this.Controls.Add(this.checkBox_splitting);
			this.Controls.Add(this.checkBox_Messages);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.button_reset);
			this.Controls.Add(this.trackBar_sleep);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.textBox_log);
			this.Controls.Add(this.label_num_iter);
			this.Controls.Add(this.button_start);
			this.Font = new System.Drawing.Font("Segoe WP", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.Text = "Warnock Algorithm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_sleep)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_start;
		private System.Windows.Forms.Label label_num_iter;
		private System.Windows.Forms.TextBox textBox_log;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TrackBar trackBar_sleep;
		private System.Windows.Forms.Button button_reset;
		private System.ComponentModel.BackgroundWorker MyBGWorker;
		private System.Windows.Forms.Button button_cancel;
		private System.Windows.Forms.CheckBox checkBox_Messages;
		private System.Windows.Forms.CheckBox checkBox_splitting;
		private System.Windows.Forms.CheckBox checkBox_poly1;
		private System.Windows.Forms.CheckBox checkBox_poly2;
		private System.Windows.Forms.CheckBox checkBox_poly6;
		private System.Windows.Forms.CheckBox checkBox_poly5;
		private System.Windows.Forms.CheckBox checkBox_poly4;
		private System.Windows.Forms.CheckBox checkBox_poly3;
	}
}

