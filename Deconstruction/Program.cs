namespace Deconstruction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 4, 2, 6, 11, 5, 83, 1, 2 };
            var analysisResult = AnalyzeNumbers(numbers);

            var (sum, count, average) = AnalyzeNumbers(numbers);

            // Can be skipped by using discard
            //var (sum, _, average) = AnalyzeNumbers(numbers);

            //var count = analysisResult.count;
            //var sum = analysisResult.sum;
            //var average = analysisResult.average;

            // Deconstructing Tuples
            var tuple = Tuple.Create("abc", 10, true);
            var (text, number, boolean) = tuple;

            var pet = new Pet("Whiskers", PetType.Cat, 3.5f);
            
            // Deconstruct Method
            var (name, type, weight) = pet;
            Console.WriteLine(name);
            Console.WriteLine(type);
            Console.WriteLine(weight);

            // How to deconstruct something like DateTime
            var date = new DateTime(2026, 2, 2);
            var (year, month, day) = date;
            Console.WriteLine($"{year}/{month}/{day}");

            if (analysisResult.count == 0)
            {
                Console.WriteLine("The collection is empty.");
            }
            else
            {
                Console.WriteLine($"The collection has {count} elements, " +
                    $"with a total sum of {sum} and the average " +
                    $"of {average:F3}");
            }

            var numbersAverageSize = average > 100 ? "large" : "small";

                (int sum, int count, double average) AnalyzeNumbers(IEnumerable<int> numbers)
                {
                    var sum = 0;
                    var count = 0;
                    foreach (var number in numbers)
                    {
                        sum += number;
                        count++;
                    }

                    var average = (double)sum / count;
                    return (sum, count, average);
                }
        }

        public class Pet
        {
            public string? Name { get;  }
            public PetType PetType { get; }
            public float Weight { get; }

            public Pet(string n, PetType petType, float weight)
            {
                Name = n;
                PetType = petType;
                Weight = weight;
            }

            public void Deconstruct(
                out string name,
                out PetType type,
                out float weight)
            {
                name = Name;
                type = PetType;
                weight = Weight;
            }
        }

        public enum PetType
        {
            Cat,
            Dog,
            Gerbil
        }
        
    }
}
