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
using System.Xml.Linq;

namespace Sklep_Odzieżowy
{
    public partial class HistoriaZakupówHurt : Form
    {

        Zakupy zakupy = new Zakupy();
        int idPozycjiZH;
        public HistoriaZakupówHurt()
        {
            InitializeComponent();
        }

        private void HistoriaZakupówHurt_Load(object sender, EventArgs e)
        {
            zakupy.WyswietlZamowieniaDostarczone(dataGridView1);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {

                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                idPozycjiZH = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["IdPozycjiZH"].Value);
                SzczegółyZakupuHurtcs szczegółyZakupuHurtcs = new SzczegółyZakupuHurtcs();
                szczegółyZakupuHurtcs.idPozycjiZH = idPozycjiZH;
                szczegółyZakupuHurtcs.Show();
            }
            else
            {
                
                    MessageBox.Show("Proszę zaznaczyć zamówienie");
                    return;
                
            }
        }
    }
}
