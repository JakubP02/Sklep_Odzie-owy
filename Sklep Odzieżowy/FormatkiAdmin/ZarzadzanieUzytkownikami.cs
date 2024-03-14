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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sklep_Odzieżowy
{
    public partial class ZarzadzanieUzytkownikami : Form
    {

        private Baza mojabaza;
        private string HasłoAdmina = "1234";
        public string HasłoWprowadzone;
        public string Id;



        List<string> listaWartosci = new List<string>
        {
              "Pracownik",
              "Admin"

        };


        public ZarzadzanieUzytkownikami()
        {
            InitializeComponent();

            comboBoxDodajPracownika.DataSource = listaWartosci;


            mojabaza = new Baza();



            txtbHaslo.PasswordChar = '*';
            txtbPowtórzHasło.PasswordChar = '*';
            txtbNoweHasłoEdycja.PasswordChar = '*';
            txtbPowtórzHasloEdycja.PasswordChar = '*';
            txtbRola.Visible = false;
            txtbHasłoEdycja.Visible = false;


            WczytajDaneUżytkowników();




        }




        private void ZarzadzanieUzytkownikami_Load(object sender, EventArgs e)
        {




            WczytajDaneUżytkowników();

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;



        }

        public void WczytajDaneUżytkowników()
        {
            Użytkownicy user = new Użytkownicy();
            List<Użytkownicy> uzytkownicy = user.PobierzWszystkichUzytkownikow();


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Imię", typeof(string));
            dataTable.Columns.Add("Nazwisko", typeof(string));
            dataTable.Columns.Add("AdresEmail", typeof(string));
            dataTable.Columns.Add("Hasło", typeof(string));
            dataTable.Columns.Add("NrTel", typeof(string));
            dataTable.Columns.Add("StawkaGodzinowa", typeof(int));
            dataTable.Columns.Add("Rola", typeof(string));


            foreach (var uzytkownik in uzytkownicy)
            {
                if (uzytkownik is Administrator)
                {
                    Administrator administrator = (Administrator)uzytkownik;
                    dataTable.Rows.Add(
                        administrator.Imie,
                        administrator.Nazwisko,
                        administrator.AdresEmail,
                        administrator.Haslo,
                        administrator.NrTel,
                        0,
                        administrator.Rola
                    ); ;
                }
                else if (uzytkownik is Klient)
                {
                    Klient klient = (Klient)uzytkownik;
                    dataTable.Rows.Add(

                        klient.Imie,
                        klient.Nazwisko,
                        klient.AdresEmail,
                        klient.Haslo,
                        klient.NrTel,
                        0,
                        klient.Rola
                    );
                }
                else if (uzytkownik is Pracownik)
                {
                    Pracownik pracownik = (Pracownik)uzytkownik;
                    dataTable.Rows.Add(

                        pracownik.Imie,
                        pracownik.Nazwisko,
                        pracownik.AdresEmail,
                        pracownik.Haslo,
                        pracownik.NrTel,
                        pracownik.StawkaGodz,
                        pracownik.Rola
                    );
                }
            }


            dataGridView1.DataSource = dataTable;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

        }



        private void comboBoxDodajPracownika_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zaznaczonaWartosc = comboBoxDodajPracownika.SelectedItem.ToString();


            if (zaznaczonaWartosc == "Pracownik")
            {
                numericUpDownStawkaGodz.Visible = true;
                labelStawkaGodz.Visible = true;

            }
            else
            {
                numericUpDownStawkaGodz.Visible = false;
                labelStawkaGodz.Visible = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imię = txtbImię.Text;
            string nazwisko = txtbNazwisko.Text;
            string email = txtbEmail.Text;
            string powtorzEmail = txtbPowtórzEmail.Text;
            string nrTel = txtbNrTel.Text;
            string haslo = txtbHaslo.Text;
            string powtorzHaslo = txtbPowtórzHasło.Text;
            int StawkaGodz = (int)numericUpDownStawkaGodz.Value;
            string rola = comboBoxDodajPracownika.Text;

            Użytkownicy user = new Użytkownicy();


            if (imię == "" && nazwisko == "" && email == "" && powtorzEmail == "" && nrTel == "" && haslo == "" && powtorzHaslo == "")
            {
                MessageBox.Show("Wszystkie pola muszą być zaznaczone");
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




            if (rola == "Pracownik")
            {

                user.DodajUżytkownika(imię, nazwisko, email, haslo, nrTel, rola, StawkaGodz);
                txtbImię.Clear();
                txtbNazwisko.Clear();
                txtbEmail.Clear();
                txtbPowtórzEmail.Clear();
                txtbNrTel.Clear();
                txtbHaslo.Clear();
                txtbPowtórzHasło.Clear();

                WczytajDaneUżytkowników();
                return;

            }

            if (rola == "Admin")
            {
                user.DodajUżytkownika(imię, nazwisko, email, haslo, nrTel, rola);
                txtbImię.Clear();
                txtbNazwisko.Clear();
                txtbEmail.Clear();
                txtbPowtórzEmail.Clear();
                txtbNrTel.Clear();
                txtbHaslo.Clear();
                txtbPowtórzHasło.Clear();

                WczytajDaneUżytkowników();
                return;
            }

          


        }

        private void btnDodajUzytk_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {



            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


                string imie = selectedRow.Cells["Imię"].Value.ToString();
                string nazwisko = selectedRow.Cells["Nazwisko"].Value.ToString();
                string adresEmail = selectedRow.Cells["AdresEmail"].Value.ToString();
                string haslo = selectedRow.Cells["Hasło"].Value.ToString();
                string nrTel = selectedRow.Cells["NrTel"].Value.ToString();
                int stawkaGodzinowa = Convert.ToInt32(selectedRow.Cells["StawkaGodzinowa"].Value);
                string rola = selectedRow.Cells["Rola"].Value.ToString();

                TxtbImięEdycja.Text = imie;
                txtbNazwiskoEdycja.Text = nazwisko;
                txtbEmailEdycja.Text = adresEmail;
                txtbHasłoEdycja.Text = haslo;
                txtbNrTelEdycja.Text = nrTel;
                txtbRola.Text = rola;

                if (rola == "Pracownik")
                {
                    numericUpDown1.Value = stawkaGodzinowa;
                    numericUpDown1.Visible = true;
                }
                else
                {
                    numericUpDown1.Visible = false;
                }
            }


        }

        private void txtbWyszukiwarka_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnEdytujUzytk_Click(object sender, EventArgs e)
        {
            string imię = TxtbImięEdycja.Text;
            string nazwisko = txtbNazwiskoEdycja.Text;
            string email = txtbEmailEdycja.Text;
            string NrTel = txtbNrTelEdycja.Text;
            string rola = txtbRola.Text;
            int StawkaGodz = (int)numericUpDown1.Value;
            string haslo = txtbHasłoEdycja.Text;





            Użytkownicy user = new Użytkownicy();


            if (!user.IsValidEmail(email))
            {
                MessageBox.Show("Niepoprawny adres e-mail");
                //txtbEmail.ForeColor = Color.Red;
                return;
            }
            if (!user.IsValidPhoneNumberFormat(NrTel))
            {
                MessageBox.Show("Numer telefonu ma niepoprawny format. Oczekiwany format: XXX-XXX-XXX");
                return;
            }






            int IdUżytkownika = user.PobierzIdUzytkownika(email, haslo);


            if (rola == "Klient")
            {
                Klient klient = new Klient();
                klient.EdytujDaneKlienta(IdUżytkownika, imię, nazwisko, email, NrTel);


            }
            if (rola == "Pracownik")
            {
                if (StawkaGodz < 22)
                {
                    MessageBox.Show("Minimalna Stawka Godzinowa to 22 zł ");
                    return;
                }
                Pracownik pracownik = new Pracownik();
                pracownik.EdytujDanePracownika(IdUżytkownika, imię, nazwisko, email, NrTel, StawkaGodz);

            }
            if (rola == "Admin")
            {

                Administrator administrator = new Administrator();


                if (IdUżytkownika == int.Parse(Id))
                {







                    administrator.EdytujDaneAdmina(IdUżytkownika, imię, nazwisko, email, NrTel);


                }

                else
                {


                    HasłoAdminacs hasłoAdminacs = new HasłoAdminacs();

                    if (hasłoAdminacs.ShowDialog() == DialogResult.OK)
                    {
                        HasłoWprowadzone = hasłoAdminacs.HasłoWprowadzone;


                        if (HasłoAdmina == HasłoWprowadzone)
                        {





                            administrator.EdytujDaneAdmina(IdUżytkownika, imię, nazwisko, email, NrTel);



                        }
                        else
                        {
                            MessageBox.Show("Wprowadzone hasło było niepoprawne");
                        }
                    }



                }


            }

            WczytajDaneUżytkowników();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string noweHasło = txtbNoweHasłoEdycja.Text;
            string powtórzHasło = txtbPowtórzHasloEdycja.Text;
            string email = txtbEmailEdycja.Text;






            Użytkownicy user = new Użytkownicy();
            int idUżytkownika = user.PobierzIdUzytkownika(email, txtbHasłoEdycja.Text);

            if (idUżytkownika == int.Parse(Id))
            {
                if (noweHasło == "" && powtórzHasło == "")
                {
                    MessageBox.Show("Uzupełnij wszytskie pola");
                    return;
                }

                if (!user.IsValidPassword(noweHasło))
                {
                    MessageBox.Show("Hasło musi mieć 1 dużą literę, 1 małą literę, 1 cyfrę. Minimalna ilość znaków to 8, maksymalna ilość znaków to 20");
                    return;
                }

                if (noweHasło != powtórzHasło)
                {
                    MessageBox.Show("Podane hasła są różne");
                    return;
                }

                user.ZmienHaslo(idUżytkownika, noweHasło);

                WczytajDaneUżytkowników();
                txtbNoweHasłoEdycja.Clear();
                txtbPowtórzHasloEdycja.Clear();


            }
            else
            {


                HasłoAdminacs hasłoAdminacs = new HasłoAdminacs();

                if (hasłoAdminacs.ShowDialog() == DialogResult.OK)
                {
                    HasłoWprowadzone = hasłoAdminacs.HasłoWprowadzone;


                    if (HasłoAdmina == HasłoWprowadzone)
                    {

                        if (noweHasło == "" && powtórzHasło == "")
                        {
                            MessageBox.Show("Uzupełnij wszytskie pola");
                            return;
                        }

                        if (!user.IsValidPassword(noweHasło))
                        {
                            MessageBox.Show("Hasło musi mieć 1 dużą literę, 1 małą literę, 1 cyfrę. Minimalna ilość znaków to 8, maksymalna ilość znaków to 20");
                            return;
                        }

                        if (noweHasło != powtórzHasło)
                        {
                            MessageBox.Show("Podane hasła są różne");
                            return;
                        }



                        user.ZmienHaslo(idUżytkownika, noweHasło);

                        WczytajDaneUżytkowników();
                        txtbNoweHasłoEdycja.Clear();
                        txtbPowtórzHasloEdycja.Clear();








                    }
                    else
                    {
                        MessageBox.Show("Wprowadzone hasło było niepoprawne");
                        return;
                    }
                }








            }











        }

        private void btnWyszukajUzytk_Click(object sender, EventArgs e)
        {
        }
        private void btnUsunUzytk_Click(object sender, EventArgs e)
        {

            Użytkownicy user = new Użytkownicy();
            string email = txtbEmailEdycja.Text;
            string haslo = txtbHasłoEdycja.Text;
            string rola = txtbRola.Text;


            if (rola != "Admin")
            {




                int IdUżytkownika = user.PobierzIdUzytkownika(email, haslo);



                user.UsuńUżytkownika(IdUżytkownika);

                WczytajDaneUżytkowników();

            }
            else
            {
                int IdUżytkownika = user.PobierzIdUzytkownika(email, haslo);

                if (IdUżytkownika == int.Parse(Id))
                {
                    MessageBox.Show("Nie możesz usunąć swojego Konta");
                    return;

                }




                HasłoAdminacs hasłoAdminacs = new HasłoAdminacs();

                if (hasłoAdminacs.ShowDialog() == DialogResult.OK)
                {
                    HasłoWprowadzone = hasłoAdminacs.HasłoWprowadzone;


                    if (HasłoAdmina == HasłoWprowadzone)
                    {




                        user.UsuńUżytkownika(IdUżytkownika);
                        WczytajDaneUżytkowników();



                    }
                    else
                    {
                        MessageBox.Show("Wprowadzone hasło było niepoprawne");
                    }
                }










            }






        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Hasło")
            {
                // Zastępujemy tekst gwiazdkami (lub innym znakiem)
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
