namespace Interface
{
    partial class Translater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Translater));
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            numbre = new TextBox();
            resultButton = new Button();
            help = new Label();
            toolTip1 = new ToolTip(components);
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            resultNumbre = new Label();
            label7 = new Label();
            accuracy = new TextBox();
            baseToChange = new TextBox();
            changedBase = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(155, 214);
            label1.Name = "label1";
            label1.Size = new Size(265, 45);
            label1.TabIndex = 0;
            label1.Text = "Исходное число*";
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
            label2.BackColor = Color.FromArgb(199, 210, 242);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Monotype Corsiva", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1103, 133);
            label2.TabIndex = 1;
            label2.Text = "Перевод чисел из одной системы счисления в другую ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numbre
            // 
            numbre.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            numbre.Location = new Point(528, 210);
            numbre.Name = "numbre";
            numbre.Size = new Size(128, 49);
            numbre.TabIndex = 2;
            // 
            // resultButton
            // 
            resultButton.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            resultButton.Location = new Point(392, 549);
            resultButton.Name = "resultButton";
            resultButton.Size = new Size(274, 73);
            resultButton.TabIndex = 8;
            resultButton.Text = "Рассчитать";
            resultButton.UseVisualStyleBackColor = true;
            resultButton.Click += result_Click;
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
            toolTip1.SetToolTip(help, resources.GetString("help.ToolTip"));
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
            label3.Location = new Point(70, 326);
            label3.Name = "label3";
            label3.Size = new Size(368, 45);
            label3.TabIndex = 21;
            label3.Text = "Направления перевода*";
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
            label4.Location = new Point(694, 329);
            label4.Name = "label4";
            label4.Size = new Size(35, 45);
            label4.TabIndex = 25;
            label4.Text = "в";
            // 
            // resultNumbre
            // 
            resultNumbre.AutoSize = true;
            resultNumbre.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            resultNumbre.Location = new Point(497, 679);
            resultNumbre.Name = "resultNumbre";
            resultNumbre.Size = new Size(65, 45);
            resultNumbre.TabIndex = 26;
            resultNumbre.Text = "     ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label7.Location = new Point(70, 444);
            label7.Name = "label7";
            label7.Size = new Size(406, 45);
            label7.TabIndex = 27;
            label7.Text = "Точность представления";
            // 
            // accuracy
            // 
            accuracy.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            accuracy.Location = new Point(528, 440);
            accuracy.Name = "accuracy";
            accuracy.Size = new Size(128, 49);
            accuracy.TabIndex = 28;
            // 
            // baseToChange
            // 
            baseToChange.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            baseToChange.Location = new Point(528, 326);
            baseToChange.Name = "baseToChange";
            baseToChange.Size = new Size(128, 49);
            baseToChange.TabIndex = 29;
            // 
            // changedBase
            // 
            changedBase.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            changedBase.Location = new Point(788, 326);
            changedBase.Name = "changedBase";
            changedBase.Size = new Size(128, 49);
            changedBase.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Monotype Corsiva", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.Location = new Point(438, 326);
            label6.Name = "label6";
            label6.Size = new Size(53, 45);
            label6.TabIndex = 31;
            label6.Text = "из";
            // 
            // Translater
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(199, 210, 242);
            ClientSize = new Size(1103, 809);
            Controls.Add(label6);
            Controls.Add(changedBase);
            Controls.Add(baseToChange);
            Controls.Add(accuracy);
            Controls.Add(label7);
            Controls.Add(resultNumbre);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(help);
            Controls.Add(resultButton);
            Controls.Add(numbre);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Translater";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox numbre;
        private Button resultButton;
        private Label help;
        private ToolTip toolTip1;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label resultNumbre;
        private Label label7;
        private TextBox accuracy;
        private TextBox baseToChange;
        private TextBox changedBase;
        private Label label6;
    }
}
