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
            this.Changed.Subscribe(_ =>
                {
                    this.IsDirty = true;
                }
                );
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

        private bool _isDirty;
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                if (_isDirty == value)
                {
                    return;
                }
                _isDirty = value;
                this.OnPropertyChanged("IsDirty");
            }

        }

        
    }
}
