using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class OtherProtected
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.EntityType, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("EntityTypeName");
                }
                );
            this.WhenAny(x => x.RelationshipToPlaintiff, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("RelationshipName");
                    this.OnPropertyChanged("RelationshipToPlaintiffEnum");
                });

            this.EntityType = (int)FACCTS.Server.Model.Enums.FACCTSEntity.Person;
            this.RelationshipToPlaintiff = (int)FACCTS.Server.Model.Enums.Relationship.C;
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
                return ((FACCTS.Server.Model.Enums.Relationship)this.RelationshipToPlaintiff).ToDescription();
            }
        }

        public FACCTS.Server.Model.Enums.Relationship RelationshipToPlaintiffEnum
        {
            get
            {
                return (FACCTS.Server.Model.Enums.Relationship)this.RelationshipToPlaintiff;
            }
            set
            {
                this.RelationshipToPlaintiff = (int)value;
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
