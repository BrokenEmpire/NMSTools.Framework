using System;

namespace NMSTools.Framework.Extensions
{
    public static class NumericExtensions
    {
        public static int FloorDivide(this int a, int b)
            => a / b - Convert.ToInt32(((a < 0) ^ (b < 0)) && (a % b != 0));
    }
}
