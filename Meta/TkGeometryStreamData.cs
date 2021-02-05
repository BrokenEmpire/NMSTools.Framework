using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace NMSTools.Framework.Meta
{
    using static Extensions.MetaExtensions;

    public class TkGeometryStreamData
    {
        public IList<TkMeshData> StreamDataArray;

        //todo: move to NMSTools.Serialization
        public static TkGeometryStreamData Load(Stream inputStream)
        {
            var xdoc = XDocument.Load(inputStream);
            var root = xdoc.Element("Data");

            return root.ReadTkGeometryStreamData();
        }
    }
}
