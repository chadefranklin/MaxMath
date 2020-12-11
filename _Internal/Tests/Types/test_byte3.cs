﻿using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class Byte3
    {
        internal const int NUM_TESTS = 4;


        internal static byte3[] TestData_LHS => new byte3[]
        {
            new byte3{ x = 143,
	                   y = 55,
	                   z = 99 },
	
            new byte3{ x = 22,
	                   y = 12,
	                   z = 16},
	      // EQUAL
            new byte3{ x = 47,
	                   y = byte.MaxValue,
	                   z = 17},
	
            new byte3{ x = byte.MinValue,
	                   y = 13,
	                   z = 111 }
        };

        internal static byte3[] TestData_RHS => new byte3[]
        {
            new byte3{ x = 12,
	                   y = 4,
	                   z = 53},
	
            new byte3{ x = 22,
	                   y = 12,
	                   z = 16 },
	      // EQUAL
            new byte3{ x = 17,
	                   y = 47,
	                   z = 9 },
	
            new byte3{ x = 2,
	                   y = 9,
	                   z = 200 }
        };


        [UnitTest("Types", "byte3")]
        public static bool Constructor_Byte_Byte_Byte()
        {
            byte3 x = new byte3(TestData_LHS[0].x, TestData_LHS[0].y, TestData_LHS[0].z);

            return x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z;
        }

        [UnitTest("Types", "byte3")]
        public static bool Constructor_Byte()
        {
            byte3 x = new byte3(TestData_LHS[0].x);

            return x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].x &
                   x.z == TestData_LHS[0].x;
        }

        [UnitTest("Types", "byte3")]
        public static bool Constructor_Byte2_Byte()
        {
            byte3 x = new byte3(new byte2(TestData_LHS[0].x, TestData_LHS[0].y), TestData_LHS[0].z);

            return x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z;
        }

        [UnitTest("Types", "byte3")]
        public static bool Constructor_Byte_Byte2()
        {
            byte3 x = new byte3(TestData_LHS[0].x, new byte2(TestData_LHS[0].y, TestData_LHS[0].z));

            return x.x == TestData_LHS[0].x & 
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z;
        }

        [UnitTest("Types", "byte3")]
        public static bool Indexer()
        {
            return TestData_LHS[0][0] == TestData_LHS[0].x &
                   TestData_LHS[0][1] == TestData_LHS[0].y &
                   TestData_LHS[0][2] == TestData_LHS[0].z;
        }


        [UnitTest("Types", "byte3")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x + TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y + TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z + TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x - TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y - TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z - TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x * TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y * TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z * TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x / TestData_RHS[i].x) &
                          x.y == (byte)(TestData_LHS[i].y / TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z / TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x % TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y % TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z % TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x & TestData_RHS[i].x) &
                          x.y == (byte)(TestData_LHS[i].y & TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z & TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x | TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y | TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z | TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x == (byte)(TestData_LHS[i].x ^ TestData_RHS[i].x) & 
                          x.y == (byte)(TestData_LHS[i].y ^ TestData_RHS[i].y) &
                          x.z == (byte)(TestData_LHS[i].z ^ TestData_RHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = ~TestData_LHS[i];

                result &= x.x == (byte)(~TestData_LHS[i].x) & 
                          x.y == (byte)(~TestData_LHS[i].y) &
                          x.z == (byte)(~TestData_LHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j  < 8; j++)
                {
                    byte3 x = TestData_LHS[i] << j;

                    result &= x.x == (byte)(TestData_LHS[i].x << j) & 
                              x.y == (byte)(TestData_LHS[i].y << j) &
                              x.z == (byte)(TestData_LHS[i].z << j);
                }
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j  < 8; j++)
                {
                    byte3 x = TestData_LHS[i] >> j;

                    result &= x.x == (byte)(TestData_LHS[i].x >> j) &
                              x.y == (byte)(TestData_LHS[i].y >> j) &
                              x.z == (byte)(TestData_LHS[i].z >> j);
                }
            }

            return result;
        }


        [UnitTest("Types", "byte3")]
        public static bool Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x == TestData_RHS[i].x,
                                             TestData_LHS[i].y == TestData_RHS[i].y,
                                             TestData_LHS[i].z == TestData_RHS[i].z));
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x < TestData_RHS[i].x,
                                             TestData_LHS[i].y < TestData_RHS[i].y,
                                             TestData_LHS[i].z < TestData_RHS[i].z));
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x > TestData_RHS[i].x,
                                             TestData_LHS[i].y > TestData_RHS[i].y,
                                             TestData_LHS[i].z > TestData_RHS[i].z));
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x != TestData_RHS[i].x,
                                             TestData_LHS[i].y != TestData_RHS[i].y,
                                             TestData_LHS[i].z != TestData_RHS[i].z));
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x <= TestData_RHS[i].x,
                                             TestData_LHS[i].y <= TestData_RHS[i].y,
                                             TestData_LHS[i].z <= TestData_RHS[i].z));
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool3(TestData_LHS[i].x >= TestData_RHS[i].x,
                                             TestData_LHS[i].y >= TestData_RHS[i].y,
                                             TestData_LHS[i].z >= TestData_RHS[i].z));
            }

            return result;
        }


        [UnitTest("Types", "byte3")]
        public static bool AllEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool x = TestData_LHS[i].Equals(TestData_RHS[i]);

                result &= x == math.all(new bool3(TestData_LHS[i].x == TestData_RHS[i].x,
                                                  TestData_LHS[i].y == TestData_RHS[i].y,
                                                  TestData_LHS[i].z == TestData_RHS[i].z));
            }

            return result;
        }


        [UnitTest("Types", "byte3")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte4 xxxx = TestData_LHS[i].xxxx;
                result &= xxxx.x == TestData_LHS[i].x &
                          xxxx.y == TestData_LHS[i].x &
                          xxxx.z == TestData_LHS[i].x &
                          xxxx.w == TestData_LHS[i].x;

                byte4 xxxy = TestData_LHS[i].xxxy;
                result &= xxxy.x == TestData_LHS[i].x &
                          xxxy.y == TestData_LHS[i].x &
                          xxxy.z == TestData_LHS[i].x &
                          xxxy.w == TestData_LHS[i].y;

                byte4 xxxz = TestData_LHS[i].xxxz;
                result &= xxxz.x == TestData_LHS[i].x &
                          xxxz.y == TestData_LHS[i].x &
                          xxxz.z == TestData_LHS[i].x &
                          xxxz.w == TestData_LHS[i].z;

                byte4 xxyx = TestData_LHS[i].xxyx;
                result &= xxyx.x == TestData_LHS[i].x &
                          xxyx.y == TestData_LHS[i].x &
                          xxyx.z == TestData_LHS[i].y &
                          xxyx.w == TestData_LHS[i].x;

                byte4 xxyy = TestData_LHS[i].xxyy;
                result &= xxyy.x == TestData_LHS[i].x &
                          xxyy.y == TestData_LHS[i].x &
                          xxyy.z == TestData_LHS[i].y &
                          xxyy.w == TestData_LHS[i].y;

                byte4 xxyz = TestData_LHS[i].xxyz;
                result &= xxyz.x == TestData_LHS[i].x &
                          xxyz.y == TestData_LHS[i].x &
                          xxyz.z == TestData_LHS[i].y &
                          xxyz.w == TestData_LHS[i].z;

                byte4 xxzx = TestData_LHS[i].xxzx;
                result &= xxzx.x == TestData_LHS[i].x &
                          xxzx.y == TestData_LHS[i].x &
                          xxzx.z == TestData_LHS[i].z &
                          xxzx.w == TestData_LHS[i].x;

                byte4 xxzy = TestData_LHS[i].xxzy;
                result &= xxzy.x == TestData_LHS[i].x &
                          xxzy.y == TestData_LHS[i].x &
                          xxzy.z == TestData_LHS[i].z &
                          xxzy.w == TestData_LHS[i].y;

                byte4 xxzz = TestData_LHS[i].xxzz;
                result &= xxzz.x == TestData_LHS[i].x &
                          xxzz.y == TestData_LHS[i].x &
                          xxzz.z == TestData_LHS[i].z &
                          xxzz.w == TestData_LHS[i].z;

                byte4 xyxx = TestData_LHS[i].xyxx;
                result &= xyxx.x == TestData_LHS[i].x &
                          xyxx.y == TestData_LHS[i].y &
                          xyxx.z == TestData_LHS[i].x &
                          xyxx.w == TestData_LHS[i].x;

                byte4 xyxy = TestData_LHS[i].xyxy;
                result &= xyxy.x == TestData_LHS[i].x &
                          xyxy.y == TestData_LHS[i].y &
                          xyxy.z == TestData_LHS[i].x &
                          xyxy.w == TestData_LHS[i].y;

                byte4 xyxz = TestData_LHS[i].xyxz;
                result &= xyxz.x == TestData_LHS[i].x &
                          xyxz.y == TestData_LHS[i].y &
                          xyxz.z == TestData_LHS[i].x &
                          xyxz.w == TestData_LHS[i].z;

                byte4 xyyx = TestData_LHS[i].xyyx;
                result &= xyyx.x == TestData_LHS[i].x &
                          xyyx.y == TestData_LHS[i].y &
                          xyyx.z == TestData_LHS[i].y &
                          xyyx.w == TestData_LHS[i].x;

                byte4 xyyy = TestData_LHS[i].xyyy;
                result &= xyyy.x == TestData_LHS[i].x &
                          xyyy.y == TestData_LHS[i].y &
                          xyyy.z == TestData_LHS[i].y &
                          xyyy.w == TestData_LHS[i].y;

                byte4 xyyz = TestData_LHS[i].xyyz;
                result &= xyyz.x == TestData_LHS[i].x &
                          xyyz.y == TestData_LHS[i].y &
                          xyyz.z == TestData_LHS[i].y &
                          xyyz.w == TestData_LHS[i].z;

                byte4 xyzx = TestData_LHS[i].xyzx;
                result &= xyzx.x == TestData_LHS[i].x &
                          xyzx.y == TestData_LHS[i].y &
                          xyzx.z == TestData_LHS[i].z &
                          xyzx.w == TestData_LHS[i].x;

                byte4 xyzy = TestData_LHS[i].xyzy;
                result &= xyzy.x == TestData_LHS[i].x &
                          xyzy.y == TestData_LHS[i].y &
                          xyzy.z == TestData_LHS[i].z &
                          xyzy.w == TestData_LHS[i].y;

                byte4 xyzz = TestData_LHS[i].xyzz;
                result &= xyzz.x == TestData_LHS[i].x &
                          xyzz.y == TestData_LHS[i].y &
                          xyzz.z == TestData_LHS[i].z &
                          xyzz.w == TestData_LHS[i].z;

                byte4 xzxx = TestData_LHS[i].xzxx;
                result &= xzxx.x == TestData_LHS[i].x &
                          xzxx.y == TestData_LHS[i].z &
                          xzxx.z == TestData_LHS[i].x &
                          xzxx.w == TestData_LHS[i].x;

                byte4 xzxy = TestData_LHS[i].xzxy;
                result &= xzxy.x == TestData_LHS[i].x &
                          xzxy.y == TestData_LHS[i].z &
                          xzxy.z == TestData_LHS[i].x &
                          xzxy.w == TestData_LHS[i].y;

                byte4 xzxz = TestData_LHS[i].xzxz;
                result &= xzxz.x == TestData_LHS[i].x &
                          xzxz.y == TestData_LHS[i].z &
                          xzxz.z == TestData_LHS[i].x &
                          xzxz.w == TestData_LHS[i].z;

                byte4 xzyx = TestData_LHS[i].xzyx;
                result &= xzyx.x == TestData_LHS[i].x &
                          xzyx.y == TestData_LHS[i].z &
                          xzyx.z == TestData_LHS[i].y &
                          xzyx.w == TestData_LHS[i].x;

                byte4 xzyy = TestData_LHS[i].xzyy;
                result &= xzyy.x == TestData_LHS[i].x &
                          xzyy.y == TestData_LHS[i].z &
                          xzyy.z == TestData_LHS[i].y &
                          xzyy.w == TestData_LHS[i].y;

                byte4 xzyz = TestData_LHS[i].xzyz;
                result &= xzyz.x == TestData_LHS[i].x &
                          xzyz.y == TestData_LHS[i].z &
                          xzyz.z == TestData_LHS[i].y &
                          xzyz.w == TestData_LHS[i].z;

                byte4 xzzx = TestData_LHS[i].xzzx;
                result &= xzzx.x == TestData_LHS[i].x &
                          xzzx.y == TestData_LHS[i].z &
                          xzzx.z == TestData_LHS[i].z &
                          xzzx.w == TestData_LHS[i].x;

                byte4 xzzy = TestData_LHS[i].xzzy;
                result &= xzzy.x == TestData_LHS[i].x &
                          xzzy.y == TestData_LHS[i].z &
                          xzzy.z == TestData_LHS[i].z &
                          xzzy.w == TestData_LHS[i].y;

                byte4 xzzz = TestData_LHS[i].xzzz;
                result &= xzzz.x == TestData_LHS[i].x &
                          xzzz.y == TestData_LHS[i].z &
                          xzzz.z == TestData_LHS[i].z &
                          xzzz.w == TestData_LHS[i].z;

                byte4 yxxx = TestData_LHS[i].yxxx;
                result &= yxxx.x == TestData_LHS[i].y &
                          yxxx.y == TestData_LHS[i].x &
                          yxxx.z == TestData_LHS[i].x &
                          yxxx.w == TestData_LHS[i].x;

                byte4 yxxy = TestData_LHS[i].yxxy;
                result &= yxxy.x == TestData_LHS[i].y &
                          yxxy.y == TestData_LHS[i].x &
                          yxxy.z == TestData_LHS[i].x &
                          yxxy.w == TestData_LHS[i].y;

                byte4 yxxz = TestData_LHS[i].yxxz;
                result &= yxxz.x == TestData_LHS[i].y &
                          yxxz.y == TestData_LHS[i].x &
                          yxxz.z == TestData_LHS[i].x &
                          yxxz.w == TestData_LHS[i].z;

                byte4 yxyx = TestData_LHS[i].yxyx;
                result &= yxyx.x == TestData_LHS[i].y &
                          yxyx.y == TestData_LHS[i].x &
                          yxyx.z == TestData_LHS[i].y &
                          yxyx.w == TestData_LHS[i].x;

                byte4 yxyy = TestData_LHS[i].yxyy;
                result &= yxyy.x == TestData_LHS[i].y &
                          yxyy.y == TestData_LHS[i].x &
                          yxyy.z == TestData_LHS[i].y &
                          yxyy.w == TestData_LHS[i].y;

                byte4 yxyz = TestData_LHS[i].yxyz;
                result &= yxyz.x == TestData_LHS[i].y &
                          yxyz.y == TestData_LHS[i].x &
                          yxyz.z == TestData_LHS[i].y &
                          yxyz.w == TestData_LHS[i].z;

                byte4 yxzx = TestData_LHS[i].yxzx;
                result &= yxzx.x == TestData_LHS[i].y &
                          yxzx.y == TestData_LHS[i].x &
                          yxzx.z == TestData_LHS[i].z &
                          yxzx.w == TestData_LHS[i].x;

                byte4 yxzy = TestData_LHS[i].yxzy;
                result &= yxzy.x == TestData_LHS[i].y &
                          yxzy.y == TestData_LHS[i].x &
                          yxzy.z == TestData_LHS[i].z &
                          yxzy.w == TestData_LHS[i].y;

                byte4 yxzz = TestData_LHS[i].yxzz;
                result &= yxzz.x == TestData_LHS[i].y &
                          yxzz.y == TestData_LHS[i].x &
                          yxzz.z == TestData_LHS[i].z &
                          yxzz.w == TestData_LHS[i].z;

                byte4 yyxx = TestData_LHS[i].yyxx;
                result &= yyxx.x == TestData_LHS[i].y &
                          yyxx.y == TestData_LHS[i].y &
                          yyxx.z == TestData_LHS[i].x &
                          yyxx.w == TestData_LHS[i].x;

                byte4 yyxy = TestData_LHS[i].yyxy;
                result &= yyxy.x == TestData_LHS[i].y &
                          yyxy.y == TestData_LHS[i].y &
                          yyxy.z == TestData_LHS[i].x &
                          yyxy.w == TestData_LHS[i].y;

                byte4 yyxz = TestData_LHS[i].yyxz;
                result &= yyxz.x == TestData_LHS[i].y &
                          yyxz.y == TestData_LHS[i].y &
                          yyxz.z == TestData_LHS[i].x &
                          yyxz.w == TestData_LHS[i].z;

                byte4 yyyx = TestData_LHS[i].yyyx;
                result &= yyyx.x == TestData_LHS[i].y &
                          yyyx.y == TestData_LHS[i].y &
                          yyyx.z == TestData_LHS[i].y &
                          yyyx.w == TestData_LHS[i].x;

                byte4 yyyy = TestData_LHS[i].yyyy;
                result &= yyyy.x == TestData_LHS[i].y &
                          yyyy.y == TestData_LHS[i].y &
                          yyyy.z == TestData_LHS[i].y &
                          yyyy.w == TestData_LHS[i].y;

                byte4 yyyz = TestData_LHS[i].yyyz;
                result &= yyyz.x == TestData_LHS[i].y &
                          yyyz.y == TestData_LHS[i].y &
                          yyyz.z == TestData_LHS[i].y &
                          yyyz.w == TestData_LHS[i].z;

                byte4 yyzx = TestData_LHS[i].yyzx;
                result &= yyzx.x == TestData_LHS[i].y &
                          yyzx.y == TestData_LHS[i].y &
                          yyzx.z == TestData_LHS[i].z &
                          yyzx.w == TestData_LHS[i].x;

                byte4 yyzy = TestData_LHS[i].yyzy;
                result &= yyzy.x == TestData_LHS[i].y &
                          yyzy.y == TestData_LHS[i].y &
                          yyzy.z == TestData_LHS[i].z &
                          yyzy.w == TestData_LHS[i].y;

                byte4 yyzz = TestData_LHS[i].yyzz;
                result &= yyzz.x == TestData_LHS[i].y &
                          yyzz.y == TestData_LHS[i].y &
                          yyzz.z == TestData_LHS[i].z &
                          yyzz.w == TestData_LHS[i].z;

                byte4 yzxx = TestData_LHS[i].yzxx;
                result &= yzxx.x == TestData_LHS[i].y &
                          yzxx.y == TestData_LHS[i].z &
                          yzxx.z == TestData_LHS[i].x &
                          yzxx.w == TestData_LHS[i].x;

                byte4 yzxy = TestData_LHS[i].yzxy;
                result &= yzxy.x == TestData_LHS[i].y &
                          yzxy.y == TestData_LHS[i].z &
                          yzxy.z == TestData_LHS[i].x &
                          yzxy.w == TestData_LHS[i].y;

                byte4 yzxz = TestData_LHS[i].yzxz;
                result &= yzxz.x == TestData_LHS[i].y &
                          yzxz.y == TestData_LHS[i].z &
                          yzxz.z == TestData_LHS[i].x &
                          yzxz.w == TestData_LHS[i].z;

                byte4 yzyx = TestData_LHS[i].yzyx;
                result &= yzyx.x == TestData_LHS[i].y &
                          yzyx.y == TestData_LHS[i].z &
                          yzyx.z == TestData_LHS[i].y &
                          yzyx.w == TestData_LHS[i].x;

                byte4 yzyy = TestData_LHS[i].yzyy;
                result &= yzyy.x == TestData_LHS[i].y &
                          yzyy.y == TestData_LHS[i].z &
                          yzyy.z == TestData_LHS[i].y &
                          yzyy.w == TestData_LHS[i].y;

                byte4 yzyz = TestData_LHS[i].yzyz;
                result &= yzyz.x == TestData_LHS[i].y &
                          yzyz.y == TestData_LHS[i].z &
                          yzyz.z == TestData_LHS[i].y &
                          yzyz.w == TestData_LHS[i].z;

                byte4 yzzx = TestData_LHS[i].yzzx;
                result &= yzzx.x == TestData_LHS[i].y &
                          yzzx.y == TestData_LHS[i].z &
                          yzzx.z == TestData_LHS[i].z &
                          yzzx.w == TestData_LHS[i].x;

                byte4 yzzy = TestData_LHS[i].yzzy;
                result &= yzzy.x == TestData_LHS[i].y &
                          yzzy.y == TestData_LHS[i].z &
                          yzzy.z == TestData_LHS[i].z &
                          yzzy.w == TestData_LHS[i].y;

                byte4 yzzz = TestData_LHS[i].yzzz;
                result &= yzzz.x == TestData_LHS[i].y &
                          yzzz.y == TestData_LHS[i].z &
                          yzzz.z == TestData_LHS[i].z &
                          yzzz.w == TestData_LHS[i].z;
                byte4 zxxx = TestData_LHS[i].zxxx;
                result &= zxxx.x == TestData_LHS[i].z &
                          zxxx.y == TestData_LHS[i].x &
                          zxxx.z == TestData_LHS[i].x &
                          zxxx.w == TestData_LHS[i].x;

                byte4 zxxy = TestData_LHS[i].zxxy;
                result &= zxxy.x == TestData_LHS[i].z &
                          zxxy.y == TestData_LHS[i].x &
                          zxxy.z == TestData_LHS[i].x &
                          zxxy.w == TestData_LHS[i].y;

                byte4 zxxz = TestData_LHS[i].zxxz;
                result &= zxxz.x == TestData_LHS[i].z &
                          zxxz.y == TestData_LHS[i].x &
                          zxxz.z == TestData_LHS[i].x &
                          zxxz.w == TestData_LHS[i].z;

                byte4 zxyx = TestData_LHS[i].zxyx;
                result &= zxyx.x == TestData_LHS[i].z &
                          zxyx.y == TestData_LHS[i].x &
                          zxyx.z == TestData_LHS[i].y &
                          zxyx.w == TestData_LHS[i].x;

                byte4 zxyy = TestData_LHS[i].zxyy;
                result &= zxyy.x == TestData_LHS[i].z &
                          zxyy.y == TestData_LHS[i].x &
                          zxyy.z == TestData_LHS[i].y &
                          zxyy.w == TestData_LHS[i].y;

                byte4 zxyz = TestData_LHS[i].zxyz;
                result &= zxyz.x == TestData_LHS[i].z &
                          zxyz.y == TestData_LHS[i].x &
                          zxyz.z == TestData_LHS[i].y &
                          zxyz.w == TestData_LHS[i].z;

                byte4 zxzx = TestData_LHS[i].zxzx;
                result &= zxzx.x == TestData_LHS[i].z &
                          zxzx.y == TestData_LHS[i].x &
                          zxzx.z == TestData_LHS[i].z &
                          zxzx.w == TestData_LHS[i].x;

                byte4 zxzy = TestData_LHS[i].zxzy;
                result &= zxzy.x == TestData_LHS[i].z &
                          zxzy.y == TestData_LHS[i].x &
                          zxzy.z == TestData_LHS[i].z &
                          zxzy.w == TestData_LHS[i].y;

                byte4 zxzz = TestData_LHS[i].zxzz;
                result &= zxzz.x == TestData_LHS[i].z &
                          zxzz.y == TestData_LHS[i].x &
                          zxzz.z == TestData_LHS[i].z &
                          zxzz.w == TestData_LHS[i].z;

                byte4 zyxx = TestData_LHS[i].zyxx;
                result &= zyxx.x == TestData_LHS[i].z &
                          zyxx.y == TestData_LHS[i].y &
                          zyxx.z == TestData_LHS[i].x &
                          zyxx.w == TestData_LHS[i].x;

                byte4 zyxy = TestData_LHS[i].zyxy;
                result &= zyxy.x == TestData_LHS[i].z &
                          zyxy.y == TestData_LHS[i].y &
                          zyxy.z == TestData_LHS[i].x &
                          zyxy.w == TestData_LHS[i].y;

                byte4 zyxz = TestData_LHS[i].zyxz;
                result &= zyxz.x == TestData_LHS[i].z &
                          zyxz.y == TestData_LHS[i].y &
                          zyxz.z == TestData_LHS[i].x &
                          zyxz.w == TestData_LHS[i].z;

                byte4 zyyx = TestData_LHS[i].zyyx;
                result &= zyyx.x == TestData_LHS[i].z &
                          zyyx.y == TestData_LHS[i].y &
                          zyyx.z == TestData_LHS[i].y &
                          zyyx.w == TestData_LHS[i].x;

                byte4 zyyy = TestData_LHS[i].zyyy;
                result &= zyyy.x == TestData_LHS[i].z &
                          zyyy.y == TestData_LHS[i].y &
                          zyyy.z == TestData_LHS[i].y &
                          zyyy.w == TestData_LHS[i].y;

                byte4 zyyz = TestData_LHS[i].zyyz;
                result &= zyyz.x == TestData_LHS[i].z &
                          zyyz.y == TestData_LHS[i].y &
                          zyyz.z == TestData_LHS[i].y &
                          zyyz.w == TestData_LHS[i].z;

                byte4 zyzx = TestData_LHS[i].zyzx;
                result &= zyzx.x == TestData_LHS[i].z &
                          zyzx.y == TestData_LHS[i].y &
                          zyzx.z == TestData_LHS[i].z &
                          zyzx.w == TestData_LHS[i].x;

                byte4 zyzy = TestData_LHS[i].zyzy;
                result &= zyzy.x == TestData_LHS[i].z &
                          zyzy.y == TestData_LHS[i].y &
                          zyzy.z == TestData_LHS[i].z &
                          zyzy.w == TestData_LHS[i].y;

                byte4 zyzz = TestData_LHS[i].zyzz;
                result &= zyzz.x == TestData_LHS[i].z &
                          zyzz.y == TestData_LHS[i].y &
                          zyzz.z == TestData_LHS[i].z &
                          zyzz.w == TestData_LHS[i].z;

                byte4 zzxx = TestData_LHS[i].zzxx;
                result &= zzxx.x == TestData_LHS[i].z &
                          zzxx.y == TestData_LHS[i].z &
                          zzxx.z == TestData_LHS[i].x &
                          zzxx.w == TestData_LHS[i].x;

                byte4 zzxy = TestData_LHS[i].zzxy;
                result &= zzxy.x == TestData_LHS[i].z &
                          zzxy.y == TestData_LHS[i].z &
                          zzxy.z == TestData_LHS[i].x &
                          zzxy.w == TestData_LHS[i].y;

                byte4 zzxz = TestData_LHS[i].zzxz;
                result &= zzxz.x == TestData_LHS[i].z &
                          zzxz.y == TestData_LHS[i].z &
                          zzxz.z == TestData_LHS[i].x &
                          zzxz.w == TestData_LHS[i].z;

                byte4 zzyx = TestData_LHS[i].zzyx;
                result &= zzyx.x == TestData_LHS[i].z &
                          zzyx.y == TestData_LHS[i].z &
                          zzyx.z == TestData_LHS[i].y &
                          zzyx.w == TestData_LHS[i].x;

                byte4 zzyy = TestData_LHS[i].zzyy;
                result &= zzyy.x == TestData_LHS[i].z &
                          zzyy.y == TestData_LHS[i].z &
                          zzyy.z == TestData_LHS[i].y &
                          zzyy.w == TestData_LHS[i].y;

                byte4 zzyz = TestData_LHS[i].zzyz;
                result &= zzyz.x == TestData_LHS[i].z &
                          zzyz.y == TestData_LHS[i].z &
                          zzyz.z == TestData_LHS[i].y &
                          zzyz.w == TestData_LHS[i].z;

                byte4 zzzx = TestData_LHS[i].zzzx;
                result &= zzzx.x == TestData_LHS[i].z &
                          zzzx.y == TestData_LHS[i].z &
                          zzzx.z == TestData_LHS[i].z &
                          zzzx.w == TestData_LHS[i].x;

                byte4 zzzy = TestData_LHS[i].zzzy;
                result &= zzzy.x == TestData_LHS[i].z &
                          zzzy.y == TestData_LHS[i].z &
                          zzzy.z == TestData_LHS[i].z &
                          zzzy.w == TestData_LHS[i].y;

                byte4 zzzz = TestData_LHS[i].zzzz;
                result &= zzzz.x == TestData_LHS[i].z &
                          zzzz.y == TestData_LHS[i].z &
                          zzzz.z == TestData_LHS[i].z &
                          zzzz.w == TestData_LHS[i].z;


                byte3 xxx = TestData_LHS[i].xxx;
                result &= xxx.x == TestData_LHS[i].x &
                          xxx.y == TestData_LHS[i].x &
                          xxx.z == TestData_LHS[i].x;

                byte3 xxy = TestData_LHS[i].xxy;
                result &= xxy.x == TestData_LHS[i].x &
                          xxy.y == TestData_LHS[i].x &
                          xxy.z == TestData_LHS[i].y;

                byte3 xxz = TestData_LHS[i].xxz;
                result &= xxz.x == TestData_LHS[i].x &
                          xxz.y == TestData_LHS[i].x &
                          xxz.z == TestData_LHS[i].z;

                byte3 xyx = TestData_LHS[i].xyx;
                result &= xyx.x == TestData_LHS[i].x &
                          xyx.y == TestData_LHS[i].y &
                          xyx.z == TestData_LHS[i].x;

                byte3 xyy = TestData_LHS[i].xyy;
                result &= xyy.x == TestData_LHS[i].x &
                          xyy.y == TestData_LHS[i].y &
                          xyy.z == TestData_LHS[i].y;

                byte3 xzx = TestData_LHS[i].xzx;
                result &= xzx.x == TestData_LHS[i].x &
                          xzx.y == TestData_LHS[i].z &
                          xzx.z == TestData_LHS[i].x;

                byte3 xzy = TestData_LHS[i].xzy;
                result &= xzy.x == TestData_LHS[i].x &
                          xzy.y == TestData_LHS[i].z &
                          xzy.z == TestData_LHS[i].y;

                byte3 xzz = TestData_LHS[i].xzz;
                result &= xzz.x == TestData_LHS[i].x &
                          xzz.y == TestData_LHS[i].z &
                          xzz.z == TestData_LHS[i].z;

                byte3 yxx = TestData_LHS[i].yxx;
                result &= yxx.x == TestData_LHS[i].y &
                          yxx.y == TestData_LHS[i].x &
                          yxx.z == TestData_LHS[i].x;

                byte3 yxy = TestData_LHS[i].yxy;
                result &= yxy.x == TestData_LHS[i].y &
                          yxy.y == TestData_LHS[i].x &
                          yxy.z == TestData_LHS[i].y;

                byte3 yxz = TestData_LHS[i].yxz;
                result &= yxz.x == TestData_LHS[i].y &
                          yxz.y == TestData_LHS[i].x &
                          yxz.z == TestData_LHS[i].z;

                byte3 yyx = TestData_LHS[i].yyx;
                result &= yyx.x == TestData_LHS[i].y &
                          yyx.y == TestData_LHS[i].y &
                          yyx.z == TestData_LHS[i].x;

                byte3 yyy = TestData_LHS[i].yyy;
                result &= yyy.x == TestData_LHS[i].y &
                          yyy.y == TestData_LHS[i].y &
                          yyy.z == TestData_LHS[i].y;

                byte3 yyz = TestData_LHS[i].yyz;
                result &= yyz.x == TestData_LHS[i].y &
                          yyz.y == TestData_LHS[i].y &
                          yyz.z == TestData_LHS[i].z;

                byte3 yzx = TestData_LHS[i].yzx;
                result &= yzx.x == TestData_LHS[i].y &
                          yzx.y == TestData_LHS[i].z &
                          yzx.z == TestData_LHS[i].x;

                byte3 yzy = TestData_LHS[i].yzy;
                result &= yzy.x == TestData_LHS[i].y &
                          yzy.y == TestData_LHS[i].z &
                          yzy.z == TestData_LHS[i].y;

                byte3 yzz = TestData_LHS[i].yzz;
                result &= yzz.x == TestData_LHS[i].y &
                          yzz.y == TestData_LHS[i].z &
                          yzz.z == TestData_LHS[i].z;

                byte3 zxx = TestData_LHS[i].zxx;
                result &= zxx.x == TestData_LHS[i].z &
                          zxx.y == TestData_LHS[i].x &
                          zxx.z == TestData_LHS[i].x;

                byte3 zxy = TestData_LHS[i].zxy;
                result &= zxy.x == TestData_LHS[i].z &
                          zxy.y == TestData_LHS[i].x &
                          zxy.z == TestData_LHS[i].y;

                byte3 zxz = TestData_LHS[i].zxz;
                result &= zxz.x == TestData_LHS[i].z &
                          zxz.y == TestData_LHS[i].x &
                          zxz.z == TestData_LHS[i].z;

                byte3 zyx = TestData_LHS[i].zyx;
                result &= zyx.x == TestData_LHS[i].z &
                          zyx.y == TestData_LHS[i].y &
                          zyx.z == TestData_LHS[i].x;

                byte3 zyy = TestData_LHS[i].zyy;
                result &= zyy.x == TestData_LHS[i].z &
                          zyy.y == TestData_LHS[i].y &
                          zyy.z == TestData_LHS[i].y;

                byte3 zyz = TestData_LHS[i].zyz;
                result &= zyz.x == TestData_LHS[i].z &
                          zyz.y == TestData_LHS[i].y &
                          zyz.z == TestData_LHS[i].z;

                byte3 zzx = TestData_LHS[i].zzx;
                result &= zzx.x == TestData_LHS[i].z &
                          zzx.y == TestData_LHS[i].z &
                          zzx.z == TestData_LHS[i].x;

                byte3 zzy = TestData_LHS[i].zzy;
                result &= zzy.x == TestData_LHS[i].z &
                          zzy.y == TestData_LHS[i].z &
                          zzy.z == TestData_LHS[i].y;

                byte3 zzz = TestData_LHS[i].zzz;
                result &= zzz.x == TestData_LHS[i].z &
                          zzz.y == TestData_LHS[i].z &
                          zzz.z == TestData_LHS[i].z;


                byte2 xx = TestData_LHS[i].xx;
                result &= xx.x == TestData_LHS[i].x &
                          xx.y == TestData_LHS[i].x;

                byte2 xy = TestData_LHS[i].xy;
                result &= xy.x == TestData_LHS[i].x &
                          xy.y == TestData_LHS[i].y;

                byte2 xz = TestData_LHS[i].xz;
                result &= xz.x == TestData_LHS[i].x &
                          xz.y == TestData_LHS[i].z;

                byte2 yx = TestData_LHS[i].yx;
                result &= yx.x == TestData_LHS[i].y &
                          yx.y == TestData_LHS[i].x;

                byte2 yy = TestData_LHS[i].yy;
                result &= yy.x == TestData_LHS[i].y &
                          yy.y == TestData_LHS[i].y;

                byte2 yz = TestData_LHS[i].yz;
                result &= yz.x == TestData_LHS[i].y &
                          yz.y == TestData_LHS[i].z;

                byte2 zx = TestData_LHS[i].zx;
                result &= zx.x == TestData_LHS[i].z &
                          zx.y == TestData_LHS[i].x;

                byte2 zy = TestData_LHS[i].zy;
                result &= zy.x == TestData_LHS[i].z &
                          zy.y == TestData_LHS[i].y;

                byte2 zz = TestData_LHS[i].zz;
                result &= zz.x == TestData_LHS[i].z &
                          zz.y == TestData_LHS[i].z;
            }

            return result;
        }


        [UnitTest("Types", "byte3")]
        public static bool Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v128 x = TestData_LHS[i];

                result &= x.Byte0 == TestData_LHS[i].x &
                          x.Byte1 == TestData_LHS[i].y &
                          x.Byte2 == TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = TestData_LHS[i];
                v128 c = x;
                x = c;

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z;
            }

            return result;
        }


        [UnitTest("Types", "byte3")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort3 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int3 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToUInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint3 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long3 x = TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y &
                          x.z == (long)TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong3 x = TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y &
                          x.z == (ulong)TestData_LHS[i].z;
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToFloat()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float3 x = TestData_LHS[i];

                result &= maxmath.approx(x.x, (float)TestData_LHS[i].x) &
                          maxmath.approx(x.y, (float)TestData_LHS[i].y) &
                          maxmath.approx(x.z, (float)TestData_LHS[i].z);
            }

            return result;
        }

        [UnitTest("Types", "byte3")]
        public static bool Cast_ToDouble()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double3 x = TestData_LHS[i];

                result &= maxmath.approx(x.x, (double)TestData_LHS[i].x) &
                          maxmath.approx(x.y, (double)TestData_LHS[i].y) &
                          maxmath.approx(x.z, (double)TestData_LHS[i].z);
            }

            return result;
        }
    }
}