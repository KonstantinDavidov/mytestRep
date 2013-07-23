using org.pdfclown.documents.interaction.forms;
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
        public const string BooleanTrueString = "1";
        public static Dictionary<string, string> SerializeXMLToDictionary(string pathToXml, string attr1Name, string attr2Name)
        {
            XDocument doc;
            try
            {
                doc = XDocument.Load(pathToXml);
            }
            catch(Exception ex)
            {
                //todo
                throw ex;
            }
            return ParseXML(doc, attr1Name, attr2Name);
            
        }

        public static Dictionary<string, string> SerializeXMLToDictionary(XDocument doc, string attr1Name, string attr2Name)
        {
            return ParseXML(doc, attr1Name, attr2Name); ;
        }

        private static Dictionary<string, string> ParseXML(XDocument doc, string attr1Name, string attr2Name)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (XElement elm in doc.Root.Elements())
            {
                string dictKey = elm.Attribute(attr1Name).Value;
                string dictVal = elm.Attribute(attr2Name).Value;
                if ((!string.IsNullOrEmpty(dictKey) || dictKey.CompareTo("NULL") != 0) && !dict.ContainsKey(dictKey))
                {
                    dict.Add(dictKey, dictVal);
                }
            }
            return dict;
        }

        public static void SetPdfField(Form pdfForm, Dictionary<string, string> mapper, string key, string value)
        {
            if (value != null)
            {
                pdfForm.Fields[mapper[key]].Value = value;
            }
        }
        public static void SetPdfField(Form pdfForm, Dictionary<string, string> mapper, string key, bool value = true)
        {
            pdfForm.Fields[mapper[key]].Value = value ? BooleanTrueString : null;
        }
        public static void SetPdfField(Form pdfForm, Dictionary<string, string> mapper, string key, bool? value)
        {
            if(value.HasValue)
            {
                pdfForm.Fields[mapper[key]].Value = value.Value ? BooleanTrueString : null;
            }
        }


        public static string ToOrderDate(this DateTime date)
        {
            return date.ToShortDateString();
        }

        public static bool IsAM(this DateTime date)
        {
            return date.TimeOfDay.Hours < 12;
        }
        public static bool IsPM(this DateTime date)
        {
            return date.TimeOfDay.Hours >= 12;
        }
        public static bool IsMidnight(this DateTime date)
        {
            return date.TimeOfDay.Ticks == 0;
        }
        public static string ToOrderTime(this DateTime date)
        {
            return date.ToShortTimeString();
        }

    }
}
