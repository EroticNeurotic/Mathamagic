using System;

namespace MathFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int bits = 8;

            bool[] number1 = new bool[] { false, false, true, true, false, false, false, true };
            bool[] number2 = new bool[] { true, true, true, false, false, true, false, true };

            bool digit1 = true;
            bool digit2 = true;
            bool carry = false;

            bool[] result = FullAdder(digit1, digit2, carry);

            Console.WriteLine("Sum " + result[0]);
            Console.WriteLine("Carry " + result[1]);
            Console.ReadKey();

            bool[] add = Addition(number1, number2, bits);

            PrintResult(add);

            Console.ReadKey();
        }

        static bool[] Addition(bool[] first, bool[] second, int digits)
        {

            bool[] result = new bool[digits];
            bool[] temp = new bool[]{false, false};
            bool carry = false;

            for (int count = 0; count < digits; count++)
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

        static void PrintResult(bool[] Answer)
        {
            foreach (bool element in Answer)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
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
    }
}
