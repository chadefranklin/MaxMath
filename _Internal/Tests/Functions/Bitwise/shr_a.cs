﻿using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class shr_a
    {
        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 2)
                {
                    long2 x = maxmath.shr_a(Tests.Long2.TestData_LHS[i], new long2(math.min(j, 63), math.min(j + 1, 63)));

                    result &= x.x == Tests.Long2.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long2.TestData_LHS[i].y >> math.min(j + 1, 63);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 3)
                {
                    long3 x = maxmath.shr_a(Tests.Long3.TestData_LHS[i], new long3(math.min(j, 63), math.min(j + 1, 63), math.min(j + 2, 63)));

                    result &= x.x == Tests.Long3.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long3.TestData_LHS[i].y >> math.min(j + 1, 63);
                    result &= x.z == Tests.Long3.TestData_LHS[i].z >> math.min(j + 2, 63);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 4)
                {
                    long4 x = maxmath.shr_a(Tests.Long4.TestData_LHS[i], new long4(math.min(j, 63), math.min(j + 1, 63), math.min(j + 2, 63), math.min(j + 3, 63)));

                    result &= x.x == Tests.Long4.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long4.TestData_LHS[i].y >> math.min(j + 1, 63);
                    result &= x.z == Tests.Long4.TestData_LHS[i].z >> math.min(j + 2, 63);
                    result &= x.w == Tests.Long4.TestData_LHS[i].w >> math.min(j + 3, 63);
                }
            }

            return result;
        }
    }
}