namespace Interface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            help = new Label();
            toolTip1 = new ToolTip(components);
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(91, 210);
            label1.Name = "label1";
            label1.Size = new Size(248, 45);
            label1.TabIndex = 0;
            label1.Text = "Исходное число";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 255);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1103, 133);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Monotype Corsiva", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1103, 133);
            label2.TabIndex = 1;
            label2.Text = "Перевод чисел из одной системы счисления в другую ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(497, 210);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 49);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Monotype Corsiva", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.Location = new Point(497, 545);
            button1.Name = "button1";
            button1.Size = new Size(274, 73);
            button1.TabIndex = 8;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // help
            // 
            help.AutoSize = true;
            help.BackColor = Color.DeepSkyBlue;
            help.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            help.ForeColor = SystemColors.ControlLightLight;
            help.Location = new Point(1060, 759);
            help.Name = "help";
            help.Size = new Size(31, 41);
            help.TabIndex = 20;
            help.Text = "?";
            help.TextAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(help, "svjsojvds\r\nykff");
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 0;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.Location = new Point(91, 326);
            label3.Name = "label3";
            label3.Size = new Size(351, 45);
            label3.TabIndex = 21;
            label3.Text = "Направления перевода";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(91, 679);
            label5.Name = "label5";
            label5.Size = new Size(184, 45);
            label5.TabIndex = 22;
            label5.Text = "Результат";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.Location = new Point(736, 326);
            label4.Name = "label4";
            label4.Size = new Size(35, 45);
            label4.TabIndex = 25;
            label4.Text = "в";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.Location = new Point(497, 679);
            label6.Name = "label6";
            label6.Size = new Size(65, 45);
            label6.TabIndex = 26;
            label6.Text = "     ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label7.Location = new Point(91, 444);
            label7.Name = "label7";
            label7.Size = new Size(177, 45);
            label7.TabIndex = 27;
            label7.Text = "Точность";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(497, 440);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(202, 49);
            textBox2.TabIndex = 28;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            textBox3.Location = new Point(497, 326);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(202, 49);
            textBox3.TabIndex = 29;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            textBox4.Location = new Point(812, 326);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(202, 49);
            textBox4.TabIndex = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(1103, 809);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(help);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Label help;
        private ToolTip toolTip1;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}
