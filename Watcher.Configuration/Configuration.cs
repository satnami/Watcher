namespace Watcher.Configuration
{
    public static class Configuration
    {
        private static Settings _settings;

        public static Settings Settings
        {
            get
            {
                if (_settings != null) return _settings;

                _settings = Helper.Load();

                return _settings;
            }
        }
    }
}