using Microsoft.VisualBasic.ApplicationServices;
using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy
{
    public partial class KontoPracownik : Form
    {
        private Baza mojabaza;
        public string IdUżytkownika;
        Pracownik pracownik = new Pracownik();
        public string Idpracownika;
        public KontoPracownik()
        {
            InitializeComponent();
            mojabaza = new Baza();


            txtbStareHasło.PasswordChar = '*';
            txtbPowtórzHasło.PasswordChar = '*';
            txtbNoweHasło.PasswordChar = '*';
            numericUpDownStawkaGodz.Controls[0].Visible = false;
        }

        private void KontoPracownik_Load(object sender, EventArgs e)
        {
            Pracownik pracownik = new Pracownik();
            txtbImię.Text = pracownik.PobierzDanePracownika(int.Parse(IdUżytkownika)).Imie;
            txtbNazwisko.Text = pracownik.PobierzDanePracownika(int.Parse(IdUżytkownika)).Nazwisko;
            txtbNrTel.Text = pracownik.PobierzDanePracownika(int.Parse(IdUżytkownika)).NrTel;
            txtbEmail.Text = pracownik.PobierzDanePracownika(int.Parse(IdUżytkownika)).AdresEmail;
            numericUpDownStawkaGodz.Value = (decimal)pracownik.PobierzDanePracownika(int.Parse(IdUżytkownika)).StawkaGodz;

          

            WczytajDaneGrafiku();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdytujKlient_Click(object sender, EventArgs e)
        {
            string imie = txtbImię.Text;
            string nazwisko = txtbNazwisko.Text;
            string email = txtbEmail.Text;
            string nrTel = txtbNrTel.Text;

            Użytkownicy user = new Użytkownicy();



            if (!user.IsValidEmail(email))
            {

                MessageBox.Show("Niepoprawny adres e-mail");
                //txtbEmail.ForeColor = Color.Red;
                return;


            }

            if (!user.IsValidPhoneNumberFormat(nrTel))
            {
                MessageBox.Show("Numer telefonu ma niepoprawny format. Oczekiwany format: XXX-XXX-XXX");
            }


            Pracownik pracownik = new Pracownik();
            pracownik.EdytujDanePracownika((int.Parse(IdUżytkownika)), imie, nazwisko, email, nrTel);




        }

        private void btnZmianaHasła_Click(object sender, EventArgs e)
        {
            string stareHasło = txtbStareHasło.Text;
            string noweHasło = txtbNoweHasło.Text;
            string powtórzHasło = txtbPowtórzHasło.Text;


            if (string.IsNullOrEmpty(stareHasło) || string.IsNullOrEmpty(noweHasło) || string.IsNullOrEmpty(powtórzHasło))
            {
                MessageBox.Show("Proszę uzupełnić wszytskie pola")
                    ; return;
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

            txtbPowtórzHasło.Clear();
            txtbNoweHasło.Clear();
            txtbStareHasło.Clear();
        }

        private string FormatujCzas(object czasDB)
        {
            if (czasDB != null && DateTime.TryParse(czasDB.ToString(), out DateTime czas))
            {
                return czas.ToString("HH:mm");
            }
            return "";
        }

        private void WyczyscTextBoxy()
        {
            textBox16.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            textBox5.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
        }

        private void WczytajDaneGrafiku()
        {
            SqlConnection connection = mojabaza.PolaczZBaza();
            string query = "SELECT * FROM tbl_grafik WHERE IdPracownika = @IdPracownika AND Status = 1";

            try
            {
                int Id = pracownik.ZnajdzIdPracownika(int.Parse(IdUżytkownika));
             
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdPracownika", Id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    textBox16.Text = FormatujCzas(reader["Pon_od"]);
                    textBox15.Text = FormatujCzas(reader["Pon_do"]);
                    textBox14.Text = FormatujCzas(reader["Wt_od"]);
                    textBox13.Text = FormatujCzas(reader["Wt_do"]);
                    textBox12.Text = FormatujCzas(reader["Śr_od"]);
                    textBox11.Text = FormatujCzas(reader["Śr_do"]);
                    textBox8.Text = FormatujCzas(reader["Czw_od"]);
                    textBox5.Text = FormatujCzas(reader["Czw_do"]);
                    textBox10.Text = FormatujCzas(reader["Pt_od"]);
                    textBox9.Text = FormatujCzas(reader["Pt_do"]);
                }
                else
                {
                    WyczyscTextBoxy();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
