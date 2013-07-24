using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class AddressInfo
    {
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public USAState USAState { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }
    }
}
