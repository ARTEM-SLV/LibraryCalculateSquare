using System;

namespace LibraryCalculateArea
{
    public static class Const
    {
        public static double Pi = 3.14;
    }

    public interface IOvalArea
    {
        public double OvalArea(double radius);
    }

    public interface ITriangleArea
    {
        public double TriangleArea(double a, double b, double c);
        public double TriangleArea(double a, double b, double c, out bool isRectangular);
    }

    public class CalculateArea : IOvalArea, ITriangleArea
    {
        public double OvalArea(double radius)
        {
            double square = Const.Pi * (radius * radius);

            return square;
        }

        public double TriangleArea(double a, double b, double c)
        {
            double p = CalculatePerimeter(a, b, c); //вычисляем полупериметр треугольника
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return s;
        }

        public double TriangleArea(double a, double b, double c, out bool isRectangular)
        {
            isRectangular = false;
            if (a * a == (c * c) + (b * b))
                isRectangular = true;
            else if (b * b == (a * a) + (c * c))
                isRectangular = true;
            else if (c * c == (a * a) + (b * b))
                isRectangular = true;

            double p = CalculatePerimeter(a, b, c); //вычисляем полупериметр треугольника
            double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            return s;
        }

        public double CalculatePerimeter(double a, double b, double c)
        {
            return (a + b + c) / 2;
        }
    }
}
