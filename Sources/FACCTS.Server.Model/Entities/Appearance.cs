using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [ComplexType]
    public partial class Appearance
    {

        public bool? Party1Appear { get; set; }

        public bool? Party1Sworn { get; set; }

        public bool? Party1AttorneyPresent { get; set; }

        public bool? Party1Atty { get; set; }

        public bool? Party2Appear { get; set; }

        public bool? Party2Sworn { get; set; }

        public bool? Party2AttorneyPresent { get; set; }

        public bool? Party2Atty { get; set; }

    }
}
