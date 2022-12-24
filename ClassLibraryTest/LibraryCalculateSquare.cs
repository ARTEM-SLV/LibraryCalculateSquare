using System;

namespace LibraryCalculateSquare
{
    public static class Const
    {
        public static double Pi = 3.14;
    }

    public interface IOvalSquare
    {
        public double OvalSquare(double radius);
    }

    public interface ITriangleSquare
    {
        public double TriangleSquare(double a, double b, double c);

        public double TriangleSquare(double a, double b, double c, out bool isRectangular);
    }

    public class CalculateSquare : IOvalSquare , ITriangleSquare
    {
        public double OvalSquare(double radius)
        {
            double square = Const.Pi * (radius * radius);

            return square;
        }

        public double TriangleSquare(double a, double b, double c)
        {
            double p = CalculateHalfPerimeter(a, b, c); //вычисляем полупериметр треугольника
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return s;
        }

        public double TriangleSquare(double a, double b, double c, out bool isRectangular)
        {
            isRectangular = false;
            if ( (a*a == hypotenuse(b, c)) || (b*b == hypotenuse(a, c)) || (c*c == hypotenuse(a, b)) )
                isRectangular = true;

            double p = CalculateHalfPerimeter(a, b, c); //вычисляем полупериметр треугольника
            double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            return s;
        }

        public double hypotenuse(double a, double b)
        {
            return a * a + b * b;
        }

        public double CalculateHalfPerimeter(double a, double b, double c)
        {
            return (a + b + c) / 2;
        }
    }
}

