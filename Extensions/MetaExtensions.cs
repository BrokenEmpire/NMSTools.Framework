using System.Collections.Generic;
using System.Linq;
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

        internal static TkGeometryStreamData ReadTkGeometryStreamData(this XElement element)
            => element.Elements().Select(i => new TkGeometryStreamData
            {
                StreamDataArray = i.Elements().Select(i => i.ReadTkMeshData()).ToList()
            }).FirstOrDefault();

        internal static TkGeometryData ReadTkGeometryData(this XElement element)
            => new TkGeometryData
            {
                VertexCount = element.ReadTkPropertyAsInt("VertexCount"),
                IndexCount = element.ReadTkPropertyAsInt("IndexCount"),
                Indices16Bit = element.ReadTkPropertyAsInt("Indices16Bit"),
                CollisionIndexCount = element.ReadTkPropertyAsInt("CollisionIndexCount"),
                JointBindings = element.ReadTkJointBindingData(),
                JointExtents = element.ReadTkJointExtentData(),
                JointMirrorPairs = element.ReadTkPropertyAsIntArray("JointMirrorPairs"),
                JointMirrorAxes = element.ReadTkJointMirrorAxis(),
                SkinMatrixLayout = element.ReadTkPropertyAsIntArray("JointMirrorPairs"),
                MeshVertRStart = element.ReadTkPropertyAsIntArray("MeshVertRStart"),
                MeshVertREnd = element.ReadTkPropertyAsIntArray("MeshVertREnd"),
                BoundHullVertSt = element.ReadTkPropertyAsIntArray("BoundHullVertSt"),
                BoundHullVertEd = element.ReadTkPropertyAsIntArray("BoundHullVertEd"),
                MeshBaseSkinMat = element.ReadTkPropertyAsIntArray("MeshBaseSkinMat"),
                MeshAABBMin = element.ReadTkVectorArray("MeshAABBMin"),
                MeshAABBMax = element.ReadTkVectorArray("MeshAABBMax"),
                BoundHullVerts = element.ReadTkVectorArray("BoundHullVerts"),
                VertexLayout = element.ReadTkVertexLayout("VertexLayout"),
                SmallVertexLayout = element.ReadTkVertexLayout("SmallVertexLayout"),
                IndexBuffer = element.ReadTkPropertyAsIntArray("JointMirrorPairs"),
                StreamMetaDataArray = element.ReadTkMeshMetaData()
            };

        internal static TkMeshData ReadTkMeshData(this XElement element)
            => new TkMeshData
            {
                IdString = element.ReadTkPropertyAsString("IdString"),
                Hash = element.ReadTkPropertyAsULong("Hash"),
                VertexDataSize = element.ReadTkPropertyAsInt("VertexDataSize"),
                IndexDataSize = element.ReadTkPropertyAsInt("IndexDataSize"),
                MeshDataStream = element.ReadTkPropertyAsByteArray("MeshDataStream")
            };

        internal static IList<TkJointBindingData> ReadTkJointBindingData(this XElement element)
        {
            var elements = element.Elements().Where(i => i.Attribute("name").Value.Equals("JointBindings"));
            if (!elements.Any())
                return new List<TkJointBindingData>();

            return elements.FirstOrDefault()
                .Elements()
                .Where(i => i.Attribute("value").Value.Equals("TkJointBindingData.xml"))
                .Select(i => new TkJointBindingData
                {
                    InvBindMatrix = i.ReadTkPropertyAsFloatArray("InvBindMatrix"),
                    BindTranslate = i.ReadTkPropertyAsFloatArray("BindTranslate"),
                    BindRotate = i.ReadTkPropertyAsFloatArray("BindRotate"),
                    BindScale = i.ReadTkPropertyAsFloatArray("BindScale")
                }).ToList();
        }

        internal static IList<TkJointExtentData> ReadTkJointExtentData(this XElement element)
        {
            var elements = element.Elements().Where(i => i.Attribute("name").Value.Equals("JointExtents"));
            if (!elements.Any())
                return new List<TkJointExtentData>();

            return elements.FirstOrDefault()
                .Elements()
                .Where(i => i.Attribute("value").Value.Equals("TkJointExtentData.xml"))
                .Select(i => new TkJointExtentData
                {
                    JointExtentMin = i.ReadTkPropertyAsFloatArray("JointExtentMin"),
                    JointExtentMax = i.ReadTkPropertyAsFloatArray("JointExtentMax"),
                    JointExtentCenter = i.ReadTkPropertyAsFloatArray("JointExtentCenter"),
                    JointExtentStdDev = i.ReadTkPropertyAsFloatArray("JointExtentStdDev")
                }).ToList();
        }

        internal static IList<TkJointMirrorAxis> ReadTkJointMirrorAxis(this XElement element)
        {
            var elements = element.Elements().Where(i => i.Attribute("name").Value.Equals("JointMirrorAxes"));
            if (!elements.Any())
                return new List<TkJointMirrorAxis>();

            return elements.FirstOrDefault()
                .Elements()
                .Where(i => i.Attribute("value").Value.Equals("TkJointMirrorAxis.xml"))
                .Select(i => new TkJointMirrorAxis
                {
                    TransMirrorAxisX = i.ReadTkPropertyAsFloat("TransMirrorAxisX"),
                    TransMirrorAxisY = i.ReadTkPropertyAsFloat("TransMirrorAxisY"),
                    TransMirrorAxisZ = i.ReadTkPropertyAsFloat("TransMirrorAxisZ"),
                    RotAdjustX = i.ReadTkPropertyAsFloat("RotAdjustX"),
                    RotAdjustY = i.ReadTkPropertyAsFloat("RotAdjustY"),
                    RotAdjustZ = i.ReadTkPropertyAsFloat("RotAdjustZ"),
                    RotAdjustW = i.ReadTkPropertyAsFloat("RotAdjustW"),
                    RotMirrorAxisX = i.ReadTkPropertyAsFloat("RotMirrorAxisX"),
                    RotMirrorAxisY = i.ReadTkPropertyAsFloat("RotMirrorAxisY"),
                    RotMirrorAxisZ = i.ReadTkPropertyAsFloat("RotMirrorAxisZ"),
                    MirrorAxisMode = i.ReadTkPropertyAsInt("MirrorAxisMode")
                }).ToList();
        }

        internal static IList<TkVector4f> ReadTkVectorArray(this XElement element, string propertyName)
        {
            var elements = element.Elements().Where(i => i.Attribute("name").Value.Equals(propertyName));
            if (!elements.Any())
                return new List<TkVector4f>();

            return elements.FirstOrDefault()
                .Elements()
                .Select(i => i.ReadTkVector4f())
                .ToList();
        }

        internal static IList<TkMeshMetaData> ReadTkMeshMetaData(this XElement element)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals("StreamMetaDataArray"))
                .FirstOrDefault()
                .Elements()
                .Select(i => new TkMeshMetaData 
                {
                    IdString = i.ReadTkPropertyAsString("IdString"),
                    Hash = i.ReadTkPropertyAsULong("Hash"),
                    VertexDataSize = i.ReadTkPropertyAsInt("VertexDataSize"),
                    VertexDataOffset = i.ReadTkPropertyAsInt("VertexDataOffset"),
                    IndexDataSize = i.ReadTkPropertyAsInt("IndexDataSize"),
                    IndexDataOffset = i.ReadTkPropertyAsInt("IndexDataOffset")
                }).ToList();

        internal static TkVector4f ReadTkVector4f(this XElement element)
            => new TkVector4f
            {
                x = element.ReadTkPropertyAsFloat("x"),
                y = element.ReadTkPropertyAsFloat("y"),
                z = element.ReadTkPropertyAsFloat("z"),
                t = element.ReadTkPropertyAsFloat("t"),
            };

        internal static TkVertexLayout ReadTkVertexLayout(this XElement element, string propertyName)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals(propertyName) && i.Attribute("value").Value.Equals("TkVertexLayout.xml"))
                .Select(i => new TkVertexLayout
                {
                    ElementCount = i.ReadTkPropertyAsInt("ElementCount"),
                    Stride = i.ReadTkPropertyAsInt("Stride"),
                    PlatformData = i.ReadTkPropertyAsString("PlatformData"),
                    VertexElements = i.ReadTkVertexElement()
                }).FirstOrDefault();


        internal static IList<TkVertexElement> ReadTkVertexElement(this XElement element)
            => element.Elements().Where(i => i.Attribute("name").Value.Equals("VertexElements"))
                .FirstOrDefault()
                .Elements()
                .Select(i => new TkVertexElement
                {
                    SemanticID = i.ReadTkPropertyAsInt("SemanticID"),
                    Size = i.ReadTkPropertyAsInt("Size"),
                    Type = i.ReadTkPropertyAsInt("Type"),
                    Offset = i.ReadTkPropertyAsInt("Offset"),
                    Normalise = i.ReadTkPropertyAsInt("Normalise"),
                    Instancing = i.ReadTkPropertyAsString("Instancing"),
                    PlatformData = i.ReadTkPropertyAsString("PlatformData")
                }).ToList();
    }
}
