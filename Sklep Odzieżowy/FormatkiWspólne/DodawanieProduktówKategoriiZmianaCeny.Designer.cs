namespace Sklep_Odzieżowy
{
    partial class DodawanieProduktówKategoriiZmianaCeny
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
            numericUpDownCenaNowyProd = new NumericUpDown();
            comboBoxKategorie = new ComboBox();
            btnDodajUzytk = new Button();
            textBoxNazwaProd = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            comboBoxWybierzProdObniżka = new ComboBox();
            numericUpDownObniżCeneProcent = new NumericUpDown();
            label5 = new Label();
            numericUpDownNowaCena = new NumericUpDown();
            label7 = new Label();
            button1 = new Button();
            label1 = new Label();
            label6 = new Label();
            groupBox3 = new GroupBox();
            button2 = new Button();
            txtKategoria = new TextBox();
            label10 = new Label();
            groupBox4 = new GroupBox();
            comboBox1 = new ComboBox();
            label9 = new Label();
            button3 = new Button();
            label12 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCenaNowyProd).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownObniżCeneProcent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNowaCena).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDownCenaNowyProd);
            groupBox1.Controls.Add(comboBoxKategorie);
            groupBox1.Controls.Add(btnDodajUzytk);
            groupBox1.Controls.Add(textBoxNazwaProd);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(207, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(406, 252);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj Nowy Produkt";
            // 
            // numericUpDownCenaNowyProd
            // 
            numericUpDownCenaNowyProd.DecimalPlaces = 2;
            numericUpDownCenaNowyProd.Location = new Point(162, 126);
            numericUpDownCenaNowyProd.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDownCenaNowyProd.Name = "numericUpDownCenaNowyProd";
            numericUpDownCenaNowyProd.Size = new Size(153, 22);
            numericUpDownCenaNowyProd.TabIndex = 13;
            // 
            // comboBoxKategorie
            // 
            comboBoxKategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKategorie.FormattingEnabled = true;
            comboBoxKategorie.Location = new Point(162, 80);
            comboBoxKategorie.Name = "comboBoxKategorie";
            comboBoxKategorie.Size = new Size(153, 24);
            comboBoxKategorie.TabIndex = 11;
            // 
            // btnDodajUzytk
            // 
            btnDodajUzytk.BackColor = Color.LightSkyBlue;
            btnDodajUzytk.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnDodajUzytk.Location = new Point(126, 177);
            btnDodajUzytk.Name = "btnDodajUzytk";
            btnDodajUzytk.Size = new Size(144, 53);
            btnDodajUzytk.TabIndex = 10;
            btnDodajUzytk.Text = "Dodaj Produkt";
            btnDodajUzytk.UseVisualStyleBackColor = false;
            btnDodajUzytk.Click += btnDodajUzytk_Click;
            // 
            // textBoxNazwaProd
            // 
            textBoxNazwaProd.Location = new Point(162, 35);
            textBoxNazwaProd.Name = "textBoxNazwaProd";
            textBoxNazwaProd.Size = new Size(153, 22);
            textBoxNazwaProd.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 128);
            label4.Name = "label4";
            label4.Size = new Size(47, 16);
            label4.TabIndex = 2;
            label4.Text = "Cena:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 86);
            label3.Name = "label3";
            label3.Size = new Size(78, 16);
            label3.TabIndex = 1;
            label3.Text = "Kategoria:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 38);
            label2.Name = "label2";
            label2.Size = new Size(122, 16);
            label2.TabIndex = 0;
            label2.Text = "Nazwa Produktu:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxWybierzProdObniżka);
            groupBox2.Controls.Add(numericUpDownObniżCeneProcent);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numericUpDownNowaCena);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(207, 347);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(406, 252);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Obniż Cenę";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // comboBoxWybierzProdObniżka
            // 
            comboBoxWybierzProdObniżka.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWybierzProdObniżka.FormattingEnabled = true;
            comboBoxWybierzProdObniżka.Location = new Point(227, 35);
            comboBoxWybierzProdObniżka.Name = "comboBoxWybierzProdObniżka";
            comboBoxWybierzProdObniżka.Size = new Size(153, 24);
            comboBoxWybierzProdObniżka.TabIndex = 15;
            comboBoxWybierzProdObniżka.SelectedIndexChanged += comboBoxWybierzProdObniżka_SelectedIndexChanged;
            // 
            // numericUpDownObniżCeneProcent
            // 
            numericUpDownObniżCeneProcent.Location = new Point(227, 126);
            numericUpDownObniżCeneProcent.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownObniżCeneProcent.Name = "numericUpDownObniżCeneProcent";
            numericUpDownObniżCeneProcent.ReadOnly = true;
            numericUpDownObniżCeneProcent.Size = new Size(153, 22);
            numericUpDownObniżCeneProcent.TabIndex = 14;
            numericUpDownObniżCeneProcent.ValueChanged += numericUpDownObniżCeneProcent_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 128);
            label5.Name = "label5";
            label5.Size = new Size(187, 16);
            label5.TabIndex = 13;
            label5.Text = "Wartość % aktualnej Ceny";
            // 
            // numericUpDownNowaCena
            // 
            numericUpDownNowaCena.DecimalPlaces = 2;
            numericUpDownNowaCena.Location = new Point(227, 82);
            numericUpDownNowaCena.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDownNowaCena.Name = "numericUpDownNowaCena";
            numericUpDownNowaCena.ReadOnly = true;
            numericUpDownNowaCena.Size = new Size(153, 22);
            numericUpDownNowaCena.TabIndex = 12;
            numericUpDownNowaCena.ValueChanged += numericUpDownNowaCena_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(192, 61);
            label7.Name = "label7";
            label7.Size = new Size(0, 16);
            label7.TabIndex = 11;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(126, 175);
            button1.Name = "button1";
            button1.Size = new Size(144, 60);
            button1.TabIndex = 10;
            button1.Text = "Zmień Cenę Produktu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 88);
            label1.Name = "label1";
            label1.Size = new Size(90, 16);
            label1.TabIndex = 2;
            label1.Text = "Nowa Cena:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 38);
            label6.Name = "label6";
            label6.Size = new Size(124, 16);
            label6.TabIndex = 0;
            label6.Text = "Wybierz Produkt:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(txtKategoria);
            groupBox3.Controls.Add(label10);
            groupBox3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = Color.WhiteSmoke;
            groupBox3.Location = new Point(659, 54);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(346, 160);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dodaj Nową Kategorię";
            // 
            // button2
            // 
            button2.BackColor = Color.LightSkyBlue;
            button2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(114, 86);
            button2.Name = "button2";
            button2.Size = new Size(144, 60);
            button2.TabIndex = 10;
            button2.Text = "Dodaj Kategorię";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtKategoria
            // 
            txtKategoria.Location = new Point(156, 35);
            txtKategoria.Name = "txtKategoria";
            txtKategoria.Size = new Size(153, 22);
            txtKategoria.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(34, 38);
            label10.Name = "label10";
            label10.Size = new Size(123, 16);
            label10.TabIndex = 0;
            label10.Text = "Nazwa Kategorii:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(label12);
            groupBox4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.ForeColor = Color.WhiteSmoke;
            groupBox4.Location = new Point(659, 347);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(346, 160);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Usuń Produkt";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(152, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(153, 24);
            comboBox1.TabIndex = 15;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(180, 65);
            label9.Name = "label9";
            label9.Size = new Size(0, 16);
            label9.TabIndex = 11;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSkyBlue;
            button3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(100, 86);
            button3.Name = "button3";
            button3.Size = new Size(144, 60);
            button3.TabIndex = 10;
            button3.Text = "Usuń Produkt";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 42);
            label12.Name = "label12";
            label12.Size = new Size(124, 16);
            label12.TabIndex = 0;
            label12.Text = "Wybierz Produkt:";
            // 
            // DodawanieProduktówKategoriiZmianaCeny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1249, 809);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "DodawanieProduktówKategoriiZmianaCeny";
            Text = "DodawanieProduktówKategorii";
            Load += DodawanieProduktówKategoriiZmianaCeny_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCenaNowyProd).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownObniżCeneProcent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNowaCena).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxNazwaProd;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnDodajUzytk;
        private GroupBox groupBox2;
        private Button button1;
        private Label label1;
        private Label label6;
        private NumericUpDown numericUpDownCenaNowyProd;
        private ComboBox comboBoxKategorie;
        private ComboBox comboBoxWybierzProdObniżka;
        private NumericUpDown numericUpDownObniżCeneProcent;
        private Label label5;
        private NumericUpDown numericUpDownNowaCena;
        private Label label7;
        private GroupBox groupBox3;
        private Button button2;
        private TextBox txtKategoria;
        private Label label10;
        private GroupBox groupBox4;
        private ComboBox comboBox1;
        private Label label9;
        private Button button3;
        private Label label12;
    }
}