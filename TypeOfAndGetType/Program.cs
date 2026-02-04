namespace TypeOfAndGetType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type1 = typeof(Base);
            Console.WriteLine(type1.FullName);
            
            var baseObj = new Base();
            Type type2 = baseObj.GetType();
            Console.WriteLine(type2.FullName);

            PrintTypedName("Hello");
            PrintTypedName(500);
            PrintTypedName(50.0);

            Base derivedAsBase = new Derived();
            var type = derivedAsBase.GetType();
            Console.WriteLine($"derivedAsBase: {type.FullName}");
        }

        static void PrintTypedName(object obj)
        {
            var type = obj.GetType();
            Console.WriteLine($"Type name is {type.Name}");
        }
    }

    public class Base
    {

    }

    public class Derived : Base
    {

    }
}
