using System;

namespace MathFunctions
{
    class Operations
    {

        public static bool[] Multiplication(bool[] first, bool[] second, int bits)
        {
            bool[] result = new bool[bits];
            bool[] temp = new bool[bits];

            for(int count = 0; count < bits; count ++)
            {
                if(first[count] == true)
                {
                    temp = second;

                    if(count != 0)
                    {
                        for(int index = 1; index <= count; index ++)
                        {
                            temp = ShiftRight(temp, bits);
                        }
                    }

                    result = Addition(result, temp, bits);
                }

            }

            return result;

        }

        public static bool[] ShiftRight(bool[] barray, int bits)
        {
            bool[] result = new bool[bits];

            Array.Copy(barray, result, bits);

            for(int count = 1; count < bits; count ++)
            {
                result[count] = barray[count - 1];
            }
            result[0] = false;

            return result;
        }

        public static bool[] Addition(bool[] first, bool[] second, int bits)
        {

            bool[] result = new bool[bits];
            bool[] temp = new bool[] { false, false };
            bool carry = false;

            for (int count = 0; count < bits; count++)    //for loops are cheating, uses ints and addition (while loops?)
            {
                temp = FullAdder(first[count], second[count], carry);
                result[count] = temp[0];
                carry = temp[1];
            }

            if (carry == true)
            {
                Console.WriteLine("Overflow Error");
            }

            return result;
        }

        static bool[] FullAdder(bool A, bool B, bool C)
        {
            bool[] HalfResult = HalfAdder(A, B);

            bool Result = new bool();
            bool Carry = new bool();

            Result = HalfResult[0] ^ C;
            Carry = HalfResult[1] || (C & HalfResult[0]);

            return new bool[] { Result, Carry };
        }

        static bool[] HalfAdder(bool A, bool B)
        {
            bool sum = new bool();
            bool carry = new bool();

            sum = A ^ B;
            carry = A & B;

            return new bool[] { sum, carry };
        }

        public static void PrintResult(bool[] Answer)
        {
            foreach (bool element in Answer)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }

    }
}
