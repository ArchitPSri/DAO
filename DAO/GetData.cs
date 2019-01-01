using System;
using DBConnection;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class GetData
    {
        public GetData()
        { }

        public void CallDB()
        {
            try
            {
                DBConnectionClass dBConnection = new DBConnectionClass
                {
                    DatabaseName = "TestDB"
                };

                if (dBConnection.IsConnect())
                {

                    string query = "SELECT * FROM TestTable";
                    var cmd = new SqlCommand(query, dBConnection.Connection);
                    var reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            string someStringFromColumnZero = reader.GetString(0);
                            string someStringFromColumnOne = reader.GetString(1);
                            System.Diagnostics.Debug.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Empty reader");
                    }
                    dBConnection.Close();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Conn failed");
                    Console.WriteLine("Conn failed");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                System.Diagnostics.Debug.WriteLine("CATCH -> CallDB");
                throw e;
            }
        }
    }
}
