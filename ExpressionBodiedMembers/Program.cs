using System.Reflection.Metadata.Ecma335;
using System.Runtime;

namespace ExpressionBodiedMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Mike", 1983);
            Console.WriteLine(person);
            Console.WriteLine(person.Age);
        }
    }

    public class Person
    {
        public string Name { get; }
        public int YearOfBirth { get; }
        public double Base { get; set; }
        public double Height { get; set; }

        public double Area() => 0.5 * Base * Height;

        private string _lastName;

        public string LastName {
            get => _lastName;
            set => value.Trim();                
        }

        public string PrintAndTrim(string input) => Console.Write(input);

        public Person(string name) => Name = name;

        public string LastName2
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        // Old way
        public int Age1 {
            get
            {
                return DateTime.Now.Year - YearOfBirth;
            }
        }

        // Expression body
        public int Age => DateTime.Now.Year - YearOfBirth;

        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        public override string ToString() =>        
            $"{Name} who was born on {YearOfBirth}";
        
    }


}
