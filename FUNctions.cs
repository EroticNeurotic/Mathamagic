namespace AbsoluteUnit
{
    class FUNctions
    {
        public static double Power(double value, double exponent)
        {
            if (exponent == 0) { return 1; }

            double integerpart = Floor(exponent);
            double decimalpart = exponent - integerpart;
            double result = 1;

            for(int count = 1; count <= Absolute(integerpart); count ++)
            {
                result *= value;
            }

            /*Taylor series stuff to find non integer part 
             *ln required, ln only works for 0<x<2
             *product rule for exponents until x of each ln is in that range
            */

            if(exponent < 0) { result = 1 / result; }

            if (decimalpart == 0) { return result; }

            return result;
        }



        public static double Floor(double flora)
        {
            return flora - (flora % 1);
        }



        public static double Ceilling(double cella)
        {
            return -Floor(-cella);
        }



        public static double Absolute(double solute)
        {
            if(solute > 0) { return solute; }
            return -solute;
        }

        //add derivative and integral approximations (numerical methods)

        public static double e(double x, int iterations)    //find a general way to write Taylor series
        {
            double sum = 0;

            for(int i = 0; i <= iterations; i ++)
            {
                sum += Power(x, i) / factorial(i);
            }

            return sum;
        }



        public static double ln(double x, int iterations)   //valid for 0<x<2
        {
            double sum = 0;

            x -= 1;

            for (int i = 1; i <= iterations; i++)
            {
                sum += Power(-1, i + 1) * Power(x, i) / i;
            }

            return sum;
        }



        static int factorial(int Number)
        {
            if (Number <= 1) return 1;
            return Number * factorial(Number - 1);
        }

        //add square root, trigonemtry and other functions

    }

    class funkshun
    {
        private double exponent;
        private double coefficient;

        //no clue where I'm going with this
    }
}
