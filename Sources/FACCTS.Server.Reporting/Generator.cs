using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using org.pdfclown;
using org.pdfclown.documents;
using org.pdfclown.documents.interaction.forms;
using FACCTS.Server.DataContracts;
using System.ComponentModel.Composition;
using FACCTS.Server.Common;

namespace FACCTS.Server.Reporting
{
    public abstract class Generator
    {
        public IDataManager DataManager
        {
            get;
            set;
        }
       
        public Byte[] Run(string pathToPdf, Dictionary<string, string> mapper, object data)
        {
            org.pdfclown.files.File file = new org.pdfclown.files.File(pathToPdf);
            Document document = file.Document;

            Form form = document.Form;
            if (form.Exists())
            {
                FillForm(form, mapper, data);
            }

            return Serialize(file);
        }

        protected abstract void FillForm(Form form, Dictionary<string, string> mapper, object data);

        protected Byte[] Serialize(org.pdfclown.files.File pdfFile)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                org.pdfclown.bytes.Stream pdfstream = new org.pdfclown.bytes.Stream(stream);
                pdfFile.Save(pdfstream, org.pdfclown.files.SerializationModeEnum.Incremental);
                return pdfstream.ToByteArray();
            }
        }
        
    }
}
