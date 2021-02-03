using System;
using System.Runtime.InteropServices;

namespace NMSTools.Framework.Primitives
{
    /// <summary>
    /// https://devblogs.microsoft.com/dotnet/introducing-the-half-type/
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct Half
    {
        [FieldOffset(0)]
        private readonly byte b1;

        [FieldOffset(1)]
        private readonly byte b0;

        [FieldOffset(0)]
        public ushort Value;

        private int Sign => Value >> 0x0F;
        private int Exponent => (Value >> 0x0A) & 0x1F;
        private int Significand => Value & 0x03FF;

        public Half(ushort value)
        {
            b1 = b0 = 0;
            Value = value;
        }
        public Half(byte[] values)
        {
            Value = 0;

            b1 = values[0];
            b0 = values[1];
        }

        public byte this[int index]
        {
            get
            {
                return index switch
                {
                    0 => b0,
                    1 => b1,
                    _ => default
                };
            }
        }

        public static implicit operator ushort(Half obj) => obj.Value;
        public static implicit operator Half(ushort obj) => new Half(obj);

        public static implicit operator float(Half obj) 
        {
            if (obj.Exponent == 0)
            {
                if (obj.Significand == 0)
                {
                    if (obj.Sign == 0)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    return (float)(Math.Pow(-1, obj.Sign) * Math.Pow(2, -14) * (0 + (obj.Significand / 1024f)));
                }
            }
            else if (obj.Exponent == 0x1F)
            {
                if (obj.Significand == 0)
                {
                    if (obj.Sign == 0)
                    {
                        // PositiveInfinity
                        // ----------------------
                        // 0x7C00
                        // 31744
                        // 0111 1100 0000 0000
                        //Console.WriteLine("{0, 3}: {1, 20}  [F, {2, 5}]", i, "Positive Infinity", n);
                    }
                    else
                    {
                        // Negative Infinity
                        // ----------------------
                        // 0xFC00
                        // -1024
                        // 1111 1100 0000 0000
                        //Console.WriteLine("{0, 3}: {1, 20}  [G, {2, 5}]", i, "Negative Infinity", n);
                    }
                }
                else
                {
                    // NaN
                    // ----------------------
                    // 0xFE00
                    // -512
                    // 1111 1110 0000 0000
                    //Console.WriteLine("{0, 3}: {1, 20:g18}  [E, {2, 5}]", i, "NaM", n);
                }
            }
            else
            {
                return (float)(Math.Pow(-1, obj.Sign) * Math.Pow(2, obj.Exponent - 15) * (1 + (obj.Significand / 1024f)));
            }

            return 0f;
        }

        public static bool operator ==(Half left, Half right) => left.Value.Equals(right.Value);
        public static bool operator !=(Half left, Half right) => !(left.Value == right.Value);

        public override bool Equals(object obj)
        {
            if (obj is Half t)
                return t[0].Equals(b0) && t[1].Equals(b1);

            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 633813365;
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + b1.GetHashCode();
            hashCode = hashCode * -1521134295 + b0.GetHashCode();

            return hashCode;
        }

        public override string ToString() => string.Format("{0:G18}", (float)this);      
    }
}
