using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class Witnesses
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.EntityType, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("EntityTypeName");
                }
                );
            this.EntityType = (int)FACCTS.Server.Model.Enums.FACCTSEntity.PERSON;
        }

        public string EntityTypeName
        {
            get
            {
                return ((FACCTS.Server.Model.Enums.FACCTSEntity)this.EntityType).ToDescription();
            }
        }
    }
}
