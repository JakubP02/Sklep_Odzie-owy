using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Odzieżowy.Klasy
{
    internal class Baza
    {

        private string connectionString;
        public Baza()
        {

            connectionString = "Data Source=localhost;Initial Catalog=Sklep_Odzieżowy;Integrated Security=True;";
        }


        public SqlConnection PolaczZBaza()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd podczas łączenia z bazą danych: " + ex.Message);
                return null;
            }
        }


     
    }




}










