using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public class Race : IEntityWithState
    {
        [CsvField(Index = 0)]
        public long Id { get; set; }

        [CsvField(Index = 1)]
        [StringLength(150)]
        public string RaceName { get; set; }

        [CsvField(Ignore = true)]
        public ObjectState State { get; set; }
    }
}
