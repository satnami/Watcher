using System.ServiceProcess;

namespace Watcher.Service
{
    partial class MonitorService : ServiceBase
    {
        public MonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var enabledServices = Configuration.Configuration.Settings.Services.GetEnabledService();
            foreach (var service in enabledServices)
            {
                var watcher = new Configuration.Watcher(service);
                watcher.Initialize();
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
