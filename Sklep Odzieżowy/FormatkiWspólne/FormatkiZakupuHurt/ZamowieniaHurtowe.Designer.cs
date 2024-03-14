namespace Sklep_Odzieżowy
{
    partial class ZamowieniaHurtowe
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            button2 = new Button();
            groupBox1 = new GroupBox();
            button1 = new Button();
            numericUpDownDO = new NumericUpDown();
            label4 = new Label();
            numericUpDownOD = new NumericUpDown();
            label3 = new Label();
            comboBoxKategoria = new ComboBox();
            label2 = new Label();
            txtbNazwa = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            dataGridView2 = new DataGridView();
            button3 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDO).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.LightSkyBlue;
            button2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(938, 433);
            button2.Name = "button2";
            button2.Size = new Size(169, 58);
            button2.TabIndex = 5;
            button2.Text = "Dodaj do koszyka";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(numericUpDownDO);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numericUpDownOD);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBoxKategoria);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtbNazwa);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(582, 274);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Opcje wyszukiwania:";
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(200, 195);
            button1.Name = "button1";
            button1.Size = new Size(107, 41);
            button1.TabIndex = 12;
            button1.Text = "Szukaj";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // numericUpDownDO
            // 
            numericUpDownDO.Location = new Point(344, 139);
            numericUpDownDO.Name = "numericUpDownDO";
            numericUpDownDO.Size = new Size(131, 22);
            numericUpDownDO.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 141);
            label4.Name = "label4";
            label4.Size = new Size(25, 16);
            label4.TabIndex = 6;
            label4.Text = "do";
            // 
            // numericUpDownOD
            // 
            numericUpDownOD.Location = new Point(177, 139);
            numericUpDownOD.Name = "numericUpDownOD";
            numericUpDownOD.Size = new Size(130, 22);
            numericUpDownOD.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 141);
            label3.Name = "label3";
            label3.Size = new Size(156, 16);
            label3.TabIndex = 4;
            label3.Text = "Przedział cenowy od:";
            // 
            // comboBoxKategoria
            // 
            comboBoxKategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKategoria.FormattingEnabled = true;
            comboBoxKategoria.Location = new Point(163, 83);
            comboBoxKategoria.Name = "comboBoxKategoria";
            comboBoxKategoria.Size = new Size(161, 24);
            comboBoxKategoria.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 91);
            label2.Name = "label2";
            label2.Size = new Size(142, 16);
            label2.TabIndex = 2;
            label2.Text = "Kategoria produktu:";
            // 
            // txtbNazwa
            // 
            txtbNazwa.Location = new Point(138, 35);
            txtbNazwa.Name = "txtbNazwa";
            txtbNazwa.Size = new Size(161, 22);
            txtbNazwa.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 38);
            label1.Name = "label1";
            label1.Size = new Size(121, 16);
            label1.TabIndex = 0;
            label1.Text = "Nazwa produktu:";
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
            dataGridView1.Location = new Point(12, 295);
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(920, 322);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Controls.Add(button3);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.WhiteSmoke;
            groupBox2.Location = new Point(621, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(574, 274);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Koszyk";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.LightSkyBlue;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.SkyBlue;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView2.Location = new Point(6, 22);
            dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(438, 241);
            dataGridView2.TabIndex = 2;
            // 
            // button3
            // 
            button3.BackColor = Color.LightSkyBlue;
            button3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(450, 114);
            button3.Name = "button3";
            button3.Size = new Size(117, 56);
            button3.TabIndex = 1;
            button3.Text = "Zamów";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // ZamowieniaHurtowe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1248, 730);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "ZamowieniaHurtowe";
            Text = "ZamowieniaHurtowe";
            Load += ZamowieniaHurtowe_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDO).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownOD).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private GroupBox groupBox1;
        private Button button1;
        private NumericUpDown numericUpDownDO;
        private Label label4;
        private NumericUpDown numericUpDownOD;
        private Label label3;
        private ComboBox comboBoxKategoria;
        private Label label2;
        private TextBox txtbNazwa;
        private Label label1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private DataGridView dataGridView2;
        private Button button3;
    }
}