using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using FACCTS.Server.DataContracts;
using System.ComponentModel.Composition;
using FACCTS.Server.Common;

namespace FACCTS.Server.Reporting
{
    public static class OrderGenerator
    {
        public static Byte[] GenerateOrder(object orderData, IDataManager dm, string pathToPdfTemplate, string pathToXmlMapper)
        {
            Byte[] res = null;

            string orderModelTypeName = string.Empty;
            string orderModelTypeAssemblyName = string.Empty;
            string handlerTypeName = string.Empty;
            string handlerTypeAssemblyName = string.Empty;

            XDocument doc = null;
            try
            {
                doc = XDocument.Load(pathToXmlMapper);
                XElement root = doc.Root;
                var temp = root.Attribute("orderModelTypeName").Value;
                orderModelTypeName = temp.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)[0] ;
                orderModelTypeAssemblyName = temp.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                temp = root.Attribute("orderModelHandlerTypeName").Value;
                handlerTypeName = temp.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                handlerTypeAssemblyName = temp.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            catch (Exception ex)
            {
                //todo
                throw ex;
            }

            Dictionary<string, string> mapping = Utils.SerializeXMLToDictionary(doc, "mapValue", "originalValue");
            
            Type handlerType = Type.GetType(handlerTypeName);
            if (handlerType != null)
            {
                Generator generator = (Generator)Activator.CreateInstance(handlerType);
                if (generator != null)
                {
                    generator.DataManager = dm;
                    res = generator.Run(pathToPdfTemplate, mapping, orderData);
                }
            }
            return res;
        }
    }
}
