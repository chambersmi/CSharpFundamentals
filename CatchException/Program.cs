namespace CatchException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var numbers = Enumerable.Empty<int>();
                var first = GetFirstOrDefault(numbers);

                // Crash on purpose
                throw new Exception("Unknown exception");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error happened and " +
                    $"the application can't continue. The error message is" +
                    $"{ex.Message}, stack trace is: {ex.StackTrace}");
            }

        }

        private static double Average(IEnumerable<int> numbers)
        {
            if(numbers == null)
            {
                throw new ArgumentNullException("The numbers collection is null.");
            }

            double sum = 0;
            int count = 0;
            foreach(var number in numbers)
            {
                sum += number;
                count++;
            }

            if(count > 0)
            {
                return sum / count;
            }

            throw new InvalidOperationException("The collection is empty!");
        }

        private static T? GetFirstOrDefault<T>(IEnumerable<T> items)
        {
            try
            {
                return items.First();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("The collection is empty!");
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }
    }
}
