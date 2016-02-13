using System;
using System.IO;
using System.Xml;

namespace Watcher.Configuration
{
    public static class Helper
    {
        private const string FILENAME = "Settings.xml";

        public static Settings Load()
        {
            var path = IOHelper.ExecutionPath + "\\" + FILENAME;
            var xml = GetXMLDoc(path);
            var settings = XMLSerializer.Deserialize<Settings>(xml);
            return settings;
        }

        public static string GetXMLDoc(string xmlPath)
        {
            if (!File.Exists(xmlPath))
                return string.Empty;

            using (var reader = new XmlTextReader(xmlPath)
            {
                WhitespaceHandling = WhitespaceHandling.None
            })
            {
                var xmlDoc = new XmlDocument();
                {
                    xmlDoc.Load(reader);

                    return xmlDoc.OuterXml;
                }
            }
        }

        public static bool Save(string Settings)
        {
            try
            {
                var path = IOHelper.ExecutionPath + "\\" + FILENAME;

                var xml = XMLSerializer.Serialize(Settings);
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(xml);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}