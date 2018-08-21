namespace Cuckooshka_2._0
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TuesdayButton = new System.Windows.Forms.Button();
            this.Today_panel = new System.Windows.Forms.Panel();
            this.Head_today = new System.Windows.Forms.Label();
            this.TodayListTextBox = new System.Windows.Forms.RichTextBox();
            this.cat_comboBox = new System.Windows.Forms.ComboBox();
            this.MondayButton = new System.Windows.Forms.Button();
            this.WednesdayButton = new System.Windows.Forms.Button();
            this.ThursdayButton = new System.Windows.Forms.Button();
            this.FridayButton = new System.Windows.Forms.Button();
            this.SaturdayButton = new System.Windows.Forms.Button();
            this.SundayButton = new System.Windows.Forms.Button();
            this.Today_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TuesdayButton
            // 
            this.TuesdayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.TuesdayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TuesdayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TuesdayButton.ForeColor = System.Drawing.Color.White;
            this.TuesdayButton.Location = new System.Drawing.Point(31, 62);
            this.TuesdayButton.Name = "TuesdayButton";
            this.TuesdayButton.Size = new System.Drawing.Size(643, 60);
            this.TuesdayButton.TabIndex = 2;
            this.TuesdayButton.Text = "+ Вторник";
            this.TuesdayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TuesdayButton.UseVisualStyleBackColor = false;
            this.TuesdayButton.Click += new System.EventHandler(this.TuesdayButton_Click);
            // 
            // Today_panel
            // 
            this.Today_panel.AutoScroll = true;
            this.Today_panel.BackColor = System.Drawing.Color.SteelBlue;
            this.Today_panel.Controls.Add(this.Head_today);
            this.Today_panel.Controls.Add(this.TodayListTextBox);
            this.Today_panel.Controls.Add(this.cat_comboBox);
            this.Today_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Today_panel.Location = new System.Drawing.Point(709, 0);
            this.Today_panel.Margin = new System.Windows.Forms.Padding(0);
            this.Today_panel.Name = "Today_panel";
            this.Today_panel.Size = new System.Drawing.Size(469, 723);
            this.Today_panel.TabIndex = 3;
            // 
            // Head_today
            // 
            this.Head_today.AutoSize = true;
            this.Head_today.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Head_today.ForeColor = System.Drawing.Color.White;
            this.Head_today.Location = new System.Drawing.Point(32, 27);
            this.Head_today.Name = "Head_today";
            this.Head_today.Size = new System.Drawing.Size(107, 32);
            this.Head_today.TabIndex = 11;
            this.Head_today.Text = "Сегодня";
            // 
            // TodayListTextBox
            // 
            this.TodayListTextBox.BackColor = System.Drawing.Color.SteelBlue;
            this.TodayListTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TodayListTextBox.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TodayListTextBox.ForeColor = System.Drawing.Color.White;
            this.TodayListTextBox.Location = new System.Drawing.Point(38, 92);
            this.TodayListTextBox.Name = "TodayListTextBox";
            this.TodayListTextBox.ReadOnly = true;
            this.TodayListTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TodayListTextBox.Size = new System.Drawing.Size(390, 586);
            this.TodayListTextBox.TabIndex = 1;
            this.TodayListTextBox.Text = "";
            // 
            // cat_comboBox
            // 
            this.cat_comboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cat_comboBox.ForeColor = System.Drawing.Color.DimGray;
            this.cat_comboBox.FormattingEnabled = true;
            this.cat_comboBox.Items.AddRange(new object[] {
            "Работа",
            "Домашние дела",
            "Учеба",
            "Другие"});
            this.cat_comboBox.Location = new System.Drawing.Point(215, 27);
            this.cat_comboBox.Name = "cat_comboBox";
            this.cat_comboBox.Size = new System.Drawing.Size(225, 36);
            this.cat_comboBox.TabIndex = 9;
            this.cat_comboBox.Text = "Все дела";
            this.cat_comboBox.Visible = false;
            // 
            // MondayButton
            // 
            this.MondayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.MondayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MondayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MondayButton.ForeColor = System.Drawing.Color.White;
            this.MondayButton.Location = new System.Drawing.Point(31, 2);
            this.MondayButton.Margin = new System.Windows.Forms.Padding(0);
            this.MondayButton.Name = "MondayButton";
            this.MondayButton.Size = new System.Drawing.Size(643, 60);
            this.MondayButton.TabIndex = 1;
            this.MondayButton.Text = "+ Понедельник";
            this.MondayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MondayButton.UseVisualStyleBackColor = false;
            this.MondayButton.Click += new System.EventHandler(this.MondayButton_Click);
            // 
            // WednesdayButton
            // 
            this.WednesdayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.WednesdayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WednesdayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WednesdayButton.ForeColor = System.Drawing.Color.White;
            this.WednesdayButton.Location = new System.Drawing.Point(31, 122);
            this.WednesdayButton.Name = "WednesdayButton";
            this.WednesdayButton.Size = new System.Drawing.Size(643, 60);
            this.WednesdayButton.TabIndex = 2;
            this.WednesdayButton.Text = "+ Среда";
            this.WednesdayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WednesdayButton.UseVisualStyleBackColor = false;
            this.WednesdayButton.Click += new System.EventHandler(this.WednesdayButton_Click);
            // 
            // ThursdayButton
            // 
            this.ThursdayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ThursdayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThursdayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThursdayButton.ForeColor = System.Drawing.Color.White;
            this.ThursdayButton.Location = new System.Drawing.Point(31, 183);
            this.ThursdayButton.Name = "ThursdayButton";
            this.ThursdayButton.Size = new System.Drawing.Size(643, 60);
            this.ThursdayButton.TabIndex = 2;
            this.ThursdayButton.Text = "+ Четверг";
            this.ThursdayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThursdayButton.UseVisualStyleBackColor = false;
            this.ThursdayButton.Click += new System.EventHandler(this.ThursdayButton_Click);
            // 
            // FridayButton
            // 
            this.FridayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.FridayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FridayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FridayButton.ForeColor = System.Drawing.Color.White;
            this.FridayButton.Location = new System.Drawing.Point(31, 244);
            this.FridayButton.Name = "FridayButton";
            this.FridayButton.Size = new System.Drawing.Size(643, 60);
            this.FridayButton.TabIndex = 2;
            this.FridayButton.Text = "+ Пятница";
            this.FridayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FridayButton.UseVisualStyleBackColor = false;
            this.FridayButton.Click += new System.EventHandler(this.FridayButton_Click);
            // 
            // SaturdayButton
            // 
            this.SaturdayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SaturdayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaturdayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaturdayButton.ForeColor = System.Drawing.Color.White;
            this.SaturdayButton.Location = new System.Drawing.Point(31, 305);
            this.SaturdayButton.Name = "SaturdayButton";
            this.SaturdayButton.Size = new System.Drawing.Size(643, 60);
            this.SaturdayButton.TabIndex = 2;
            this.SaturdayButton.Text = "+ Суббота";
            this.SaturdayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaturdayButton.UseVisualStyleBackColor = false;
            this.SaturdayButton.Click += new System.EventHandler(this.SaturdayButton_Click);
            // 
            // SundayButton
            // 
            this.SundayButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SundayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SundayButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SundayButton.ForeColor = System.Drawing.Color.White;
            this.SundayButton.Location = new System.Drawing.Point(31, 365);
            this.SundayButton.Name = "SundayButton";
            this.SundayButton.Size = new System.Drawing.Size(643, 60);
            this.SundayButton.TabIndex = 2;
            this.SundayButton.Text = "+ Воскресенье";
            this.SundayButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SundayButton.UseVisualStyleBackColor = false;
            this.SundayButton.Click += new System.EventHandler(this.SundayButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 723);
            this.Controls.Add(this.SundayButton);
            this.Controls.Add(this.SaturdayButton);
            this.Controls.Add(this.FridayButton);
            this.Controls.Add(this.ThursdayButton);
            this.Controls.Add(this.WednesdayButton);
            this.Controls.Add(this.TuesdayButton);
            this.Controls.Add(this.MondayButton);
            this.Controls.Add(this.Today_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUCKOOSHKA week 1.0 ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Today_panel.ResumeLayout(false);
            this.Today_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button TuesdayButton;
        private System.Windows.Forms.Panel Today_panel;
        private System.Windows.Forms.ComboBox cat_comboBox;
        private System.Windows.Forms.RichTextBox TodayListTextBox;
        private System.Windows.Forms.Button MondayButton;
        private System.Windows.Forms.Label Head_today;
        private System.Windows.Forms.Button WednesdayButton;
        private System.Windows.Forms.Button ThursdayButton;
        private System.Windows.Forms.Button FridayButton;
        private System.Windows.Forms.Button SaturdayButton;
        private System.Windows.Forms.Button SundayButton;
    }
}

