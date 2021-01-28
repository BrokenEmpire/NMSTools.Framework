using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMSTools.Framework.Primitives
{
    using Framework.Helpers;

    public struct Half : IComparable, IFormattable, IConvertible, IComparable<Half>, IEquatable<Half>
    {
        /// <summary>
        /// Internal representation of the half-precision floating-point number.
        /// </summary>
        internal ushort value;

        /// <summary>
        /// Represents the smallest positive System.Half value greater than zero.
        /// </summary>
        public static readonly Half Epsilon = Half.ToHalf(0x0001);

        /// <summary>
        /// Represents the largest possible value of System.Half.
        /// </summary>
        public static readonly Half MaxValue = Half.ToHalf(0x7bff);

        /// <summary>
        /// Represents the smallest possible value of System.Half.
        /// </summary>
        public static readonly Half MinValue = Half.ToHalf(0xfbff);

        /// <summary>
        /// Represents not a number (NaN).
        /// </summary>
        public static readonly Half NaN = Half.ToHalf(0xfe00);

        /// <summary>
        /// Represents negative infinity.
        /// </summary>
        public static readonly Half NegativeInfinity = Half.ToHalf(0xfc00);

        /// <summary>
        /// Represents positive infinity.
        /// </summary>
        public static readonly Half PositiveInfinity = Half.ToHalf(0x7c00);

        /// <summary>
        /// Represents the 1.0 constant.
        /// </summary>
        public static readonly Half One = new Half(1.0f);

        /// <summary>
        /// Represents the zero constant.
        /// </summary>
        public static readonly Half Zero = new Half(0.0f);


        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified single-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(float value) => this = HalfHelper.SingleToHalf(value);
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified 32-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(int value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified 64-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(long value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified double-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(double value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified decimal number.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(decimal value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(uint value) : this((float)value) { }
        /// <summary>
        /// Initializes a new instance of System.Half to the value of the specified 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a System.Half.</param>
        public Half(ulong value) : this((float)value) { }


        /// <summary>
        /// Returns a half-precision floating point number converted from two bytes
        /// at a specified position in a byte array.
        /// </summary>
        /// <param name="value">An array of bytes.</param>
        /// <param name="startIndex">The starting position within value.</param>
        /// <returns>A half-precision floating point number formed by two bytes beginning at startIndex.</returns>
        /// <exception cref="System.ArgumentException">
        /// startIndex is greater than or equal to the length of value minus 1, and is
        /// less than or equal to the length of value minus 1.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">startIndex is less than zero or greater than the length of value minus 1.</exception>
        public static Half ToHalf(byte[] value, int startIndex)
            => ToHalf((ushort)BitConverter.ToInt16(value, startIndex));

        /// <summary>
        /// Returns a half-precision floating point number converted from its binary representation.
        /// </summary>
        /// <param name="bits">Binary representation of System.Half value</param>
        /// <returns>A half-precision floating point number formed by its binary representation.</returns>
        public static Half ToHalf(ushort bits)
        {
            const ushort NegZero = (ushort)32768u;
            const ushort Zero = (ushort)0u;

            return new Half { value = bits == NegZero ? Zero : bits };
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Half other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Half other)
        {
            throw new NotImplementedException();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
