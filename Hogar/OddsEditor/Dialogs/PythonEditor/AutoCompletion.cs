using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Scripting.Hosting;
using Hogar;
using Hogar.BrisPastPerformances;

namespace OddsEditor.Dialogs.PythonEditor
{
    static class AutoCompletion
    {

        static private bool GetProperties(Type type, List<string> methodPath, List<string> properties)
        {
            if (null == type)
                return false;

            if (methodPath.Count == 0)
            {
                properties.Clear();
                properties.AddRange(type.GetProperties().Select(pro2 => pro2.Name));
                return true;
            }

            foreach (PropertyInfo prop in type.GetProperties())
            {
                Trace.WriteLine(prop.PropertyType.Name);
                if (prop.Name == methodPath[0])
                {
                    methodPath.RemoveAt(0);
                    return GetProperties(prop.PropertyType, methodPath, properties);
                }
            }

            properties.Clear();
            return false;


        }

        static public bool GetProperties(ScriptScope scriptScope, string method, List<string> properties)
        {
            properties.Clear();


            var m = method.Split('.').ToList();

            if (m.Count() <= 0)
                return false;

            //var s = scriptScope.GetVariable<object>(m[0]);

            var s = scriptScope.GetVariable(m[0]);

            if (null == s)
                return false;

            m.RemoveAt(0);

            return GetProperties(s.GetType(), m, properties);

        }
    }
}
