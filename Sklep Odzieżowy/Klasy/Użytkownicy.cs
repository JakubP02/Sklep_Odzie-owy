using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Użytkownicy
    {
        private Baza mojabaza;


        public int IdUzytkownika { get; set; }
        public string AdresEmail { get; set; }
        public string Haslo { get; set; }
        public string Rola { get; set; }



        public void ZmienHaslo(int idUzytkownika, string noweHaslo)
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
                string updateQuery = "UPDATE tbl_Użytkownicy SET Hasło = @NoweHaslo, Status = 0 WHERE IdUżytkownika = @IdUzytkownika";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                cmd.Parameters.AddWithValue("@NoweHaslo", noweHaslo);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Hasło zostało pomyślnie zaktualizowane.");
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować hasła.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmiany hasła: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool SprawdzPoprawnoscStaregoHasla(int idUzytkownika, string stareHaslo)
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
                string selectQuery = "SELECT IdUżytkownika FROM tbl_Użytkownicy WHERE IdUżytkownika = @IdUzytkownika AND Hasło = @StareHaslo";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);
                cmd.Parameters.AddWithValue("@StareHaslo", stareHaslo);

                object result = cmd.ExecuteScalar();

                return (result != null && result != DBNull.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas sprawdzania starego hasła: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool IsValidPassword(string password)
        {

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$";


            return Regex.IsMatch(password, pattern);
        }

        public bool IsValidEmail(string email)
        {

            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";


            return Regex.IsMatch(email, pattern);
        }

        public bool AreAllTextBoxesFilled(Control container)
        {

            var textBoxes = container.Controls.OfType<TextBox>();


            return textBoxes.All(textBox => !string.IsNullOrWhiteSpace(textBox.Text));
        }
        public bool IsValidPhoneNumberFormat(string phoneNumber)
        {

            string pattern = @"^\d{3}-\d{3}-\d{3}$";


            return Regex.IsMatch(phoneNumber, pattern);
        }



        public void DodajUżytkownika (string imię, string nazwisko, string email, string haslo ,string nrTel, string rola, int StawkaGodz = 0)
        {

            mojabaza = new Baza();
            SqlConnection connection = mojabaza.PolaczZBaza();
            try
            {

                string checkUserQuery = "SELECT COUNT(*) FROM tbl_Użytkownicy WHERE adresEmail=@Email";
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, connection);
                checkUserCmd.Parameters.AddWithValue("@Email", email);

                int userCount = (int)checkUserCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Użytkownik o podanym adresie e-mail już istnieje");
                    return;
                }

                string addUserQuery = "INSERT INTO tbl_Użytkownicy (adresEmail, Hasło, rola) VALUES (@Email, @Haslo, @rola)";
                SqlCommand addUserCmd = new SqlCommand(addUserQuery, connection);
                addUserCmd.Parameters.AddWithValue("@Email", email);
                addUserCmd.Parameters.AddWithValue("@Haslo", haslo);
                addUserCmd.Parameters.AddWithValue("@rola", rola);

                addUserCmd.ExecuteNonQuery();

                string getUserIdQuery = "SELECT IdUżytkownika FROM tbl_Użytkownicy WHERE adresEmail = @Email";
                int userId;
                using (SqlCommand getUserIdCmd = new SqlCommand(getUserIdQuery, connection))
                {
                    getUserIdCmd.Parameters.AddWithValue("@Email", email);
                    userId = (int)getUserIdCmd.ExecuteScalar();
                }


                if (rola == "Pracownik")
                {
                    string addClientQuery = "INSERT INTO tbl_Pracownicy (IdUżytkownika, Imię, Nazwisko, AdresEmail, NrTEl, StawkaGodzinowa) " +
                                      "VALUES (@IdUzytkownik, @Imie, @Nazwisko, @Email, @NrTel, @StawkaGodzinowa)";
                    SqlCommand addClientCmd = new SqlCommand(addClientQuery, connection);
                    addClientCmd.Parameters.AddWithValue("@IdUzytkownik", userId);
                    addClientCmd.Parameters.AddWithValue("@Imie", imię);
                    addClientCmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    addClientCmd.Parameters.AddWithValue("@Email", email);
                    addClientCmd.Parameters.AddWithValue("@NrTel", nrTel);
                    addClientCmd.Parameters.AddWithValue("@StawkaGodzinowa", StawkaGodz);

                    addClientCmd.ExecuteNonQuery();

                    MessageBox.Show("Rejestracja zakończona sukcesem");
                    return;





                }

                if (rola == "Admin")
                {
                    string addClientQuery = "INSERT INTO tbl_Administratorzy (IdUżytkownika, Imię, Nazwisko, AdresEmail, NrTEl ) " +
                                   "VALUES (@IdUzytkownik, @Imie, @Nazwisko, @Email, @NrTel)";
                    SqlCommand addClientCmd = new SqlCommand(addClientQuery, connection);
                    addClientCmd.Parameters.AddWithValue("@IdUzytkownik", userId);
                    addClientCmd.Parameters.AddWithValue("@Imie", imię);
                    addClientCmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    addClientCmd.Parameters.AddWithValue("@Email", email);
                    addClientCmd.Parameters.AddWithValue("@NrTel", nrTel);


                    addClientCmd.ExecuteNonQuery();

                    MessageBox.Show("Rejestracja zakończona sukcesem");
                  



                }
                else
                {
                    string addClientQuery = "INSERT INTO tbl_Klienci (IdUżytkownika, Imię, Nazwisko, AdresEmail, NrTEl) " +
                                       "VALUES (@IdUzytkownik, @Imie, @Nazwisko, @Email, @NrTel)";
                    SqlCommand addClientCmd = new SqlCommand(addClientQuery, connection);
                    addClientCmd.Parameters.AddWithValue("@IdUzytkownik", userId);
                    addClientCmd.Parameters.AddWithValue("@Imie", imię);
                    addClientCmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    addClientCmd.Parameters.AddWithValue("@Email", email);
                    addClientCmd.Parameters.AddWithValue("@NrTel", nrTel);

                    addClientCmd.ExecuteNonQuery();

                    MessageBox.Show("Rejestracja zakończona sukcesem");



                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas rejestracji: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


        }

        public List<Użytkownicy> PobierzWszystkichUzytkownikow()
        {
            try
            {
                List<Użytkownicy> uzytkownicy = new List<Użytkownicy>();
                mojabaza = new Baza();

                using (SqlConnection connection = mojabaza.PolaczZBaza())
                {
                    string query = "SELECT * FROM tbl_Użytkownicy WHERE CzyUsunięty <> 1";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int idUzytkownika = Convert.ToInt32(reader["IdUżytkownika"]);
                            string rola = reader["rola"].ToString();

                
                        
                          


                            Użytkownicy uzytkownik = new Użytkownicy();


                            switch (rola)
                            {
                                case "Admin":
                                    Administrator administrator = new Administrator();
                                    uzytkownik = administrator.PobierzDaneKAdministratora(idUzytkownika);

                                    break;
                                case "Klient":
                                    Klient klient = new Klient();
                                    uzytkownik = klient.PobierzDaneKlienta(idUzytkownika);
                                    // uzytkownik = klient;
                                    break;
                                case "Pracownik":
                                    Pracownik pracownik = new Pracownik();
                                    uzytkownik = pracownik.PobierzDanePracownika(idUzytkownika);
                                    // uzytkownik = pracownik;
                                    break;
                            }

                            if (uzytkownik != null)
                            {
                                uzytkownik.Haslo = reader["Hasło"].ToString();
                                uzytkownik.Rola = rola;
                                uzytkownicy.Add(uzytkownik);
                            }
                        }
                    }
                }

                return uzytkownicy;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
                return null;
            }
        }

        public int PobierzIdUzytkownika(string adresEmail, string haslo)
        {
            int idUzytkownika = -1; 
            mojabaza = new Baza();

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                string query = "SELECT IdUżytkownika FROM tbl_Użytkownicy WHERE adresEmail = @AdresEmail AND Hasło = @Haslo";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AdresEmail", adresEmail);
                    cmd.Parameters.AddWithValue("@Haslo", haslo);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        idUzytkownika = Convert.ToInt32(result);
                    }
                }
            }

            return idUzytkownika;
        }

        public void UsuńUżytkownika(int idUzytkownika)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
               

                string updateQuery = "UPDATE tbl_Użytkownicy SET CzyUsunięty = 1 WHERE IdUżytkownika = @IdUzytkownika";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@IdUzytkownika", idUzytkownika);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Użytkownik został usunięty");
                    }
                    else
                    {
                        Console.WriteLine("Nie udało się usunąć użytkownika");
                    }
                }
            }
        }
        public bool SprawdzCzyUzytkownikIstnieje(string email)
        {
            mojabaza = new Baza();
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {
                

                string query = "SELECT COUNT(*) FROM tbl_Użytkownicy WHERE adresEmail=@Email";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    int liczbaUzytkownikow = (int)cmd.ExecuteScalar();

                    return liczbaUzytkownikow > 0;
                }
            }
        }


    }
}
