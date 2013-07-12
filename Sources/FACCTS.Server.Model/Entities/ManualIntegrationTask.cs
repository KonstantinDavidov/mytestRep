using FACCTS.Server.Model.Entities;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class ManualIntegrationTask : BaseEntity
    {

        public DateTime? ReceiveTime { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Info { get; set; }

        public long? UserId { get; set; }

        /// <summary>
        /// User, who placed the order
        /// </summary>
        public User User { get; set; }

        public IntegrationTaskState TaskState { get; set; }

        [NotMapped]
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
