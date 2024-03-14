namespace Sklep_Odzieżowy
{
    partial class KlienciRaport
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 63);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 16);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // KlienciRaport
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(617, 251);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(4, 3, 4, 3);
            Name = "KlienciRaport";
            Text = "KtóryKlientWydałNajwięcejRaport";
            Load += KtóryKlientWydałNajwięcejRaport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
    }
}