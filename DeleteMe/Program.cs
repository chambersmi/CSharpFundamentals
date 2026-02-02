namespace DeleteMe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> areEqual = (a, b) => a == b;

            bool result = areEqual("hello", "hello");
            bool result2 = areEqual("hello", "world");
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
    }
}
