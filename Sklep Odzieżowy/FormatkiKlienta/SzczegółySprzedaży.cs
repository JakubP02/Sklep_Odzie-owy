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
    public partial class SzczegółySprzedaży : Form
    {
        public int IdpozycjiSD;
        public SzczegółySprzedaży()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SzczegółySprzedaży_Load(object sender, EventArgs e)
        {

            Sprzedaż sprzedaż = new Sprzedaż();
            sprzedaż.WyswietlSzczegolyZamowienia(IdpozycjiSD, dataGridView1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }
    }
}
