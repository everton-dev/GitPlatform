using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Models
{
    public class BrotherDesignationModel
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserCreation { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserChange { get; set; }
        public DateTime? DateChange { get; set; }
        #endregion
    }
}
