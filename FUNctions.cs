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
                result = result * value;
            }

            //Taylor series stuff to find non integer part 

            if(exponent < 0) { result = 1 / result; }

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
    }

    class funkshun
    {
        private double exponent;
        private double coefficient;

        //no clue where I'm going with this
    }
}
