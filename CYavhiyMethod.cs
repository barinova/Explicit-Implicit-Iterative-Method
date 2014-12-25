using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplicitIterativeMethod
{
    class CYavhiyMethod
    {
        double A1, B1, C1, D1, A2, B2, C2, D2, F1, F2, GAMMA, EPSILON, M, Ro;
        public CYavhiyMethod(double _A1, double _B1, double _C1, double _D1, double _A2, double _B2, double _C2,
            double _D2, double _F1, double _F2, double _GAMMA, double _EPSILON, double _M, double _Ro)
        {
            A1 = _A1;
            B1  =_B1;
            C1 = _C1;
            D1 = _D1;
            A2 = _A2;
            B2 = _B2;
            C2 = _C2;
            D2 = _D2;
            F1 = _F1;
            F2 = _F2;
            GAMMA = _GAMMA;
            EPSILON = _EPSILON;
            M = _M;
            Ro = _Ro;
	        Point result = new Point(F1, F2);
	        Point start= new Point(0,0);	//(0,0)
	        Point solution;
	        double a1 = A1*3*Math.Pow(Ro,2.0)+B1;
	        double a2 = C1;
	        double b1 = B2;
	        double b2 = 7*Math.Pow(Ro,6.0) + C2;
	        double first = Math.Pow(a1,2) + Math.Pow(b1,2); 
	        double second = Math.Pow(a2,2) + Math.Pow(b2,2);
	        double Lip = Math.Sqrt(2* Math.Max(first, second));
            //Console.WriteLine("Lip = {0:F}\n", Lip);
            double t = 2 / (2 * Lip);
            int iterations = yavniyMethod(start, result, t, out solution, EPSILON);
            Point val = Operator(solution);

            Console.Write("Solution: x = {0:0.000000}\t", solution.x);
            Console.WriteLine("y = {0:0.000000}", solution.y);
            Console.Write("Function: ({0:0.000000}, ", val.x);
            Console.WriteLine("{0:0.000000})", val.y);
            Console.WriteLine("Epsilon = {0:0.000000}", EPSILON);
            Console.WriteLine("iterations = {0:D}", iterations);
        }

        Point Operator(Point pnt)
        {
            return new Point((A1 * Math.Pow(pnt.x, 3) + B1 * pnt.x + C1 * pnt.y + D1),
                A2 * Math.Pow(pnt.y, 7) + B2 * pnt.x + C2 * pnt.y + D2);
        }

        Point Function(Point pnt)
        {
            Point p = Operator(pnt) - new Point(F1, F2);
            return p;
        }

        public int yavniyMethod(Point start, Point result, double t, out Point solution, double _epsilon)
        {
	        int iterations = 0;
	        Point epsilon = new Point(_epsilon, _epsilon);
	        Point previousStepValue;
	        Point nextStepValue = start;
	        do
	        {
		        iterations++;
		        previousStepValue = nextStepValue;
		        nextStepValue = previousStepValue - Function(previousStepValue) * t;
                Console.Write("x = {0:0.000000}\t", nextStepValue.x);
                Console.WriteLine("y = {0:0.000000}", nextStepValue.y);
	        } while (Point.abs((Operator(nextStepValue) - result)) > epsilon);

	        solution = nextStepValue;

	        return iterations;
        }
    }
}
