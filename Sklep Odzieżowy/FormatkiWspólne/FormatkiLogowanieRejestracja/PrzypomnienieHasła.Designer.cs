namespace Sklep_Odzieżowy
{
    partial class PrzypomnienieHasła
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
            label2 = new Label();
            txtbEmail = new TextBox();
            btnZarejestrujSię = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(127, 89);
            label2.Name = "label2";
            label2.Size = new Size(101, 18);
            label2.TabIndex = 6;
            label2.Text = "Podaj email:";
            // 
            // txtbEmail
            // 
            txtbEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtbEmail.Location = new Point(127, 119);
            txtbEmail.Margin = new Padding(3, 2, 3, 2);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(196, 26);
            txtbEmail.TabIndex = 5;
            // 
            // btnZarejestrujSię
            // 
            btnZarejestrujSię.BackColor = Color.LightSkyBlue;
            btnZarejestrujSię.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnZarejestrujSię.ForeColor = Color.WhiteSmoke;
            btnZarejestrujSię.Location = new Point(127, 169);
            btnZarejestrujSię.Margin = new Padding(3, 2, 3, 2);
            btnZarejestrujSię.Name = "btnZarejestrujSię";
            btnZarejestrujSię.Size = new Size(196, 48);
            btnZarejestrujSię.TabIndex = 15;
            btnZarejestrujSię.Text = "Wyślij hasło tymczasowe";
            btnZarejestrujSię.UseVisualStyleBackColor = false;
            btnZarejestrujSię.Click += btnZarejestrujSię_Click;
            // 
            // PrzypomnienieHasła
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(471, 315);
            Controls.Add(btnZarejestrujSię);
            Controls.Add(label2);
            Controls.Add(txtbEmail);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PrzypomnienieHasła";
            Text = "PrzypomnienieHasła";
            Load += PrzypomnienieHasła_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtbEmail;
        private Button btnZarejestrujSię;
    }
}