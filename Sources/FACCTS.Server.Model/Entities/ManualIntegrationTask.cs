using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class ManualIntegrationTask
    {
        public int Id { get; set; }

        public DateTime? ReceiveTime { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Info { get; set; }

        public int? UserId { get; set; }

        /// <summary>
        /// User, who placed the order
        /// </summary>
        public User User { get; set; }

        public IntegrationTaskState State { get; set; }
    }
}
