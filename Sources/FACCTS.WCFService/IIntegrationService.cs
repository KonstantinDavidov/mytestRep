using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.WCFService
{
    [ServiceContract]
    public interface IIntegrationService
    {
        [OperationContract]
        string GetData();
    }
}
