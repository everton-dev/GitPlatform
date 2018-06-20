using Git.Platform.Database;
using Git.Platform.Database.Enums;
using Git.Platform.Operation.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Operation.Data
{
    internal class DataBrotherDesignation : DatabaseConfiguration, IData<BrotherDesignation>
    {
        #region Procedures
        private const string PROC_LIST_BROTHER_DESIGNATION = "proc_list_brother_designation";
        private const string PROC_RETURN_BROTHER_DESIGNATION = "proc_return_brother_designation";
        private const string PROC_INSERT_BROTHER_DESIGNATION = "proc_insert_brother_designation";
        private const string PROC_UPDATE_BROTHER_DESIGNATION = "proc_update_brother_designation";
        private const string PROC_DELETE_BROTHER_DESIGNATION = "proc_delete_brother_designation";
        #endregion

        #region Public
        public List<BrotherDesignation> List(BrotherDesignation o)
        {
            DataTable dt = null;
            List<BrotherDesignation> listReturn = new List<BrotherDesignation>();

            try
            {
                dt = oData.ExecuteToDataTable(PROC_LIST_BROTHER_DESIGNATION, EnumExecutionType.StoredProcedure);
                listReturn = (List<BrotherDesignation>)Utils.ConvertDataTableToList<BrotherDesignation>(dt);
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

            return listReturn;
        }

        public BrotherDesignation Return(BrotherDesignation o)
        {
            DataTable dt = null;
            List<BrotherDesignation> listReturn = new List<BrotherDesignation>();
            BrotherDesignation objReturn = new BrotherDesignation();

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_brother_designation", o.Id);

                    dt = oData.ExecuteToDataTable(PROC_RETURN_BROTHER_DESIGNATION, EnumExecutionType.StoredProcedure);
                    listReturn = (List<BrotherDesignation>)Utils.ConvertDataTableToList<BrotherDesignation>(dt);
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

        public int Insert(BrotherDesignation o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("description", o.Description);
                    oData.AddParameter("user_creation", o.UserCreation);
                    oData.AddParameter("creation_date", o.CreationDate);

                    dt = oData.ExecuteToDataTable(PROC_INSERT_BROTHER_DESIGNATION, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_brother_designation"];
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

        public int Update(BrotherDesignation o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_brother_designation", o.Id);
                    oData.AddParameter("description", o.Description);
                    oData.AddParameter("user_change", o.UserChange);
                    oData.AddParameter("change_date", o.DateChange);

                    dt = oData.ExecuteToDataTable(PROC_UPDATE_BROTHER_DESIGNATION, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_brother_designation"];
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

        public int Delete(BrotherDesignation o)
        {
            DataTable dt = null;
            int returnId = 0;

            try
            {
                if (o != null)
                {
                    oData.AddParameter("id_brother_designation", o.Id);

                    dt = oData.ExecuteToDataTable(PROC_UPDATE_BROTHER_DESIGNATION, EnumExecutionType.StoredProcedure);
                    if (dt.Rows.Count > 0)
                        returnId = (int)dt.Rows[0]["id_brother_designation"];
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
