using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy
{
    public partial class HasłoAdminacs : Form
    {
        public string HasłoWprowadzone;
        public HasłoAdminacs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnZarejestrujSię_Click(object sender, EventArgs e)
        {
            string hasło = txtbEmail.Text;
            ZarzadzanieUzytkownikami zarzadzanieUzytkownikami = new ZarzadzanieUzytkownikami();
            HasłoWprowadzone = hasło;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void HasłoAdminacs_Load(object sender, EventArgs e)
        {
            txtbEmail.PasswordChar = '*';

            MessageBox.Show("Aby modyfikować lub usuwać konta Administratorów musisz posiadać Status głownego Administartora Systemu. Głowny Administartor posiada specjalne hasło, wpisz je abyśmy mogli zweryfikować twój status");
        }
    }
}
