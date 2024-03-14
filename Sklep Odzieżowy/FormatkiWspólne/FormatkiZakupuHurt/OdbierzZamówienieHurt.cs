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
    public partial class OdbierzZamówienieHurt : Form
    {
        Zakupy zakupy = new Zakupy();
        public int IdPozycjiZH;
        public OdbierzZamówienieHurt()
        {
            InitializeComponent();
        }

        private void OdbierzZamówienieHurt_Load(object sender, EventArgs e)
        {

            zakupy.WyswietlZamowieniaNiedostarczone(dataGridView1);

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
            IdPozycjiZH = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["IdPozycjiZH"].Value);
            zakupy.AktualizujStanProduktow(IdPozycjiZH);
            zakupy.ZmienStatus(IdPozycjiZH, "dostarczony");
            zakupy.WyswietlZamowieniaNiedostarczone(dataGridView1);


        }
    }
}
