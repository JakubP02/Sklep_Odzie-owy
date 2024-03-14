using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Odzieżowy.Klasy
{
    internal class ProduktWKoszyku
    {
        public string NazwaProduktu { get; set; }
        public string KodProduktu { get; set; }
        public decimal SumaSprzedazy { get; set; }
        public int Ilosc { get; set; }



        public void AktualizujKoszyk(DataGridView dataGridView, List<ProduktWKoszyku> koszykProduktow)
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


            dataGridView.DataSource = koszykDataTable;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.ReadOnly = true;
            }
        }


        public void dodajProduktDoKoszyka(DataGridViewRow selectedRow, List<ProduktWKoszyku> koszykProduktow)
        {


            string kodProduktu = Convert.ToString(selectedRow.Cells["Kod Produktu"].Value);


            ProduktWKoszyku istniejacyProdukt = koszykProduktow.FirstOrDefault(p => p.KodProduktu == kodProduktu);

            if (istniejacyProdukt != null)
            {

                istniejacyProdukt.Ilosc += Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
                istniejacyProdukt.SumaSprzedazy += Convert.ToDecimal(selectedRow.Cells["Cena Hurtowa"].Value) * Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
            }
            else
            {

                string nazwaProduktu = Convert.ToString(selectedRow.Cells["Nazwa Produktu"].Value);
                decimal sumaSprzedazy = Convert.ToDecimal(selectedRow.Cells["Cena Hurtowa"].Value) * Convert.ToInt32(selectedRow.Cells["Ilość"].Value);
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




    }
}
