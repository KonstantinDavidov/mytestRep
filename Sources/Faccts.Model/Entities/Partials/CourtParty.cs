using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CourtParty
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.FirstName, x => x.LastName, x => x.MiddleName, (x, y, z) => new { FirstName = x.Value, LastName = y.Value, MiddleName = z.Value })
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("FullName");
                }
                );
            this.Attorneys = new Attorneys();
        }

        private DateTime? _dateOfBirthNullable;
        public DateTime? DateOfBirthNullable
        {
            get
            {
                if (DateTime.Now.Subtract(TimeSpan.FromDays(365 * 200)) >= this.DateOfBirth)
                {
                    _dateOfBirthNullable = null;
                } else
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

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.LastName, this.FirstName, this.MiddleName);
            }
        }

        public FACCTS.Server.Model.DataModel.CourtParty ToDTO()
        {
            FACCTS.Server.Model.DataModel.CourtParty dto = new FACCTS.Server.Model.DataModel.CourtParty()
                {
                    Id = this.Id,
                    FirstName = this.FirstName,
                    MiddleName = this.MiddleName,
                    LastName = this.LastName,
                    Designation = this.Designation != null ? this.Designation.ToDTO() : null,
                    Description = this.Description,
                    ParticipantRole = this.ParticipantRole,
                    Address = this.Address,
                    City = this.City,
                    USAState = this.State,
                    ZipCode = this.ZipCode,
                    Phone = this.Phone,
                    Fax = this.Fax,
                    ParentRole = this.ParentRole,
                    EntityType = this.EntityType,
                    Email = this.Email,
                    Sex = this.Sex,
                    HairColor = this.HairColor != null ? this.HairColor.ToDTO() : null,
                    EyesColor = this.EyesColor != null ? this.EyesColor.ToDTO() : null,
                    Race = this.Race != null ? this.Race.ToDTO() : null,
                    RelationToOtherParty = this.RelationToOtherParty,
                    Weight = this.Weight,
                    HeightFt = this.HeightFt,
                    HeightIns = this.HeightIns,
                    DateOfBirth = this.DateOfBirth,
                    Age = this.Age,
                    //HasAttorney = this.HasAttorney,
                    //Attorney = this.Attorneys != null ? this.Attorneys.ToDTO() : null,
                    State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,

                };
            return dto;
        }
        
    }
}
