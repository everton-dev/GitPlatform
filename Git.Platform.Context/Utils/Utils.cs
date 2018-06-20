using Git.Platform.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Context
{
    public static class Utils
    {
        public static void SetProperty(object o, string propertyName, string value)
        {
            PropertyInfo propertyInfo = o.GetType().GetProperty(propertyName);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(o, value, null);
            }
        }

        public static List<PropertyInfo> GetProperties(object o)
        {
            return o.GetType().GetProperties().ToList();
        }

        public static string ReplaceContext(List<GlobalModel> oListGlobal, string value)
        {
            if (value == null) return value;
            if (string.IsNullOrWhiteSpace(value)) return value;

            foreach (GlobalModel oGlobalModel in oListGlobal)
            {
                string token = string.Format("(${0}$)", oGlobalModel.Key);
                if (value.Contains(token))
                    value = value.Replace(token, oGlobalModel.Value);

                if (!value.Contains("($"))
                    break;
            }

            return value;
        }

        public static void ReplaceInstance<T>(List<GlobalModel> oListGlobal, List<T> o)
        {
            foreach (T oInjectionClassModel in o)
            {
                foreach (PropertyInfo oPropertyInfo in Utils.GetProperties(oInjectionClassModel))
                {
                    if (oPropertyInfo.PropertyType == typeof(string))
                    {
                        string value = oPropertyInfo.GetValue(oInjectionClassModel).ToString();
                        Utils.SetProperty(oInjectionClassModel, oPropertyInfo.Name, Utils.ReplaceContext(oListGlobal, value));
                    }
                }
            }
        }
    }
}
