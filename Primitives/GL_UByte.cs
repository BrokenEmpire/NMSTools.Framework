using System.Runtime.InteropServices;

namespace NMSTools.Framework.Primitives
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct GL_UByte
    {
        [FieldOffset(0)]
        private readonly byte b0;

        [FieldOffset(0)]
        public uint Value;

        public GL_UByte(uint value)
        {
            b0 = 0;
            Value = value;
        }
        public GL_UByte(byte value)
        {
            Value = 0;
            b0 = value;
        }

        public byte this[int index]
        {
            get
            {
                return index switch
                {
                    0 => b0,
                    _ => default
                };
            }
        }

        public static implicit operator uint(GL_UByte obj) => obj.Value;
        public static implicit operator GL_UByte(uint obj) => new GL_UByte(obj);

        public override string ToString() => string.Format("{0}", Value);
    }
}
