using System;
using System.Data.SqlClient;

namespace Hogar.DbTools
{
    sealed public class DbReader : IDisposable
    {
        SqlDataReader _myReader = null;

        public bool Open(string sql)
        {
            Close();
            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.CommandTimeout = 1200;
            _myReader = myCommand.ExecuteReader();
            return HasRows;
        }

        public bool HasRows
        {
            get
            {
                return null != _myReader ? _myReader.HasRows : false;
            }
        }

        public T GetValue<T>(string fieldName)
        {
            return (T)_myReader[fieldName];
        }

        public bool MoveToNextRow()
        {
            return null != _myReader ? _myReader.Read() : false;
        }

        public void Close()
        {
            if (null != _myReader && _myReader.IsClosed == false)
            {
                _myReader.Dispose();
                _myReader = null;
            }
        }

        public void Dispose()
        {
            Close();
        }

        static public void ExecuteNonQuery(string sql)
        {
            var myCommand = new SqlCommand(sql, Hogar.DbTools.DbUtilities.SqlConnection);
            myCommand.ExecuteNonQuery();
        }
    }    
}
