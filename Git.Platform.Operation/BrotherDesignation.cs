using Git.Platform.Operation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Operation
{
    [Serializable]
    public class BrotherDesignation : IDisposable, IData<BrotherDesignation>
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserCreation { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserChange { get; set; }
        public DateTime? DateChange { get; set; }
        #endregion

        #region Converter Model
        public static explicit operator Models.BrotherDesignationModel(BrotherDesignation o)
        {
            if (o == null)
                return null;

            Models.BrotherDesignationModel oModel = new Models.BrotherDesignationModel()
            {
                Id = o.Id,
                Description = o.Description,
                UserCreation = o.UserCreation,
                CreationDate = o.CreationDate,
                UserChange = o.UserChange,
                DateChange = o.DateChange
            };

            return oModel;
        }
        public static explicit operator BrotherDesignation(Models.BrotherDesignationModel o)
        {
            if (o == null)
                return null;

            BrotherDesignation oOperation = new BrotherDesignation()
            {
                Id = o.Id,
                Description = o.Description,
                UserCreation = o.UserCreation,
                CreationDate = o.CreationDate,
                UserChange = o.UserChange,
                DateChange = o.DateChange
            };

            return oOperation;
        }
        #endregion

        #region Public Static Methods
        public List<BrotherDesignation> List(BrotherDesignation o)
        {
            try
            {
                return new Data.DataBrotherDesignation().List(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BrotherDesignation Return(BrotherDesignation o)
        {
            try
            {
                return new Data.DataBrotherDesignation().Return(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Insert(BrotherDesignation o)
        {
            try
            {
                return new Data.DataBrotherDesignation().Insert(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Update(BrotherDesignation o)
        {
            try
            {
                return new Data.DataBrotherDesignation().Update(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(BrotherDesignation o)
        {
            try
            {
                return new Data.DataBrotherDesignation().Delete(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region IDisposable Support
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
