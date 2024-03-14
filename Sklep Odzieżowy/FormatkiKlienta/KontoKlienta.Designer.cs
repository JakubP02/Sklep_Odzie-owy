namespace Sklep_Odzieżowy
{
    partial class KontoKlienta
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
            groupBox1 = new GroupBox();
            txtbNrTel = new TextBox();
            txtbEmail = new TextBox();
            btnEdytujKlient = new Button();
            txtbNazwisko = new TextBox();
            txtbImię = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtbPowtorzHaslo = new TextBox();
            txtbStareHaslo = new TextBox();
            label6 = new Label();
            label1 = new Label();
            txtbNoweHaslo = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            buttonZmieńHasło = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtbNrTel);
            groupBox1.Controls.Add(txtbEmail);
            groupBox1.Controls.Add(btnEdytujKlient);
            groupBox1.Controls.Add(txtbNazwisko);
            groupBox1.Controls.Add(txtbImię);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(186, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 306);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Edycja danych";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtbNrTel
            // 
            txtbNrTel.Location = new Point(116, 172);
            txtbNrTel.Name = "txtbNrTel";
            txtbNrTel.Size = new Size(173, 22);
            txtbNrTel.TabIndex = 17;
            // 
            // txtbEmail
            // 
            txtbEmail.Location = new Point(116, 128);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(173, 22);
            txtbEmail.TabIndex = 9;
            // 
            // btnEdytujKlient
            // 
            btnEdytujKlient.BackColor = Color.LightSkyBlue;
            btnEdytujKlient.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdytujKlient.Location = new Point(126, 229);
            btnEdytujKlient.Name = "btnEdytujKlient";
            btnEdytujKlient.Size = new Size(132, 47);
            btnEdytujKlient.TabIndex = 6;
            btnEdytujKlient.Text = "Edytuj";
            btnEdytujKlient.UseVisualStyleBackColor = false;
            btnEdytujKlient.Click += btnEdytujKlient_Click;
            // 
            // txtbNazwisko
            // 
            txtbNazwisko.Location = new Point(116, 83);
            txtbNazwisko.Name = "txtbNazwisko";
            txtbNazwisko.Size = new Size(173, 22);
            txtbNazwisko.TabIndex = 8;
            // 
            // txtbImię
            // 
            txtbImię.Location = new Point(116, 38);
            txtbImię.Name = "txtbImię";
            txtbImię.Size = new Size(173, 22);
            txtbImię.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 175);
            label5.Name = "label5";
            label5.Size = new Size(54, 16);
            label5.TabIndex = 3;
            label5.Text = "Nr Tel:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 128);
            label4.Name = "label4";
            label4.Size = new Size(50, 16);
            label4.TabIndex = 2;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 86);
            label3.Name = "label3";
            label3.Size = new Size(77, 16);
            label3.TabIndex = 1;
            label3.Text = "Nazwisko:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 38);
            label2.Name = "label2";
            label2.Size = new Size(40, 16);
            label2.TabIndex = 0;
            label2.Text = "Imię:";
            // 
            // txtbPowtorzHaslo
            // 
            txtbPowtorzHaslo.Location = new Point(139, 136);
            txtbPowtorzHaslo.Name = "txtbPowtorzHaslo";
            txtbPowtorzHaslo.Size = new Size(153, 22);
            txtbPowtorzHaslo.TabIndex = 16;
            // 
            // txtbStareHaslo
            // 
            txtbStareHaslo.Location = new Point(139, 35);
            txtbStareHaslo.Name = "txtbStareHaslo";
            txtbStareHaslo.Size = new Size(153, 22);
            txtbStareHaslo.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 139);
            label6.Name = "label6";
            label6.Size = new Size(110, 16);
            label6.TabIndex = 14;
            label6.Text = "Powtórz hasło:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 38);
            label1.Name = "label1";
            label1.Size = new Size(93, 16);
            label1.TabIndex = 13;
            label1.Text = "Stare hasło:";
            // 
            // txtbNoweHaslo
            // 
            txtbNoweHaslo.Location = new Point(139, 83);
            txtbNoweHaslo.Name = "txtbNoweHaslo";
            txtbNoweHaslo.Size = new Size(153, 22);
            txtbNoweHaslo.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 86);
            label7.Name = "label7";
            label7.Size = new Size(95, 16);
            label7.TabIndex = 5;
            label7.Text = "Nowe hasło:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonZmieńHasło);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtbNoweHaslo);
            groupBox2.Controls.Add(txtbPowtorzHaslo);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtbStareHaslo);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(643, 68);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(396, 306);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Zmiana Hasła";
            // 
            // buttonZmieńHasło
            // 
            buttonZmieńHasło.BackColor = Color.LightSkyBlue;
            buttonZmieńHasło.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonZmieńHasło.Location = new Point(102, 229);
            buttonZmieńHasło.Name = "buttonZmieńHasło";
            buttonZmieńHasło.Size = new Size(132, 47);
            buttonZmieńHasło.TabIndex = 17;
            buttonZmieńHasło.Text = "Zmień hasło";
            buttonZmieńHasło.UseVisualStyleBackColor = false;
            buttonZmieńHasło.Click += button1_Click;
            // 
            // KontoKlienta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1175, 516);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "KontoKlienta";
            Text = "KontoKlienta";
            Load += KontoKlienta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private Label label1;
        private TextBox txtbNoweHaslo;
        private TextBox txtbEmail;
        private TextBox txtbNazwisko;
        private TextBox txtbImię;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtbPowtorzHaslo;
        private TextBox txtbStareHaslo;
        private Button btnEdytujKlient;
        private TextBox txtbNrTel;
        private GroupBox groupBox2;
        private Button buttonZmieńHasło;
    }
}