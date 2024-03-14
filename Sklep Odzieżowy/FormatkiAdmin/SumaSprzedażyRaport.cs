using Sklep_Odzieżowy.Klasy;
using System.Data.SqlClient;

namespace Sklep_Odzieżowy
{

    public partial class SumaSprzedażyRaport : Form
    {
        private Baza mojabaza = new Baza();
        public DateTime DataOd;
        public DateTime DataDo;
        public SumaSprzedażyRaport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SumaSprzedażyRaport_Load(object sender, EventArgs e)
        {
            ObliczStatystyki(DataOd, DataDo);
        }

        public void ObliczStatystyki(DateTime dataOd, DateTime dataDo)
        {
            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {

                string querySprzedaz = "SELECT SUM(SumaSprzedaży) FROM tbl_PozycjaSprzedaży " +
                                       "WHERE DataZamówienia BETWEEN @DataOd AND @DataDo";
                using (SqlCommand cmdSprzedaz = new SqlCommand(querySprzedaz, connection))
                {
                    cmdSprzedaz.Parameters.AddWithValue("@DataOd", dataOd);
                    cmdSprzedaz.Parameters.AddWithValue("@DataDo", dataDo);

                    object sumaSprzedazyObj = cmdSprzedaz.ExecuteScalar();

                    decimal sumaSprzedazy = sumaSprzedazyObj != DBNull.Value ? (decimal)sumaSprzedazyObj : 0;




                    label5.Text = $"Suma sprzedaży: {sumaSprzedazy:C}";


                    decimal podatekVat = sumaSprzedazy / 100 * 23;
                    label6.Text = $"Podatek vat: {podatekVat:C}";



                    string queryKoszty = "SELECT SUM(SumaZakupu) FROM tbl_PozycjaZakupyHurt " +
                    "WHERE DataZamówienia BETWEEN @DataOd AND @DataDo";

                    using (SqlCommand cmdKoszty = new SqlCommand(queryKoszty, connection))
                    {
                        cmdKoszty.Parameters.AddWithValue("@DataOd", dataOd);
                        cmdKoszty.Parameters.AddWithValue("@DataDo", dataDo);


                        object sumaKosztówObj = cmdKoszty.ExecuteScalar();

                        decimal sumaKosztów = sumaKosztówObj != DBNull.Value ? (decimal)sumaKosztówObj : 0;

                        label7.Text = $"Suma Zakupów Hurtowych: {sumaKosztów:C}";

                        decimal dochód = sumaSprzedazy - podatekVat - sumaKosztów;


                        label8.Text = $"Dochód: {dochód:C}";





                    }

                }

            }
        }

    }
}
