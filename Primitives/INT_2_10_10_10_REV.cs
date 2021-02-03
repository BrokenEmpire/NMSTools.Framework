using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace NMSTools.Framework.Primitives
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct INT_2_10_10_10_REV
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

        public INT_2_10_10_10_REV(uint value)
        {
            b3 = b2 = b1 = b0 = 0;
            Value = value;
        }
        public INT_2_10_10_10_REV(byte[] values)
        {
            Value = 0;

            b3 = values[0];
            b2 = values[1];
            b1 = values[2];
            b0 = values[3];
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

        public static implicit operator uint(INT_2_10_10_10_REV obj) => obj.Value;
        public static implicit operator INT_2_10_10_10_REV(uint obj) => new INT_2_10_10_10_REV(obj);

        public static implicit operator Vector4(INT_2_10_10_10_REV obj)
        {
            var selector = 0x03FF;
            var mask = 0x0200;

            var raw = new long[4]
            {
                obj.Value & selector,
                (obj.Value & (selector << 0x0A)) >> 0x0A,
                (obj.Value & (selector << 0x14)) >> 0x14,
                (obj.Value & (selector << 0x1E)) >> 0x1E
            }.Select(i => ((i & mask) * -1) + (i & ~mask)).ToArray();

            var magnitude = Math.Pow(Math.Pow(raw[0], 2) + Math.Pow(raw[1], 2) + Math.Pow(raw[2], 2), 0.5f);

            return new Vector4
            {
                X = raw[0] / magnitude,
                Y = raw[1] / magnitude,
                Z = raw[2] / magnitude,
                W = raw[3]
            };
        }

        public override string ToString() => string.Format("{0}", (Vector4)this);
    }
}
