using System.Collections.Generic;

namespace NMSTools.Framework.Meta
{
    public class TkVertexLayout
    {
        public int ElementCount;
        public int Stride;
        public string PlatformData;
        public IList<TkVertexElement> VertexElements;
    }
}
