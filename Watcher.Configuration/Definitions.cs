using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Watcher.Configuration
{
    [Serializable]
    public class Settings
    {
        public Services Services { get; set; }
    }

    [Serializable]
    [XmlRoot("Services")]
    public class Services : List<Service>
    {
        public List<Service> GetEnabledService()
        {
            return FindAll(t => t.Enable == "true" || t.Enable == "1");
        }
    }

    [Serializable]
    [XmlRoot("Service")]
    public class Service
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Enable { get; set; }
        public string Filter { get; set; }
        public string WatchedFolderPathUri { get; set; }
        public string OnCreateActionUri { get; set; }
        public string OnDeleteActionUri { get; set; }
        public string OnRenameActionUri { get; set; }
        public string OnChangeActionUri { get; set; }

    }
}
