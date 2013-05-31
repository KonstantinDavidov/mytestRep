﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("Interpreters")]
    public partial class Interpreter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual CourtParty InterpreterFor { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contact { get; set; }

        [InverseProperty("Interpreters")]
        public virtual CaseRecord CaseRecord { get; set; }
    }
}