using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class DataItem
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public string Description;
    }
}
