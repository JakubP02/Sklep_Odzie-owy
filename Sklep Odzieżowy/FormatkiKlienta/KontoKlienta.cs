using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sklep_Odzieżowy.Klasy;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace Sklep_Odzieżowy
{
    public partial class KontoKlienta : Form
    {


        public string IdUżytkownika;
        private Baza mojabaza;
        public KontoKlienta()
        {
            InitializeComponent();

            mojabaza = new Baza();


            txtbStareHaslo.PasswordChar = '*';
            txtbNoweHaslo.PasswordChar = '*';
            txtbPowtorzHaslo.PasswordChar = '*';




        }



        private void KontoKlienta_Load(object sender, EventArgs e)
        {
            Klient klient = new Klient();
            txtbImię.Text = klient.PobierzDaneKlienta(int.Parse(IdUżytkownika)).Imie;
            txtbNazwisko.Text = klient.PobierzDaneKlienta(int.Parse(IdUżytkownika)).Nazwisko;
            txtbEmail.Text = klient.PobierzDaneKlienta(int.Parse(IdUżytkownika)).AdresEmail;
            txtbNrTel.Text = klient.PobierzDaneKlienta(int.Parse(IdUżytkownika)).NrTel;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdytujKlient_Click(object sender, EventArgs e)
        {
            string noweImie = txtbImię.Text;
            string noweNazwisko = txtbNazwisko.Text;
            string nowyEmail = txtbEmail.Text;
            string nowyNrTel = txtbNrTel.Text;


            Klient klient = new Klient();
            klient.EdytujDaneKlienta((int.Parse(IdUżytkownika)), noweImie, noweNazwisko, nowyEmail, nowyNrTel);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string stareHasło = txtbStareHaslo.Text;
            string noweHasło = txtbNoweHaslo.Text;
            string powtórzHasło = txtbPowtorzHaslo.Text;

            if (string.IsNullOrEmpty(stareHasło) || string.IsNullOrEmpty(noweHasło) || string.IsNullOrEmpty(powtórzHasło))
            {
                MessageBox.Show("Proszę uzupełnić wszytskie pola");
                return;
            }


            Użytkownicy user = new Użytkownicy();

            if (!user.SprawdzPoprawnoscStaregoHasla(int.Parse(IdUżytkownika), stareHasło))
            {
                MessageBox.Show(" Wprowadzono błędne aktualne hasło");



            }

            if (!user.IsValidPassword(noweHasło))
            {
                MessageBox.Show("Hasło musi mieć 1 dużą literę, 1 małą literę, 1 cyfrę. Minimalna ilość znaków to 8, maksymalna ilość znaków to 20");
                return;
            }

            if (noweHasło != powtórzHasło)
            {
                MessageBox.Show("Podane hasła nie są jednakowe");
                //txtbPowtórzHasło.ForeColor = Color.Red;
                //txtbHaslo.ForeColor = Color.Red;
                return;
            }



            Użytkownicy użytkownicy = new Użytkownicy();
            użytkownicy.ZmienHaslo(int.Parse(IdUżytkownika), noweHasło);

            txtbPowtorzHaslo.Clear();
            txtbStareHaslo.Clear();
            txtbNoweHaslo.Clear();

        }
    }
}
