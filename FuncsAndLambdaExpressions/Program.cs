
namespace FuncsAndLambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 4, 7, 19, 2 };
            //Console.WriteLine($"IsAnyLargerThan10? " + IsAnyLargerThan10(numbers));
            //Console.WriteLine($"IsAnyEven? " + IsAnyEven(numbers));

            bool IsLargerThan10(int number)
            {
                return number > 10;
            }

            bool IsEven(int number)
            {
                return number % 2 == 0;
            }

            Func<int, bool> predicate1 = IsLargerThan10;
            Console.WriteLine($"IsLargerThan10? " + IsAny(numbers, IsLargerThan10));

            Func<int, bool> predicate2 = IsEven;
            Console.WriteLine($"IsEven? " + IsAny(numbers, IsEven));


            // Lambda
            Console.WriteLine($"Lambda Expression: IsAnyEven? {IsAny(numbers, n=> n%2==0)}");

            LambdaClass lc = new LambdaClass();
            Console.WriteLine($"Lambda Exppression: IsOdd? {lc.IsOdd(numbers, n => n % 2 != 0)}");
            
        }

        private static bool IsAnyLargerThan10(IEnumerable<int> numbers)
        {
            foreach(var number in numbers)
            {
                if(number > 10)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAnyEven(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Can be assigned any function that takes int, dateTime, string and returns decimal
        Func<int, DateTime, string, decimal> someFunc;

        // For void functions, we use Action
        Action<string, string, bool> someAction;

        private static bool IsAny(IEnumerable<int> numbers, Func<int,bool> predicate)
        {
            foreach(var number in numbers)
            {
                if(predicate(number))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class LambdaClass
    {
        public bool IsOdd(IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            foreach(var number in numbers)
            {
                if(predicate(number))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
