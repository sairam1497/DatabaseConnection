using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string connectionString = $@"Data Source = DESKTOP-FKSO33P\SQLEXPRESS; Initial Catalog = DigitalsoftFactory; Persist Security Info = True; user id = sa; password = p10father_25587; MultipleActiveResultSets = True";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                   // string query = "select  value from RegCfg where App= @App and Id like @Id";
                    string query = "Insert Into RegCfg  values (@App,@Id,@Value,@Reload)";
                    //string query = $@"update RegCfg 
                    //                    set Value = 101
                    //                    where App='WIP' and Id like 'CP0%' and value = 100";
                    //string query = "Delete  RegCfg where App='WIP' and Id like 'CP0%' and value = 100";
                    using (SqlCommand cmd = new SqlCommand(query,cnn))
                    {
                      cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@App","WIP"));
                        cmd.Parameters.Add(new SqlParameter("@Id", "CP03"));
                        cmd.Parameters.Add(new SqlParameter("@Value","200"));
                        cmd.Parameters.Add(new SqlParameter("@Reload","0"));

                        cnn.Open();
                      int RowsAffected = (int)cmd.ExecuteNonQuery();
                        Console.WriteLine(RowsAffected);
                    }
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally{
                Console.ReadLine();
            }
            
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
