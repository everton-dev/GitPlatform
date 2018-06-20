using Git.Platform.Database.Enums;
using Git.Platform.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Database.Base
{
    public abstract class DatabaseBase : IDatabase
    {
        public DataTable oTableReturn { get; set; }
        public DataSet oDataSetReturn { get; set; }
        public bool IsSuccess { get; set; }
        public int RowAffecteds { get; set; }
        public abstract bool AddParameter(string parameterName, object value);
        public abstract bool Close();
        public abstract int Execute(string sComando, EnumExecutionType execution);
        public abstract DataSet ExecuteToDataSet(string sComando, EnumExecutionType execution);
        public abstract DataTable ExecuteToDataTable(string sComando, EnumExecutionType execution);
        public abstract bool Open();
        public abstract void ClearParameters();
        protected CommandType ConvertToCommandType(EnumExecutionType execution)
        {
            if (execution == EnumExecutionType.Text)
                return CommandType.Text;
            else if (execution == EnumExecutionType.StoredProcedure)
                return CommandType.StoredProcedure;
            else if (execution == EnumExecutionType.TableDirect)
                return CommandType.TableDirect;
            else
                return CommandType.Text;
        }
    }
}
