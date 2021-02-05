namespace NMSTools.Framework.Meta
{
    public class TkSceneNodeAttributeData
    {
        public string Name;
        public string AltID;
        public string Value;

        public override string ToString() => string.Format("{0}: {1}", Name, Value);
    }
}
