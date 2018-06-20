using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Models
{
    public class BrotherModel
    {
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
    }
}
