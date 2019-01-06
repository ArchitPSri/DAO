using System;
using DBConnection;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entities;

namespace DAO
{
    public class SendData
    {
        public SendData()
        { }

        public string CallDBToSend(DBConnectionTesting data)
        {
            try
            {
                DBConnectionClass dBConnection = new DBConnectionClass
                {
                    DatabaseName = "TestDB"
                };

                string Col_FirstName = data.FirstName;
                string Col_LastName = data.LastName;

                if (dBConnection.IsConnect())
                {
                    string query = "INSERT INTO TestTable (Column1,Column2) values (@Col_FirstName , @Col_LastName)";
                    var cmd = new SqlCommand(query, dBConnection.Connection);
                    cmd.Parameters.AddWithValue("@Col_FirstName", Col_FirstName);
                    cmd.Parameters.AddWithValue("@Col_LastName", Col_LastName);
                    string value = cmd.ExecuteNonQuery().ToString();
                    
                    dBConnection.Close();
                    return value;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Conn Failed");
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Unsuccessful Query Excution");
                throw e;
            }
        }
    }
}
