using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Pracownik : Użytkownicy
    {

        private Baza mojabaza;

        public string Imie;
        public string Nazwisko;
        public string AdresEmail;
        public string NrTel;
        public double StawkaGodz;


        public Pracownik PobierzDanePracownika(int idUzytkownika)
        {
            mojabaza = new Baza();
            Pracownik pracownik = null;

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return pracownik;
            }

            try
            {
                string selectQuery = "SELECT * FROM tbl_Pracownicy WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pracownik = new Pracownik
                    {

                        Imie = reader["Imię"].ToString(),
                        Nazwisko = reader["Nazwisko"].ToString(),
                        AdresEmail = reader["AdresEmail"].ToString(),
                        NrTel = reader["NrTEl"].ToString(),
                        StawkaGodz = Convert.ToDouble(reader["StawkaGodzinowa"])

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

            return pracownik;
        }

        public void EdytujDanePracownika(int idUzytkownika, string noweImie, string noweNazwisko, string nowyEmail, string nowyNrTel, int? nowaStawkaGodzinowa = null)
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
                string updateQuery = "UPDATE tbl_Pracownicy SET Imię = @NoweImie, Nazwisko = @NoweNazwisko, AdresEmail = @NowyEmail, NrTEl = @NowyNrTel";

                if (nowaStawkaGodzinowa.HasValue)
                {
                    updateQuery += ", StawkaGodzinowa = @NowaStawkaGodzinowa";
                }

                updateQuery += " WHERE IdUżytkownika = @IdUzytkownika";

                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@NoweImie", noweImie);
                cmd.Parameters.AddWithValue("@NoweNazwisko", noweNazwisko);
                cmd.Parameters.AddWithValue("@NowyEmail", nowyEmail);
                cmd.Parameters.AddWithValue("@NowyNrTel", nowyNrTel);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                if (nowaStawkaGodzinowa.HasValue)
                {
                    cmd.Parameters.AddWithValue("@NowaStawkaGodzinowa", nowaStawkaGodzinowa.Value);
                }

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dane pracownika zostały zaktualizowane w bazie danych.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych pracownika w bazie danych.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas edytowania danych pracownika: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public int ZnajdzIdPracownika(int idUzytkownika)
        {

            mojabaza = new Baza();
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                string query = "SELECT IdPracownika FROM tbl_Pracownicy WHERE IdUżytkownika = @IdUzytkownika";

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
