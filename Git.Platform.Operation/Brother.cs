using Git.Platform.Operation.Interfaces;
using Git.Platform.Operation.Interfaces.RuleInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Operation
{
    [Serializable]
    public class Brother : IDisposable, IData<Brother>
    {
        #region Encapsulation
        private BrotherDesignation _BrotherDesignation;
        #endregion

        #region Properties
        public int Id { get; set; }
        public int IdBrotherDesignation { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateBaptism { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string UserCreation { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserChange { get; set; }
        public DateTime? DateChange { get; set; }
        #endregion

        #region Relashionship Properties
        public BrotherDesignation BrotherDesignation {
            get
            {
                if (_BrotherDesignation == null)
                    _BrotherDesignation = BrotherDesignation.Return(new BrotherDesignation() { Id = this.IdBrotherDesignation });

                return _BrotherDesignation;
            }
            set
            {
                _BrotherDesignation = value;
            }
        }
        #endregion

        #region Converter Model
        public static explicit operator Brother(Models.BrotherModel o)
        {
            if (o == null)
                return null;

            Brother oOperation = new Brother()
            {
                Id = o.Id,
                IdBrotherDesignation = o.IdBrotherDesignation,
                Name = o.Name,
                DateBirth = o.DateBirth,
                DateBaptism = o.DateBaptism,
                Cpf = o.Cpf,
                Rg = o.Rg,
                UserCreation = o.UserCreation,
                CreationDate = o.CreationDate,
                UserChange = o.UserChange,
                DateChange = o.DateChange
            };

            return oOperation;
        }
        public static explicit operator Models.BrotherModel(Brother o)
        {
            if (o == null)
                return null;

            Models.BrotherModel oModel = new Models.BrotherModel()
            {
                Id = o.Id,
                IdBrotherDesignation = o.IdBrotherDesignation,
                Name = o.Name,
                DateBirth = o.DateBirth,
                DateBaptism = o.DateBaptism,
                Cpf = o.Cpf,
                Rg = o.Rg,
                UserCreation = o.UserCreation,
                CreationDate = o.CreationDate,
                UserChange = o.UserChange,
                DateChange = o.DateChange
            };

            return oModel;
        }
        #endregion

        #region Public Static Methods
        public List<Brother> List(Brother o)
        {
            try
            {
                return new Data.DataBrother().List(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Brother Return(Brother o)
        {
            try
            {
                return new Data.DataBrother().Return(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Insert(Brother o)
        {
            try
            {
                return new Data.DataBrother().Insert(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Update(Brother o)
        {
            try
            {
                return new Data.DataBrother().Update(o);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(Brother o)
        {
            try
            {
                return new Data.DataBrother().Delete(o);
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
