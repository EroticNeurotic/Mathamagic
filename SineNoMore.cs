using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sine = Sine(Convert.ToDouble(Console.ReadLine()));

            Console.WriteLine(sine);
            Console.ReadKey();

        }

        static double Sine(double angle)
        {
            var OriginalAngle = angle;
            var CalculationAngle = angle;
            char Sign = '+';

            CalculationAngle = CheckRange(CalculationAngle);
            Sign = CheckSign(CalculationAngle);
            CalculationAngle = CheckQuadrant(CalculationAngle);

            return TaylorSeries(CalculationAngle);
        }

        static double CheckRange(double angle)
        {
            if(angle >= 0 & angle <= 360)return angle;

            if(angle < 0)
            {
                do
                {
                    angle += 360;
                } while (angle < 0);
            }

            if(angle > 360)
            {
                do
                {
                    angle -= 360;
                } while (angle > 360);               
            }

            return angle;
        }

        static double CheckQuadrant(double angle)
        {
            if (angle > 90 & angle <= 270) return 180 - angle;
            if (angle > 270 & angle <= 360) return 360 - angle; 
            return angle;
        }

        static char CheckSign(double angle)
        {
            if (angle > 180) { return '-'; }
            return '+';
        }

        static double TaylorSeries(double angle)
        {
            var Iterations = 5;
            double sine = new double();
            double OneThing = 1;
            double Toppo = new double();
            double Botto = new double();

            double radians = angle * Math.PI / 180;

            for(int count = 1; count <= Iterations; count++)
            {
                OneThing = Math.Pow(-1, count - 1);
                Toppo = Math.Pow(radians, 2 * count - 1);
                Botto = factorial(2 * count - 1);
                sine += OneThing * Toppo / Botto;
            }

            return sine;
        }

        static int factorial(int Number)
        {
            if (Number <= 1) return 1;
            return Number * factorial(Number - 1);
        }
    }
}
