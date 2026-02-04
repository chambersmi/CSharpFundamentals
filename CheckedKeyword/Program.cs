using System.Diagnostics;

namespace CheckedKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account ac = new Account();
            //ac.MakePayment(1900000000);
            //ac.MakePayment(1000000000);
            const int setSize = 1000000000;
            var checkedResult = MeasureChecked(setSize);
            Console.WriteLine($"Checked test for {setSize} took {checkedResult} ms");


            var uncheckedResult = MeasureUnchecked(setSize);
            Console.WriteLine($"Un-Checked test for {setSize} took {uncheckedResult} ms");

            Console.WriteLine($"Checked took {(((double)checkedResult / (double)uncheckedResult)):F5}% longer.");
        }

        static long MeasureChecked(int setSize)
        {
            var stopwatch = Stopwatch.StartNew();
            int a = 1;
            int b = 2;

            checked
            {
                for(int i=0; i < setSize; i++)
                {
                    a = i + b + a;
                    a = 1;
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long MeasureUnchecked(int setSize)
        {
            var stopwatch = Stopwatch.StartNew();
            int a = 1;
            int b = 2;

            unchecked
            {
                for (int i = 0; i < setSize; i++)
                {
                    a = i + b + a;
                    a = 1;
                }
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }

    public class Account
    {
        private int _todaysPaymentsSum;
        private const int MaxDailyPaymentsSum = 2000000000;

        public void MakePayment(int amount)
        {
            checked // complex operation. use wisely
            {
                try
                {
                    var paymentsSumAfterPayment = _todaysPaymentsSum + amount;
                    if (paymentsSumAfterPayment < MaxDailyPaymentsSum)
                    {
                        _todaysPaymentsSum = paymentsSumAfterPayment;
                        Console.WriteLine($"UNCHECKED {amount} transferred.");
                        Console.WriteLine($"Payment sum for today: {_todaysPaymentsSum}");
                    }
                    else
                    {
                        Console.WriteLine($"Transaction limit of ${MaxDailyPaymentsSum} reached");
                    }
                } catch (OverflowException)
                {
                    Console.WriteLine("Overflow limit reached.");
                }
            }
           
        }
    }
}
