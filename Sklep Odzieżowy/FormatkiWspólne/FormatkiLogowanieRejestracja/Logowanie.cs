using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy
{
    public partial class Logowanie : Form
    {

        private Baza mojabaza;



        public Logowanie()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            mojabaza = new Baza();
            txtbHasło.PasswordChar = '*';

        }

        private void label4_Click(object sender, EventArgs e)
        {
            PrzypomnienieHasła przypomnienieHasła = new PrzypomnienieHasła();
            przypomnienieHasła.Show();


        }

        private void btnRejestracja_Click(object sender, EventArgs e)
        {
            Rejestracja rejestracja = new Rejestracja();
            rejestracja.Show();



        }

        private void btnZaloguj_Click(object sender, EventArgs e)
        {



            string email = txtbEmail.Text;

            string haslo = txtbHasło.Text;



            SqlConnection connection = mojabaza.PolaczZBaza();


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }




            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {

                string query = "SELECT rola, Status, IdUżytkownika FROM tbl_Użytkownicy WHERE adresEmail=@Email AND Hasło=@Haslo AND CzyUsunięty <> 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Haslo", haslo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    string rola = reader["rola"].ToString();
                    int status = Convert.ToInt32(reader["Status"]);
                    int id = Convert.ToInt32(reader["IdUżytkownika"]);





                    if (status != 1)
                    {

                        if (rola == "Klient")

                        {





                            Menu menu = new Menu();
                            menu.Show();
                            Panel panel = menu.PanelPracownik();
                            Panel panel1 = menu.PanelAdmin();
                            Panel panel2 = menu.PanelKlient();
                            Button btn = menu.ButtonPracownik();
                            Button btn1 = menu.ButtonAdmin();
                            panel.Visible = false; panel1.Visible = false;
                            btn.Visible = false; btn1.Visible = false;
                            menu.label1.Text = id.ToString();
                            panel2.Dock = DockStyle.Fill;






                        }
                        if (rola == "Pracownik")
                        {


                            Menu menu = new Menu();
                            menu.Show();
                            Panel panel = menu.PanelKlient();
                            Panel panel1 = menu.PanelAdmin();
                            Panel panel2 = menu.PanelPracownik();
                            Button btn = menu.ButtonKlient();
                            Button btn1 = menu.ButtonAdmin();
                            panel.Visible = false; panel1.Visible = false;
                            btn.Visible = false; btn1.Visible = false;
                            menu.label1.Text = id.ToString();
                            panel2.Dock = DockStyle.Fill;

                        }
                        if (rola == "Admin")
                        {

                            Menu menu = new Menu();
                            menu.Show();
                            Panel panel = menu.PanelKlient();
                            Panel panel1 = menu.PanelPracownik();
                            Panel panel2 = menu.PanelAdmin();
                            Button btn = menu.ButtonKlient();
                            Button btn1 = menu.ButtonPracownik();
                            panel.Visible = false; panel1.Visible = false;
                            menu.label1.Text = id.ToString();
                            btn.Visible = false; btn1.Visible = false;
                            panel2.Dock = DockStyle.Fill;

                        }

                    }
                    else
                    {


                        ZmianaHasłaTymczasowego zmianaHasła = new ZmianaHasłaTymczasowego();
                        zmianaHasła.idUżytkownika = id.ToString();
                        zmianaHasła.Show();

                    }
                }
                else
                {

                    MessageBox.Show("Nieprawidłowy email lub hasło");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas logowania: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }





            txtbEmail.Clear();
            txtbHasło.Clear();


            this.Hide();




        }

        private void Logowanie_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
