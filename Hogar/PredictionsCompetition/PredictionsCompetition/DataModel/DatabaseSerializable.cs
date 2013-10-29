using System;
using System.Reflection;
using System.Text;

namespace PredictionsCompetition.DataModel
{
    public abstract class  DatabaseSerializable
    {
        public static string LoadFromDb(Type t)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ");
            int count = 0;
            foreach (PropertyInfo property in t.GetProperties())
            {
                if(count++ > 0)
                {
                    sb.Append(",");
                }

                sb.Append(property.Name);

            }
            sb.Append(" FROM ");
            sb.Append(t.Name);
            return sb.ToString();

        }

        public void InsertToDb()
        {
            
        }

        public void DeleteFromDb()
        {
            
        }

        public void UpdateDb()
        {
            
        }

        public int Id { get; protected set; }

    }
}