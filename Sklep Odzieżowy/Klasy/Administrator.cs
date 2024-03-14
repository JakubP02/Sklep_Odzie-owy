using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Administrator : Użytkownicy
    {
        private Baza mojabaza;


        public string Imie;
        public string Nazwisko;
        public string NrTel;
        public string AdresEmail;




        public Administrator PobierzDaneKAdministratora(int idUzytkownika)
        {
            mojabaza = new Baza();
            Administrator admin = null;

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return admin;
            }

            try
            {
                string selectQuery = "SELECT * FROM tbl_Administratorzy WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    admin = new Administrator
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

            return admin;
        }

        public void EdytujDaneAdmina(int idUzytkownika, string noweImie, string noweNazwisko, string nowyEmail, string nowyNrTel)
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
                string updateQuery = "UPDATE tbl_Administratorzy SET Imię = @NoweImie, Nazwisko = @NoweNazwisko, AdresEmail = @NowyEmail, NrTEl = @NowyNrTel WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@NoweImie", noweImie);
                cmd.Parameters.AddWithValue("@NoweNazwisko", noweNazwisko);
                cmd.Parameters.AddWithValue("@NowyEmail", nowyEmail);
                cmd.Parameters.AddWithValue("@NowyNrTel", nowyNrTel);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dane Administratora zostały zaktualizowane w bazie danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych administartora w bazie danych.");
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

        public string PobierzHasloUzytkownika(int idUzytkownika)
        {
            string haslo = null;

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Hasło FROM tbl_Użytkownicy WHERE IdUżytkownika = @IdUzytkownika";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                haslo = reader["Hasło"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd: " + ex.Message);
                }
            }

            return haslo;
        }


    }
}
