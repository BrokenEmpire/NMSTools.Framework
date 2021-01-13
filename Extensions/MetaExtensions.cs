using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NMSTools.Framework.Extensions
{
    using Meta;

    public static class MetaExtensions
    {
        internal static TkSceneNodeData ReadTkSceneNodeData(this XElement element)
            => new TkSceneNodeData
        {
            Name = element.ReadTkPropertyAsString("Name"),
            NameHash = element.ReadTkPropertyAsULong("NameHash"),
            Type = element.ReadTkPropertyAsString("Type"),
            Transform = element.ReadTkTransformData(),
            Attributes = element.ReadTkSceneNodeAttributes(),
            Children = element.ReadTkSceneNodeChildren()
        };

        internal static TkTransformData ReadTkTransformData(this XElement element)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals("Transform") && i.Attribute("value").Value.Equals("TkTransformData.xml"))
                .Select(i => new TkTransformData
                {
                    TransX = i.ReadTkPropertyAsFloat("TransX"),
                    TransY = i.ReadTkPropertyAsFloat("TransY"),
                    TransZ = i.ReadTkPropertyAsFloat("TransZ"),
                    RotX = i.ReadTkPropertyAsFloat("RotX"),
                    RotY = i.ReadTkPropertyAsFloat("RotY"),
                    RotZ = i.ReadTkPropertyAsFloat("RotZ"),
                    ScaleX = i.ReadTkPropertyAsFloat("ScaleX"),
                    ScaleY = i.ReadTkPropertyAsFloat("ScaleY"),
                    ScaleZ = i.ReadTkPropertyAsFloat("ScaleZ")
                }).FirstOrDefault();

        internal static IList<TkSceneNodeAttributeData> ReadTkSceneNodeAttributes(this XElement element)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals("Attributes"))
                .FirstOrDefault()
                .Elements()
                .Select(i => new TkSceneNodeAttributeData
                {
                    Name = i.ReadTkPropertyAsString("Name"),
                    AltID = i.ReadTkPropertyAsString("AltID"),
                    Value = i.ReadTkPropertyAsString("Value")
                }).ToList();

        internal static IList<TkSceneNodeData> ReadTkSceneNodeChildren(this XElement element)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals("Children"))
                .FirstOrDefault()
                .Elements()
                .Select(i => i.ReadTkSceneNodeData())
                .ToList();

        internal static TkMeshData ReadTkMeshData(this XmlReader reader)
        {
            return new TkMeshData();
        }

        internal static TkMeshMetaData ReadTkMeshMetaData<T>(this XmlReader reader)
        {
            return new TkMeshMetaData();
        }

        internal static TkVector4f ReadTkVector4f(this XmlReader reader)
        {
            return new TkVector4f();
        }

        internal static TkVertexElement ReadTkVertexElement(this XmlReader reader)
        {
            return new TkVertexElement();
        }

        internal static TkVertexLayout ReadTkVertexLayout(this XmlReader reader)
        {
            return new TkVertexLayout();
        }
    }
}
