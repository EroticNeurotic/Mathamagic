using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
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
