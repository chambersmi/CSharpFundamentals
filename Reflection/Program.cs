namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new ObjectToTextConverter();
            var x = converter.Convert(new House("123 Maple", 170.8, 2));
            Console.WriteLine(x);
        }
    }

    class ObjectToTextConverter
    {
        public string Convert(object obj)
        {
            // Get Type            
            Type type = obj.GetType();

            // Read all properties, except EqualityContract
            var properties = type
                .GetProperties()
                .Where(p => p.Name != "EqualityContract");


            // Output: Address is 123 Maple, Area is 170.8, Floors is 2
            return String.Join(", ",
                properties
                .Select(property => $"{property.Name} is {property.GetValue(obj)}"));
        }
    }

    public record Pet(string Name, PetType PetType, float Weight);
    public record House(string Address, double Area, int Floors);
    public enum PetType { Cat, Dog, Muskrat }
}
