using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Git.Platform.Context.Models
{
    public class GlobalModel
    {
        [XmlAttribute("Key")]
        public string Key { get; set; }
        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
