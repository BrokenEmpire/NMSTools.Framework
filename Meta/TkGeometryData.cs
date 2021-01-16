using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace NMSTools.Framework.Meta
{
    using static Extensions.MetaExtensions;

    public class TkGeometryData
    {
        public int VertexCount;
        public int IndexCount;
        public int Indices16Bit;
        public int CollisionIndexCount;

        public IList<TkJointBindingData> JointBindings;
        public IList<TkJointExtentData> JointExtents;

        public IList<int> JointMirrorPairs;
        public IList<TkJointMirrorAxis> JointMirrorAxes;

        public IList<int> SkinMatrixLayout;
        public IList<int> MeshVertRStart;
        public IList<int> MeshVertREnd;
        public IList<int> BoundHullVertSt;
        public IList<int> BoundHullVertEd;
        public IList<int> MeshBaseSkinMat;

        public IList<TkVector4f> MeshAABBMin;
        public IList<TkVector4f> MeshAABBMax;
        public IList<TkVector4f> BoundHullVerts;

        public TkVertexLayout VertexLayout;
        public TkVertexLayout SmallVertexLayout;

        public IList<int> IndexBuffer;
        public IList<TkMeshMetaData> StreamMetaDataArray;

        public static TkGeometryData Load(Stream inputStream)
        {
            var xdoc = XDocument.Load(inputStream);
            var root = xdoc.Element("Data");

            return root.ReadTkGeometryData();
        }
    }
}
