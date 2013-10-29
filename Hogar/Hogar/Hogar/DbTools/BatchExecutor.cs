using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Hogar.DbTools;

namespace Hogar.DbTools
{
    public static class BatchExecutor
    {
        static string _sqlBatch = "";
        static int _count=0;

        static int MAX_BATCH_SIZE = 30;


        static public void AddToBatch(string sql)
        {
            if (_sqlBatch.Length > 0)
            {
                _sqlBatch += "; ";
            }
            _sqlBatch += sql;
            ++_count;
            if (_count >= MAX_BATCH_SIZE)
            {
                ExecuteBatch();
            }
        }

        static public void ExecuteBatch()
        {
            if (_sqlBatch.Length > 0)
            {
                SqlCommand myCommand = new SqlCommand(_sqlBatch, Hogar.DbTools.DbUtilities.SqlConnection);
                myCommand.ExecuteNonQuery();
                _sqlBatch = "";
                _count = 0;
            }
        }
    }
}
