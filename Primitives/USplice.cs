using System;
using System.Runtime.InteropServices;

namespace NMSTools.Framework.Primitives
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct USplice
    {
        [FieldOffset(0)]
        private readonly byte b3;

        [FieldOffset(1)]
        private readonly byte b2;

        [FieldOffset(2)]
        private readonly byte b1;

        [FieldOffset(3)]
        private readonly byte b0;

        [FieldOffset(0)]
        public uint Value;

        public USplice(uint value)
        {
            b3 = b2 = b1 = b0 = 0;
            Value = value;
        }
        public USplice(byte[] values)
        {
            Value = 0;
            b3 = b2 = b1 = b0 = 0;

            if (values.Length == 2)
            {
                b3 = values[0];
                b2 = values[1];
            }
            else if (values.Length == 4)
            {
                b3 = values[0];
                b2 = values[1];
                b1 = values[2];
                b0 = values[3];
            }
        }

        public byte this[int index]
        {
            get
            {
                return index switch
                {
                    0 => b0,
                    1 => b1,
                    2 => b2,
                    3 => b3,
                    _ => default
                };
            }
        }

        public static implicit operator uint(USplice obj) => obj.Value;
        public static implicit operator USplice(uint obj) => new USplice(obj);

        public override string ToString() => string.Format("{0}", Value);
    }
}
