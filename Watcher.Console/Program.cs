namespace Watcher.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var enabledServices = Configuration.Configuration.Settings.Services.GetEnabledService();
            foreach (var service in enabledServices)
            {
                var monitor = new Configuration.Watcher(service);
                monitor.Initialize();
            }
            while (System.Console.Read() != 'q') ;
        }
    }
}
