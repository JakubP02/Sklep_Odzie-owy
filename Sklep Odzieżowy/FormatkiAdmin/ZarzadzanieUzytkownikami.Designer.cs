namespace Sklep_Odzieżowy
{
    partial class ZarzadzanieUzytkownikami
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            txtbNrTelEdycja = new TextBox();
            txtbEmailEdycja = new TextBox();
            btnEdytujUzytk = new Button();
            btnUsunUzytk = new Button();
            txtbNazwiskoEdycja = new TextBox();
            TxtbImięEdycja = new TextBox();
            label8 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtbHasłoEdycja = new TextBox();
            label7 = new Label();
            groupBox2 = new GroupBox();
            numericUpDownStawkaGodz = new NumericUpDown();
            button1 = new Button();
            labelStawkaGodz = new Label();
            label9 = new Label();
            txtbNrTel = new TextBox();
            label10 = new Label();
            txtbNazwisko = new TextBox();
            label12 = new Label();
            txtbImię = new TextBox();
            label13 = new Label();
            txtbPowtórzEmail = new TextBox();
            label14 = new Label();
            txtbPowtórzHasło = new TextBox();
            label15 = new Label();
            label16 = new Label();
            txtbHaslo = new TextBox();
            txtbEmail = new TextBox();
            comboBoxDodajPracownika = new ComboBox();
            label11 = new Label();
            groupBox3 = new GroupBox();
            txtbNoweHasłoEdycja = new TextBox();
            button2 = new Button();
            txtbPowtórzHasloEdycja = new TextBox();
            label6 = new Label();
            txtbRola = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStawkaGodz).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.LightSkyBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.SkyBlue;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(50, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(872, 226);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(txtbNrTelEdycja);
            groupBox1.Controls.Add(txtbEmailEdycja);
            groupBox1.Controls.Add(btnEdytujUzytk);
            groupBox1.Controls.Add(btnUsunUzytk);
            groupBox1.Controls.Add(txtbNazwiskoEdycja);
            groupBox1.Controls.Add(TxtbImięEdycja);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(50, 305);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 324);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Edycja danych";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(153, 217);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 22);
            numericUpDown1.TabIndex = 13;
            // 
            // txtbNrTelEdycja
            // 
            txtbNrTelEdycja.Location = new Point(153, 169);
            txtbNrTelEdycja.Name = "txtbNrTelEdycja";
            txtbNrTelEdycja.Size = new Size(153, 22);
            txtbNrTelEdycja.TabIndex = 10;
            // 
            // txtbEmailEdycja
            // 
            txtbEmailEdycja.Location = new Point(153, 125);
            txtbEmailEdycja.Name = "txtbEmailEdycja";
            txtbEmailEdycja.Size = new Size(153, 22);
            txtbEmailEdycja.TabIndex = 9;
            // 
            // btnEdytujUzytk
            // 
            btnEdytujUzytk.BackColor = Color.LightSkyBlue;
            btnEdytujUzytk.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdytujUzytk.Location = new Point(89, 263);
            btnEdytujUzytk.Name = "btnEdytujUzytk";
            btnEdytujUzytk.Size = new Size(102, 46);
            btnEdytujUzytk.TabIndex = 6;
            btnEdytujUzytk.Text = "Edytuj";
            btnEdytujUzytk.UseVisualStyleBackColor = false;
            btnEdytujUzytk.Click += btnEdytujUzytk_Click;
            // 
            // btnUsunUzytk
            // 
            btnUsunUzytk.BackColor = Color.LightSkyBlue;
            btnUsunUzytk.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsunUzytk.Location = new Point(237, 263);
            btnUsunUzytk.Name = "btnUsunUzytk";
            btnUsunUzytk.Size = new Size(102, 46);
            btnUsunUzytk.TabIndex = 7;
            btnUsunUzytk.Text = "Usuń";
            btnUsunUzytk.UseVisualStyleBackColor = false;
            btnUsunUzytk.Click += btnUsunUzytk_Click;
            // 
            // txtbNazwiskoEdycja
            // 
            txtbNazwiskoEdycja.Location = new Point(153, 80);
            txtbNazwiskoEdycja.Name = "txtbNazwiskoEdycja";
            txtbNazwiskoEdycja.Size = new Size(153, 22);
            txtbNazwiskoEdycja.TabIndex = 8;
            // 
            // TxtbImięEdycja
            // 
            TxtbImięEdycja.Location = new Point(153, 35);
            TxtbImięEdycja.Name = "TxtbImięEdycja";
            TxtbImięEdycja.Size = new Size(153, 22);
            TxtbImięEdycja.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 222);
            label8.Name = "label8";
            label8.Size = new Size(141, 16);
            label8.TabIndex = 6;
            label8.Text = "Stawka Godzinowa:";
            label8.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 174);
            label5.Name = "label5";
            label5.Size = new Size(54, 16);
            label5.TabIndex = 3;
            label5.Text = "Nr Tel:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 128);
            label4.Name = "label4";
            label4.Size = new Size(50, 16);
            label4.TabIndex = 2;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 83);
            label3.Name = "label3";
            label3.Size = new Size(77, 16);
            label3.TabIndex = 1;
            label3.Text = "Nazwisko:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 38);
            label2.Name = "label2";
            label2.Size = new Size(40, 16);
            label2.TabIndex = 0;
            label2.Text = "Imię:";
            // 
            // txtbHasłoEdycja
            // 
            txtbHasłoEdycja.Location = new Point(622, 591);
            txtbHasłoEdycja.Name = "txtbHasłoEdycja";
            txtbHasłoEdycja.Size = new Size(144, 23);
            txtbHasłoEdycja.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 41);
            label7.Name = "label7";
            label7.Size = new Size(98, 16);
            label7.TabIndex = 5;
            label7.Text = "Nowe Hasło:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDownStawkaGodz);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(labelStawkaGodz);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtbNrTel);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtbNazwisko);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(txtbImię);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(txtbPowtórzEmail);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtbPowtórzHasło);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(txtbHaslo);
            groupBox2.Controls.Add(txtbEmail);
            groupBox2.Controls.Add(comboBoxDodajPracownika);
            groupBox2.Controls.Add(label11);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(949, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(254, 501);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dodaj Pracownika/Administratora";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // numericUpDownStawkaGodz
            // 
            numericUpDownStawkaGodz.Location = new Point(37, 405);
            numericUpDownStawkaGodz.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDownStawkaGodz.Minimum = new decimal(new int[] { 22, 0, 0, 0 });
            numericUpDownStawkaGodz.Name = "numericUpDownStawkaGodz";
            numericUpDownStawkaGodz.Size = new Size(185, 22);
            numericUpDownStawkaGodz.TabIndex = 42;
            numericUpDownStawkaGodz.Value = new decimal(new int[] { 22, 0, 0, 0 });
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(71, 439);
            button1.Name = "button1";
            button1.Size = new Size(102, 46);
            button1.TabIndex = 41;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // labelStawkaGodz
            // 
            labelStawkaGodz.AutoSize = true;
            labelStawkaGodz.Location = new Point(37, 385);
            labelStawkaGodz.Name = "labelStawkaGodz";
            labelStawkaGodz.Size = new Size(141, 16);
            labelStawkaGodz.TabIndex = 40;
            labelStawkaGodz.Text = "Stawka Godzinowa:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(37, 118);
            label9.Name = "label9";
            label9.Size = new Size(48, 16);
            label9.TabIndex = 38;
            label9.Text = "Nr tel:";
            // 
            // txtbNrTel
            // 
            txtbNrTel.Location = new Point(37, 135);
            txtbNrTel.Margin = new Padding(3, 2, 3, 2);
            txtbNrTel.Name = "txtbNrTel";
            txtbNrTel.Size = new Size(185, 22);
            txtbNrTel.TabIndex = 37;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(37, 76);
            label10.Name = "label10";
            label10.Size = new Size(77, 16);
            label10.TabIndex = 36;
            label10.Text = "Naziwsko:";
            // 
            // txtbNazwisko
            // 
            txtbNazwisko.Location = new Point(37, 94);
            txtbNazwisko.Margin = new Padding(3, 2, 3, 2);
            txtbNazwisko.Name = "txtbNazwisko";
            txtbNazwisko.Size = new Size(185, 22);
            txtbNazwisko.TabIndex = 35;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(37, 27);
            label12.Name = "label12";
            label12.Size = new Size(40, 16);
            label12.TabIndex = 34;
            label12.Text = "Imię:";
            // 
            // txtbImię
            // 
            txtbImię.Location = new Point(37, 44);
            txtbImię.Margin = new Padding(3, 2, 3, 2);
            txtbImię.Name = "txtbImię";
            txtbImię.Size = new Size(185, 22);
            txtbImię.TabIndex = 33;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(37, 205);
            label13.Name = "label13";
            label13.Size = new Size(107, 16);
            label13.TabIndex = 32;
            label13.Text = "Powtórz email:";
            // 
            // txtbPowtórzEmail
            // 
            txtbPowtórzEmail.Location = new Point(37, 223);
            txtbPowtórzEmail.Margin = new Padding(3, 2, 3, 2);
            txtbPowtórzEmail.Name = "txtbPowtórzEmail";
            txtbPowtórzEmail.Size = new Size(185, 22);
            txtbPowtórzEmail.TabIndex = 31;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(37, 289);
            label14.Name = "label14";
            label14.Size = new Size(110, 16);
            label14.TabIndex = 30;
            label14.Text = "Powtórz hasło:";
            // 
            // txtbPowtórzHasło
            // 
            txtbPowtórzHasło.Location = new Point(37, 306);
            txtbPowtórzHasło.Margin = new Padding(3, 2, 3, 2);
            txtbPowtórzHasło.Name = "txtbPowtórzHasło";
            txtbPowtórzHasło.Size = new Size(185, 22);
            txtbPowtórzHasło.TabIndex = 29;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(37, 245);
            label15.Name = "label15";
            label15.Size = new Size(55, 16);
            label15.TabIndex = 28;
            label15.Text = "Hasło:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(37, 163);
            label16.Name = "label16";
            label16.Size = new Size(50, 16);
            label16.TabIndex = 27;
            label16.Text = "Email:";
            // 
            // txtbHaslo
            // 
            txtbHaslo.Location = new Point(37, 263);
            txtbHaslo.Margin = new Padding(3, 2, 3, 2);
            txtbHaslo.Name = "txtbHaslo";
            txtbHaslo.Size = new Size(185, 22);
            txtbHaslo.TabIndex = 26;
            // 
            // txtbEmail
            // 
            txtbEmail.Location = new Point(37, 181);
            txtbEmail.Margin = new Padding(3, 2, 3, 2);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(185, 22);
            txtbEmail.TabIndex = 25;
            // 
            // comboBoxDodajPracownika
            // 
            comboBoxDodajPracownika.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDodajPracownika.FormattingEnabled = true;
            comboBoxDodajPracownika.Location = new Point(37, 355);
            comboBoxDodajPracownika.Name = "comboBoxDodajPracownika";
            comboBoxDodajPracownika.Size = new Size(185, 24);
            comboBoxDodajPracownika.TabIndex = 14;
            comboBoxDodajPracownika.SelectedIndexChanged += comboBoxDodajPracownika_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 337);
            label11.Name = "label11";
            label11.Size = new Size(44, 16);
            label11.TabIndex = 4;
            label11.Text = "Rola:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtbNoweHasłoEdycja);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(txtbPowtórzHasloEdycja);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label7);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.WhiteSmoke;
            groupBox3.Location = new Point(486, 305);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(436, 202);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Zmiana Hasła";
            // 
            // txtbNoweHasłoEdycja
            // 
            txtbNoweHasłoEdycja.Location = new Point(158, 35);
            txtbNoweHasłoEdycja.Name = "txtbNoweHasłoEdycja";
            txtbNoweHasłoEdycja.Size = new Size(153, 22);
            txtbNoweHasłoEdycja.TabIndex = 16;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSkyBlue;
            button2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(154, 134);
            button2.Name = "button2";
            button2.Size = new Size(157, 46);
            button2.TabIndex = 15;
            button2.Text = "Zmiana Hasła";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtbPowtórzHasloEdycja
            // 
            txtbPowtórzHasloEdycja.Location = new Point(158, 88);
            txtbPowtórzHasloEdycja.Name = "txtbPowtórzHasloEdycja";
            txtbPowtórzHasloEdycja.Size = new Size(153, 22);
            txtbPowtórzHasloEdycja.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 89);
            label6.Name = "label6";
            label6.Size = new Size(113, 16);
            label6.TabIndex = 13;
            label6.Text = "Powtórz Hasło:";
            // 
            // txtbRola
            // 
            txtbRola.Location = new Point(622, 550);
            txtbRola.Name = "txtbRola";
            txtbRola.Size = new Size(144, 23);
            txtbRola.TabIndex = 15;
            // 
            // ZarzadzanieUzytkownikami
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1308, 675);
            Controls.Add(txtbRola);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(txtbHasłoEdycja);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "ZarzadzanieUzytkownikami";
            Text = "ZarzadzanieUzytkownikami";
            Load += ZarzadzanieUzytkownikami_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStawkaGodz).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtbHasłoEdycja;
        private TextBox txtbNrTelEdycja;
        private TextBox txtbEmailEdycja;
        private TextBox txtbNazwiskoEdycja;
        private TextBox TxtbImięEdycja;
        private Label label8;
        private Label label7;
        private Button btnEdytujUzytk;
        private Button btnUsunUzytk;
        private GroupBox groupBox2;
        private ComboBox comboBoxDodajPracownika;
        private Label label11;
        private Button button1;
        private Label labelStawkaGodz;
        private Label label9;
        private TextBox txtbNrTel;
        private Label label10;
        private TextBox txtbNazwisko;
        private Label label12;
        private TextBox txtbImię;
        private Label label13;
        private TextBox txtbPowtórzEmail;
        private Label label14;
        private TextBox txtbPowtórzHasło;
        private Label label15;
        private Label label16;
        private TextBox txtbHaslo;
        private TextBox txtbEmail;
        private NumericUpDown numericUpDownStawkaGodz;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox3;
        private Button button2;
        private TextBox txtbPowtórzHasloEdycja;
        private Label label6;
        private TextBox txtbRola;
        private TextBox txtbNoweHasłoEdycja;
    }
}