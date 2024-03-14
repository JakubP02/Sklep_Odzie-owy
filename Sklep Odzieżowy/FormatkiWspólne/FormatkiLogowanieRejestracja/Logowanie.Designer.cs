namespace Sklep_Odzieżowy
{
    partial class Logowanie
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
            btnZaloguj = new Button();
            txtbEmail = new TextBox();
            txtbHasło = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnRejestracja = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(142, 52);
            label1.Name = "label1";
            label1.Size = new Size(164, 31);
            label1.TabIndex = 0;
            label1.Text = "Zaloguj się ";
            // 
            // btnZaloguj
            // 
            btnZaloguj.BackColor = Color.LightSkyBlue;
            btnZaloguj.FlatAppearance.BorderColor = Color.Black;
            btnZaloguj.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnZaloguj.ForeColor = Color.WhiteSmoke;
            btnZaloguj.Location = new Point(111, 317);
            btnZaloguj.Margin = new Padding(3, 2, 3, 2);
            btnZaloguj.Name = "btnZaloguj";
            btnZaloguj.Size = new Size(226, 44);
            btnZaloguj.TabIndex = 1;
            btnZaloguj.Text = "Zaloguj ";
            btnZaloguj.UseVisualStyleBackColor = false;
            btnZaloguj.Click += btnZaloguj_Click;
            // 
            // txtbEmail
            // 
            txtbEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtbEmail.Location = new Point(111, 148);
            txtbEmail.Margin = new Padding(3, 2, 3, 2);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(226, 26);
            txtbEmail.TabIndex = 2;
            // 
            // txtbHasło
            // 
            txtbHasło.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtbHasło.Location = new Point(111, 213);
            txtbHasło.Margin = new Padding(3, 2, 3, 2);
            txtbHasło.Name = "txtbHasło";
            txtbHasło.Size = new Size(226, 26);
            txtbHasło.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(111, 122);
            label2.Name = "label2";
            label2.Size = new Size(55, 18);
            label2.TabIndex = 4;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(111, 186);
            label3.Name = "label3";
            label3.Size = new Size(57, 18);
            label3.TabIndex = 5;
            label3.Text = "Hasło:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(111, 264);
            label4.Name = "label4";
            label4.Size = new Size(166, 20);
            label4.TabIndex = 6;
            label4.Text = "Zapomniałeś hasła ";
            label4.Click += label4_Click;
            // 
            // btnRejestracja
            // 
            btnRejestracja.BackColor = Color.LightSkyBlue;
            btnRejestracja.FlatAppearance.BorderColor = Color.Black;
            btnRejestracja.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRejestracja.ForeColor = Color.WhiteSmoke;
            btnRejestracja.Location = new Point(111, 381);
            btnRejestracja.Margin = new Padding(3, 2, 3, 2);
            btnRejestracja.Name = "btnRejestracja";
            btnRejestracja.Size = new Size(226, 44);
            btnRejestracja.TabIndex = 7;
            btnRejestracja.Text = "Zarejestruj się";
            btnRejestracja.UseVisualStyleBackColor = false;
            btnRejestracja.Click += btnRejestracja_Click;
            // 
            // Logowanie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(447, 526);
            Controls.Add(btnRejestracja);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtbHasło);
            Controls.Add(txtbEmail);
            Controls.Add(btnZaloguj);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Logowanie";
            Text = "Zaloguj się ";
            Load += Logowanie_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnZaloguj;
        private TextBox txtbEmail;
        private TextBox txtbHasło;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnRejestracja;
    }
}