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

namespace Sklep_Odzieżowy
{
    public partial class ZarzadzanieGrafikiem : Form
    {

        private Baza mojabaza;

        public ZarzadzanieGrafikiem()
        {
            InitializeComponent();
            mojabaza = new Baza();
        }

        private void ZarzadzanieGrafikiem_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private int GetSelectedPracownikId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdPracownika"].Value);
            }
            return -1;
        }

        private void odswiez_siatke()
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            try
            {
                SqlCommand query = new SqlCommand("SELECT p.IdPracownika, p.Imię, p.Nazwisko, p.AdresEmail, g.Pon_od, g.Pon_do, g.Wt_od, g.Wt_do, g.Śr_od, g.Śr_do, g.Czw_od, g.Czw_do, g.Pt_od, g.Pt_do, g.Status FROM tbl_Pracownicy p INNER JOIN tbl_Grafik g ON p.IdPracownika = g.IdPracownika;", connection);
                SqlDataAdapter pobraniebaza = new SqlDataAdapter();
                pobraniebaza.SelectCommand = query;
                DataTable dt = new DataTable();
                pobraniebaza.Fill(dt);
                BindingSource zrodlo = new BindingSource();
                zrodlo.DataSource = dt;
                dataGridView1.DataSource = zrodlo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            string pon_od = txt1ZGp.Text;
            string pon_do = txt1ZGk.Text;
            string wt_od = txt2ZGp.Text;
            string wt_do = txt2ZGk.Text;
            string śr_od = txt3ZGp.Text;
            string śr_do = txt3ZGk.Text;
            string czw_od = txt4ZGp.Text;
            string czw_do = txt4ZGk.Text;
            string pt_od = txt5ZGp.Text;
            string pt_do = txt5ZGk.Text;

            if (pon_od == "" && pon_do == "" && wt_od == "" && wt_do == "" && śr_od == "" && śr_do == "" && czw_od == "" && czw_do == "" && pt_od == "" && pt_do == "")
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
                return;
            }


            SqlConnection connection = mojabaza.PolaczZBaza();

            int idPracownika = GetSelectedPracownikId();
            if (idPracownika == -1)
            {
                MessageBox.Show("Proszę wybrać pracownika");
                return;
            }

            try
            {
                string query = "UPDATE tbl_Grafik SET Pon_od=@Pon_od, Pon_do=@Pon_do, Wt_od=@Wt_od ,Wt_do=@Wt_do, Śr_od=@Śr_od, Śr_do=@Śr_do, Czw_od=@Czw_od, Czw_do=@Czw_do, Pt_od=@Pt_od, Pt_do=@Pt_do, Status = 1 WHERE IdPracownika = @IdPracownika";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdPracownika", idPracownika);
                cmd.Parameters.AddWithValue("@Pon_od", pon_od);
                cmd.Parameters.AddWithValue("@Pon_do", pon_do);
                cmd.Parameters.AddWithValue("@Wt_od", wt_od);
                cmd.Parameters.AddWithValue("@Wt_do", wt_do);
                cmd.Parameters.AddWithValue("@Śr_od", śr_od);
                cmd.Parameters.AddWithValue("@Śr_do", śr_do);
                cmd.Parameters.AddWithValue("@Czw_od", czw_od);
                cmd.Parameters.AddWithValue("@Czw_do", czw_do);
                cmd.Parameters.AddWithValue("@Pt_od", pt_od);
                cmd.Parameters.AddWithValue("@Pt_do", pt_do);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Grafik został zaakceptowany");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            odswiez_siatke();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void szablon_godzin(int czasStart)
        {
            TextBox[] czas_pocz = { txt1ZGp, txt2ZGp, txt3ZGp, txt4ZGp, txt5ZGp };
            TextBox[] czas_kon = { txt1ZGk, txt2ZGk, txt3ZGk, txt4ZGk, txt5ZGk };

            for (int i = 0; i < 5; i++)
            {
                czas_pocz[i].Text = czasStart.ToString("D2") + ":00";
                czas_kon[i].Text = (czasStart + 8).ToString("D2") + ":00";
            }
        }





        private void btnWyszukajUzytk_Click(object sender, EventArgs e)
        {
            string searchString = "%" + textBox1.Text + "%";

            SqlConnection connection = mojabaza.PolaczZBaza();

            try
            {
                string query = @"SELECT p.IdPracownika, p.Imię, p.Nazwisko, p.AdresEmail, g.Pon_od, g.Pon_do, g.Wt_od, g.Wt_do, g.Śr_od, g.Śr_do, g.Czw_od, g.Czw_do, g.Pt_od, g.Pt_do, g.Status FROM tbl_Pracownicy p INNER JOIN tbl_Grafik g ON p.IdPracownika = g.IdPracownika WHERE p.Imię LIKE @search OR p.Nazwisko LIKE @search OR p.AdresEmail LIKE @search";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@search", searchString);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
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
            txt1ZGp.Text = "";
            txt1ZGk.Text = "";
            txt2ZGp.Text = "";
            txt2ZGk.Text = "";
            txt3ZGp.Text = "";
            txt3ZGk.Text = "";
            txt4ZGp.Text = "";
            txt4ZGk.Text = "";
            txt5ZGp.Text = "";
            txt5ZGk.Text = "";
        }

        private void WczytajDaneGrafiku(int idPracownika)
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            try
            {
                string query = "SELECT * FROM tbl_Grafik WHERE IdPracownika = @IdPracownika";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdPracownika", idPracownika);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txt1ZGp.Text = FormatujCzas(reader["Pon_od"]);
                    txt1ZGk.Text = FormatujCzas(reader["Pon_do"]);
                    txt2ZGp.Text = FormatujCzas(reader["Wt_od"]);
                    txt2ZGk.Text = FormatujCzas(reader["Wt_do"]);
                    txt3ZGp.Text = FormatujCzas(reader["Śr_od"]);
                    txt3ZGk.Text = FormatujCzas(reader["Śr_do"]);
                    txt4ZGp.Text = FormatujCzas(reader["Czw_od"]);
                    txt4ZGk.Text = FormatujCzas(reader["Czw_do"]);
                    txt5ZGp.Text = FormatujCzas(reader["Pt_od"]);
                    txt5ZGk.Text = FormatujCzas(reader["Pt_do"]);

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
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idPracownika = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdPracownika"].Value);
                WczytajDaneGrafiku(idPracownika);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            int idPracownika = GetSelectedPracownikId();
            if (idPracownika == -1)
            {
                MessageBox.Show("Proszę wybrać pracownika");
                return;
            }

            var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć ten grafik?", "Potwierdź usunięcie", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                UsunGrafik(idPracownika);
            }
        }

        private void UsunGrafik(int idPracownika)
        {
            SqlConnection connection = mojabaza.PolaczZBaza();

            try
            {
                string query = "DELETE FROM tbl_Grafik WHERE IdPracownika = @IdPracownika";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdPracownika", idPracownika);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Grafik został usunięty");
                }
                else
                {
                    MessageBox.Show("Nie znaleziono grafiku do usunięcia");
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
            odswiez_siatke();
            WyczyscTextBoxy();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
