using Sklep_Odzieżowy.Klasy;
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
using System.Diagnostics.Eventing.Reader;

namespace Sklep_Odzieżowy
{
    public partial class DodawanieProduktówKategoriiZmianaCeny : Form
    {
        private Baza mojabaza;

        public DodawanieProduktówKategoriiZmianaCeny()
        {
            InitializeComponent();


            mojabaza = new Baza();

            WypelnijComboBoxKategoriami();
            WypelnijComboBoxProduktami();


        }

        private void DodawanieProduktówKategoriiZmianaCeny_Load(object sender, EventArgs e)
        {

        }

        private void WypelnijComboBoxKategoriami()
        {
            comboBoxKategorie.Items.Clear();


            List<string> kategorie = PobierzKategorieZBazy();


            comboBoxKategorie.Items.AddRange(kategorie.ToArray());

        }

        private decimal PobierzAktualnaCeneProduktu(string nazwaProduktu)
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return -1;
            }

            try
            {
                string selectQuery = "SELECT Cena FROM tbl_Produkty WHERE Nazwa = @NazwaProduktu";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@NazwaProduktu", nazwaProduktu);

                object result = cmd.ExecuteScalar();

                return (result != null) ? Convert.ToDecimal(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania aktualnej ceny produktu: " + ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
        private void WypelnijComboBoxProduktami()
        {
            comboBoxWybierzProdObniżka.Items.Clear();
            comboBox1.Items.Clear();


            List<string> produkty = PobierzProduktyZBazy();


            comboBoxWybierzProdObniżka.Items.AddRange(produkty.ToArray());
            comboBox1.Items.AddRange(produkty.ToArray());

        }

        private List<string> PobierzKategorieZBazy()
        {
            List<string> kategorie = new List<string>();

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return kategorie;
            }

            try
            {
                string selectQuery = "SELECT Kategoria FROM tbl_Kategoria";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string kategoria = reader["Kategoria"].ToString();
                        kategorie.Add(kategoria);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania kategorii: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return kategorie;
        }
        private List<string> PobierzProduktyZBazy()
        {
            List<string> produkty = new List<string>();

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return produkty;
            }

            try
            {
                string selectQuery = "SELECT Nazwa FROM tbl_Produkty WHERE CzyUsunięty <>1";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string produkt = reader["Nazwa"].ToString();
                        produkty.Add(produkt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania kategorii: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return produkty;
        }



        private string GenerujKodProduktu()
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return string.Empty;
            }

            try
            {
                string selectQuery = "SELECT COUNT(*) FROM tbl_Produkty";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);

                int liczbaProduktow = (int)cmd.ExecuteScalar();

                return "PR" + (liczbaProduktow + 1).ToString("D5");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas generowania kodu produktu: " + ex.Message);
                return string.Empty;
            }
            finally
            {
                connection.Close();
            }
        }

        private int PobierzIdKategorii(string nazwaKategorii)
        {

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return -1;
            }

            try
            {
                string selectQuery = "SELECT IdKategorii FROM tbl_Kategoria WHERE Kategoria = @NazwaKategorii";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@NazwaKategorii", nazwaKategorii);

                object result = cmd.ExecuteScalar();

                return (result != null) ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania IdKategorii: " + ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string nowaKategoria = txtKategoria.Text;


            if (string.IsNullOrEmpty(nowaKategoria))
            {
                MessageBox.Show("Proszę uzupełnić pole Nazwa kategoria");
                return;
            }


            SqlConnection connection = mojabaza.PolaczZBaza();



            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }



            string selectQuery = "SELECT COUNT(*) FROM tbl_Kategoria WHERE Kategoria = @NowaKategoria";
            SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
            selectCmd.Parameters.AddWithValue("@NowaKategoria", nowaKategoria);

            int existingCategoriesCount = (int)selectCmd.ExecuteScalar();

            if (existingCategoriesCount > 0)
            {
                MessageBox.Show("Kategoria o podanej nazwie już istnieje w bazie danych.");
                return;
            }

            try
            {
                string insertQuery = "INSERT INTO tbl_Kategoria (Kategoria) VALUES (@NowaKategoria)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@NowaKategoria", nowaKategoria);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Nowa kategoria została dodana do bazy danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać nowej kategorii do bazy danych.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania nowej kategorii: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            txtKategoria.Clear();

            WypelnijComboBoxKategoriami();
        }

        private void btnDodajUzytk_Click(object sender, EventArgs e)
        {

            string nazwaProduktu = textBoxNazwaProd.Text;
            decimal cena = (decimal)numericUpDownCenaNowyProd.Value;
            string nazwaKategorii = comboBoxKategorie.Text;

            if (string.IsNullOrEmpty(nazwaProduktu))
            {
                MessageBox.Show("Proszę wpisać nazwę produktu");
                return;
            }
            if (string.IsNullOrEmpty(nazwaKategorii))
            {
                MessageBox.Show("Proszę wybrać kategroię produktu");
                return;
            }
            if (cena <= 0)
            {
                MessageBox.Show("Cena produktu musi być większa od 0");
                return;
            }


            if (SprawdzCzyProduktIstnieje(nazwaProduktu) == true)
            {
                return;
            }

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {

                string kodProduktu = GenerujKodProduktu();


                int idKategorii = PobierzIdKategorii(nazwaKategorii);


                string insertQuery = "INSERT INTO tbl_Produkty (KodProduktu, Nazwa, Cena, Stan, IdKategorii) " +
                                     "VALUES (@KodProduktu, @Nazwa, @Cena, 0, @IdKategorii)";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@KodProduktu", kodProduktu);
                cmd.Parameters.AddWithValue("@Nazwa", nazwaProduktu);
                cmd.Parameters.AddWithValue("@Cena", cena);
                cmd.Parameters.AddWithValue("@IdKategorii", idKategorii);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Nowy produkt został dodany do bazy danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać nowego produktu do bazy danych.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania nowego produktu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            textBoxNazwaProd.Clear();
            numericUpDownCenaNowyProd.Value = 0;

            WypelnijComboBoxProduktami();
            comboBoxKategorie.Items.Clear();
            WypelnijComboBoxKategoriami();

        }
        public bool SprawdzCzyProduktIstnieje(string nazwaProduktu)
        {
            mojabaza = new Baza();
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return false;
            }

            try
            {
                string query = "SELECT COUNT(*) FROM tbl_Produkty WHERE Nazwa = @NazwaProduktu";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@NazwaProduktu", nazwaProduktu);

                int rowCount = (int)cmd.ExecuteScalar();

                if (rowCount > 0)
                {
                    MessageBox.Show("Produkt o nazwie " + nazwaProduktu + " już istnieje w bazie danych.");
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas sprawdzania istnienia produktu: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void comboBoxWybierzProdObniżka_SelectedIndexChanged(object sender, EventArgs e)
        {


            label7.Text = ("Aktualna Cena: " + PobierzAktualnaCeneProduktu(comboBoxWybierzProdObniżka.SelectedItem.ToString()) + " zł");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void AktualizujCeneProduktu(string nazwaProduktu, decimal nowaCena)
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {
                decimal AktulanaCEna = PobierzAktualnaCeneProduktu(nazwaProduktu);
                if (nowaCena > AktulanaCEna)
                {
                    ZmienStatusPromocji(nazwaProduktu, false);
                }
                if (nowaCena < AktulanaCEna)
                {
                    ZmienStatusPromocji(nazwaProduktu, true);
                }
                string updateQuery = "UPDATE tbl_Produkty SET Cena = @NowaCena WHERE Nazwa = @NazwaProduktu";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NowaCena", nowaCena);
                cmd.Parameters.AddWithValue("@NazwaProduktu", nazwaProduktu);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cena produktu została zaktualizowana w bazie danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować ceny produktu w bazie danych.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizowania ceny produktu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void ZastosujObnizkeProcentowa(string nazwaProduktu, decimal procentObnizki)
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {
                if (numericUpDownObniżCeneProcent.Value < 100)
                {
                    decimal aktualnaCena = PobierzAktualnaCeneProduktu(nazwaProduktu);
                    decimal nowaCena = aktualnaCena * (1 - procentObnizki / 100);
                    decimal nowaCena2 = aktualnaCena - nowaCena;
                    if (nowaCena2 < 0.01m)
                    {
                        MessageBox.Show("Minalna wartość produktu wynosi 1 grosz");
                        return;
                    }


                    AktualizujCeneProduktu(nazwaProduktu, nowaCena2);
                    ZmienStatusPromocji(nazwaProduktu, true);
                }
                if (numericUpDownObniżCeneProcent.Value > 100)
                {
                    decimal aktualnaCena = PobierzAktualnaCeneProduktu(nazwaProduktu);
                    decimal nowaCena = aktualnaCena * (1 + procentObnizki / 100);
                    decimal nowaCena2 = nowaCena - aktualnaCena;

                    AktualizujCeneProduktu(nazwaProduktu, nowaCena2);
                    ZmienStatusPromocji(nazwaProduktu, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zastosowania obniżki procentowej: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ZmienStatusPromocji(string nazwaProduktu, bool czyWPromocji)
        {
            mojabaza = new Baza();
            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {
                string updateQuery = "UPDATE tbl_Produkty SET Promocja = @CzyWPromocji WHERE Nazwa = @NazwaProduktu";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@CzyWPromocji", czyWPromocji ? "tak" : "nie");
                cmd.Parameters.AddWithValue("@NazwaProduktu", nazwaProduktu);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Status promocji został pomyślnie zaktualizowany.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować statusu promocji dla produktu o nazwie: " + nazwaProduktu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmiany statusu promocji: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void numericUpDownNowaCena_ValueChanged(object sender, EventArgs e)
        {


            if (numericUpDownNowaCena.Value != 0)
            {
                numericUpDownObniżCeneProcent.Visible = false;
            }

            if (numericUpDownNowaCena.Value == 0)
            {
                numericUpDownObniżCeneProcent.Visible = true;
            }
        }

        private void numericUpDownObniżCeneProcent_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownObniżCeneProcent.Value != 0)
            {
                numericUpDownNowaCena.Visible = false;
            }
            if (numericUpDownObniżCeneProcent.Value == 0)
            {
                numericUpDownNowaCena.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBoxWybierzProdObniżka.Text == "")
            {
                MessageBox.Show("Proszę wybrać produkt");
                return;

            }
            string nazwaProduktu = comboBoxWybierzProdObniżka.SelectedItem.ToString();

            if (numericUpDownNowaCena.Visible == true)
            {
                if (numericUpDownNowaCena.Value <= 0)
                {
                    MessageBox.Show("Nowa cena musi być większa od 0");
                    return;

                }
            }
            if (numericUpDownObniżCeneProcent.Visible == true)

            {
                if (numericUpDownObniżCeneProcent.Value <= 0)
                {
                    MessageBox.Show("Wartość procentowa produktu musi być większa od 0");
                    return;
                }
            }

            if (numericUpDownNowaCena.Visible)
            {
                decimal nowaCena = numericUpDownNowaCena.Value;
                AktualizujCeneProduktu(nazwaProduktu, nowaCena);
            }
            else if (numericUpDownObniżCeneProcent.Visible)
            {
                decimal procentObnizki = numericUpDownObniżCeneProcent.Value;
                ZastosujObnizkeProcentowa(nazwaProduktu, procentObnizki);

            }
            comboBoxWybierzProdObniżka.Items.Clear();
            WypelnijComboBoxProduktami();
            label7.Text = "";
            numericUpDownObniżCeneProcent.Value = 0;
            numericUpDownNowaCena.Value = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Proszę wybrać produkt do usunięcia");
                return;
            }


            string nazwaProduktu = comboBox1.SelectedItem.ToString();

            Produkt produkt = new Produkt();
            produkt.UsuńProdukt(nazwaProduktu);

            comboBox1.Items.Clear();
            WypelnijComboBoxProduktami();
        }
    }
}
