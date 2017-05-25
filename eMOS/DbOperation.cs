using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace eMOS
{
    public class DbOperation
    {
        public void StoreSnap()
        {
            ExecuteProcedure("dbo.StoreDbSnapShot");
        }


        public void ReStoreSnap()
        {
            ExecuteProcedure("dbo.RestoreDbSnapShot");
        }

        

        private void ExecuteProcedure(string procedureName)
        {
            // var connectionString = "Data Source=172.16.0.233\\MSSQLSERVER,1433;Initial Catalog=master;user id=sa; password=J@ntrik007#";

            var connectionString = ConfigurationManager.ConnectionStrings["Dashboard"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
