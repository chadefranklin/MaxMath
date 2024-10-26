using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blci_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(inc_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blci_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(inc_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blci_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(inc_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blci_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(inc_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blci_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(mm256_inc_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blci_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(mm256_inc_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blci_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(mm256_inc_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blci_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(mm256_inc_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_surroundlowest0(UInt128 x)
        {
            return x | ~(x + 1);
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_surroundlowest0(Int128 x)
        {
            return (Int128)bits_surroundlowest0((UInt128)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_surroundlowest0(byte x)
        {
            return (byte)bits_surroundlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_surroundlowest0(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi8(x);
            }
            else
            {
                return new byte2(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_surroundlowest0(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi8(x);
            }
            else
            {
                return new byte3(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_surroundlowest0(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi8(x);
            }
            else
            {
                return new byte4(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z), bits_surroundlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_surroundlowest0(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi8(x);
            }
            else
            {
                return new byte8(bits_surroundlowest0(x.x0),
                                 bits_surroundlowest0(x.x1),
                                 bits_surroundlowest0(x.x2),
                                 bits_surroundlowest0(x.x3),
                                 bits_surroundlowest0(x.x4),
                                 bits_surroundlowest0(x.x5),
                                 bits_surroundlowest0(x.x6),
                                 bits_surroundlowest0(x.x7));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_surroundlowest0(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi8(x);
            }
            else
            {
                return new byte16(bits_surroundlowest0(x. x0),
                                  bits_surroundlowest0(x. x1),
                                  bits_surroundlowest0(x. x2),
                                  bits_surroundlowest0(x. x3),
                                  bits_surroundlowest0(x. x4),
                                  bits_surroundlowest0(x. x5),
                                  bits_surroundlowest0(x. x6),
                                  bits_surroundlowest0(x. x7),
                                  bits_surroundlowest0(x. x8),
                                  bits_surroundlowest0(x. x9),
                                  bits_surroundlowest0(x.x10),
                                  bits_surroundlowest0(x.x11),
                                  bits_surroundlowest0(x.x12),
                                  bits_surroundlowest0(x.x13),
                                  bits_surroundlowest0(x.x14),
                                  bits_surroundlowest0(x.x15));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_surroundlowest0(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blci_epi8(x);
            }
            else
            {
                return new byte32(bits_surroundlowest0(x.v16_0), bits_surroundlowest0(x.v16_16));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_surroundlowest0(sbyte x)
        {
            return (sbyte)bits_surroundlowest0((byte)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_surroundlowest0(sbyte2 x)
        {
            return (sbyte2)bits_surroundlowest0((byte2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_surroundlowest0(sbyte3 x)
        {
            return (sbyte3)bits_surroundlowest0((byte3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_surroundlowest0(sbyte4 x)
        {
            return (sbyte4)bits_surroundlowest0((byte4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_surroundlowest0(sbyte8 x)
        {
            return (sbyte8)bits_surroundlowest0((byte8)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_surroundlowest0(sbyte16 x)
        {
            return (sbyte16)bits_surroundlowest0((byte16)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_surroundlowest0(sbyte32 x)
        {
            return (sbyte32)bits_surroundlowest0((byte32)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_surroundlowest0(ushort x)
        {
            return (ushort)bits_surroundlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_surroundlowest0(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi16(x);
            }
            else
            {
                return new ushort2(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_surroundlowest0(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi16(x);
            }
            else
            {
                return new ushort3(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_surroundlowest0(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi16(x);
            }
            else
            {
                return new ushort4(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z), bits_surroundlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_surroundlowest0(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi16(x);
            }
            else
            {
                return new ushort8(bits_surroundlowest0(x.x0),
                                   bits_surroundlowest0(x.x1),
                                   bits_surroundlowest0(x.x2),
                                   bits_surroundlowest0(x.x3),
                                   bits_surroundlowest0(x.x4),
                                   bits_surroundlowest0(x.x5),
                                   bits_surroundlowest0(x.x6),
                                   bits_surroundlowest0(x.x7));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_surroundlowest0(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blci_epi16(x);
            }
            else
            {
                return new ushort16(bits_surroundlowest0(x.v8_0), bits_surroundlowest0(x.v8_8));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_surroundlowest0(short x)
        {
            return (short)bits_surroundlowest0((ushort)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_surroundlowest0(short2 x)
        {
            return (short2)bits_surroundlowest0((ushort2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_surroundlowest0(short3 x)
        {
            return (short3)bits_surroundlowest0((ushort3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_surroundlowest0(short4 x)
        {
            return (short4)bits_surroundlowest0((ushort4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_surroundlowest0(short8 x)
        {
            return (short8)bits_surroundlowest0((ushort8)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_surroundlowest0(short16 x)
        {
            return (short16)bits_surroundlowest0((ushort16)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_surroundlowest0(uint x)
        {
            return x | ~(x + 1);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_surroundlowest0(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blci_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_surroundlowest0(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blci_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_surroundlowest0(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blci_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y), bits_surroundlowest0(x.z), bits_surroundlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_surroundlowest0(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blci_epi32(x);
            }
            else
            {
                return new uint8(bits_surroundlowest0(x.v4_0), bits_surroundlowest0(x.v4_4));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_surroundlowest0(int x)
        {
            return (int)bits_surroundlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_surroundlowest0(int2 x)
        {
            return (int2)bits_surroundlowest0((uint2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_surroundlowest0(int3 x)
        {
            return (int3)bits_surroundlowest0((uint3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_surroundlowest0(int4 x)
        {
            return (int4)bits_surroundlowest0((uint4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_surroundlowest0(int8 x)
        {
            return (int8)bits_surroundlowest0((uint8)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_surroundlowest0(ulong x)
        {
            return x | ~(x + 1);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_surroundlowest0(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blci_epi64(x);
            }
            else
            {
                return new ulong2(bits_surroundlowest0(x.x), bits_surroundlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_surroundlowest0(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blci_epi64(x);
            }
            else
            {
                return new ulong3(bits_surroundlowest0(x.xy), bits_surroundlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_surroundlowest0(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blci_epi64(x);
            }
            else
            {
                return new ulong4(bits_surroundlowest0(x.xy), bits_surroundlowest0(x.zw));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_surroundlowest0(long x)
        {
            return (long)bits_surroundlowest0((ulong)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_surroundlowest0(long2 x)
        {
            return (long2)bits_surroundlowest0((ulong2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_surroundlowest0(long3 x)
        {
            return (long3)bits_surroundlowest0((ulong3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_surroundlowest0(long4 x)
        {
            return (long4)bits_surroundlowest0((ulong4)x);
        }
    }
}
