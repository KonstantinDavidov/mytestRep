using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Appearance : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Appearance>
    {
        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.Appearance ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.Appearance()
            {
                Party1Appear = this.Party1Appear.GetValueOrDefault(false),
                Party1Sworn = this.Party1Sworn.GetValueOrDefault(false),
                Party1AttorneyPresent = this.Party1AttorneyPresent.GetValueOrDefault(false),
                Party2Appear = this.Party2Appear.GetValueOrDefault(false),
                Party2Sworn = this.Party2Sworn.GetValueOrDefault(false),
                Party2AttorneyPresent = this.Party2AttorneyPresent.GetValueOrDefault(false),
            };
        }

    }
}
