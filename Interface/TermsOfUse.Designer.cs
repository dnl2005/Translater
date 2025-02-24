namespace Interface
{
    partial class TermsOfUse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermsOfUse));
            LabelTermOfUse = new Label();
            SuspendLayout();
            // 
            // LabelTermOfUse
            // 
            LabelTermOfUse.Dock = DockStyle.Fill;
            LabelTermOfUse.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelTermOfUse.ImageAlign = ContentAlignment.TopLeft;
            LabelTermOfUse.Location = new Point(0, 0);
            LabelTermOfUse.Name = "LabelTermOfUse";
            LabelTermOfUse.Size = new Size(1532, 853);
            LabelTermOfUse.TabIndex = 0;
            LabelTermOfUse.Text = resources.GetString("LabelTermOfUse.Text");
            // 
            // TermsOfUse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1532, 853);
            Controls.Add(LabelTermOfUse);
            Name = "TermsOfUse";
            Text = "Руководство пользователя";
            ResumeLayout(false);
        }

        #endregion

        private Label LabelTermOfUse;
    }
}