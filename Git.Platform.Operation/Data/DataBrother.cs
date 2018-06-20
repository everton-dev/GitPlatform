using Git.Platform.Operation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Git.Platform.Database;
using Git.Platform.Database.Enums;

namespace Git.Platform.Operation.Data
{
    internal class DataBrother : DatabaseConfiguration, IData<Brother>
    {
        #region Procedures
        private const string PROC_LIST_USER_SYSTEM = "proc_list_user_system";
        private const string PROC_RETURN_USER_SYSTEM = "proc_return_user_system";
        private const string PROC_INSERT_USER_SYSTEM = "proc_insert_user_system";
        private const string PROC_UPDATE_USER_SYSTEM = "proc_update_user_system";
        private const string PROC_DELETE_USER_SYSTEM = "proc_delete_user_system";
        #endregion

        #region Public
        public List<Brother> List(Brother o)
        {
            DataTable dt = null;
            List<Brother> listReturn = new List<Brother>();

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_user_system", o.Id);
                    oData.AddParameter("name", o.Name);
                    //oData.AddParameter("age", o.Age);
                }

                dt = oData.ExecuteToDataTable(PROC_LIST_USER_SYSTEM, EnumExecutionType.StoredProcedure);
                listReturn = (List<Brother>)Utils.ConvertDataTableToList<Brother>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(dt != null)
                    dt.Dispose();
            }

            return listReturn;
        }

        public Brother Return(Brother o)
        {
            DataTable dt = null;
            List<Brother> listReturn = new List<Brother>();
            Brother objReturn = new Brother();

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_user_system", o.Id);
                    oData.AddParameter("name", o.Name);
                    //oData.AddParameter("age", o.Age);

                    dt = oData.ExecuteToDataTable(PROC_RETURN_USER_SYSTEM, EnumExecutionType.StoredProcedure);
                    listReturn = (List<Brother>)Utils.ConvertDataTableToList<Brother>(dt);
                    objReturn = listReturn.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Dispose();
                listReturn = null;
            }

            return objReturn;
        }

        public int Insert(Brother o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("name", o.Name);
                    //oData.AddParameter("age", o.Age);
                    oData.AddParameter("user_creation", o.UserCreation);
                    oData.AddParameter("creation_date", o.CreationDate);

                    dt = oData.ExecuteToDataTable(PROC_INSERT_USER_SYSTEM, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_user_system"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Dispose();
            }

            return returnId;
        }

        public int Update(Brother o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_user_system", o.Id);
                    oData.AddParameter("name", o.Name);
                    //oData.AddParameter("age", o.Age);
                    oData.AddParameter("user_change", o.UserChange);
                    oData.AddParameter("change_date", o.DateChange);

                    dt = oData.ExecuteToDataTable(PROC_UPDATE_USER_SYSTEM, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_user_system"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Dispose();
            }

            return returnId;
        }

        public int Delete(Brother o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_user_system", o.Id);
                    oData.AddParameter("name", o.Name);
                    //oData.AddParameter("age", o.Age);

                    dt = oData.ExecuteToDataTable(PROC_UPDATE_USER_SYSTEM, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_user_system"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Dispose();
            }

            return returnId;
        }
        #endregion
    }
}
