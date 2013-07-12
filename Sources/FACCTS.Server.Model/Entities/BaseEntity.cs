using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public enum ObjectState
    {
        Unchanged = 0x1,
        Added = 0x2,
        Modified = 0x4,
        Deleted = 0x8
    }

    public class BaseEntity 
    {
        public BaseEntity()
        {
            State = ObjectState.Unchanged;
        }

        [Key]
        [Column("Id")]
        public virtual long Id { get; set; }

        [CsvField(Ignore=true)]
        public virtual ObjectState State { get; set; }
    }
}
