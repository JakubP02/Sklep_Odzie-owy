namespace Sklep_Odzieżowy
{
    partial class KontoPracownik
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
            btnEdytujKlient = new Button();
            groupBox1 = new GroupBox();
            txtbNrTel = new TextBox();
            numericUpDownStawkaGodz = new NumericUpDown();
            label8 = new Label();
            txtbEmail = new TextBox();
            txtbNazwisko = new TextBox();
            txtbImię = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtbPowtórzHasło = new TextBox();
            txtbStareHasło = new TextBox();
            label6 = new Label();
            label1 = new Label();
            txtbNoweHasło = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox5 = new TextBox();
            textBox8 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            textBox15 = new TextBox();
            textBox16 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            groupBox3 = new GroupBox();
            btnZmianaHasła = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStawkaGodz).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnEdytujKlient
            // 
            btnEdytujKlient.BackColor = Color.LightSkyBlue;
            btnEdytujKlient.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdytujKlient.Location = new Point(104, 241);
            btnEdytujKlient.Name = "btnEdytujKlient";
            btnEdytujKlient.Size = new Size(125, 58);
            btnEdytujKlient.TabIndex = 9;
            btnEdytujKlient.Text = "Edytuj";
            btnEdytujKlient.UseVisualStyleBackColor = false;
            btnEdytujKlient.Click += btnEdytujKlient_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtbNrTel);
            groupBox1.Controls.Add(btnEdytujKlient);
            groupBox1.Controls.Add(numericUpDownStawkaGodz);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtbEmail);
            groupBox1.Controls.Add(txtbNazwisko);
            groupBox1.Controls.Add(txtbImię);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(190, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 316);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Edycja danych";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtbNrTel
            // 
            txtbNrTel.Location = new Point(109, 172);
            txtbNrTel.Name = "txtbNrTel";
            txtbNrTel.Size = new Size(168, 22);
            txtbNrTel.TabIndex = 19;
            // 
            // numericUpDownStawkaGodz
            // 
            numericUpDownStawkaGodz.DecimalPlaces = 2;
            numericUpDownStawkaGodz.Location = new Point(174, 211);
            numericUpDownStawkaGodz.Name = "numericUpDownStawkaGodz";
            numericUpDownStawkaGodz.ReadOnly = true;
            numericUpDownStawkaGodz.Size = new Size(88, 22);
            numericUpDownStawkaGodz.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 213);
            label8.Name = "label8";
            label8.Size = new Size(141, 16);
            label8.TabIndex = 17;
            label8.Text = "Stawka Godzinowa:";
            // 
            // txtbEmail
            // 
            txtbEmail.Location = new Point(109, 128);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(168, 22);
            txtbEmail.TabIndex = 9;
            // 
            // txtbNazwisko
            // 
            txtbNazwisko.Location = new Point(109, 83);
            txtbNazwisko.Name = "txtbNazwisko";
            txtbNazwisko.Size = new Size(168, 22);
            txtbNazwisko.TabIndex = 8;
            // 
            // txtbImię
            // 
            txtbImię.Location = new Point(109, 38);
            txtbImię.Name = "txtbImię";
            txtbImię.Size = new Size(168, 22);
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
            // txtbPowtórzHasło
            // 
            txtbPowtórzHasło.Location = new Point(134, 149);
            txtbPowtórzHasło.Name = "txtbPowtórzHasło";
            txtbPowtórzHasło.Size = new Size(153, 22);
            txtbPowtórzHasło.TabIndex = 16;
            // 
            // txtbStareHasło
            // 
            txtbStareHasło.Location = new Point(134, 56);
            txtbStareHasło.Name = "txtbStareHasło";
            txtbStareHasło.Size = new Size(153, 22);
            txtbStareHasło.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 152);
            label6.Name = "label6";
            label6.Size = new Size(110, 16);
            label6.TabIndex = 14;
            label6.Text = "Powtórz hasło:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 59);
            label1.Name = "label1";
            label1.Size = new Size(93, 16);
            label1.TabIndex = 13;
            label1.Text = "Stare hasło:";
            // 
            // txtbNoweHasło
            // 
            txtbNoweHasło.Location = new Point(134, 104);
            txtbNoweHasło.Name = "txtbNoweHasło";
            txtbNoweHasło.Size = new Size(153, 22);
            txtbNoweHasło.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 107);
            label7.Name = "label7";
            label7.Size = new Size(95, 16);
            label7.TabIndex = 5;
            label7.Text = "Nowe hasło:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox9);
            groupBox2.Controls.Add(textBox10);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox8);
            groupBox2.Controls.Add(textBox11);
            groupBox2.Controls.Add(textBox12);
            groupBox2.Controls.Add(textBox13);
            groupBox2.Controls.Add(textBox14);
            groupBox2.Controls.Add(textBox15);
            groupBox2.Controls.Add(textBox16);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label13);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(190, 349);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(401, 291);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Godziny pracy";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(258, 231);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 22);
            textBox9.TabIndex = 14;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(129, 231);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(100, 22);
            textBox10.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(258, 182);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 22);
            textBox5.TabIndex = 12;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(129, 182);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 22);
            textBox8.TabIndex = 11;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(258, 130);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(100, 22);
            textBox11.TabIndex = 10;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(129, 130);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(100, 22);
            textBox12.TabIndex = 9;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(258, 82);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(100, 22);
            textBox13.TabIndex = 8;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(129, 82);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(100, 22);
            textBox14.TabIndex = 7;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(258, 38);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(100, 22);
            textBox15.TabIndex = 6;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(129, 38);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(100, 22);
            textBox16.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 234);
            label9.Name = "label9";
            label9.Size = new Size(51, 16);
            label9.TabIndex = 4;
            label9.Text = "Piątek";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 185);
            label10.Name = "label10";
            label10.Size = new Size(69, 16);
            label10.TabIndex = 3;
            label10.Text = "Czwartek";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 133);
            label11.Name = "label11";
            label11.Size = new Size(49, 16);
            label11.TabIndex = 2;
            label11.Text = "Środa";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(23, 85);
            label12.Name = "label12";
            label12.Size = new Size(56, 16);
            label12.TabIndex = 1;
            label12.Text = "Wtorek";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(23, 41);
            label13.Name = "label13";
            label13.Size = new Size(100, 16);
            label13.TabIndex = 0;
            label13.Text = "Poniedziałek";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnZmianaHasła);
            groupBox3.Controls.Add(txtbStareHasło);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtbNoweHasło);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(txtbPowtórzHasło);
            groupBox3.Controls.Add(label7);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.WhiteSmoke;
            groupBox3.Location = new Point(586, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(334, 316);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Zmiana Hasła";
            // 
            // btnZmianaHasła
            // 
            btnZmianaHasła.BackColor = Color.LightSkyBlue;
            btnZmianaHasła.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnZmianaHasła.Location = new Point(108, 241);
            btnZmianaHasła.Name = "btnZmianaHasła";
            btnZmianaHasła.Size = new Size(134, 58);
            btnZmianaHasła.TabIndex = 17;
            btnZmianaHasła.Text = "Zmiana Hasła";
            btnZmianaHasła.UseVisualStyleBackColor = false;
            btnZmianaHasła.Click += btnZmianaHasła_Click;
            // 
            // KontoPracownik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1090, 695);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "KontoPracownik";
            Text = "KontoPracownik";
            Load += KontoPracownik_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStawkaGodz).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEdytujKlient;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDownStawkaGodz;
        private Label label8;
        private TextBox txtbPowtórzHasło;
        private TextBox txtbStareHasło;
        private Label label6;
        private Label label1;
        private TextBox txtbNoweHasło;
        private TextBox txtbEmail;
        private TextBox txtbNazwisko;
        private TextBox txtbImię;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox5;
        private TextBox textBox8;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtbNrTel;
        private GroupBox groupBox3;
        private Button btnZmianaHasła;
    }
}