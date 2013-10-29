using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sipp
{
    public static class SippDbUtilities
    {
        [ThreadStatic]
        private static SqlConnection _MY_CONNECTION = null;

        private static string _CONN_STG = "Data Source=s05.winhost.com;Initial Catalog=DB_28661_sipp;User ID=DB_28661_sipp_user;Password=nestor";

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
            if (null != _MY_CONNECTION)
            {
                _MY_CONNECTION.Close();
                _MY_CONNECTION = null;
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
