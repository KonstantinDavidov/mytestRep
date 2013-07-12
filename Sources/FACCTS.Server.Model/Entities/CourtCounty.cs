using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FACCTS.Server.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtCounty : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [CsvField(Index = 0)]
        public override long Id { get; set; }

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

        [CsvField(Ignore=true)]
        [InverseProperty("CourtCounty")]
        public virtual ICollection<CourtLocation> CourtLocations { get; set; }


        [CsvField(Ignore = true)]
        [InverseProperty("CourtCounty")]
        [JsonProperty(ItemReferenceLoopHandling = ReferenceLoopHandling.Serialize)]
        public virtual ICollection<CourtDepartment> Departments
        {
            get;
            set;
        }

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
