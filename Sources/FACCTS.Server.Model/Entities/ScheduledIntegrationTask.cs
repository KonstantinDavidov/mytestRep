using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class ScheduledIntegrationTask : BaseEntity
    {

        public DateTime StartTime { get; set; }

        public IntegrationTaskRepeatPeriod RepeatPeriod { get; set; }

        public string Info { get; set; }

        public long? UserId { get; set; }

        /// <summary>
        /// User, who placed the order
        /// </summary>
        public User User { get; set; }

        public bool Enabled { get; set; }

        public IntegrationTaskState TaskState { get; set; }
    }
}
