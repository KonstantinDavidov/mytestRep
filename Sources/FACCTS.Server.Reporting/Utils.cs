using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FACCTS.Server.Reporting
{
    public static class Utils
    {
        public static Dictionary<string, string> SerializeXMLToDictionary(string pathToXml, string attr1, string attr2)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                XDocument doc = XDocument.Load(pathToXml);

                foreach (XElement elm in doc.Root.Elements())
                {
                    string dictKey = elm.Attribute(attr1).Value;
                    string dictVal = elm.Attribute(attr2).Value;
                    dict.Add(dictKey, dictVal);

                }
            }
            catch(Exception ex)
            {
                //todo
            }
            return dict;
        }
    }
}
