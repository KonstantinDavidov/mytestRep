using FACCTS.Server.Common;
using log4net;

namespace FACCTS.WCFService
{
    public class IntegrationService : IIntegrationService
    {
        public IntegrationService()
        {
            log4net.Config.XmlConfigurator.Configure();
            MefCongif.RegisterMef();
            _logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        private ILog _logger;

        public string GetData()
        {
            _logger.Info("GetData called");
            return "Hello";
        }
    }
}
