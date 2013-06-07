using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{

    public partial class CourtCaseStatus
    {
        public CourtCaseStatus()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [CsvField(Index=0)]
        public int Id { get; set; }
        [Required]
        [CsvField(Index = 1)]
        [StringLength(100)]
        public string CaseStatus { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            CourtCaseStatus cs = (CourtCaseStatus)obj;
            if (Id != cs.Id)
                return false;

            if (CaseStatus != cs.CaseStatus)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Id ^ CaseStatus.GetHashCode();

        }
    }
}
