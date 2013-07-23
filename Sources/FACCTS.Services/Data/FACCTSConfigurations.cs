using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class FACCTSConfigurations : WebApiClientBase
    {
        private static FACCTSConfiguration _configuration;
        public static FACCTSConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new FACCTSConfigurations().GetConfiguration();
                }
                return _configuration;
            }
        }

        private FACCTSConfiguration GetConfiguration()
        {
            var config = this.CallServiceGet<FACCTS.Server.Model.DataModel.Configuration.FACCTSConfiguration>("FACCTSConfiguration");
            if (config != null)
            {
                var result =  new FACCTSConfiguration()
                {
                    Id = config.Id,
                    CurrentCourtCountyId = config.CurrentCourtCountyId,
                    CaseNumberAutoGeneration = config.CaseNumberAutoGeneration,
                };
                return result;
            }
            return null;
        }
    }
}
