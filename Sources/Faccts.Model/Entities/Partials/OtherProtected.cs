using Faccts.Model.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class OtherProtected
    {

        public override string this[string propertyName]
        {
            get
            {
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requierdFields, _errors, propertyName);
            }
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public override IList<string> Errors
        {
            get
            {
                return _errors.Values.ToList().AsReadOnly();
            }
        }

        private static Dictionary<string, string> _requierdFields = new Dictionary<string, string>()
        {
            {"EntityType", "Entity Type"},
            {"FirstName", "First Name"},
            {"LastName", "Last Name"},
            {"Sex", "Sex"},
            {"RelationshipToProtected", "Relationship To Protected"},
            {"DateOfBirth", "Date Of Birth"},
        };
    }
}
