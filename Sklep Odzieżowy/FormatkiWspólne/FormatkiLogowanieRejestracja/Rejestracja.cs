using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy
{
    public partial class Rejestracja : Form
    {
        private Baza mojabaza;
        public Rejestracja()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            mojabaza = new Baza();



            txtbHaslo.PasswordChar = '*';
            txtbPowtórzHasło.PasswordChar = '*';
        }

        private void Rejestracja_Load(object sender, EventArgs e)
        {

        }

        private void BtnWróć_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnZarejestrujSię_Click(object sender, EventArgs e)
        {
            string imię = txtbImię.Text;
            string nazwisko = txtbNazwisko.Text;
            string email = txtbEmail.Text;
            string powtorzEmail = txtbPowtórzEmail.Text;
            string nrTel = txtbNrTel.Text;
            string haslo = txtbHaslo.Text;
            string powtorzHaslo = txtbPowtórzHasło.Text;
            string rola = "Klient";

            Użytkownicy user = new Użytkownicy();



            if (!user.AreAllTextBoxesFilled(this))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }
            if (user.SprawdzCzyUzytkownikIstnieje(email))
            {
                MessageBox.Show("Użytkownik o podanym adresie email już istnieje w bazie ");
                return;

            }




            if (!user.IsValidEmail(email))
            {

                MessageBox.Show("Niepoprawny adres e-mail");
                //txtbEmail.ForeColor = Color.Red;
                return;


            }

            if (email != powtorzEmail)
            {
                MessageBox.Show("Podane adresy e-mail nie są jednakowe");
                //txtbPowtórzEmail.ForeColor = Color.Red;
                //txtbEmail.ForeColor = Color.Red;
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

            if (!user.IsValidPhoneNumberFormat(nrTel))
            {
                MessageBox.Show("Numer telefonu ma niepoprawny format. Oczekiwany format: XXX-XXX-XXX");
                return;
            }




            user.DodajUżytkownika(imię, nazwisko, email, haslo, nrTel, rola);

            this.Hide();





        }
    }
}
