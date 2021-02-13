using System;
using System.IO;

namespace NMSTools.Framework.Extensions
{
    using Primitives;

    public static class IOExtensions
    {
        public static Vector4 ReadVec4(this BinaryReader reader, int type) => type switch
        {
            // format code 5121 (GL_UNSIGNED_BYTE)
            05121 => new Vector4
            {
                X = new GL_UByte(reader.ReadByte()),
                Y = new GL_UByte(reader.ReadByte()),
                Z = new GL_UByte(reader.ReadByte()),
                W = new GL_UByte(reader.ReadByte())
            },

            // format code 5131 (IEEE half-float)
            05131 => new Vector4
            {
                X = new Half(reader.ReadBytes(2)),
                Y = new Half(reader.ReadBytes(2)),
                Z = new Half(reader.ReadBytes(2)),
                W = new Half(reader.ReadBytes(2))
            },

            // format code 36255 (INT_2_10_10_10_REV)
            36255 => new INT_2_10_10_10_REV(reader.ReadBytes(4)),

            _ => throw new Exception("Unrecongized type")
        };
    }
}
