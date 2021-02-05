using System.Collections.Generic;

namespace NMSTools.Framework.Meta
{
    public class TkSceneNodeData
    {
        public string Name;
        public ulong NameHash;
        public string Type;
        public TkTransformData Transform;

        public IList<TkSceneNodeAttributeData> Attributes;
        public IList<TkSceneNodeData> Children;

        public override string ToString() 
            => string.Format("Name: {0}, Hash: {1}, Type: {2}, A: {3}, C: {4}", Name, NameHash, Type, Attributes.Count, Children.Count);
    }
}
