using Microsoft.IdentityModel.Tokens;
using Sklep_Odzieżowy.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sklep_Odzieżowy
{
    public partial class WyszukiwarkaProduktow : Form
    {
        private List<ProduktWKoszyku> koszykProduktow = new List<ProduktWKoszyku>();

        private Baza mojabaza;
        public string IdUżytkownika;
        private Produkt produkt = new Produkt();
        private Sprzedaż sprzedaż = new Sprzedaż();



        public WyszukiwarkaProduktow()
        {
            InitializeComponent();
            mojabaza = new Baza();

        }

        private void WyszukiwarkaProduktow_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            Produkt produktKlasa = new Produkt();
            List<Produkt> wszystkieProdukty = produktKlasa.PobierzWszystkieProdukty();
            produkt.WyswietlProduktyWDataGridView(dataGridView1, wszystkieProdukty);
            produkt.DodajKolumny(dataGridView1);


            WypelnijComboBoxKategoriami();

            comboBoxPromocja.Items.Add("Tak");
            comboBoxPromocja.Items.Add("Nie");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }


            dataGridView1.Columns["Ilość"].ReadOnly = false;




        }

        private void WypelnijComboBoxKategoriami()
        {
            comboBoxKategorie.Items.Clear();


            List<string> kategorie = produkt.PobierzKategorieZBazy();


            comboBoxKategorie.Items.AddRange(kategorie.ToArray());

        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dodajProduktDoKoszyka(DataGridViewRow selectedRow)
        {


            string kodProduktu = Convert.ToString(selectedRow.Cells["Kod Produktu"].Value);


            ProduktWKoszyku istniejacyProdukt = koszykProduktow.FirstOrDefault(p => p.KodProduktu == kodProduktu);

            if (istniejacyProdukt != null)
            {

                istniejacyProdukt.Ilosc += Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
                istniejacyProdukt.SumaSprzedazy += Convert.ToDecimal(selectedRow.Cells["Cena"].Value) * Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
            }
            else
            {

                string nazwaProduktu = Convert.ToString(selectedRow.Cells["Nazwa Produktu"].Value);
                decimal sumaSprzedazy = Convert.ToDecimal(selectedRow.Cells["Cena"].Value) * Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
                int ilosc = Convert.ToInt32(selectedRow.Cells["Ilość"].Value);

                koszykProduktow.Add(new ProduktWKoszyku
                {
                    NazwaProduktu = nazwaProduktu,
                    KodProduktu = kodProduktu,
                    SumaSprzedazy = sumaSprzedazy,
                    Ilosc = ilosc
                });
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
                            if (ilosc < stan)
                            {
                                ilosc++;
                                iloscCell.Value = ilosc;
                            }
                            else
                            {
                                MessageBox.Show("Ilość Nie może przekroczyć stanu produktu");
                            }
                        }
                        else if (buttonCell.Value.ToString() == "-" && ilosc > 0)
                        {
                            if (ilosc > 0)
                            {
                                ilosc--;
                                iloscCell.Value = ilosc;
                            }
                        }


                        dataGridView1.Rows[e.RowIndex].Cells["Ilość"].Value = ilosc;


                        dataGridView1.CellClick += dataGridView1_CellClick;
                    }
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int ilosc = Convert.ToInt32(row.Cells["Ilość"].Value);

                if (ilosc > 0)
                {
                    dodajProduktDoKoszyka(row);
                    row.Cells["Ilość"].Value = 0;
                }
            }
            if (koszykProduktow.IsNullOrEmpty())
            {
                MessageBox.Show("Aby dodać produkt do koszyka wpisz w pole ilość wartość większą od 0 lub skorzytaj z przycików + i - przy wybranym produckie ");
                return;
            }

            aktualizujKoszykDataGridView();

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.ReadOnly = true;
            }


        }
        public void aktualizujKoszykDataGridView()
        {

            DataTable koszykDataTable = new DataTable();
            koszykDataTable.Columns.Add("Nazwa Produktu", typeof(string));
            koszykDataTable.Columns.Add("Kod Produktu", typeof(string));
            koszykDataTable.Columns.Add("Suma Sprzedaży", typeof(decimal));
            koszykDataTable.Columns.Add("Ilość", typeof(int));


            foreach (var produktWKoszyku in koszykProduktow)
            {
                koszykDataTable.Rows.Add(
                    produktWKoszyku.NazwaProduktu,
                    produktWKoszyku.KodProduktu,
                    produktWKoszyku.SumaSprzedazy,
                    produktWKoszyku.Ilosc
                );
            }


            dataGridView2.DataSource = koszykDataTable;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty");
                return;
            }



            Klient klient = new Klient();

            int IdKlienta = klient.ZnajdzIdKlienta(int.Parse(IdUżytkownika));
            sprzedaż.DodajZamowienieDoBazyDanych(koszykProduktow, IdKlienta);


            sprzedaż.AktualizujStanProduktow(koszykProduktow);


            koszykProduktow.Clear();


            aktualizujKoszykDataGridView();


            Produkt produktKlasa = new Produkt();
            List<Produkt> wszystkieProdukty = produktKlasa.PobierzWszystkieProdukty();
            produkt.WyswietlProduktyWDataGridView(dataGridView1, wszystkieProdukty);
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


                        int stan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Stan"].Value);
                        if (ilosc > stan)
                        {
                            MessageBox.Show("Ilość nie może być większa niż stan. Wprowadź poprawną ilość.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cell.Value = stan;
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




        private void button1_Click(object sender, EventArgs e)
        {





            string nazwa = txtbNazwa.Text;
            string kategoria = comboBoxKategorie.SelectedItem?.ToString();
            decimal? cenaOd = numericUpDownOD.Value;
            decimal? cenaDo = numericUpDownDO.Value;
            string promocja = comboBoxPromocja.SelectedItem?.ToString();
            if (cenaOd > cenaDo)
            {
                MessageBox.Show("Cena od nie może być większą niż cena do");
                cenaOd = 0;
                cenaDo = 0;
                return;
            }
            if (cenaDo > 0)
            {
                DataTable dataTable = sprzedaż.WyszukajProdukty(nazwa, kategoria, cenaOd, cenaDo, promocja);
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }

            }
            else
            {
                DataTable dataTable = sprzedaż.WyszukajProdukty(nazwa, kategoria, cenaOd, 100000000, promocja);
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }


            }
            nazwa = "";
            cenaOd = 0;
            cenaDo = 0;
            comboBoxKategorie.Items.Clear();
            WypelnijComboBoxKategoriami();
            comboBoxPromocja.Items.Clear();
            comboBoxPromocja.Items.Add("Tak");
            comboBoxPromocja.Items.Add("Nie");










        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

