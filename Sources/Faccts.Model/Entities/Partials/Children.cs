using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel;

namespace Faccts.Model.Entities
{
    public partial class Children
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.EntityType, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("EntityTypeName");
                }
                );
            this.WhenAny(x => x.RelationshipToProtected, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("RelationshipName");
                    this.OnPropertyChanged("RelationshipToProtectedEnum");
                });

            this.EntityType = (int)FACCTS.Server.Model.Enums.FACCTSEntity.PERSON;
            this.RelationshipToProtected = (int)FACCTS.Server.Model.Enums.Relationship.C;
            //this.Sex = new Sex();
        }

        public string EntityTypeName
        {
            get
            {
                return ((FACCTS.Server.Model.Enums.FACCTSEntity)this.EntityType).ToDescription();
            }
        }

        public string RelationshipName
        {
            get
            {
                return ((FACCTS.Server.Model.Enums.Relationship)this.RelationshipToProtected).ToDescription();
            }
        }

        public FACCTS.Server.Model.Enums.Relationship RelationshipToProtectedEnum
        {
            get
            {
                return (FACCTS.Server.Model.Enums.Relationship)this.RelationshipToProtected;
            }
            set
            {
                this.RelationshipToProtected = (int)value;
            }
        }

        private DateTime? _dateOfBirthNullable;
        public DateTime? DateOfBirthNullable
        {
            get
            {
                if (DateTime.Now.Subtract(TimeSpan.FromDays(365 * 200)) >= this.DateOfBirth)
                {
                    _dateOfBirthNullable = null;
                }
                else
                {
                    _dateOfBirthNullable = this.DateOfBirth;
                }
                return _dateOfBirthNullable;
            }
            set
            {
                if (value == _dateOfBirthNullable)
                    return;
                this.OnPropertyChanging("DateOfBirthNullable");
                _dateOfBirthNullable = value;
                if (_dateOfBirthNullable.HasValue)
                {
                    this.DateOfBirth = _dateOfBirthNullable.Value;
                }
                this.OnPropertyChanged("DateOfBirthNullable");
            }

        }
        
    }
}
