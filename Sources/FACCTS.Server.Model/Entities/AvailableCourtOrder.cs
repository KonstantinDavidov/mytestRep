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
    [Table("AvailableCourtOrder")]
    public partial class AvailableCourtOrder
    {
        [Key]
        [CsvField(Index=0)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [CsvField(Index=1)]
        public string Name { get; set; }

        [StringLength(255)]
        [CsvField(Index=2)]
        [TypeConverter(typeof(NullStringConverter))]
        public string FileName { get; set; }

        [StringLength(15)]
        [CsvField(Index = 3)]
        [TypeConverter(typeof(NullStringConverter))]
        public string Code { get; set; }
       
    }
}
