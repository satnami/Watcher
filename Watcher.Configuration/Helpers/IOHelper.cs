using System;
using System.IO;

namespace Watcher.Configuration
{
    public static class IOHelper
    {
        public static string ExecutionPath
        {
            get
            {
                var env = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

                return Path.GetDirectoryName(new Uri(env).LocalPath);
            }
        }
    }
}
