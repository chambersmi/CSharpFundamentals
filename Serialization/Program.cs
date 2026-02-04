using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XML_OpenFileIfExistsOtherwiseAskQuestions();
        }

        static void XML_OpenFileIfExistsOtherwiseAskQuestions()
        {
            const string filePath = "person.xml";
            if (File.Exists(filePath))
            {
                using Stream stream = File.OpenRead(filePath);
                var xmlSerializer = new XmlSerializer(typeof(Person));
                using StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                var person = (Person?)xmlSerializer.Deserialize(
                    new XmlTextReader(streamReader));

                Console.WriteLine($"Hello {person.Name} {person.LastName}, " +
                    $"from {person.Residence}! Do you still enjoy {person.Hobby}?");
            }
            else
            {
                var name = Read("name");
                var lastName = Read("last name");
                var residence = Read("place of residence");
                var hobby = Read("hobby");

                var person = new Person(name, lastName, residence, hobby);
                var xml = Serialize(person);
                SaveToXmlFile(xml, filePath);
            }
        }

        static void SaveToXmlFile(string xml, string path)
        {
            File.WriteAllText(path, xml);
        }

        static string Read(string what)
        {
            Console.WriteLine($"Enter the {what}: ");
            return Console.ReadLine();
        }

        static string Serialize(Person person)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter,
                new XmlWriterSettings { Indent = true});
            xmlSerializer.Serialize(xmlWriter, person);
            
            return stringWriter.ToString();
        }
    }

    public record Person
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Residence { get; set; }
        public string? Hobby { get; set; }

        public Person()
        {
            
        }

        public Person(string n, string ln, string r, string h)
        {
            Name = n;
            LastName = ln;
            Residence = r;
            Hobby = h;
        }
    }
}
