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
    public partial class HistoriaZamówień : Form
    {
        public string IdUżytkownika;
        public int idPozycjiSD;

        Klient klient = new Klient();
        Sprzedaż sprzedaż = new Sprzedaż();

        public HistoriaZamówień()
        {
            InitializeComponent();
        }

        private void HistoriaZamówień_Load(object sender, EventArgs e)
        {

            int idKlienta = klient.ZnajdzIdKlienta(int.Parse(IdUżytkownika));
            sprzedaż.WyswietlZamowieniaOdebrane(dataGridView1, idKlienta);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                idPozycjiSD = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["IdPozycjiSD"].Value);
                //MessageBox.Show(" " + idPozycjiSD);
                SzczegółySprzedaży szczegółySprzedaży = new SzczegółySprzedaży();
                szczegółySprzedaży.IdpozycjiSD = idPozycjiSD;
                szczegółySprzedaży.Show();
            }
            else
            {
                MessageBox.Show("Proszę wybrać zamówienie");
                return;
            }
        }
    }
}
