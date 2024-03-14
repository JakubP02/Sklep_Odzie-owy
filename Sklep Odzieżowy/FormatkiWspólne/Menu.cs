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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }



        public Panel PanelKlient()
        {
            return pnlEmployeeSubmenu;

        }
        public Panel PanelPracownik()
        {
            return panel2;
        }
        public Panel PanelAdmin()
        {
            return panel1;
        }

        public Button ButtonKlient()
        {
            return btnEmployee;
        }
        public Button ButtonPracownik()
        {
            return button2;
        }
        public Button ButtonAdmin()
        {
            return button4;
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {

            OdbierzZamówienie historia = new OdbierzZamówienie();
            historia.IdUżytkownika = label1.Text;
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();



        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {

            GrafikPracownika historia = new GrafikPracownika();
            historia.TopLevel = false;
            historia.Idpracownika = label1.Text;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZarzadzanieUzytkownikami historia = new ZarzadzanieUzytkownikami();
            historia.TopLevel = false;
            historia.Id = label1.Text;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WyszukiwarkaProduktow historia = new WyszukiwarkaProduktow();
            historia.IdUżytkownika = label1.Text;
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();



        }

        private void btnZamówieniaHurtowe_Click(object sender, EventArgs e)
        {

            ZamowieniaHurtowe historia = new ZamowieniaHurtowe();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ZarzadzanieGrafikiem historia = new ZarzadzanieGrafikiem();
            historia.TopLevel = false;
            //historia.Idpracownika = label1.Text;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            KontoPracownik historia = new KontoPracownik();
            historia.IdUżytkownika = label1.Text;
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void btnZarządzanieKontem_Click(object sender, EventArgs e)
        {

            KontoKlienta historia = new KontoKlienta();
            historia.IdUżytkownika = label1.Text;
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();


        }

        private void button12_Click(object sender, EventArgs e)
        {



            DodawanieProduktówKategoriiZmianaCeny historia = new DodawanieProduktówKategoriiZmianaCeny();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();

        }

        private void button13_Click(object sender, EventArgs e)
        {




        }

        private void button11_Click(object sender, EventArgs e)
        {


            ZamowieniaHurtowe historia = new ZamowieniaHurtowe();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

            DodawanieProduktówKategoriiZmianaCeny historia = new DodawanieProduktówKategoriiZmianaCeny();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

            DodawanieProduktówKategoriiZmianaCeny historia = new DodawanieProduktówKategoriiZmianaCeny();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnWyloguj_Click(object sender, EventArgs e)
        {


            this.Hide();
            Logowanie logowanie = new Logowanie();
            logowanie.Show();






        }

        private void button10_Click(object sender, EventArgs e)
        {
            ZatwierdzanieSprzedaży historia = new ZatwierdzanieSprzedaży();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            HistoriaZamówień historia = new HistoriaZamówień();
            historia.IdUżytkownika = label1.Text;
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void btnOdbierzHurt_Click(object sender, EventArgs e)
        {
            OdbierzZamówienieHurt historia = new OdbierzZamówienieHurt();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void btnHistoriaHurt_Click(object sender, EventArgs e)
        {
            HistoriaZakupówHurt historia = new HistoriaZakupówHurt();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OdbierzZamówienieHurt historia = new OdbierzZamówienieHurt();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            HistoriaZakupówHurt historia = new HistoriaZakupówHurt();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            Raporty historia = new Raporty();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            HistoriaZakupówHurt historia = new HistoriaZakupówHurt();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ZatwierdzanieSprzedaży historia = new ZatwierdzanieSprzedaży();
            historia.TopLevel = false;
            historia.FormBorderStyle = FormBorderStyle.None;
            historia.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(historia);
            pnlMenu.Tag = historia;
            historia.BringToFront();
            historia.Show();
        }
    }
}
