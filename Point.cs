using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplicitIterativeMethod
{
    class Point
    {
        double eps;

        public Point(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
        }

        public double x { get; set; }

        public double y { get; set; }

        public static Point operator+(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b)
        {
	        return new Point(a.x - b.x, a.y - b.y);
        }

        public static Point operator*(Point a, double val)
        {
	        return new Point(a.x * val, a.y * val);
        }

        public static Point operator/(Point a, double val)
        {
            return new Point(a.x / val, a.y / val);
        }

        public static Point abs(Point a)
        {
            return new Point(Math.Abs(a.x), Math.Abs(a.y));
        }

        public static bool operator >(Point a, Point b)
        {
	        return a.x > b.x || a.y > b.y;
        }

        public static bool operator <(Point a, Point b)
        {
            return a.x < b.x || a.y < b.y;
        }
    }
}
