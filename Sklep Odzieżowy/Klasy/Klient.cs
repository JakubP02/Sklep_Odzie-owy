using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Klient : Użytkownicy
    {



        public string Imie;
        public string Nazwisko;
        public string AdresEmail;
        public string NrTel;

        private Baza mojabaza;

        


        public Klient PobierzDaneKlienta(int idUzytkownika)
        {
        
            Klient klient = null;
            mojabaza = new Baza();

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return klient;
            }

            try
            {
                string selectQuery = "SELECT * FROM tbl_Klienci WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    klient = new Klient
                    {

                        Imie = reader["Imię"].ToString(),
                        Nazwisko = reader["Nazwisko"].ToString(),
                        AdresEmail = reader["AdresEmail"].ToString(),
                        NrTel = reader["NrTEl"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych klienta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return klient;
        }

        public void EdytujDaneKlienta(int idUzytkownika, string noweImie, string noweNazwisko, string nowyEmail, string nowyNrTel)
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
                string updateQuery = "UPDATE tbl_Klienci SET Imię = @NoweImie, Nazwisko = @NoweNazwisko, AdresEmail = @NowyEmail, NrTEl = @NowyNrTel WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@NoweImie", noweImie);
                cmd.Parameters.AddWithValue("@NoweNazwisko", noweNazwisko);
                cmd.Parameters.AddWithValue("@NowyEmail", nowyEmail);
                cmd.Parameters.AddWithValue("@NowyNrTel", nowyNrTel);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dane klienta zostały zaktualizowane w bazie danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych klienta w bazie danych.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edytowania danych klienta: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public int ZnajdzIdKlienta(int idUzytkownika)
        {
     
            mojabaza = new Baza();
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                

                string query = "SELECT IdKlienta FROM tbl_Klienci WHERE IdUżytkownika = @IdUzytkownika";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                 
                    object result = command.ExecuteScalar();

            
                    if (result != null && result is int)
                    {
                        return (int)result;
                    }
                }
            }

          
            return -1;
        }






    }
}
