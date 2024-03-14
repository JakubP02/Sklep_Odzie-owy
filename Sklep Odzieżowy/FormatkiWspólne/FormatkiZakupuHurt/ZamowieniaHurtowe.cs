using Microsoft.IdentityModel.Tokens;
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
    public partial class ZamowieniaHurtowe : Form


    {
        private List<ProduktWKoszyku> koszykProduktow = new List<ProduktWKoszyku>();
        ProduktWKoszyku produktWKoszyku = new ProduktWKoszyku();

        Zakupy zakupy1 = new Zakupy();

        Produkt produkt = new Produkt();

        public ZamowieniaHurtowe()
        {
            InitializeComponent();
        }

        private void ZamowieniaHurtowe_Load(object sender, EventArgs e)
        {

            WyświetlProduktyWDatagridView();
            WypelnijComboBoxKategoriami();
            Produkt produktKlasa = new Produkt();
            produktKlasa.DodajKolumny(dataGridView1);


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }


            dataGridView1.Columns["Ilość"].ReadOnly = false;




        }
        private void WyświetlProduktyWDatagridView()
        {

            Produkt produktKlasa = new Produkt();
            List<Produkt> produktyStanPonizej10 = produktKlasa.PobierzWszystkieProduktyStanPoniżej10();
            Dictionary<int, decimal> cenyHurtoweStanPonizej10 = produktKlasa.PobierzCenyHurtoweDlaProduktowStanPonizej10();
            produktKlasa.WyswietlProduktyWDataGridViewZamówieniaHurtowe(dataGridView1, produktyStanPonizej10, cenyHurtoweStanPonizej10);




        }
        private void WypelnijComboBoxKategoriami()
        {
            comboBoxKategoria.Items.Clear();


            List<string> kategorie = produkt.PobierzKategorieZBazy();


            comboBoxKategoria.Items.AddRange(kategorie.ToArray());

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Ilość"].Index)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value != null)
                {
                    int ilosc = 0;

                    if (int.TryParse(cell.Value.ToString(), out ilosc))
                    {
                        if (ilosc < 0)
                        {
                            MessageBox.Show("Ilość nie może być ujemna. Wprowadź poprawną ilość.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cell.Value = 0;
                        }



                    }
                    else
                    {
                        MessageBox.Show("Wprowadź poprawną liczbę całkowitą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cell.Value = 0;
                    }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell iloscCell = dataGridView1.Rows[e.RowIndex].Cells["Ilość"];
                DataGridViewCell stanCell = dataGridView1.Rows[e.RowIndex].Cells["Stan"];

                int ilosc = Convert.ToInt32(iloscCell.Value);
                int stan = Convert.ToInt32(stanCell.Value);
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewButtonCell)
                {
                    var buttonCell = (DataGridViewButtonCell)cell;

                    if (buttonCell.Value != null)
                    {


                        dataGridView1.CellClick -= dataGridView1_CellClick;

                        if (buttonCell.Value.ToString() == "+")
                        {


                            ilosc++;
                            iloscCell.Value = ilosc;


                        }
                        else if (buttonCell.Value.ToString() == "-" && ilosc > 0)
                        {

                            ilosc--;
                            iloscCell.Value = ilosc;

                        }


                        dataGridView1.Rows[e.RowIndex].Cells["Ilość"].Value = ilosc;


                        dataGridView1.CellClick += dataGridView1_CellClick;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int ilosc = Convert.ToInt32(row.Cells["Ilość"].Value);

                if (ilosc > 0)
                {
                    produktWKoszyku.dodajProduktDoKoszyka(row, koszykProduktow);
                    row.Cells["Ilość"].Value = 0;
                }
            }

            if (koszykProduktow.IsNullOrEmpty())
            {
                MessageBox.Show("Aby dodać produkt do koszyka wpisz w pole ilość wartość większą od 0 lub skorzytaj z przycików + i - przy wybranym produckie ");
                return;
            }
            produktWKoszyku.AktualizujKoszyk(dataGridView2, koszykProduktow);

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.ReadOnly = true;
            }

            dataGridView2.Columns["Ilość"].ReadOnly = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty");
                return;
            }





            Zakupy zakupy = new Zakupy();





            zakupy.DodajZamowienieDoBazyDanych(koszykProduktow);





            koszykProduktow.Clear();


            produktWKoszyku.AktualizujKoszyk(dataGridView2, koszykProduktow);




            WyświetlProduktyWDatagridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string nazwa = txtbNazwa.Text;
            string kategoria = comboBoxKategoria.SelectedItem?.ToString();
            decimal? cenaOd = numericUpDownOD.Value;
            decimal? cenaDo = numericUpDownDO.Value;

            if (cenaOd > cenaDo)
            {
                MessageBox.Show("Cena od nie może być większą niż cena do");
                cenaOd = 0;
                cenaDo = 0;
                return;
            }
            if (cenaDo > 0)
            {
                DataTable dataTable = zakupy1.WyszukajProdukty(nazwa, kategoria, cenaOd, cenaDo);
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }

            }
            else
            {
                DataTable dataTable = zakupy1.WyszukajProdukty(nazwa, kategoria, cenaOd, 100000000);
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }


            }
            nazwa = "";
            cenaOd = 0;
            cenaDo = 0;
            comboBoxKategoria.Items.Clear();
            WypelnijComboBoxKategoriami();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                dataGridView2.Rows.Remove(dataGridView2.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć wiersz do usunięcia.");
            }
        }
    }
}
