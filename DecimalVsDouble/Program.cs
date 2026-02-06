using System.Diagnostics;

namespace DecimalVsDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // False when it should be true
            Console.WriteLine("Double: " + (0.3d == 0.2d + 0.1d));

            // True. Floats are more accurate
            Console.WriteLine("Decimal: " + (0.3m == 0.2m + 0.1m));

            static bool AreEqual(double a, double b, double tolerance)
            {
                return Math.Abs(a - b) < tolerance;
            }

            int iterations = 30000000;
            var resultForDouble = DoubleTest(iterations);
            var resultForDecimal = DecimalTest(iterations);
            Console.WriteLine($"{iterations} iterations\nDouble took {resultForDouble}" +
                $"and decimal took {resultForDecimal}.");
            Console.WriteLine($"Decimal took {(((double)resultForDecimal/(double)resultForDouble)):F2}% longer.");
        }

        static long DoubleTest(int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            double z = 0;
            for(int i=0; i < iterations; i++)
            {
                double x = i;
                double y = x * i;
                z += y;
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long DecimalTest(int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            decimal z = 0;
            for (int i = 0; i < iterations; i++)
            {
                decimal x = i;
                decimal y = x * i;
                z += y;
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
