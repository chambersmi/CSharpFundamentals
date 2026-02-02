namespace DisposeVsFinalize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt");
            //var line1 = fileReader.ReadLine();
            //var line2 = fileReader.ReadLine();
            //fileReader.Dispose();

            // using automatically calls Dispose()
            using (var fileReader2 = new FileReader("input.txt"))
            {
                var line1 = fileReader.ReadLine();
                var line2 = fileReader.ReadLine();
            }
        }
    }

    public class Person
    {
        public string? Name { get; set; }
        public Person(string name) => Name = name;

        ~Person()
        {
            Console.WriteLine($"Person {Name} is being destructed.");
        }
    }

    public class FileReader : IDisposable
    {
        private StreamReader? _streamReader;
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string ReadLine()
        {
            _streamReader ??= new StreamReader(_path);
            return _streamReader.ReadLine();
        }

        // Cleanup unmanaged resources
        public void Dispose()
        {
            _streamReader?.Dispose();
        }
    }
}
