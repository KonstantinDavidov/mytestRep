using CsvHelper.Configuration;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class Permission
    {
        [Key]
        [CsvField(Index = 0)]
        public long Id { get; set; }
        [CsvField(Index = 1)]
        public string Name { get; set; }
        [CsvField(Ignore = true)]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
