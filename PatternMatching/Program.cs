namespace PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NullCheck("Hello");
            NullCheck(5);
        }

        static string NullCheck(object obj)
        {
            // Type Test
            // Check if variable is of a type
            //if(obj.GetType() == typeof(string))
            if (obj is string asString)
            {
                //var asString = obj as string;
                Console.WriteLine($"String is {asString}");
            }
            else
            {
                Console.WriteLine("Not a string.");
            }

            if (obj is null)
            {
                return "Object is null";
            }
            return "Object is NOT null.";
        }
    }
}
