using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Xml.Linq;
using System.Configuration;

namespace CSVToXMLConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
                this.button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string fieldName = ConfigurationManager.AppSettings["csvFieldName"];
            XElement root = new XElement("pdfFields");
            using(var sr = new System.IO.StreamReader(openFileDialog1.FileName))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.Delimiter = ";";
                while (csv.Read())
                {
                    string mapValue = null;
                    
                    csv.TryGetField<string>(fieldName, out mapValue);
                    if (!string.IsNullOrEmpty(mapValue))
                    {
                        var elem = new XElement("pdfField");
                        elem.Add(new XAttribute("originalValue" , mapValue));
                        elem.Add(new XAttribute("mapValue" , mapValue));
                        root.Add(elem); 
                    }
                }
            }
            var saveres = saveFileDialog1.ShowDialog();
            if (saveres == System.Windows.Forms.DialogResult.OK)
            {
                XDocument doc = new XDocument();
                doc.Add(root);
                try
                {
                    doc.Save(saveFileDialog1.FileName);
                    label2.Text = label2.Text + Environment.NewLine +"File " + saveFileDialog1.FileName + " was successfully saved.";
                }
                catch(Exception ex)
                {
                    label2.Text = label2.Text + Environment.NewLine + ex.Message;
                }
            }

        }
    }
}
