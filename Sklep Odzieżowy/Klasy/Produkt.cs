using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Produkt
    {
        public int IdProduktu;
        public string KodProduktu;
        public string Nazwa;
        public decimal Cena;
        public int Stan;
        public int IdKategorii;
        public string Promocja;
        public string NazwaKategorii;
        public decimal CenaHurtowa;

        private Baza mojabaza = new Baza();





        public List<Produkt> PobierzWszystkieProdukty()
        {
            List<Produkt> produkty = new List<Produkt>();


            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                string query = "SELECT * FROM tbl_Produkty WHERE CzyUsunięty <>1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int idProduktu = Convert.ToInt32(reader["IdProduktu"]);
                        string kodProduktu = reader["KodProduktu"].ToString();
                        string nazwa = reader["Nazwa"].ToString();
                        decimal cena = Convert.ToDecimal(reader["Cena"]);
                        int stan = Convert.ToInt32(reader["Stan"]);
                        //int idKategorii = Convert.ToInt32(reader["Idkategorii"]);
                        int idKategorii = Convert.ToInt32(reader["Idkategorii"]);
                        string promocja = reader["Promocja"].ToString();


                        string nazwaKategorii = PobierzNazweKategorii(idKategorii);

                        Produkt produkt = new Produkt
                        {
                            IdProduktu = idProduktu,
                            KodProduktu = kodProduktu,
                            Nazwa = nazwa,
                            Cena = cena,
                            Stan = stan,
                            IdKategorii = idKategorii,
                            NazwaKategorii = nazwaKategorii,
                            Promocja = promocja
                        };

                        produkty.Add(produkt);
                    }
                }
            }

            return produkty;
        }

        public List<Produkt> PobierzWszystkieProduktyStanPoniżej10()
        {
            List<Produkt> produkty = new List<Produkt>();


            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                string query = "SELECT * FROM tbl_Produkty WHERE stan < 10 AND CzyUsunięty <>1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int idProduktu = Convert.ToInt32(reader["IdProduktu"]);
                        string kodProduktu = reader["KodProduktu"].ToString();
                        string nazwa = reader["Nazwa"].ToString();
                        decimal cena = Convert.ToDecimal(reader["Cena"]);
                        int stan = Convert.ToInt32(reader["Stan"]);
                        //int idKategorii = Convert.ToInt32(reader["Idkategorii"]);
                        int idKategorii = Convert.ToInt32(reader["Idkategorii"]);
                        string promocja = reader["Promocja"].ToString();


                        string nazwaKategorii = PobierzNazweKategorii(idKategorii);

                        Produkt produkt = new Produkt
                        {
                            IdProduktu = idProduktu,
                            KodProduktu = kodProduktu,
                            Nazwa = nazwa,
                            Cena = cena,
                            Stan = stan,
                            IdKategorii = idKategorii,
                            NazwaKategorii = nazwaKategorii,
                            Promocja = promocja
                        };

                        produkty.Add(produkt);
                    }
                }
            }

            return produkty;
        }
        public string PobierzNazweKategorii(int idKategorii)
        {



            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "SELECT Kategoria FROM tbl_Kategoria WHERE IdKategorii = @IdKategorii AND IdKategorii > 0";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdKategorii", idKategorii);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        NazwaKategorii = reader["Kategoria"].ToString();
                    }



                }
            }

            return NazwaKategorii;
        }

        public List<string> PobierzKategorieZBazy()
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


        public void WyswietlProduktyWDataGridView(DataGridView dataGridView, List<Produkt> produkty)
        {
            Produkt produktKlasa = new Produkt();


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nazwa Produktu", typeof(string));
            dataTable.Columns.Add("Kod Produktu", typeof(string));
            dataTable.Columns.Add("Cena", typeof(decimal));
            dataTable.Columns.Add("Stan", typeof(int));
            dataTable.Columns.Add("Nazwa Kategorii", typeof(string));
            dataTable.Columns.Add("Promocja", typeof(string));
            dataTable.Columns.Add("Ilość", typeof(int));

            foreach (var produktWartosc in produkty)
            {
                string nazwaKategorii = produktWartosc.PobierzNazweKategorii(produktKlasa.IdKategorii);

                dataTable.Rows.Add(
                    produktWartosc.Nazwa,
                    produktWartosc.KodProduktu,
                    produktWartosc.Cena,
                    produktWartosc.Stan,
                    nazwaKategorii,
                    produktWartosc.Promocja,
                    0
                );
            }

            dataGridView.DataSource = dataTable;

         
        }
        

        public void WyswietlProduktyWDataGridViewZamówieniaHurtowe(DataGridView dataGridView, List<Produkt> produkty, Dictionary<int, decimal> cenyHurtowe)
        {
            Produkt produktKlasa =  new Produkt();


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nazwa Produktu", typeof(string));
            dataTable.Columns.Add("Kod Produktu", typeof(string));
            dataTable.Columns.Add("Cena Hurtowa", typeof(decimal)); 
            dataTable.Columns.Add("Stan", typeof(int));
            dataTable.Columns.Add("Nazwa Kategorii", typeof(string));
            dataTable.Columns.Add("Ilość", typeof(int));

            foreach (var produktWartosc in produkty)
            {
                string nazwaKategorii = produktWartosc.PobierzNazweKategorii(produktKlasa.IdKategorii);

                decimal cenaHurtowa = 0m;
                if (cenyHurtowe.ContainsKey(produktWartosc.IdProduktu))
                {
                    cenaHurtowa = cenyHurtowe[produktWartosc.IdProduktu];
                }

                dataTable.Rows.Add(
                    produktWartosc.Nazwa,
                    produktWartosc.KodProduktu,
                    cenaHurtowa, 
                    produktWartosc.Stan,
                    nazwaKategorii,
                    0
                );
            }

            dataGridView.DataSource = dataTable;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.ReadOnly = true;
            }

            

        }

        public void DodajKolumny(DataGridView dataGridView)
        {
            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn();
            addButtonColumn.Name = "Dodaj";
            addButtonColumn.HeaderText = "Dodaj";
            addButtonColumn.Text = "+";
            addButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(addButtonColumn);

            DataGridViewButtonColumn subtractButtonColumn = new DataGridViewButtonColumn();
            subtractButtonColumn.Name = "Odejmij";
            subtractButtonColumn.HeaderText = "Odejmij";
            subtractButtonColumn.Text = "-";
            subtractButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(subtractButtonColumn);

        }

        public Dictionary<int, decimal> PobierzCenyHurtoweDlaProduktowStanPonizej10()
        {
            Dictionary<int, decimal> cenyHurtowe = new Dictionary<int, decimal>();

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = @"
            SELECT p.IdProduktu, chp.CenaHurtowa
            FROM tbl_Produkty p
            JOIN tbl_cenyHurtoweProduktów chp ON p.IdProduktu = chp.IdProduktu
            WHERE p.Stan < 10";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int idProduktu = Convert.ToInt32(reader["IdProduktu"]);
                                decimal cenaHurtowa = Convert.ToDecimal(reader["CenaHurtowa"]);

                                cenyHurtowe.Add(idProduktu, cenaHurtowa);
                            }
                        }
                        
                    }
                }
            }

            return cenyHurtowe;
        }

        public void UsuńProdukt(string NazwaProduktu)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                try
                {
                    string updateQuery = "UPDATE tbl_Produkty SET CzyUsunięty = 1 WHERE Nazwa = @Nazwa";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nazwa", NazwaProduktu);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Produkt został usunięty");
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się usunąć produktu");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Błąd SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
                }
            }
        }




    }
}

