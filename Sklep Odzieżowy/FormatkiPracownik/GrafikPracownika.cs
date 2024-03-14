using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sklep_Odzieżowy
{
    public partial class GrafikPracownika : Form
    {
        private Baza mojabaza;
        Pracownik pracownik = new Pracownik();
        public string Idpracownika;


        public GrafikPracownika()
        {
            InitializeComponent();
            mojabaza = new Baza();
        

        }

        private string FormatujCzas(object czasDB)
        {
            if (czasDB != null && DateTime.TryParse(czasDB.ToString(), out DateTime czas))
            {
                return czas.ToString("HH:mm");
            }
            return "";
        }

        private void WyczyscTextBoxy()
        {
            txtGP1p.Text = "";
            txtGP1k.Text = "";
            txtGP2p.Text = "";
            txtGP2k.Text = "";
            txtGP3p.Text = "";
            txtGP3k.Text = "";
            txtGP4p.Text = "";
            txtGP4k.Text = "";
            txtGP5p.Text = "";
            txtGP5k.Text = "";
        }

        private void WczytajDane()
        {
            SqlConnection connection = mojabaza.PolaczZBaza();
            string query = "SELECT * FROM tbl_grafik WHERE IdPracownika = @IdPracownika";

            int Id = pracownik.ZnajdzIdPracownika(int.Parse(Idpracownika));
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IdPracownika", Id);


            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    txtGP1p.Text = FormatujCzas(reader["Pon_od"]);
                    txtGP1k.Text = FormatujCzas(reader["Pon_do"]);
                    txtGP2p.Text = FormatujCzas(reader["Wt_od"]);
                    txtGP2k.Text = FormatujCzas(reader["Wt_do"]);
                    txtGP3p.Text = FormatujCzas(reader["Śr_od"]);
                    txtGP3k.Text = FormatujCzas(reader["Śr_do"]);
                    txtGP4p.Text = FormatujCzas(reader["Czw_od"]);
                    txtGP4k.Text = FormatujCzas(reader["Czw_do"]);
                    txtGP5p.Text = FormatujCzas(reader["Pt_od"]);
                    txtGP5k.Text = FormatujCzas(reader["Pt_do"]);
                }
                else
                {
                    WyczyscTextBoxy();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            AktualizujStatusLabelGrafiku();
        }

        enum StatusGrafiku
        {
            BrakGrafiku,
            Zaakceptowany,
            WTrakcieRealizacji
        }


        private StatusGrafiku CzyGrafikZaakceptowany()
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            int Id = pracownik.ZnajdzIdPracownika(int.Parse(Idpracownika));
            string query = "SELECT Status FROM tbl_Grafik WHERE IdPracownika = @IdPracownika";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@IdPracownika", Id);

            try
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int status = Convert.ToInt32(result);
                    return status == 1 ? StatusGrafiku.Zaakceptowany : StatusGrafiku.WTrakcieRealizacji;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }

            return StatusGrafiku.BrakGrafiku;
        }

        private void AktualizujStatusLabelGrafiku()
        {
            StatusGrafiku status = CzyGrafikZaakceptowany();
            switch (status)
            {
                case StatusGrafiku.Zaakceptowany:
                    label6.Text = "Twój grafik został zaakceptowany";
                    label6.Visible = true;
                    break;
                case StatusGrafiku.WTrakcieRealizacji:
                    label6.Text = "Twój grafik jest w trakcie weryfikacji";
                    label6.Visible = true;
                    break;
                default:
                    label6.Text = "Nie przesłałeś jeszcze grafiku lub twój grafik został odrzucony";
                    label6.Visible = true;
                    break;
            }
        }
    

        private bool CzyGrafikIstnieje()
        {
            mojabaza = new Baza();
            SqlConnection connection = mojabaza.PolaczZBaza();
            try
            {
                int Id = pracownik.ZnajdzIdPracownika(int.Parse(Idpracownika));
                string query = "SELECT COUNT(*) FROM tbl_Grafik WHERE IdPracownika = @IdPracownika";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdPracownika", Id);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
                return false;
            }
            
            
        }

        private bool AreAllTextBoxesFilled(Control container)
        {
            foreach (Control c in container.Controls)
            {
                var textBox = c as TextBox;
                if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false;
                }

                if (c.HasChildren && !AreAllTextBoxesFilled(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void szablon_godzin(int czasStart)
        {
            TextBox[] czas_pocz = { txtGP1p, txtGP2p, txtGP3p, txtGP4p, txtGP5p };
            TextBox[] czas_kon = { txtGP1k, txtGP2k, txtGP3k, txtGP4k, txtGP5k };

            for (int i = 0; i < 5; i++)
            {
                czas_pocz[i].Text = czasStart.ToString("D2") + ":00";
                czas_kon[i].Text = (czasStart + 8).ToString("D2") + ":00";
            }
        }

        private void GrafikPracownika_Load(object sender, EventArgs e)
        {
          
        }

        private void btnGP1_Click(object sender, EventArgs e)
        {
            szablon_godzin(6);
        }

        private void btnGP2_Click(object sender, EventArgs e)
        {
            szablon_godzin(7);
        }

        private void btnGP3_Click(object sender, EventArgs e)
        {
            szablon_godzin(8);
        }

        private void btnGP4_Click(object sender, EventArgs e)
        {
            szablon_godzin(9);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void btnDodajGrafik_Click(object sender, EventArgs e)
        {

        }

        private void gbGPgodziny_Enter(object sender, EventArgs e)
        {

        }

        private void btnDodajGrafik_Click_1(object sender, EventArgs e)
        {
            string pon_od = txtGP1p.Text;
            string pon_do = txtGP1k.Text;
            string wt_od = txtGP2p.Text;
            string wt_do = txtGP2k.Text;
            string śr_od = txtGP3p.Text;
            string śr_do = txtGP3k.Text;
            string czw_od = txtGP4p.Text;
            string czw_do = txtGP4k.Text;
            string pt_od = txtGP5p.Text;
            string pt_do = txtGP5k.Text;


            SqlConnection connection = mojabaza.PolaczZBaza();

            if (!AreAllTextBoxesFilled(this))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }
            
            if (CzyGrafikIstnieje())
            {
                MessageBox.Show("Ten pracownik ma już przypisany grafik.");
                return;
            }

            if (connection == null)
            {
                MessageBox.Show("Błąd podczas łączenia z bazą danych");
                return;
            }

            try
            {
                int Id = pracownik.ZnajdzIdPracownika(int.Parse(Idpracownika));
                
                SqlCommand cmd = new SqlCommand("SELECT IdPracownika FROM tbl_Pracownicy WHERE IdPracownika = @IdPracownika", connection);
                cmd.Parameters.AddWithValue("@IdPracownika", Id);

               
           
                //Idpracownika = (int)cmd.ExecuteScalar();

                string addGrafikQuery = "INSERT INTO tbl_Grafik (IdPracownika, Pon_od, Pon_do, Wt_od, Wt_do, Śr_od, Śr_do, Czw_od, Czw_do, Pt_od, Pt_do) VALUES (@IdPracownika, @Pon_od, @Pon_do, @Wt_od, @Wt_do, @Śr_od, @Śr_do, @Czw_od, @Czw_do, @Pt_od, @Pt_do);";
                SqlCommand addGrafikCmd = new SqlCommand(addGrafikQuery, connection);
                addGrafikCmd.Parameters.AddWithValue("@IdPracownika", Id);
                addGrafikCmd.Parameters.AddWithValue("@Pon_od", pon_od);
                addGrafikCmd.Parameters.AddWithValue("@Pon_do", pon_do);
                addGrafikCmd.Parameters.AddWithValue("@Wt_od", wt_od);
                addGrafikCmd.Parameters.AddWithValue("@Wt_do", wt_do);
                addGrafikCmd.Parameters.AddWithValue("@Śr_od", śr_od);
                addGrafikCmd.Parameters.AddWithValue("@Śr_do", śr_do);
                addGrafikCmd.Parameters.AddWithValue("@Czw_od", czw_od);
                addGrafikCmd.Parameters.AddWithValue("@Czw_do", czw_do);
                addGrafikCmd.Parameters.AddWithValue("@Pt_od", pt_od);
                addGrafikCmd.Parameters.AddWithValue("@Pt_do", pt_do);

                addGrafikCmd.ExecuteNonQuery();
                MessageBox.Show("Grafik został przesłany");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania grafika: " + ex.Message);
                
            }
            finally
            {
                connection.Close();
            }
            label6.Text = "Twój grafik jest w trakcie weryfikacji";
        }

        private void btnEdytujGrafik_Click(object sender, EventArgs e)
        {
            string pon_od = txtGP1p.Text;
            string pon_do = txtGP1k.Text;
            string wt_od = txtGP2p.Text;
            string wt_do = txtGP2k.Text;
            string śr_od = txtGP3p.Text;
            string śr_do = txtGP3k.Text;
            string czw_od = txtGP4p.Text;
            string czw_do = txtGP4k.Text;
            string pt_od = txtGP5p.Text;
            string pt_do = txtGP5k.Text;

          

            SqlConnection connection = mojabaza.PolaczZBaza();

            if (!AreAllTextBoxesFilled(this))
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

                int Id = pracownik.ZnajdzIdPracownika(int.Parse(Idpracownika));
                SqlCommand cmd = new SqlCommand("SELECT IdPracownika FROM tbl_Pracownicy WHERE IdPracownika = @IdPracownika", connection);
                cmd.Parameters.AddWithValue("@IdPracownika", Id);


            

                string updGrafikQuery = "UPDATE tbl_Grafik SET Pon_od=@Pon_od, Pon_do=@Pon_do, Wt_od=@Wt_od ,Wt_do=@Wt_do, Śr_od=@Śr_od, Śr_do=@Śr_do, Czw_od=@Czw_od, Czw_do=@Czw_do, Pt_od=@Pt_od, Pt_do=@Pt_do, Status='0' WHERE IdPracownika=@IdPracownika;";
                SqlCommand updGrafikCmd = new SqlCommand(updGrafikQuery, connection);
                updGrafikCmd.Parameters.AddWithValue("@IdPracownika", Id);
                updGrafikCmd.Parameters.AddWithValue("@Pon_od", pon_od);
                updGrafikCmd.Parameters.AddWithValue("@Pon_do", pon_do);
                updGrafikCmd.Parameters.AddWithValue("@Wt_od", wt_od);
                updGrafikCmd.Parameters.AddWithValue("@Wt_do", wt_do);
                updGrafikCmd.Parameters.AddWithValue("@Śr_od", śr_od);
                updGrafikCmd.Parameters.AddWithValue("@Śr_do", śr_do);
                updGrafikCmd.Parameters.AddWithValue("@Czw_od", czw_od);
                updGrafikCmd.Parameters.AddWithValue("@Czw_do", czw_do);
                updGrafikCmd.Parameters.AddWithValue("@Pt_od", pt_od);
                updGrafikCmd.Parameters.AddWithValue("@Pt_do", pt_do);

                updGrafikCmd.ExecuteNonQuery();
                MessageBox.Show("Grafik został zmieniony");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmieniania grafika: " + ex.Message);
                
            }
            finally
            {
                connection.Close();
            }
            label6.Text = "Twój grafik jest w trakcie weryfikacji";
        }

        private void GrafikPracownika_Load_1(object sender, EventArgs e)
        {
            WczytajDane();
     
        }
    }
}
