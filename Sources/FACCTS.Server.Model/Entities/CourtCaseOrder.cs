﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtCaseOrders")]
    public partial class CourtCaseOrder
    {
        public CourtCaseOrder()
        {
            IsSigned = false;
        }

        [Key]
        public int Id { get; set; }

        public int CourtCaseId { get; set; }

        public CourtCase CourtCase { get; set; }

        public int AvailableCourtOrderId { get; set; }

        public AvailableCourtOrder AvailableCourtOrder { get; set; }

        [Column(TypeName="xml")]
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
    }

    
}