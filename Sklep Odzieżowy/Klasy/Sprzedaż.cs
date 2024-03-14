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
    internal class Sprzedaż
    {
        private Baza mojabaza = new Baza();

        Produkt produkt = new Produkt();



        public void DodajProduktDoDetalu(int idPozycjiSprzedazy, ProduktWKoszyku produktWKoszyku)
        {

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_SprzedażDetal (IdPozycjiSD, IdProduktu, Idkategorii, CenaZasztukę, Ilość) VALUES (@IdPozycjiSD, @IdProduktu, @IdKategorii, @CenaZaSzt, @Ilosc);", connection))
                {
                    cmd.Parameters.AddWithValue("@IdPozycjiSD", idPozycjiSprzedazy);
                    cmd.Parameters.AddWithValue("@IdProduktu", PobierzIdProduktu(produktWKoszyku.KodProduktu));  
                    cmd.Parameters.AddWithValue("@IdKategorii", PobierzIdKategorii(produktWKoszyku.KodProduktu));  
                    cmd.Parameters.AddWithValue("@CenaZaSzt", PobierzCeneZaszt(produktWKoszyku.KodProduktu)); 
                    cmd.Parameters.AddWithValue("@Ilosc", produktWKoszyku.Ilosc);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DodajZamowienieDoBazyDanych(List<ProduktWKoszyku> koszykProduktow, int idKlienta  )
        {
         

         
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_PozycjaSprzedaży (IdKlienta, DataZamówienia, [Status], SumaSprzedaży) VALUES (@IdKlienta, @DataZamowienia, @Status, @SumaSprzedazy); SELECT SCOPE_IDENTITY();", connection))
                {
                    cmd.Parameters.AddWithValue("@IdKlienta", idKlienta);
                    cmd.Parameters.AddWithValue("@DataZamowienia", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", "w trakcie realizacji");  
                    cmd.Parameters.AddWithValue("@SumaSprzedazy", ObliczSumeSprzedazy(koszykProduktow));

                    int idPozycjiSprzedazy = Convert.ToInt32(cmd.ExecuteScalar());

                  
                    foreach (var produktWKoszyku in koszykProduktow)
                    {
                        DodajProduktDoDetalu(idPozycjiSprzedazy, produktWKoszyku);
                    }
                }
            }
        }
        public int PobierzIdKategorii(string kodProduktu)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("SELECT IdKategorii FROM tbl_Produkty WHERE KodProduktu = @KodProduktu", connection))
                {
                    cmd.Parameters.AddWithValue("@KodProduktu", kodProduktu);

                  
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; 
                }
            }
        }

        public decimal PobierzCeneZaszt(string kodProduktu)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                using (SqlCommand cmd = new SqlCommand("SELECT Cena FROM tbl_Produkty WHERE KodProduktu = @KodProduktu", connection))
                {
                    cmd.Parameters.AddWithValue("@KodProduktu", kodProduktu);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : -1m;
                }
            }
        }

        public decimal ObliczSumeSprzedazy( List<ProduktWKoszyku> koszykProduktow )
        {
            decimal sumaSprzedazy = 0;

            foreach (var produktWKoszyku in koszykProduktow)
            {
                sumaSprzedazy += produktWKoszyku.SumaSprzedazy;
            }

            return sumaSprzedazy;
        }
        public int PobierzIdProduktu(string kodProduktu)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {

                using (SqlCommand cmd = new SqlCommand("SELECT IdProduktu FROM tbl_Produkty WHERE KodProduktu = @KodProduktu", connection))
                {
                    cmd.Parameters.AddWithValue("@KodProduktu", kodProduktu);

              
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; 
                }
            }
        }

        public void AktualizujStanProduktow(List<ProduktWKoszyku> produktyWKoszyku)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
               

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var produktWKoszyku in produktyWKoszyku)
                        {
                            using (SqlCommand cmd = new SqlCommand("UPDATE tbl_Produkty SET Stan = Stan - @Ilosc WHERE KodProduktu = @KodProduktu", connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Ilosc", produktWKoszyku.Ilosc);
                                cmd.Parameters.AddWithValue("@KodProduktu", produktWKoszyku.KodProduktu);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                      
                        transaction.Rollback();
                        MessageBox.Show($"Wystąpił błąd podczas aktualizacji stanu produktów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void WyswietlZamowieniaWtrakcieRealizacji(DataGridView dataGridView)
        {
            try
            {
                SqlConnection connection = mojabaza.PolaczZBaza();
      
             

                string query = "SELECT IdPozycjiSD, [Status], DataZamówienia, SumaSprzedaży FROM tbl_PozycjaSprzedaży WHERE [Status] = 'w trakcie realizacji'";


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

        public void WyswietlSzczegolyZamowienia(int idPozycjiSD, DataGridView dataGridView)
        {
            try
            {
            
                SqlConnection connection = mojabaza.PolaczZBaza();

         
                string query = "SELECT P.Nazwa, SD.Ilość, SD.CenaZasztukę " +
                               "FROM tbl_SprzedażDetal SD " +
                               "INNER JOIN tbl_Produkty P ON SD.IdProduktu = P.IdProduktu " +
                               "WHERE SD.IdPozycjiSD = @IdPozycjiSD";

     
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
       
                    cmd.Parameters.AddWithValue("@IdPozycjiSD", idPozycjiSD);

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

        public void ZmienStatus(int idPozycjiSD, string nowyStatus)
        {
            try
            {
            
                SqlConnection connection = mojabaza.PolaczZBaza();

           
                string query = "UPDATE tbl_PozycjaSprzedaży SET [Status] = @NowyStatus WHERE IdPozycjiSD = @IdPozycjiSD";

            
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
       
                    cmd.Parameters.AddWithValue("@IdPozycjiSD", idPozycjiSD);

                    cmd.Parameters.AddWithValue("@NowyStatus", nowyStatus);

                 
                    cmd.ExecuteNonQuery();

        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmiany statusu zamówienia: " + ex.Message);
            }
           
        }

      

        public void PobierzSprzedazeOdebrane(int idKlienta, DataGridView dataGridView)
        {
            try
            {
          
                SqlConnection connection = mojabaza.PolaczZBaza();

    
                string query = "SELECT PS.IdPozycjiSD, PS.[Status], PS.DataZamówienia, PS.SumaSprzedaży, SD.IdSprzedaży, SD.IdProduktu, P.Nazwa, SD.Ilość, SD.CenaZasztukę " +
                               "FROM tbl_PozycjaSprzedaży PS " +
                               "INNER JOIN tbl_SprzedażDetal SD ON PS.IdPozycjiSD = SD.IdPozycjiSD " +
                               "INNER JOIN tbl_Produkty P ON SD.IdProduktu = P.IdProduktu " +
                               "WHERE PS.[Status] = 'odebrane' AND PS.IdKlienta = @IdKlienta";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
             
                    cmd.Parameters.AddWithValue("@IdKlienta", idKlienta);

            
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                 
                    DataTable dataTable = new DataTable();

              
                    adapter.Fill(dataTable);

                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
            }

        }

        public void WyswietlZamowieniaWDostarczeniu(DataGridView dataGridView, int idKlienta)
        {
            try
            {
                SqlConnection connection = mojabaza.PolaczZBaza();

                string query = "SELECT IdPozycjiSD, IdKlienta, [Status], DataZamówienia, SumaSprzedaży " +
                               "FROM tbl_PozycjaSprzedaży " +
                               "WHERE [Status] = 'w dostarczeniu' AND IdKlienta = @IdKlienta";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@IdKlienta", idKlienta);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
            }
        }

        public void WyswietlZamowieniaOdebrane(DataGridView dataGridView, int idKlienta)
        {
            try
            {
                SqlConnection connection = mojabaza.PolaczZBaza();

                string query = "SELECT IdPozycjiSD, IdKlienta, [Status], DataZamówienia, SumaSprzedaży " +
                               "FROM tbl_PozycjaSprzedaży " +
                               "WHERE [Status] = 'odebrane' AND IdKlienta = @IdKlienta";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@IdKlienta", idKlienta);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message);
            }
        }

        public DataTable WyszukajProdukty(string nazwa = null, string kategoria = null, decimal? cenaOd = null, decimal? cenaDo = null, string promocja = null)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nazwa Produktu", typeof(string));
            dataTable.Columns.Add("Kod Produktu", typeof(string));
            dataTable.Columns.Add("Cena", typeof(decimal));
            dataTable.Columns.Add("Stan", typeof(int));
            dataTable.Columns.Add("Nazwa Kategorii", typeof(string));
            dataTable.Columns.Add("Promocja", typeof(string));
            dataTable.Columns.Add("Ilość", typeof(int));

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM tbl_Produkty WHERE 1=1 AND CzyUsunięty <> 1");

                if (!string.IsNullOrEmpty(nazwa))
                    queryBuilder.Append(" AND Nazwa LIKE @Nazwa");

                if (!string.IsNullOrEmpty(kategoria))
                    queryBuilder.Append(" AND Idkategorii IN (SELECT IdKategorii FROM tbl_Kategoria WHERE Kategoria = @Kategoria)");

                if (cenaOd.HasValue)
                    queryBuilder.Append(" AND Cena >= @CenaOd");

                if (cenaDo.HasValue)
                    queryBuilder.Append(" AND Cena <= @CenaDo");

                if (!string.IsNullOrEmpty(promocja))
                    queryBuilder.Append(" AND Promocja = @Promocja");

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

                    if (!string.IsNullOrEmpty(promocja))
                        cmd.Parameters.AddWithValue("@Promocja", promocja);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nazwaKategorii = produkt.PobierzNazweKategorii((int)reader["Idkategorii"]);

                            dataTable.Rows.Add(
                                reader["Nazwa"].ToString(),
                                reader["KodProduktu"].ToString(),
                                (decimal)reader["Cena"],
                                (int)reader["Stan"],
                                nazwaKategorii,
                                reader["Promocja"].ToString(),
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
