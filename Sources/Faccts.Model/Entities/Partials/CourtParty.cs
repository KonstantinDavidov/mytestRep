using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;
using System.Reactive.Linq;

namespace Faccts.Model.Entities
{
    public partial class CourtParty : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtParty>
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.FirstName, x => x.LastName, x => x.MiddleName, (x, y, z) => new { FirstName = x.Value, LastName = y.Value, MiddleName = z.Value })
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("FullName");
                }
                );
        }

        private IObservable<IObservedChange<CourtParty, string>> _fullNameChanged;
        public IObservable<IObservedChange<CourtParty, string>> FullNameChanged
        {
            get
            {
                if (_fullNameChanged == null)
                {
                    _fullNameChanged = Observable.Merge(
                        this.ObservableForProperty(x => x.FirstName),
                        this.ObservableForProperty(x => x.MiddleName),
                        this.ObservableForProperty(x => x.LastName)
                        );
                }
                return _fullNameChanged;
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
            if (!this.IsDirty)
                return null;
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
                    USAState = (USAState)this.USAState,
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
                    State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,

                };
            return dto;
        }
        
    }
}
