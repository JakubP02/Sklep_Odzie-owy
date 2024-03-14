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
    public partial class SzczegółyZakupuHurtcs : Form
    {
        public int idPozycjiZH;
        public SzczegółyZakupuHurtcs()
        {
            InitializeComponent();
        }

        private void SzczegółyZakupuHurtcs_Load(object sender, EventArgs e)
        {
            Zakupy zakupy = new Zakupy();
            zakupy.WyswietlSzczegolyZamowienia(idPozycjiZH, dataGridView1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

        }
    }
}
