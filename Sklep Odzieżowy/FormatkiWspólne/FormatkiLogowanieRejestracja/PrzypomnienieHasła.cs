using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sklep_Odzieżowy.Klasy;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sklep_Odzieżowy
{
    public partial class PrzypomnienieHasła : Form
    {

        private Baza mojabaza;
        public PrzypomnienieHasła()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            mojabaza = new Baza();

        }

        private void UpdatePasswordInDatabase(string email, string newPassword)
        {

            SqlConnection connection = mojabaza.PolaczZBaza();
            using (connection)
            {


                string updateQuery = "UPDATE tbl_Użytkownicy SET Hasło = @NewPassword, Status = 1 WHERE adresEmail = @Email";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();


                }
            }
        }

        private void btnZarejestrujSię_Click(object sender, EventArgs e)
        {

            string email = txtbEmail.Text;


            string temporaryPassword = GenerateTemporaryPassword();


            SendEmail(email, temporaryPassword);


            UpdatePasswordInDatabase(email, temporaryPassword);

            this.Hide();




        }

        private string GenerateTemporaryPassword()
        {


            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] password = new char[8];


            password[0] = characters[random.Next(26)];


            password[1] = characters[random.Next(52, 62)];


            for (int i = 2; i < 8; i++)
            {
                password[i] = characters[random.Next(characters.Length)];
            }

            return new string(password);
        }

        private void SendEmail(string recipient, string password)
        {

            bool emailExists = false;
            string email = txtbEmail.Text;

            using (SqlConnection connection = mojabaza.PolaczZBaza())
            {


                string query = "SELECT COUNT(*) FROM tbl_Użytkownicy WHERE [adresEmail] = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                        emailExists = true;
                }
            }
            if (emailExists == false)
            {
                MessageBox.Show("Użytkownik o podanym adresie email nie istnieje w naszym systemie");
                PrzypomnienieHasła przypomnienieHasła = new PrzypomnienieHasła();
                przypomnienieHasła.Show();
                return;


            }





            string smtpServer = "poczta.interia.pl";
            string smtpUsername = "apkabaza1@interia.pl";
            string smtpPassword = "Apkabaza123#";

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            mail.From = new MailAddress(smtpUsername);
            mail.To.Add(recipient);
            mail.Subject = "Reset hasła";
            mail.Body = "Twoje tymczasowe hasło: " + password;

            smtpClient.Host = "poczta.interia.pl";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
                MessageBox.Show("E-mail z hasłem tymczasowym został wysłany.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wysyłania e-maila: " + ex.Message);
            }



        }

        private void PrzypomnienieHasła_Load(object sender, EventArgs e)
        {

        }
    }
}
