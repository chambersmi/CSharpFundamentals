namespace IsVsAs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Is
            object text = "Hello!";
            bool isString = text is string;
            Console.WriteLine($"Is String? {isString}");

            bool isInt = text is int;
            Console.WriteLine($"Is Int? {isInt}");

            if (isString)
                Console.WriteLine($"{text} is a string.");

            string textAsString = text as string; // WORKS

            List<int> list = text as List<int>; // NULL

            string stringNumber = "1";
            int number = int.Parse(stringNumber);
            Console.WriteLine($"{number} + 5 = {number + 5}");
        }
    }
}