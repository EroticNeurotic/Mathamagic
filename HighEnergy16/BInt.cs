using System;
using System.Collections.Generic;

namespace MathFunctions
{
    class BInt
    {
        public bool[] binary;
        public const int bits = 16;
        private Dictionary<char, bool[]> digits;

        public BInt ()  //really shouldn't be using int but I haven't found a way around it yet
        {
            binary = new bool[bits];
            digits = valueDictionary();
        }

        public void SetValue (string val)
        {
            val = Reverse(val);
            int position = new int();
            int length = val.Length;

            bool[] temp = new bool[bits];
            bool[] value = new bool[bits];
            bool[] ten = digits['0'];
            bool[] multiplier = new bool[bits];

            for(int count = 0; count < length; count ++)
            {
                multiplier = digits['1'];
                position = count + 1;

                if (position > 1)
                {
                    for (int index = 1; index < position; index++)
                    {
                        multiplier = Operations.Multiplication(ten, multiplier, bits);
                    }
                }

                temp = digits[val[count]];
                temp = Operations.Multiplication(temp, multiplier, bits);
                value = Operations.Addition(value, temp, bits);
            }
            binary = value;

        }

        public static void printValue(bool[] value)
        { 
            foreach (bool digit in value)
            {
                Console.Write(digit + " ");
            }

            Console.WriteLine();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private Dictionary<char, bool[]> valueDictionary()
        {
            Dictionary<char, bool[]> digits = new Dictionary<char, bool[]>();   //find a way to add only the necessary digits and set the rest automatically to false
          
            digits.Add('1', new bool[bits] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false});
            digits.Add('2', new bool[bits] { false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('3', new bool[bits] { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('4', new bool[bits] { false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('5', new bool[bits] { true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('6', new bool[bits] { false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('7', new bool[bits] { true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('8', new bool[bits] { false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('9', new bool[bits] { true, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false });
            digits.Add('0', new bool[bits] { false, true, false, true, false, false, false, false, false, false, false, false, false, false, false, false });

            return digits;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BInt);
        }

        public bool Equals(BInt B)
        {
            if (Object.ReferenceEquals(B, null)) { return false; }
            if (Object.ReferenceEquals(B, this)) { return true; }
            if (this.GetType() != B.GetType()) { return false; }
            return binary == B.binary;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(BInt Left, BInt Right)
        {
            if (object.ReferenceEquals(Left, null))
            {
                if (object.ReferenceEquals(Right, null)){ return true; }
                return false;
            }
            return Left.Equals(Right);
        }

        public static bool operator !=(BInt Left, BInt Right)
        {
            return !(Left == Right);
        }

    }
}
