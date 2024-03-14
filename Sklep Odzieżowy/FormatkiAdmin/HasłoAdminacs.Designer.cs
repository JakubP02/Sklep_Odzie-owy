namespace Sklep_Odzieżowy
{
    partial class HasłoAdminacs
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
            btnZarejestrujSię = new Button();
            label2 = new Label();
            txtbEmail = new TextBox();
            SuspendLayout();
            // 
            // btnZarejestrujSię
            // 
            btnZarejestrujSię.BackColor = Color.LightSkyBlue;
            btnZarejestrujSię.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnZarejestrujSię.ForeColor = Color.WhiteSmoke;
            btnZarejestrujSię.Location = new Point(128, 134);
            btnZarejestrujSię.Margin = new Padding(3, 2, 3, 2);
            btnZarejestrujSię.Name = "btnZarejestrujSię";
            btnZarejestrujSię.Size = new Size(196, 48);
            btnZarejestrujSię.TabIndex = 18;
            btnZarejestrujSię.Text = "Zatwierdź";
            btnZarejestrujSię.UseVisualStyleBackColor = false;
            btnZarejestrujSię.Click += btnZarejestrujSię_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(128, 64);
            label2.Name = "label2";
            label2.Size = new Size(100, 18);
            label2.TabIndex = 17;
            label2.Text = "Podaj Hasło";
            // 
            // txtbEmail
            // 
            txtbEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtbEmail.Location = new Point(128, 94);
            txtbEmail.Margin = new Padding(3, 2, 3, 2);
            txtbEmail.Name = "txtbEmail";
            txtbEmail.Size = new Size(196, 26);
            txtbEmail.TabIndex = 16;
            // 
            // HasłoAdminacs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(453, 261);
            Controls.Add(btnZarejestrujSię);
            Controls.Add(label2);
            Controls.Add(txtbEmail);
            Name = "HasłoAdminacs";
            Text = "HasłoAdminacs";
            Load += HasłoAdminacs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnZarejestrujSię;
        private Label label2;
        private TextBox txtbEmail;
    }
}