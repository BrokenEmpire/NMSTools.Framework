using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NMSTools.Framework.Meta
{
    using static Extensions.XmlExtensions;
    using static Extensions.MetaExtensions;

    public class TkSceneNodeData
    {
        public string Name;
        public ulong NameHash;
        public string Type;
        public TkTransformData Transform;

        public IList<TkSceneNodeAttributeData> Attributes;
        public IList<TkSceneNodeData> Children;

        public static TkSceneNodeData Load(Stream inputStream)
        {
            var xdoc = XDocument.Load(inputStream);
            var root = xdoc.Element("Data");

            return root.ReadTkSceneNodeData();
        }
    }
}
