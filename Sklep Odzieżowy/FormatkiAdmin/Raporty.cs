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
using System.Reflection.Metadata;


namespace Sklep_Odzieżowy
{
    public partial class Raporty : Form
    {
        private Baza mojabaza = new Baza();

        public Raporty()
        {
            InitializeComponent();
        }

        private void Raporty_Load(object sender, EventArgs e)
        {
            comboBoxRaport.Items.Add("Suma Sprzedaży, Suma kosztów, dochód ");
            comboBoxRaport.Items.Add("Zestawienie Sprzedaży produktów ");
            comboBoxRaport.Items.Add("Klient, który wydał najwięcej ");
            comboBoxRaport.Items.Add("Klient, który kupił najwięcej ");
            comboBoxRaport.Items.Add("Zestawienie Sprzedaży z podziałem na kategorię ");

            dateTimePicker1.Value = DateTime.Now.AddDays(-1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public DataTable GenerujRaport(DateTime dataOd, DateTime dataDo)
        {
            DataTable raportTable = new DataTable();
            raportTable.Columns.Add("Nazwa Produktu", typeof(string));
            raportTable.Columns.Add("Kod Produktu", typeof(string));
            raportTable.Columns.Add("Ilość Sprzedanych Sztuk", typeof(int));

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "SELECT p.Nazwa, p.KodProduktu, SUM(sd.Ilość) AS IlośćSprzedanychSztuk " +
                               "FROM tbl_PozycjaSprzedaży ps " +
                               "JOIN tbl_SprzedażDetal sd ON ps.IdPozycjiSD = sd.IdPozycjiSD " +
                               "JOIN tbl_Produkty p ON sd.IdProduktu = p.IdProduktu " +
                               "WHERE ps.DataZamówienia BETWEEN @DataOd AND @DataDo " +
                               "GROUP BY p.Nazwa, p.KodProduktu " +
                               "ORDER BY IlośćSprzedanychSztuk DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DataOd", dataOd);
                    cmd.Parameters.AddWithValue("@DataDo", dataDo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            raportTable.Rows.Add(
                                reader["Nazwa"].ToString(),
                                reader["KodProduktu"].ToString(),
                                (int)reader["IlośćSprzedanychSztuk"]
                            );
                        }
                    }
                }
            }

            return raportTable;
        }

        public string GenerujRaportNajwiecejWydajacyKlient(DateTime dataOd, DateTime dataDo)
        {
            string raport = string.Empty;

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "WITH SumyWydatkow AS (" +
                               "  SELECT k.IdKlienta, k.Imię + ' ' + k.Nazwisko + ' (' + k.AdresEmail + ')' AS Klient, " +
                               "         SUM(ps.SumaSprzedaży) AS SumaWydatków " +
                               "  FROM tbl_PozycjaSprzedaży ps " +
                               "  JOIN tbl_Klienci k ON ps.IdKlienta = k.IdKlienta " +
                               "  WHERE ps.DataZamówienia BETWEEN @DataOd AND @DataDo AND ps.[Status] = 'odebrane' " +
                               "  GROUP BY k.IdKlienta, k.Imię, k.Nazwisko, k.AdresEmail" +
                               ")" +
                               "SELECT Klient, SumaWydatków FROM SumyWydatkow " +
                               "WHERE SumaWydatków = (SELECT MAX(SumaWydatków) FROM SumyWydatkow)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DataOd", dataOd);
                    cmd.Parameters.AddWithValue("@DataDo", dataDo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            raport += $"{reader["Klient"]}, Suma wydatków: {(decimal)reader["SumaWydatków"]:C}\r\n";
                        }
                    }
                }
            }
            if (raport == "")
            {
                raport = " Brak sprzedaży w wybranym okresie";
            }
            return raport;
        }

        public string GenerujRaportNajwiecejKupujacyKlient(DateTime dataOd, DateTime dataDo)
        {
            string raport = string.Empty;

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "WITH IloscProduktow AS (" +
                               "  SELECT k.Imię + ' ' + k.Nazwisko + ' (' + k.AdresEmail + ')' AS Klient, " +
                               "         COUNT(sd.IdSprzedaży) AS IloscZakupionychProduktow " +
                               "  FROM tbl_PozycjaSprzedaży ps " +
                               "  JOIN tbl_SprzedażDetal sd ON ps.IdPozycjiSD = sd.IdPozycjiSD " +
                               "  JOIN tbl_Klienci k ON ps.IdKlienta = k.IdKlienta " +
                               "  WHERE ps.DataZamówienia BETWEEN @DataOd AND @DataDo " +
                               "  GROUP BY k.Imię, k.Nazwisko, k.AdresEmail" +
                               ")" +
                               "SELECT Klient, IloscZakupionychProduktow FROM IloscProduktow " +
                               "WHERE IloscZakupionychProduktow = (SELECT MAX(IloscZakupionychProduktow) FROM IloscProduktow)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DataOd", dataOd);
                    cmd.Parameters.AddWithValue("@DataDo", dataDo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            raport += $"{reader["Klient"]}, Ilość transakcji: {reader["IloscZakupionychProduktow"]}\r\n";
                        }
                    }
                }
            }
            if (raport == "")
            {
                raport = " Brak sprzedaży w wybranym okresie";
            }
            return raport;
        }
        public void GenerujRaportSprzedazKategorie(DataGridView dataGridView)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "WITH IloscProduktowWKategorii AS (" +
                               "  SELECT k.Kategoria, " +
                               "         SUM(sd.Ilość) AS IloscZakupionychProduktow " +
                               "  FROM tbl_PozycjaSprzedaży ps " +
                               "  JOIN tbl_SprzedażDetal sd ON ps.IdPozycjiSD = sd.IdPozycjiSD " +
                               "  JOIN tbl_Produkty p ON sd.IdProduktu = p.IdProduktu " +
                               "  JOIN tbl_Kategoria k ON p.Idkategorii = k.IdKategorii " +
                               "  GROUP BY k.Kategoria" +
                               ")" +
                               "SELECT Kategoria, IloscZakupionychProduktow " +
                               "FROM IloscProduktowWKategorii " +
                               "ORDER BY IloscZakupionychProduktow DESC, Kategoria";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Wyświetl dane w DataGridView
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBoxRaport.SelectedIndex == 0)
            {
                SumaSprzedażyRaport sumaSprzedażyRaport = new SumaSprzedażyRaport();
                sumaSprzedażyRaport.DataOd = dateTimePicker1.Value;
                sumaSprzedażyRaport.DataDo = dateTimePicker2.Value;
                sumaSprzedażyRaport.Show();
            }
            if (comboBoxRaport.SelectedIndex == 1)
            {
                DateTime dataOd = dateTimePicker1.Value;
                DateTime dataDo = dateTimePicker2.Value;

                DataTable raport = GenerujRaport(dataOd, dataDo);


                dataGridView1.DataSource = raport;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            if (comboBoxRaport.SelectedIndex == 2)
            {
                string raport1 = GenerujRaportNajwiecejWydajacyKlient(dateTimePicker1.Value, dateTimePicker2.Value);
                KlienciRaport raport = new KlienciRaport();
                raport.label1.Text = raport1;
                raport.Show();

            }
            if (comboBoxRaport.SelectedIndex == 3)
            {
                string raport1 = GenerujRaportNajwiecejKupujacyKlient(dateTimePicker1.Value, dateTimePicker2.Value);
                KlienciRaport raport = new KlienciRaport();
                raport.label1.Text = raport1;
                raport.Show();

            }
            if (comboBoxRaport.SelectedIndex == 4)
            {
                GenerujRaportSprzedazKategorie(dataGridView1);
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


    }
}
