using System.Collections;

namespace ArrayLists
{
    // AVOID UNLESS ITS ANCIENT CODE!
    // USE LISTS

    internal class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new ArrayList()
            {
                1,
                "Hello",
                true,
                new DateTime(2026, 02, 04)
            };
            // ArrayLists usually hold elements of the same type.
            var numbers = new ArrayList() { 1, 2, 3, 4 };
            var words = new ArrayList() { "a", "b", "c" };
            
            // Lots of unnecessary checking
            int Sum(ArrayList hopefullyNumbers)
            {
                int result = 0;
                foreach(var hopefullyNumber in hopefullyNumbers)
                {
                    try
                    {
                        // Must be casted and hope it succeeds
                        result += (int)hopefullyNumber;
                    } 
                    catch(InvalidCastException ex)
                    {
                        Console.WriteLine($"Invalid Cast {ex.Message}");
                        throw;
                    }
                }

                return result;
            }
        }
    }
}
