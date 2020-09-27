using System;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString= $@"Data Source = DESKTOP-FKSO33P\SQLEXPRESS; Initial Catalog = DigitalsoftFactory; Persist Security Info = True; user id = sa; password = p10father_25587; MultipleActiveResultSets = True";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                //open the connection 
                cnn.Open();
                // Get Connection details 
                string connectionDetails = GetConnectionProperties(cnn);
                Console.WriteLine(connectionDetails);                
            }
            Console.ReadLine();
        }

        public static string GetConnectionProperties(SqlConnection cnn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Connection String : " + cnn.ConnectionString);
            sb.AppendLine("State : " + cnn.State.ToString());
            sb.AppendLine("Connection TimeOut : " + cnn.ConnectionTimeout);
            sb.AppendLine("DataBase : " + cnn.Database);
            sb.AppendLine("DataSource : " + cnn.DataSource);
            sb.AppendLine("Server Version : " + cnn.ServerVersion);
            sb.AppendLine("WorkStation Id : " + cnn.WorkstationId);
            return sb.ToString();
        }
    }
}
