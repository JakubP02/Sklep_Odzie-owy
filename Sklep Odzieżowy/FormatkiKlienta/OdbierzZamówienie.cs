using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy
{
    public partial class OdbierzZamówienie : Form
    {
        Sprzedaż sprzedaż = new Sprzedaż();
        Klient klient = new Klient();
        public string IdUżytkownika;
        public int idPozycjiSD;
        public OdbierzZamówienie()
        {
            InitializeComponent();
        }

        private void HistoriaZamówień_Load(object sender, EventArgs e)
        {

            Klient klient = new Klient();
            int IdKlienta = klient.ZnajdzIdKlienta(int.Parse(IdUżytkownika));


            sprzedaż.WyswietlZamowieniaWDostarczeniu(dataGridView1, IdKlienta);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Proszę zaznaczyć zamówienie");
                return;
            }


            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            idPozycjiSD = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["IdPozycjiSD"].Value);
            sprzedaż.ZmienStatus(idPozycjiSD, "odebrane");
            int idKlienta = klient.ZnajdzIdKlienta(int.Parse(IdUżytkownika));
            sprzedaż.WyswietlZamowieniaWDostarczeniu(dataGridView1, idKlienta);
        }
    }
}
