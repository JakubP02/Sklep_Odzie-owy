using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Zakupy
    {
        private Baza mojabaza = new Baza();
        Sprzedaż sprzedaż = new Sprzedaż();



        public void DodajZakubHurt(int idZamówienia, ProduktWKoszyku produktWKoszyku)
        {

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_ZakupyHurtowe (IdPozycjiZamówienia ,IdProduktu, Idkategorii, Ilość ,CenaZasztukę) VALUES ( @IdPozycjiSD,@IdProduktu, @IdKategorii,@Ilosc, @CenaZaSzt);", connection))
                {
                    cmd.Parameters.AddWithValue("@IdPozycjiSD", idZamówienia);
                    cmd.Parameters.AddWithValue("@IdProduktu", sprzedaż.PobierzIdProduktu(produktWKoszyku.KodProduktu));
                    cmd.Parameters.AddWithValue("@IdKategorii", sprzedaż.PobierzIdKategorii(produktWKoszyku.KodProduktu));
                    cmd.Parameters.AddWithValue("@Ilosc", produktWKoszyku.Ilosc);
                    cmd.Parameters.AddWithValue("@CenaZaSzt", PobierzCeneZasztHurt(sprzedaż.PobierzIdProduktu(produktWKoszyku.KodProduktu)));
                    

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DodajZamowienieDoBazyDanych(List<ProduktWKoszyku> koszykProduktow)
        {



            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_PozycjaZakupyHurt ( DataZamówienia, SumaZakupu) VALUES ( @DataZamowienia, @SumaZakupu); SELECT SCOPE_IDENTITY();", connection))
                {
                  
                    cmd.Parameters.AddWithValue("@DataZamowienia", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SumaZakupu", sprzedaż.ObliczSumeSprzedazy(koszykProduktow));

                    int idPozycjiSprzedazy = Convert.ToInt32(cmd.ExecuteScalar());


                    foreach (var produktWKoszyku in koszykProduktow)
                    {
                        DodajZakubHurt(idPozycjiSprzedazy, produktWKoszyku);
                    }
                }
            }
        }



        public decimal PobierzCeneZasztHurt(int Idproduktu)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("SELECT CenaHurtowa FROM tbl_cenyHurtoweProduktów WHERE IdProduktu = @IdProduktu", connection))
                {
                    cmd.Parameters.AddWithValue("@IdProduktu", Idproduktu);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : -1m;
                }
            }
        }

        public void AktualizujStanProduktow(int idPozycjiZamowienia)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
           

                using (SqlCommand cmd = new SqlCommand("UPDATE p SET p.Stan = p.Stan + z.Ilość FROM tbl_Produkty p INNER JOIN tbl_ZakupyHurtowe z ON p.IdProduktu = z.IdProduktu WHERE z.IdPozycjiZamówienia = @IdPozycjiZamowienia", connection))
                {
                    cmd.Parameters.AddWithValue("@IdPozycjiZamowienia", idPozycjiZamowienia);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void WyswietlZamowieniaNiedostarczone(DataGridView dataGridView)
        {
            try
            {
                SqlConnection connection = mojabaza.PolaczZBaza();

                string query = "SELECT IdPozycjiZH, [Status], DataZamówienia, SumaZakupu " +
                               "FROM tbl_PozycjaZakupyHurt " +
                               "WHERE [Status] = 'niedostarczony' ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
              

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
            }
        }

        public void ZmienStatus(int idPozycjiZH, string nowyStatus)
        {
            try
            {

                SqlConnection connection = mojabaza.PolaczZBaza();


                string query = "UPDATE tbl_PozycjaZakupyHurt SET [Status] = @NowyStatus WHERE IdPozycjiZH = @IdPozycjiZH";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@IdPozycjiZH", idPozycjiZH);

                    cmd.Parameters.AddWithValue("@NowyStatus", nowyStatus);


                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmiany statusu zamówienia: " + ex.Message);
            }

        }
        public void WyswietlZamowieniaDostarczone(DataGridView dataGridView)
        {
            try
            {
                SqlConnection connection = mojabaza.PolaczZBaza();

                string query = "SELECT IdPozycjiZH, [Status], DataZamówienia, SumaZakupu " +
                               "FROM tbl_PozycjaZakupyHurt " +
                               "WHERE [Status] = 'dostarczony' ";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
            }
        }


        public void WyswietlSzczegolyZamowienia(int idPozycjiZH, DataGridView dataGridView)
        {
            try
            {

                SqlConnection connection = mojabaza.PolaczZBaza();


                string query = "SELECT P.Nazwa, SD.Ilość, SD.CenaZasztukę " +
                               "FROM tbl_ZakupyHurtowe SD " +
                               "INNER JOIN tbl_Produkty P ON SD.IdProduktu = P.IdProduktu " +
                               "WHERE SD.IdPozycjiZamówienia = @IdPozycjiZH";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@IdPozycjiZH", idPozycjiZH);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                    DataTable dataTable = new DataTable();


                    adapter.Fill(dataTable);


                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania szczegółów zamówienia: " + ex.Message);
            }

        }


        public DataTable WyszukajProdukty(string nazwa = null, string kategoria = null, decimal? cenaOd = null, decimal? cenaDo = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nazwa Produktu", typeof(string));
            dataTable.Columns.Add("Kod Produktu", typeof(string));
            dataTable.Columns.Add("Cena Hurtowa", typeof(decimal));
            dataTable.Columns.Add("Stan", typeof(int));
            dataTable.Columns.Add("Nazwa Kategorii", typeof(string));
            dataTable.Columns.Add("Ilość", typeof(int));

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT p.Nazwa, p.KodProduktu, chp.CenaHurtowa, p.Stan, k.Kategoria " +
                                                              "FROM tbl_Produkty p " +
                                                              "INNER JOIN tbl_Kategoria k ON p.Idkategorii = k.IdKategorii " +
                                                              "LEFT JOIN tbl_cenyHurtoweProduktów chp ON p.IdProduktu = chp.IdProduktu " +
                                                              "WHERE 1=1 AND CzyUsunięty <> 1");

                if (!string.IsNullOrEmpty(nazwa))
                    queryBuilder.Append(" AND p.Nazwa LIKE @Nazwa");

                if (!string.IsNullOrEmpty(kategoria))
                    queryBuilder.Append(" AND p.Idkategorii IN (SELECT IdKategorii FROM tbl_Kategoria WHERE Kategoria = @Kategoria)");

                if (cenaOd.HasValue)
                    queryBuilder.Append(" AND chp.CenaHurtowa >= @CenaOd");

                if (cenaDo.HasValue)
                    queryBuilder.Append(" AND chp.CenaHurtowa <= @CenaDo");

                using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), connection))
                {
                    if (!string.IsNullOrEmpty(nazwa))
                        cmd.Parameters.AddWithValue("@Nazwa", "%" + nazwa + "%");

                    if (!string.IsNullOrEmpty(kategoria))
                        cmd.Parameters.AddWithValue("@Kategoria", kategoria);

                    if (cenaOd.HasValue)
                        cmd.Parameters.AddWithValue("@CenaOd", cenaOd.Value);

                    if (cenaDo.HasValue)
                        cmd.Parameters.AddWithValue("@CenaDo", cenaDo.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataTable.Rows.Add(
                                reader["Nazwa"].ToString(),
                                reader["KodProduktu"].ToString(),
                                (decimal)reader["CenaHurtowa"],
                                (int)reader["Stan"],
                                reader["Kategoria"].ToString(),
                                0
                            );
                        }
                    }
                }
            }

            return dataTable;
        }





    }
}
