using System.Linq;
using System.Xml.Linq;
using System;
namespace NMSTools.Framework.Extensions
{
    public static class XmlExtensions
    {
        public static string ReadTkPropertyAsString(this XElement element, string propertyName)
            => element.Elements()
            .Where(i => i.Attribute("name").Value.Equals(propertyName))
            .Select(i => i.Attribute("value").Value)
            .FirstOrDefault();

        public static ulong ReadTkPropertyAsULong(this XElement element, string propertyName)
            => element.Elements()
            .Where(i => i.Attribute("name").Value.Equals(propertyName))
            .Select(i => ulong.Parse(i.Attribute("value").Value))
            .FirstOrDefault();

        public static float ReadTkPropertyAsFloat(this XElement element, string propertyName)
            => element.Elements()
            .Where(i => i.Attribute("name").Value.Equals(propertyName))
            .Select(i => float.Parse(i.Attribute("value").Value))
            .FirstOrDefault();
    }
}
