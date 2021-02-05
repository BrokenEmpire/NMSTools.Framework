using System;
using System.IO;

namespace NMSTools.Framework.Extensions
{
    using Primitives;

    public static class IOExtensions
    {
        public static Vector4 ReadVec4(this BinaryReader reader, int type) => type switch
        {
            05121 => new Vector4
            {
                X = new GL_UByte(reader.ReadByte()),
                Y = new GL_UByte(reader.ReadByte()),
                Z = new GL_UByte(reader.ReadByte()),
                W = new GL_UByte(reader.ReadByte())
            },

            05131 => new Vector4
            {
                X = new Half(reader.ReadBytes(2)),
                Y = new Half(reader.ReadBytes(2)),
                Z = new Half(reader.ReadBytes(2)),
                W = new Half(reader.ReadBytes(2))
            },

            36255 => new INT_2_10_10_10_REV(reader.ReadBytes(4)),

            _ => throw new Exception("Unrecongized type")
        };
    }
}
