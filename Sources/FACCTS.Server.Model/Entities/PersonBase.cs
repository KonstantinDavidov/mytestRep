using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public abstract class PersonBase : IEntityWithId, IEntityWithState
    {
        public PersonBase()
        {
            AddressInfo = new AddressInfo();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public FACCTSEntity EntityType { get; set; }

        public Gender Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contact { get; set; }

        public int Age { get; set; }

        public AddressInfo AddressInfo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public long Id { get; set; }

        public ObjectState State { get; set; }
    }
}
