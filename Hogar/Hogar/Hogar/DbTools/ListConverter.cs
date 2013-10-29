using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Hogar.DbTools
{
    public static class ListConverter<T>
    {
        static public DataSet ConvertToDataSet(List<T> list)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);

            foreach (PropertyInfo pi in t.GetProperties())
            {
               dt.Columns.Add(pi.Name);
            }

            foreach (T item in list)
            {
                object[] obj = new object[t.GetProperties().Length];
                int index = 0;
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    obj[index] = pi.GetValue(item, null);
                    ++index;
                }
                dt.Rows.Add(obj);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
    }
}