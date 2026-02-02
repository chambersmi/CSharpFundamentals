namespace GarbageCollector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Person person = new Person();
            if(flag)
            {
                string textInsideIf = "aaa";
                person.Name = "Tom";
            }

            string text = "bbb";
        }
    }

    public class Person
    {
        public string? Name { get; set; }
    }
}
