using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi8(v128 a, v128 s, bool promise = false, byte elements = 16)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI8(s, 0, elements)))
                    {
                        s = Sse2.sub_epi8(s, Sse2.cmpeq_epi8(s, Sse2.setzero_si128()));
                    }

                    return Ssse3.sign_epi8(abs_epi8(a, elements), s);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 res = Sse2.xor_si128(a, s);
                    res = srai_epi8(res, 7);

                    return Sse2.sub_epi8(Sse2.xor_si128(a, res), res);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi8(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI8(s, 0)))
                    {
                        s = Avx2.mm256_sub_epi8(s, Avx2.mm256_cmpeq_epi8(s, Avx.mm256_setzero_si256()));
                    }

                    return Avx2.mm256_sign_epi8(mm256_abs_epi8(a), s);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi16(v128 a, v128 s, bool promise = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(a, 1, elements) || constexpr.ALL_EQ_EPI16(a, -1, elements))
                    {
                        return Sse2.or_si128(Sse2.set1_epi16(1), Sse2.srai_epi16(s, 15));
                    }
                    else if (Ssse3.IsSsse3Supported)
                    {
                        if (!(promise || constexpr.ALL_NEQ_EPI16(s, 0, elements)))
                        {
                            s = Sse2.sub_epi16(s, Sse2.cmpeq_epi16(s, Sse2.setzero_si128()));
                        }

                        return Ssse3.sign_epi16(abs_epi16(a, elements), s);
                    }
                    else
                    {
                        v128 res = Sse2.xor_si128(a, s);
                        res = Sse2.srai_epi16(res, 15);

                        return Sse2.sub_epi16(Sse2.xor_si128(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi16(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(a, 1) || constexpr.ALL_EQ_EPI16(a, -1))
                    {
                        return Avx2.mm256_or_si256(Avx.mm256_set1_epi16(1), Avx2.mm256_srai_epi16(s, 15));
                    }
                    else
                    {
                        if (!(promise || constexpr.ALL_NEQ_EPI16(s, 0)))
                        {
                            s = Avx2.mm256_sub_epi16(s, Avx2.mm256_cmpeq_epi16(s, Avx.mm256_setzero_si256()));
                        }

                        return Avx2.mm256_sign_epi16(mm256_abs_epi16(a), s);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi32(v128 a, v128 s, bool promise = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 1, elements) || constexpr.ALL_EQ_EPI32(a, -1, elements))
                    {
                        return Sse2.or_si128(Sse2.set1_epi32(1), Sse2.srai_epi32(s, 31));
                    }
                    else if (Ssse3.IsSsse3Supported)
                    {
                        if (!(promise || constexpr.ALL_NEQ_EPI32(s, 0, elements)))
                        {
                            s = Sse2.sub_epi32(s, Sse2.cmpeq_epi32(s, Sse2.setzero_si128()));
                        }

                        return Ssse3.sign_epi32(abs_epi32(a, elements), s);
                    }
                    else
                    {
                        v128 res = Sse2.xor_si128(a, s);
                        res = Sse2.srai_epi32(res, 31);

                        return Sse2.sub_epi32(Sse2.xor_si128(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi32(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 1) || constexpr.ALL_EQ_EPI32(a, -1))
                    {
                        return Avx2.mm256_or_si256(Avx.mm256_set1_epi32(1), Avx2.mm256_srai_epi32(s, 31));
                    }
                    else
                    {
                        if (!(promise || constexpr.ALL_NEQ_EPI32(s, 0)))
                        {
                            s = Avx2.mm256_sub_epi32(s, Avx2.mm256_cmpeq_epi32(s, Avx.mm256_setzero_si256()));
                        }
                        
                        return Avx2.mm256_sign_epi32(mm256_abs_epi32(a), s);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi64(v128 a, v128 s)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 1) || constexpr.ALL_EQ_EPI64(a, -1))
                    {
                        return Sse2.or_si128(Sse2.set1_epi64x(1), srai_epi64(s, 63));
                    }
                    else
                    {
                        v128 res = Sse2.xor_si128(a, s);
                        res = srai_epi64(res, 63);

                        return Sse2.sub_epi64(Sse2.xor_si128(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi64(v256 a, v256 s, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 1, elements) || constexpr.ALL_EQ_EPI64(a, -1, elements))
                    {
                        return Avx2.mm256_or_si256(Avx.mm256_set1_epi64x(1), mm256_srai_epi64(s, 63));
                    }
                    else
                    {
                        v256 res = Avx2.mm256_xor_si256(a, s);
                        res = mm256_srai_epi64(res, 63);

                        return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pq(v128 a, v128 s, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.set1_epi8(unchecked((sbyte)(1 << 7)));

                    if (!promise)
                    {
                        v128 isZero = Sse2.cmpeq_epi8(Sse2.and_si128(s, Sse2.set1_epi8(0x7F)), Sse2.setzero_si128());

                        s = Sse2.andnot_si128(isZero, srai_epi8(s, 7));
                    }
                     
                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ph(v128 a, v128 s, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.set1_epi16(unchecked((short)(1 << 15)));

                    if (!promise)
                    {
                        v128 isZero = Sse2.cmpeq_epi16(Sse2.and_si128(s, Sse2.set1_epi16(0x7FFF)), Sse2.setzero_si128());

                        s = Sse2.andnot_si128(isZero, Sse2.srai_epi16(s, 15));
                    }
                     
                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ps(v128 a, v128 s, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(1 << 31);

                    if (!promise)
                    {
                        s = Sse.cmplt_ps(s, Sse.setzero_ps());
                    }
                     
                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_ps(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1 << 31);
                    
                    if (!promise)
                    {
                        s = Avx.mm256_cmp_ps(s, Avx.mm256_setzero_ps(), (int)Avx.CMP.LT_OQ);
                    }
                     
                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pd(v128 a, v128 s, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(1L << 63);

                    if (!promise)
                    {
                        s = Sse2.cmplt_pd(s, Sse.setzero_ps());
                    }
                        
                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_pd(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1L << 63);
                    
                    if (!promise)
                    {
                        s = Avx.mm256_cmp_pd(s, Avx.mm256_setzero_pd(), (int)Avx.CMP.LT_OQ);
                    }
                        
                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 copysign(Int128 x, Int128 y)
        {
            ulong temp = (ulong)((long)(x.hi64 ^ y.hi64) >> 63);
            ulong lo = x.lo64 ^ temp;
            ulong hi = x.hi64 ^ temp;
            ulong loResult = lo - temp;
            ulong hiResult = hi - temp;
            hiResult -= tobyte(lo < temp);
            
            return new Int128(loResult, hiResult);
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte copysign(sbyte x, sbyte y)
        {
            return (sbyte)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 copysign(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                sbyte2 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 copysign(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                sbyte3 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 copysign(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                sbyte4 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 copysign(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                sbyte8 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 copysign(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                sbyte16 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 copysign(sbyte32 x, sbyte32 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi8(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte32(copysign(x.v16_0, y.v16_0, nonZero), copysign(x.v16_16, y.v16_16, nonZero));
            }
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short copysign(short x, short y)
        {
            return (short)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 copysign(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else 
            {
                short2 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 copysign(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else 
            {
                short3 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 copysign(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else 
            {
                short4 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 copysign(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else 
            {
                short8 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 copysign(short16 x, short16 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi16(x, y, nonZero.Promises(Promise.NonZero));
            }
            else 
            {
                return new short16(copysign(x.v8_0, y.v8_0, nonZero), copysign(x.v8_8, y.v8_8, nonZero));
            }
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int copysign(int x, int y)
        {
            if (Xse.constexpr.IS_TRUE(x == 1 || x == -1))
            {
                return (y >> 31) | 1;
            }

            int temp = (x ^ y) >> 31;

            return (x ^ temp) - temp;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 copysign(int2 x, int2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 2));
            }
            else
            {
                int2 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 copysign(int3 x, int3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 3));
            }
            else
            {
                int3 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 copysign(int4 x, int4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 4));
            }
            else
            {
                int4 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 copysign(int8 x, int8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi32(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new int8(copysign(x.v4_0, y.v4_0, nonZero), copysign(x.v4_4, y.v4_4, nonZero));
            }
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long copysign(long x, long y)
        {
            if (Xse.constexpr.IS_TRUE(x == 1 || x == -1))
            {
                return (y >> 63) | 1;
            }

            long temp = (x ^ y) >> 63;

            return (x ^ temp) - temp;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 copysign(long2 x, long2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_epi64(x, y);
            }
            else
            {
                long2 temp = (x ^ y) >> 63;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 copysign(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 3);
            }
            else
            {
                return new long3(copysign(x.xy, y.xy), copysign(x.z, y.z));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 copysign(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 4);
            }
            else
            {
                return new long4(copysign(x.xy, y.xy), copysign(x.zw, y.zw));
            }
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter copysign(quarter x, quarter y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Xse.movsign_pq(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).Byte0);
            }
            else
            {
                const byte SIGN_MASK = 1 << 7;
                const byte VALUE_MASK = unchecked((byte)(~SIGN_MASK));

                byte _x = asbyte(x);
                byte _y = asbyte(y);

                uint xAbs = (uint)_x & (uint)VALUE_MASK;
                uint ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = SIGN_MASK & (uint)_y;
                }
                else
                {
                    uint yIsNotZero = (uint)(-toint(y != 0));
                    ySign = (yIsNotZero & SIGN_MASK) & _y;
                }

                return asquarter((byte)(xAbs | ySign));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 copysign(quarter2 x, quarter2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<quarter2>(Xse.movsign_pq(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new quarter2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 copysign(quarter3 x, quarter3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<quarter3>(Xse.movsign_pq(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new quarter3(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 copysign(quarter4 x, quarter4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<quarter4>(Xse.movsign_pq(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new quarter4(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero), copysign(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 copysign(quarter8 x, quarter8 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<quarter8>(Xse.movsign_pq(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new quarter8(copysign(x.x0, y.x0, nonZero), copysign(x.x1, y.x1, nonZero), copysign(x.x2, y.x2, nonZero), copysign(x.x3, y.x3, nonZero), copysign(x.x4, y.x4, nonZero), copysign(x.x5, y.x5, nonZero), copysign(x.x6, y.x6, nonZero), copysign(x.x7, y.x7, nonZero));
            }
        }

        
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half copysign(half x, half y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return new half{ value = Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).UShort0 };
            }
            else
            {
                const ushort SIGN_MASK = 1 << 15;
                const ushort VALUE_MASK = unchecked((ushort)(~SIGN_MASK));

                ushort _x = asushort(x);
                ushort _y = asushort(y);

                uint xAbs = (uint)_x & (uint)VALUE_MASK;
                uint ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = SIGN_MASK & (uint)_y;
                }
                else
                {
                    uint yIsNotZero = (uint)(-toint(y != 0));
                    ySign = (yIsNotZero & SIGN_MASK) & _y;
                }

                return ashalf((ushort)(xAbs | ySign));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 copysign(half2 x, half2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<half2>(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 copysign(half3 x, half3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<half3>(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half3(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 copysign(half4 x, half4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<half4>(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half4(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero), copysign(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 copysign(half8 x, half8 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<half8>(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half8(copysign(x.x0, y.x0, nonZero), copysign(x.x1, y.x1, nonZero), copysign(x.x2, y.x2, nonZero), copysign(x.x3, y.x3, nonZero), copysign(x.x4, y.x4, nonZero), copysign(x.x5, y.x5, nonZero), copysign(x.x6, y.x6, nonZero), copysign(x.x7, y.x7, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float copysign(float x, float y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).Float0;
            }
            else
            {
                const uint SIGN_MASK = 1u << 31;
                const uint VALUE_MASK = ~SIGN_MASK;

                uint _x = math.asuint(x);
                uint _y = math.asuint(y);

                uint xAbs = _x & VALUE_MASK;
                uint ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = SIGN_MASK & _y;
                }
                else
                {
                    uint yIsNotZero = (uint)(-toint(y != 0));
                    ySign = (yIsNotZero & SIGN_MASK) & _y;
                }

                return math.asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 copysign(float2 x, float2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float2>(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                uint2 MASK = 1u << 31;

                uint2 _x = math.asuint(x);
                uint2 _y = math.asuint(y);

                uint2 xAbs = andnot(_x, MASK);
                uint2 ySign;

                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    uint2 yIsNotZero = (uint2)(-toint(y != 0));
                    ySign = (yIsNotZero & MASK) & _y;
                }

                return math.asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 copysign(float3 x, float3 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float3>(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                uint3 MASK = 1u << 31;

                uint3 _x = math.asuint(x);
                uint3 _y = math.asuint(y);
                    
                uint3 xAbs = andnot(_x, MASK);
                uint3 ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    uint3 yIsNotZero = (uint3)(-toint(y != 0));
                    ySign = (yIsNotZero & MASK) & _y;
                }

                return math.asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 copysign(float4 x, float4 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float4>(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                uint4 MASK = 1u << 31;
                    
                uint4 _x = math.asuint(x);
                uint4 _y = math.asuint(y);
                    
                uint4 xAbs = andnot(_x, MASK);
                uint4 ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    uint4 yIsNotZero = (uint4)(-toint(y != 0));
                    ySign = (yIsNotZero & MASK) & _y;
                }

                return math.asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 copysign(float8 x, float8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_movsign_ps(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new float8(copysign(x.v4_0, y.v4_0, nonZero),
                                  copysign(x.v4_4, y.v4_4, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double copysign(double x, double y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.movsign_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).Double0;
            }
            else
            {
                const ulong MASK = 1ul << 63;

                ulong _x = math.asulong(x);
                ulong _y = math.asulong(y);

                ulong xAbs = andnot(_x, MASK);
                ulong ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    ulong yIsNotZero = (ulong)(-tolong(y != 0));
                    ySign = (yIsNotZero & MASK) & _y;
                }

                return math.asdouble(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 copysign(double2 x, double2 y, Promise nonZero = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<double2>(Xse.movsign_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                ulong2 MASK = 1ul << 63;

                ulong2 _x = asulong(x);
                ulong2 _y = asulong(y);

                ulong2 xAbs = andnot(_x, MASK);
                ulong2 ySign;
                
                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    ulong2 yIsNotZero = (ulong2)(-tolong(y != 0));
                    ySign = (yIsNotZero & MASK) & _y;
                }

                return asdouble(xAbs | ySign);
            }
        }
        
        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 copysign(double3 x, double3 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToType<double3>(Xse.mm256_movsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new double3(copysign(x.xy, y.xy, nonZero),
                                   copysign(x.z,  y.z,  nonZero));
            }
        }
        
        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.      </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 copysign(double4 x, double4 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToType<double4>(Xse.mm256_movsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new double4(copysign(x.xy, y.xy, nonZero),
                                   copysign(x.zw, y.zw, nonZero));
            }
        }
    }
}