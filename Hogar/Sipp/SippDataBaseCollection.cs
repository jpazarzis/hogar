using System.Collections.Generic;

namespace Sipp
{
    public class SippDataBaseCollection<T> : List<T> where T : SippIDbPopulatable, new()
    {
        public void Load(string sql)
        {

            using (var dbr = new SippDbReader())
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