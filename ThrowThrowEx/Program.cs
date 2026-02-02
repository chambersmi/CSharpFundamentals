
namespace ThrowThrowEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MethodA();
            MethodThrow();
        }

        static void MethodA()
        {
            Console.WriteLine("I'm method A.\nCalling MethodB");
            MethodB();
        }

        static void MethodB()
        {
            Console.WriteLine("I'm Method B.\nCalling Method C");
            MethodC();
        }

        static void MethodC()
        {
            Console.WriteLine("I'm method C. Calling Stack Trace");
            Console.WriteLine(Environment.StackTrace);
            Console.WriteLine();
        }

        static void MethodThrow()
        {
            try
            {
                var collection = Enumerable.Empty<int>();
                var first = collection.First();
            }
            catch (Exception ex)
            {
                //throw ex;
                throw;
            }
        }
    }
}
