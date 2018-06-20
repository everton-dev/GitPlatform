using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Git.Platform.Context.Models
{
    [XmlRoot("Context")]
    public class ContextModel
    {
        [XmlElement("GlobalList")]
        public List<GlobalModel> GlobalList { get; set; }
        [XmlElement("InjectionClassList")]
        public List<InjectionClassModel> InjectionClassList { get; set; }
    }
}
