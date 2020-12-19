﻿using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of leading zeros in the binary representations of a byte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte lzcnt(byte x)
        {
            // eliminates second test hardcoded by Unity; min(lzcnt, 8) adds another branch (for whatever reason)

            return (x == 0) ? (byte)8 : (byte)math.lzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lzcnt(byte2 x)
        {
            return new byte2(lzcnt(x.x), lzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lzcnt(byte3 x)
        {
            return new byte3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lzcnt(byte4 x)
        {
            byte4 y;
            byte4 n = 8;
            byte4 mask;

            y = x >> 4;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 4, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 2, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Sse2.cmpeq_epi16(y, default(v128));

            return Sse4_1.blendv_epi8(n - 2, n - x, mask);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lzcnt(byte8 x)
        {
            byte8 y;
            byte8 n = 8;
            byte8 mask;

            y = x >> 4;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 4, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 2, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Sse2.cmpeq_epi16(y, default(v128));

            return Sse4_1.blendv_epi8(n - 2, n - x, mask);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lzcnt(byte16 x)
        {
            byte16 y;
            byte16 n = 8;
            byte16 mask;

            y = x >> 4;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 4, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 2, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Sse2.cmpeq_epi16(y, default(v128));

            return Sse4_1.blendv_epi8(n - 2, n - x, mask);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lzcnt(byte32 x)
        {
            byte32 y;
            byte32 n = 8;
            byte32 mask;

            y = x >> 4;
            mask = Avx2.mm256_cmpeq_epi8(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 4, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Avx2.mm256_cmpeq_epi8(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 2, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Avx2.mm256_cmpeq_epi8(y, default(v256));

            return Avx2.mm256_blendv_epi8(n - 2, n - x, mask);
        }


        /// <summary>       Returns number of leading zeros in the binary representations of an sbyte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte lzcnt(sbyte x)
        {
            return (sbyte)lzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 lzcnt(sbyte2 x)
        {
            return (sbyte2)lzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 lzcnt(sbyte3 x)
        {
            return (sbyte3)lzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 lzcnt(sbyte4 x)
        {
            return (sbyte4)lzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 lzcnt(sbyte8 x)
        {
            return (sbyte8)lzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 lzcnt(sbyte16 x)
        {
            return (sbyte16)lzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 lzcnt(sbyte32 x)
        {
            return (sbyte32)lzcnt((byte32)x);
        }


        /// <summary>       Returns number of leading zeros in the binary representations of a ushort value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort lzcnt(ushort x)
        {
            // eliminates second test hardcoded by Unity; min(lzcnt, 16) adds another branch (for whatever reason)

            return (x == 0) ? (ushort)16 : (ushort)math.lzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lzcnt(ushort2 x)
        {
            return new ushort2(lzcnt(x.x), lzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lzcnt(ushort3 x)
        {
            return new ushort3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lzcnt(ushort4 x)
        {
            ushort4 y;
            ushort4 n = 16;
            ushort4 mask;

            y = x >> 8;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 8, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 4;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 4, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 2, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Sse2.cmpeq_epi16(y, default(v128));

            return Sse4_1.blendv_epi8(n - 2, n - x, mask);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lzcnt(ushort8 x)
        {
            ushort8 y;
            ushort8 n = 16;
            ushort8 mask;

            y = x >> 8;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 8, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 4;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 4, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Sse2.cmpeq_epi16(y, default(v128));
            n = Sse4_1.blendv_epi8(n - 2, n, mask);
            x = Sse4_1.blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Sse2.cmpeq_epi16(y, default(v128));

            return Sse4_1.blendv_epi8(n - 2, n - x, mask);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lzcnt(ushort16 x)
        {
            ushort16 y;
            ushort16 n = 16;
            ushort16 mask;

            y = x >> 8;
            mask = Avx2.mm256_cmpeq_epi16(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 8, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 4;
            mask = Avx2.mm256_cmpeq_epi16(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 4, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Avx2.mm256_cmpeq_epi16(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 2, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Avx2.mm256_cmpeq_epi16(y, default(v256));

            return Avx2.mm256_blendv_epi8(n - 2, n - x, mask);
        }


        /// <summary>       Returns number of leading zeros in the binary representations of a short value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short lzcnt(short x)
        {
            return (short)lzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 lzcnt(short2 x)
        {
            return (short2)lzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 lzcnt(short3 x)
        {
            return (short3)lzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 lzcnt(short4 x)
        {
            return (short4)lzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 lzcnt(short8 x)
        {
            return (short8)lzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 lzcnt(short16 x)
        {
            return (short16)lzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a uint8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lzcnt(uint8 x)
        {
            uint8 y;
            uint8 n = 32;
            uint8 mask;

            y = x >> 16;
            mask = Avx2.mm256_cmpeq_epi32(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 16, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 8;
            mask = Avx2.mm256_cmpeq_epi32(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 8, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 4;
            mask = Avx2.mm256_cmpeq_epi32(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 4, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 2;
            mask = Avx2.mm256_cmpeq_epi32(y, default(v256));
            n = Avx2.mm256_blendv_epi8(n - 2, n, mask);
            x = Avx2.mm256_blendv_epi8(y, x, mask);

            y = x >> 1;
            mask = Avx2.mm256_cmpeq_epi32(y, default(v256));

            return Avx2.mm256_blendv_epi8(n - 2, n - x, mask);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an int8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzcnt(int8 x)
        {
            return (int8)lzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lzcnt(ulong2 x)
        {
            return new ulong2((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lzcnt(ulong3 x)
        {
            return new ulong3((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lzcnt(ulong4 x)
        {
            ulong4 y = x >> 32;
            ulong4 cmp = Avx2.mm256_cmpeq_epi64(y, default(v256));

            ulong4 bits = Avx2.mm256_blendv_epi8(y, 0x0000_0000_FFFF_FFFF & x, cmp);
            ulong4 offset = Avx2.mm256_blendv_epi8((ulong4)0x041E, (ulong4)0x043E, cmp);

            bits += 0x4330_0000_0000_0000ul;
            bits = Avx.mm256_sub_pd(bits, new v256(4503599627370496d));
            bits = offset - bits >> 52;

            return Avx2.mm256_blendv_epi8(bits, new ulong4(64), Avx2.mm256_cmpeq_epi64(x, default(v256)));
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 lzcnt(long2 x)
        {
            return (long2)lzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 lzcnt(long3 x)
        {
            return (long3)lzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 lzcnt(long4 x)
        {
            return (long4)lzcnt((ulong4)x);
        }
    }
}