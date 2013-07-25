﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;
using System.Reactive.Linq;
using System.ComponentModel;
using Faccts.Model.Entities.Validation;
using FACCTS.Server.Model.DataModel;

namespace Faccts.Model.Entities
{
    public partial class CourtParty : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtParty>, IValidatableObject
    {
        partial void Initialize()
        {
            this.Attorney = new Attorneys();
            this.AddressInfo = new AddressInfo();
            this.WhenAny(x => x.FirstName, x => x.LastName, x => x.MiddleName, (x, y, z) => new { FirstName = x.Value, LastName = y.Value, MiddleName = z.Value })
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("FullName");
                }
                );
        }

        public CourtParty(FACCTS.Server.Model.DataModel.CourtParty dto)
            : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.FirstName = dto.FirstName;
                this.MiddleName = dto.MiddleName;
                this.LastName = dto.LastName;
                this.Description = dto.Description;
                this.ParticipantRole = dto.ParticipantRole;
                this.Designation = dto.Designation;
                this.ParentRole = dto.ParentRole;
                this.HairColor = new HairColor(dto.HairColor);
                this.EyesColor = new EyesColor(dto.EyesColor);
                this.Race = new Race(dto.Race);
                this.RelationToOtherParty = dto.RelationToOtherParty;
                this.Weight = dto.Weight;
                this.HeightFt = dto.HeightFt;
                this.HeightIns = dto.HeightIns;
                this.Attorney = new Attorneys(dto.Attorney);
                this.IsProPer = dto.IsProPer;
            }
            

            this.MarkAsUnchanged();
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
                    Description = this.Description,
                    ParticipantRole = this.ParticipantRole,
                    AddressInfo = this.AddressInfo.ToDTO(),                    
                    ParentRole = this.ParentRole,
                    EntityType = this.EntityType,
                    Email = this.Email,
                    Sex = this.Sex,
                    HairColor = this.HairColor.ConvertToDTO(),
                    EyesColor = this.EyesColor.ConvertToDTO(),
                    Race = this.Race.ConvertToDTO(),
                    RelationToOtherParty = this.RelationToOtherParty,
                    Weight = this.Weight,
                    HeightFt = this.HeightFt,
                    HeightIns = this.HeightIns,
                    DateOfBirth = this.DateOfBirth,
                    Age = this.Age,
                    State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                    Attorney = this.Attorney.ToDTO(),

                };
            return dto;
        }



        public string Error
        {
            get { return this[string.Empty]; }
        }

        public string this[string propertyName]
        {
            get
            {
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, _errors, propertyName);
            }
        }


        private static Dictionary<string, string> _requiredFields = new Dictionary<string, string>()
        {
            {"FirstName", "First Name"},
            {"LastName", "Last Name"},
            {"Designation", "Designation"},
            {"Sex", "Sex"},
            {"Race", "Race"},
            {"EntityType", "Entity"},
            {"DateOfBirth", "Date of birth"},
            {"ParentRole", "Parent Role"},
            {"AddressInfo", "Address Info"},
            {"AddressInfo.StreetAddress", "Street Address"},
            {"AddressInfo.City", "City"},
            {"AddressInfo.USAState", "State"},
            {"AddressInfo.ZipCode", "Zip Code"},
        };


        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public IList<string> Errors
        {
            get { return _errors.Select(kv => kv.Value).ToList().AsReadOnly(); }
        }

        public bool IsValid
        {
            get
            {
                return !this.Error.Any();
            }
        }
    }
}
