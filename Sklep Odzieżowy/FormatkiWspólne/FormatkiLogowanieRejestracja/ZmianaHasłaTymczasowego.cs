using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sklep_Odzieżowy
{
    public partial class ZmianaHasłaTymczasowego : Form
    {


        public string email;

        public string idUżytkownika;
        public ZmianaHasłaTymczasowego()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;



            txtbHaslo.PasswordChar = '*';
            txtbPowtórzHasło.PasswordChar = '*';
        }

        private void ZmianaHasłaTymczasowego_Load(object sender, EventArgs e)
        {

        }



        private void btnZarejestrujSię_Click(object sender, EventArgs e)
        {


            string haslo = txtbHaslo.Text;
            string powtorzHaslo = txtbPowtórzHasło.Text;

            Użytkownicy user = new Użytkownicy();





            if (!user.AreAllTextBoxesFilled(this))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }


            if (!user.IsValidPassword(haslo))
            {
                MessageBox.Show("Hasło musi mieć 1 dużą literę, 1 małą literę, 1 cyfrę. Minimalna ilość znaków to 8, maksymalna ilość znaków to 20");
                return;
            }



            if (haslo != powtorzHaslo)
            {
                MessageBox.Show("Podane hasła nie są jednakowe");
                //txtbPowtórzHasło.ForeColor = Color.Red;
                //txtbHaslo.ForeColor = Color.Red;
                return;
            }


            user.ZmienHaslo((int.Parse(idUżytkownika)), haslo);


            this.Hide();
            Logowanie logowanie = new Logowanie();
            logowanie.Show();


        }
    }
}
