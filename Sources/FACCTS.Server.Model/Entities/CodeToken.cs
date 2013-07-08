using System;
using System.ComponentModel.DataAnnotations;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CodeToken
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }

        public long ClientId { get; set; }

        public string UserName { get; set; }

        public string Scope { get; set; }

        public int Type { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
