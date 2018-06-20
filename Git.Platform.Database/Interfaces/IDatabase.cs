using Git.Platform.Database.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Database.Interfaces
{
    public interface IDatabase
    {
        /// <summary>
        /// Add parameter to execute a procedure or whenever a query statment.
        /// </summary>
        /// <param name="parameterName">Parameter's Name.</param>
        /// <param name="value">Value of the Parameter.</param>
        /// <returns></returns>
        bool AddParameter(string parameterName, object value);
        /// <summary>
        /// Open a Connection.
        /// </summary>
        /// <returns></returns>
        bool Open();
        /// <summary>
        /// Close a Connection.
        /// </summary>
        /// <returns></returns>
        bool Close();
        /// <summary>
        /// Execute a query and return a DataTable.
        /// </summary>
        /// <param name="sComando">Query String of the commmand.</param>
        /// <param name="execution">Execution type.</param>
        /// <returns></returns>
        DataTable ExecuteToDataTable(string sComando, EnumExecutionType execution);
        /// <summary>
        /// Execute a query and return a DataSet.
        /// </summary>
        /// <param name="sComando">Query String of the commmand.</param>
        /// <param name="execution">Execution type.</param>
        /// <returns></returns>
        DataSet ExecuteToDataSet(string sComando, EnumExecutionType execution);
        /// <summary>
        /// Execute a query and return the row affecteds.
        /// </summary>
        /// <param name="sComando">Query String of the commmand.</param>
        /// <param name="execution">Execution type.</param>
        /// <returns></returns>
        int Execute(string sComando, EnumExecutionType execution);
        /// <summary>
        /// Clear all paramters.
        /// </summary>
        void ClearParameters();
    }
}
