using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class FormField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [CsvField(Index = 0)]
        public int Id { get; set; }

        [Column("form_field_name")]
        [CsvField(Index = 1, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string FormFieldName { get; set; }

        [Column("form_name")]
        [CsvField(Index = 2, Default=null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string FormName { get; set; }

        [Column("field_type")]
        [CsvField(Index = 3, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string FieldType { get; set; }

        [Column("screen_name")]
        [CsvField(Index = 4, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string field_type { get; set; }

        [Column("form_field_id")]
        [CsvField(Index = 5)]
        public int FormFieldId { get; set; }

        [Column("dupe")]
        [CsvField(Index = 6, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string Dupe { get; set; }

        [Column("dropdown_options")]
        [TypeConverter(typeof(NullStringConverter))]
        [CsvField(Index = 7, Default = null)]
        public string DropdownOptions { get; set; }

        [Column("bool_options")]
        [CsvField(Index = 8, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string BoolOptions { get; set; }

        [Column("screen_panel")]
        [CsvField(Index = 9, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string ScreenPanel { get; set; }

        [Column("panel_section")]
        [CsvField(Index = 10, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string PanelSection { get; set; }

        [Column("xml_export")]
        [CsvField(Index = 11, Ignore = true)]
        public string XmlExport { get; set; }
    }
}
