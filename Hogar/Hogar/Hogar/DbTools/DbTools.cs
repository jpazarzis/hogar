using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hogar.DbTools
{
    public static class DbUtilities
    {
        [ThreadStatic] private static SqlConnection _MY_CONNECTION = null;

        private static string _CONN_STG = "Data Source=REBETIIS;Initial Catalog=HorseRacing;Integrated Security=True";

        public static SqlConnection SqlConnection
        {
            get
            {
                if (null == _MY_CONNECTION)
                {
                    try
                    {
                        _MY_CONNECTION = new SqlConnection(ConnectionString);
                        _MY_CONNECTION.Open();
                    }
                    catch
                    {
                        _MY_CONNECTION = null;
                    }
                }

                return _MY_CONNECTION;
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (null != _MY_CONNECTION)
                {
                    _MY_CONNECTION.Close();
                    _MY_CONNECTION = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occured while closing connection to db: " + ex.Message);
            }
        }

        public static string ConnectionString
        {
            get
            { 
                return _CONN_STG; 
            }
            set 
            { 
                _CONN_STG = value; 
            }
        }
    }
}