using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Git.Platform.Context.Models
{
    public class InjectionClassModel
    {
        [XmlElement("Namespace")]
        public string Namespace { get; set; }
        [XmlElement("ClassName")]
        public string ClassName { get; set; }
        [XmlElement("Path")]
        public string Path { get; set; }
        public object Instance { get; set; }
    }
}
