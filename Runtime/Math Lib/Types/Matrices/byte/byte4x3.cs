using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Sequential, Size = 4 * 3 * sizeof(byte))]
    unsafe public struct byte4x3 : IEquatable<byte4x3>, IFormattable
    {
        public byte4 c0;
        public byte4 c1;
        public byte4 c2;


        public static byte4x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x3(byte4 c0, byte4 c1, byte4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x3(byte m00, byte m01, byte m02,
                       byte m10, byte m11, byte m12,
                       byte m20, byte m21, byte m22,
                       byte m30, byte m31, byte m32)
        {
            this.c0 = new byte4(m00, m10, m20, m30);
            this.c1 = new byte4(m01, m11, m21, m31);
            this.c2 = new byte4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4x3(byte v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4x3(byte v) => new byte4x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(sbyte4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(short4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(ushort4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(int4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(uint4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(long4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(ulong4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(float4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4x3(double4x3 input) => new byte4x3((byte4)input.c0, (byte4)input.c1, (byte4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4x3(byte4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4x3(byte4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(byte4x3 input) => new int4x3((int4)input.c0, (int4)input.c1, (int4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x3(byte4x3 input) => new uint4x3((uint4)input.c0, (uint4)input.c1, (uint4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x3(byte4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x3(byte4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x3(byte4x3 input) => new float4x3((float4)input.c0, (float4)input.c1, (float4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(byte4x3 input) => new double4x3((double4)input.c0, (double4)input.c1, (double4)input.c2);


        public ref byte4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((byte4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator + (byte4x3 left, byte4x3 right) => new byte4x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator - (byte4x3 left, byte4x3 right) => new byte4x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator * (byte4x3 left, byte4x3 right) => new byte4x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator / (byte4x3 left, byte4x3 right) => new byte4x3(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator % (byte4x3 left, byte4x3 right) => new byte4x3(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator * (byte4x3 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator * (byte left, byte4x3 right) => new byte4x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator / (byte4x3 left, byte right) => new byte4x3(left.c0 / right, left.c1 / right, left.c2 / right); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator % (byte4x3 left, byte right) => new byte4x3(left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator & (byte4x3 left, byte4x3 right) => new byte4x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator | (byte4x3 left, byte4x3 right) => new byte4x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator ^ (byte4x3 left, byte4x3 right) => new byte4x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator ++ (byte4x3 val) => new byte4x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator -- (byte4x3 val) => new byte4x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator ~ (byte4x3 val) => new byte4x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator << (byte4x3 x, int n) => new byte4x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4x3 operator >> (byte4x3 x, int n) => new byte4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (byte4x3 left, byte4x3 right) => new bool4x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte4x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override readonly bool Equals(object obj) => obj is byte4x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ c2.GetHashCode();


        public override readonly string ToString() => $"byte4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}