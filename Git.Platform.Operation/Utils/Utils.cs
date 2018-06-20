using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Git.Platform.Operation
{
    public static class Utils
    {
        public static string GetConfig(string sKey)
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                string sReturn = appSettings[sKey];

                if (string.IsNullOrEmpty(sReturn))
                    sReturn = string.Empty;

                return sReturn;
            }
            catch (ConfigurationErrorsException e)
            {
                return string.Empty;
            }
        }
        public static IList<T> ConvertDataTableToList<T>(DataTable oTable)
        {
            if (oTable == null)
                return null;

            return ConvertDataRowToList<T>(oTable.AsEnumerable().ToArray());
        }
        public static IList<T> ConvertDataRowToList<T>(IList<DataRow> oLines)
        {
            IList<T> oList = null;

            try
            {
                if (oLines != null)
                {
                    oList = new List<T>();
                    foreach (DataRow oLine in oLines)
                        oList.Add(CreateItem<T>(oLine));
                }

                return oList;
            }
            catch
            {
                throw;
            }
            finally
            {
                oList = null;
            }
        }
        public static T CreateItem<T>(DataRow oRow)
        {
            string sColumnName;
            string sPropertyName;
            T oObject = default(T);
            PropertyInfo oProp;
            Object oValue;
            Regex sRegex;
            string sColumnNamePK;

            if (oRow != null)
            {
                oObject = Activator.CreateInstance<T>();

                foreach (DataColumn column in oRow.Table.Columns)
                {
                    sColumnName = column.ColumnName.ToLower();

                    //Verifica se é a coluna (PK) neste caso coloca o nome padrão da propriedade para id
                    sRegex = new Regex("(?<=[A-Z])(?=[A-Z][a-z]) |"
                                        + "(?<=[^A-Z])(?=[A-Z]) |"
                                        + "(?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

                    //Se o nome da coluna do datarow for igual a coluna pk, então deve salvar na propriedade Id
                    sColumnNamePK = "id_" + sRegex.Replace(oObject.GetType().Name, " ").Replace(" ", "_").ToLower();

                    sRegex = null;

                    if (sColumnName.Equals(sColumnNamePK))
                    {
                        sPropertyName = "Id";
                    }
                    else
                    {
                        //Se não monta o nome padrão
                        sPropertyName = Strings.StrConv(column.ColumnName.Replace("_", " "), VbStrConv.ProperCase).Replace(" ", "");

                        //Pega a propriedade com a mesma coluna
                        oProp = oObject.GetType().GetProperty(sPropertyName);
                        if (oProp != null)
                        {
                            try
                            {
                                oValue = null;

                                //Pega o valor da coluna
                                oValue = oRow[sColumnName].GetType() == typeof(DBNull) ? null : oRow[sColumnName];

                                if (oProp.PropertyType.Name.Equals("HybridDictionary"))
                                {
                                    HybridDictionary oDic = new HybridDictionary();
                                    foreach (string sValue in oValue.ToString().Split('|'))
                                        oDic.Add(sValue.Split(':')[0], sValue.Split(':')[1]);

                                    oProp.SetValue(oObject, oDic, null);
                                }
                                else
                                {
                                    oProp.SetValue(oObject, oValue, null);
                                }

                            }
                            catch
                            {
                                throw;
                            }
                        }

                        oProp = null;
                    }
                }
            }

            return oObject;
        }
    }
}
