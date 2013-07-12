using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FACCTS.Server.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class FormField : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [CsvField(Index = 0)]
        public override long Id { get; set; }

        [Column("form_field_name")]
        [CsvField(Index = 1, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(150)]
        public string FormFieldName { get; set; }

        [Column("form_name")]
        [CsvField(Index = 2, Default=null)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(125)]
        public string FormName { get; set; }

        [Column("field_type")]
        [CsvField(Index = 3, Default = null)]
        [StringLength(12)]
        [TypeConverter(typeof(NullStringConverter))]
        public string FieldType { get; set; }

        [Column("screen_name")]
        [CsvField(Index = 4, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(60)]
        public string field_type { get; set; }

        [Column("form_field_id")]
        [CsvField(Index = 5)]
        public int FormFieldId { get; set; }

        [Column("dupe")]
        [StringLength(5)]
        [CsvField(Index = 6, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string Dupe { get; set; }

        [Column("dropdown_options")]
        [TypeConverter(typeof(NullStringConverter))]
        [CsvField(Index = 7, Default = null)]
        [StringLength(160)]
        public string DropdownOptions { get; set; }

        [Column("bool_options")]
        [CsvField(Index = 8, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(64)]
        public string BoolOptions { get; set; }

        [Column("screen_panel")]
        [StringLength(32)]
        [CsvField(Index = 9, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        public string ScreenPanel { get; set; }

        [Column("panel_section")]
        [CsvField(Index = 10, Default = null)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(32)]
        public string PanelSection { get; set; }

        [Column("xml_export")]
        [CsvField(Index = 11, Ignore = true)]
        [StringLength(200)]
        public string XmlExport { get; set; }

        [NotMapped]
        [CsvField(Ignore=true)]
        public override ObjectState State
        {
            get
            {
                return base.State;
            }
            set
            {
                base.State = value;
            }
        }
    }
}
