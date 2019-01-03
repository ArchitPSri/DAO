using System;
using DBConnection;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entities;

namespace DAO
{
    public class GetData
    {
        public GetData()
        { }

        public List<DBConnectionTesting> CallDB()
        {
            List<DBConnectionTesting> data = new List<DBConnectionTesting>();
            
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
                    SqlDataAdapter reader = new SqlDataAdapter(cmd);
                    if (reader != null)
                    {
                        DataTable dt = new DataTable();
                        reader.Fill(dt);
                        
                        foreach (DataRow person in dt.Rows)
                        {
                            DBConnectionTesting d = new DBConnectionTesting();
                            d.FirstName = (string)person["Column1"];
                            d.LastName = (string)person["Column2"];
                            data.Add(d);
                        }
                        return data;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Empty Reader");
                        
                    }
                    dBConnection.Close();
                    return null;
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
