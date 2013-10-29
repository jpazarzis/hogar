using System.Collections.Generic;

namespace Hogar.DbTools
{
    public class DataBaseCollection<T> : List<T> where T : IDbPopulatable, new()
    {
        public void Load(string sql)
        {
            
            using (var dbr = new DbReader())
            {
                if (dbr.Open(sql))
                {
                    while (dbr.MoveToNextRow())
                    {
                        var t = new T();
                        t.Populate(dbr);
                        Add(t);
                    }
                }
            }
        }
    }
}