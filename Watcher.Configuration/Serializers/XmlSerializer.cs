using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Watcher.Configuration
{
    public static class XMLSerializer
    {
        public static T Deserialize<T>(string xml)
        {
            T t;

            var serializer = new XmlSerializer(typeof(T));
            var context = new XmlParserContext(null, null, null, XmlSpace.None);
            var reader = new XmlTextReader(xml, XmlNodeType.Element, context);

            try
            {
                t = (T)serializer.Deserialize(reader);
            }
            catch
            {
                t = default(T);
            }

            return t;
        }

        public static T Deserialize<T>(string xml, Type[] extraTypes)
        {
            T t;

            var serializer = new XmlSerializer(typeof(T), extraTypes);
            var context = new XmlParserContext(null, null, null, XmlSpace.None);
            var reader = new XmlTextReader(xml, XmlNodeType.Element, context);

            try
            {
                t = (T)serializer.Deserialize(reader);
            }
            catch
            {
                t = default(T);
            }

            return t;
        }

        public static string Serialize<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var namespaces = new XmlSerializerNamespaces();
            {
                namespaces.Add("", "");
            }
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            try
            {
                var sb = new StringBuilder();
                using (var writer = XmlWriter.Create(sb, settings))
                {
                    serializer.Serialize(writer, obj, namespaces);

                    return sb.ToString();
                }
            }
            catch
            {
                return String.Empty;
            }
        }

        public static string Serialize<T>(T obj, Type[] extraTypes)
        {
            var serializer = new XmlSerializer(typeof(T), extraTypes);
            var namespaces = new XmlSerializerNamespaces();
            {
                namespaces.Add("", "");
            }
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };

            try
            {
                var sb = new StringBuilder();
                using (var writer = XmlWriter.Create(sb, settings))
                {

                    serializer.Serialize(writer, obj, namespaces);

                    return sb.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }         
        }
    }
}
