using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtCaseOrders")]
    public partial class CourtCaseOrder : BaseEntity
    {
        public CourtCaseOrder()
        {
            IsSigned = false;
        }

        public int AvailableCourtOrderId { get; set; }

        public MasterOrders OrderType { get; set; }

        public virtual ICollection<AttachmentOrders> AttachmentOrders { get; set; }

        public virtual ICollection<OverrunOrders> OverrunOrders { get; set; }


        [Column(TypeName = "xml")]
        public string XMLContent { get; set; }

        [NotMapped]
        public XElement Content
        {
            get
            {
                return XElement.Parse(XMLContent);
            }
            set
            {
                XMLContent = value.ToString();
            }
        }

        public bool IsSigned { get; set; }

        [StringLength(255)]
        public string ServerFileName { get; set; }

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
