using System.ServiceModel;

namespace PumpService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PumpService : IPumpService
    {
        private readonly ISettingsService _settingsService;
        private readonly IStatisticsService _statisticsService;
        private readonly IScriptService _scriptService;

        public PumpService()
        {
            _settingsService = new SettingsService();
            _statisticsService = new StatisticsService();
            _scriptService = new ScriptService(_settingsService,_statisticsService,PumpServiceCallback);
        }
        public void RunScript()
        {
            _scriptService.Run(10);   
        }

        public void UpdateAndCompliteScript(string fileName)
        {
            _settingsService.FileName = fileName;
            _scriptService.Compile();

        }

        IPumpServiceCallback PumpServiceCallback 
        { 
            get
            {
                if (OperationContext.Current != null)
                {
                    return OperationContext.Current.GetCallbackChannel<IPumpServiceCallback>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
