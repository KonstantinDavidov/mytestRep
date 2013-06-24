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
                });

            this.EntityType = (int)FACCTS.Server.Model.Enums.FACCTSEntity.Person;
            this.RelationshipToProtected = (int)FACCTS.Server.Model.Enums.Relationship.Child;
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
        
    }
}
