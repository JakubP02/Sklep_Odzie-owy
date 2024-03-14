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
    public partial class ZatwierdzanieSprzedaży : Form
    {
        public int idPozycjiSD;
        Sprzedaż sprzedaż = new Sprzedaż();
        public ZatwierdzanieSprzedaży()
        {
            InitializeComponent();
        }

        private void ZatwierdzanieSprzedaży_Load(object sender, EventArgs e)
        {

            sprzedaż.WyswietlZamowieniaWtrakcieRealizacji(dataGridView1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btnWyślijZamówienie_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                idPozycjiSD = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["IdPozycjiSD"].Value);
                sprzedaż.ZmienStatus(idPozycjiSD, "W dostarczeniu");
                sprzedaż.WyswietlZamowieniaWtrakcieRealizacji(dataGridView1);
            }
            else
            {
                MessageBox.Show("Proszę wybrać zamówienie");
                return;
            }
        }
    }
}
