using Git.Platform.Database.Base;
using Git.Platform.Database.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Database.Databases
{
    public class DatabaseMySQL : DatabaseBase
    {

        private MySqlConnection oConnection { get; set; }
        private MySqlCommand oCommand { get; set; }
        private MySqlDataAdapter oAdapter { get; set; }

        public DatabaseMySQL(string sConnectionString)
        {
            this.oConnection = new MySqlConnection(sConnectionString);
            this.oCommand = new MySqlCommand(string.Empty, oConnection);
        }

        public override bool AddParameter(string parameterName, object value)
        {
            this.oCommand.Parameters.Add(new MySqlParameter(parameterName, value));

            return true;
        }

        public override bool Close()
        {
            if (this.oCommand.Connection.State.Equals(ConnectionState.Open))
            {
                this.oCommand.Connection.Close();
            }

            return true;
        }

        public override int Execute(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();
                return this.oCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override DataSet ExecuteToDataSet(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();

                this.oAdapter = new MySqlDataAdapter(this.oCommand);
                this.oDataSetReturn = new DataSet();

                this.oAdapter.Fill(this.oDataSetReturn);

                return this.oDataSetReturn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override DataTable ExecuteToDataTable(string sComando, EnumExecutionType execution)
        {
            this.oCommand.CommandText = sComando;
            this.oCommand.CommandType = this.ConvertToCommandType(execution);

            try
            {
                this.Open();

                this.oAdapter = new MySqlDataAdapter(this.oCommand);
                this.oTableReturn = new DataTable();

                this.oAdapter.Fill(this.oTableReturn);

                return this.oTableReturn;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Close();
            }
        }

        public override bool Open()
        {
            if (!this.oCommand.Connection.State.Equals(ConnectionState.Open))
            {
                this.oCommand.Connection.Open();
            }

            return true;
        }

        public override void ClearParameters()
        {
            if (this.oCommand != null)
            {
                if (this.oCommand.Parameters != null)
                {
                    this.oCommand.Parameters.Clear();
                }
            }
        }
    }
}
