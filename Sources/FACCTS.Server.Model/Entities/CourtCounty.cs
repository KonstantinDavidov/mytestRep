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
    public class CourtCounty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [CsvField(Index = 0)]
        public int Id { get; set; }

        [Column("court_code")]
        [CsvField(Index = 1)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(8)]
        public string CourtCode { get; set; }

        [Column("county")]
        [CsvField(Index = 2)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(64)]
        public string County { get; set; }

        [Column("court_name")]
        [CsvField(Index = 3)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(50)]
        public string CourtName { get; set; }

        [Column("location")]
        [CsvField(Index = 4)]
        [TypeConverter(typeof(NullStringConverter))]
        [StringLength(64)]
        public string Location { get; set; }
    }
}
