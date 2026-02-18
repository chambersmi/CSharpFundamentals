namespace Caching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }
    }

    public class PeopleController
    {
        private readonly IRepository<Person> _peopleRepository;

        public PeopleController(IRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public Person? GetByName(string firstName, string lastName)
        {
            // This may take a long time to access this data.
            // If we already accessed it, we can store it in application memory
            return _peopleRepository
                .GetByName(firstName, lastName)
                .FirstOrDefault();
        }
    }

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public interface IRepository<T>
    {
        List<T> GetByName(string fname, string lname);
    }

    public class Repository : IRepository<Person>
    {
        public List<Person> GetByName(string fname, string lname)
        {
            List<Person> personList = new List<Person>();
            var p = new Person
            {
                FirstName = "Mike",
                LastName = "Doe"
            };

            personList.Add(p);

            return personList;

        }
    }
}
