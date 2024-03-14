namespace Sklep_Odzieżowy
{
    partial class ZmianaHasłaTymczasowego
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
            label4 = new Label();
            txtbPowtórzHasło = new TextBox();
            btnZarejestrujSię = new Button();
            label3 = new Label();
            txtbHaslo = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.SteelBlue;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(124, 212);
            label4.Name = "label4";
            label4.Size = new Size(122, 18);
            label4.TabIndex = 21;
            label4.Text = "Powtórz hasło:";
            // 
            // txtbPowtórzHasło
            // 
            txtbPowtórzHasło.Location = new Point(124, 245);
            txtbPowtórzHasło.Margin = new Padding(3, 2, 3, 2);
            txtbPowtórzHasło.Name = "txtbPowtórzHasło";
            txtbPowtórzHasło.Size = new Size(185, 23);
            txtbPowtórzHasło.TabIndex = 20;
            // 
            // btnZarejestrujSię
            // 
            btnZarejestrujSię.BackColor = Color.LightSkyBlue;
            btnZarejestrujSię.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnZarejestrujSię.ForeColor = Color.WhiteSmoke;
            btnZarejestrujSię.Location = new Point(124, 306);
            btnZarejestrujSię.Margin = new Padding(3, 2, 3, 2);
            btnZarejestrujSię.Name = "btnZarejestrujSię";
            btnZarejestrujSię.Size = new Size(185, 36);
            btnZarejestrujSię.TabIndex = 19;
            btnZarejestrujSię.Text = "Zmień hasło";
            btnZarejestrujSię.UseVisualStyleBackColor = false;
            btnZarejestrujSię.Click += btnZarejestrujSię_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(124, 134);
            label3.Name = "label3";
            label3.Size = new Size(102, 18);
            label3.TabIndex = 18;
            label3.Text = "Nowe hasło:";
            // 
            // txtbHaslo
            // 
            txtbHaslo.Location = new Point(124, 166);
            txtbHaslo.Margin = new Padding(3, 2, 3, 2);
            txtbHaslo.Name = "txtbHaslo";
            txtbHaslo.Size = new Size(185, 23);
            txtbHaslo.TabIndex = 17;
            // 
            // ZmianaHasłaTymczasowego
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(443, 487);
            Controls.Add(label4);
            Controls.Add(txtbPowtórzHasło);
            Controls.Add(btnZarejestrujSię);
            Controls.Add(label3);
            Controls.Add(txtbHaslo);
            Name = "ZmianaHasłaTymczasowego";
            Text = "ZmianaHasłaTymczasowego";
            Load += ZmianaHasłaTymczasowego_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private TextBox txtbPowtórzHasło;
        private Button btnZarejestrujSię;
        private Label label3;
        private TextBox txtbHaslo;
    }
}