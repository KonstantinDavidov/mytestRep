using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FACCTS.Server.Model.OrderModels
{
    public class DataItem : IDataItem
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
    }
}
