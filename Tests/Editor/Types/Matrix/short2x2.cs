using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_short2x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 2;


        [Test]
        public static void op_UnaryNegation()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 test = -l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], -l[j]);
                }
            }
        }

        [Test]
        public static void op_Increment()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 test = l;
                test++;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + 1);
                }
            }
        }

        [Test]
        public static void op_Decrement()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 test = l;
                test--;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - 1);
                }
            }
        }

        [Test]
        public static void op_Addition()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l + r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + r[j]);
                }
            }
        }

        [Test]
        public static void op_Subtraction()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l - r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short r = rng.NextShort();

                short2x2 testL = l * r;
                short2x2 testR = r * l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] * r);
                    Assert.AreEqual(testR[j], r * l[j]);
                }
            }
        }

        [Test]
        public static void op_Division()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short2x2 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short r = rng.NextShort();
                r = (short)(r == 0 ? 1 : r);

                short2x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short l = rng.NextShort();

                short2x2 testR = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l / r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short2x2 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short r = rng.NextShort();
                r = (short)(r == 0 ? 1 : r);

                short2x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short l = rng.NextShort();

                short2x2 testR = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l % r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseAnd()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l & r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] & r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseOr()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l | r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] | r[j]);
                }
            }
        }

        [Test]
        public static void op_OnesComplement()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = ~l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], ~l[j]);
                }
            }
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                short2x2 test = l ^ r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] ^ r[j]);
                }
            }
        }

        [Test]
        public static void op_LeftShift_int()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short r = rng.NextShort(0, 16);

                short2x2 test = l << r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] << r);
                }
            }
        }

        [Test]
        public static void op_RightShift_int()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short r = rng.NextShort(0, 16);

                short2x2 test = l >> r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >> r);
                }
            }
        }


        [Test]
        public static void op_Equality()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l == r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] == r[j]);
                }
            }
        }

        [Test]
        public static void op_Inequality()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l != r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] != r[j]);
                }
            }
        }

        [Test]
        public static void op_LessThan()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l < r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] < r[j]);
                }
            }
        }

        [Test]
        public static void op_GreaterThan()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l > r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] > r[j]);
                }
            }
        }

        [Test]
        public static void op_LessThanOrEqual()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l <= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] <= r[j]);
                }
            }
        }

        [Test]
        public static void op_GreaterThanOrEqual()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool2x2 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short x = rng.NextShort();

                short2x2 test = x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    for (int k = 0; k < ROWS; k++)
                    {
                        Assert.AreEqual(test[j][k], x);
                    }
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2x2 x = new ushort2x2(rng.NextUShort2(), rng.NextUShort2());

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2x2 x = new int2x2(rng.NextInt2(), rng.NextInt2());

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2x2 x = new uint2x2(rng.NextUInt2(), rng.NextUInt2());

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x2 x = new long2x2(rng.NextLong2(), rng.NextLong2());

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 x = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2x2 x = new float2x2(rng.NextFloat2(2f * short.MinValue, 2f * short.MaxValue), rng.NextFloat2(2f * short.MinValue, 2f * short.MaxValue));

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2x2 x = new double2x2(rng.NextDouble2(2d * short.MinValue, 2d* short.MaxValue), rng.NextDouble2(2d * short.MinValue, 2d* short.MaxValue));

                short2x2 test = (short2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                int2x2 test = (int2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                uint2x2 test = (uint2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                long2x2 test = (long2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                float2x2 test = (float2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double2x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 x = new short2x2(rng.NextShort2(), rng.NextShort2());

                double2x2 test = (double2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double2)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x2 l = new short2x2(rng.NextShort2(), rng.NextShort2());
                short2x2 r = new short2x2(rng.NextShort2(), rng.NextShort2());

                bool test = l.Equals(r);
                bool cmp = true;

                for (int j = 0; j < COLUMNS; j++)
                {
                    cmp &= l[j].Equals(r[j]);
                }

                Assert.AreEqual(test, cmp);
                Assert.IsTrue(l.Equals(l));
            }
        }


        [Test]
        public static void get_Item_int()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2* columns = stackalloc short2[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextShort2();
                }

                short2x2 test = new short2x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}