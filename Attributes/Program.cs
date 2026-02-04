using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validPerson = new Person("Mike", 1983);
            var invalidDog = new Dog("R");
            var validator = new Validator();

            Console.WriteLine(validator.Validate(validPerson) ?
                "Person is Valid" : "Person is Invalid");

            Console.WriteLine(validator.Validate(invalidDog) ?
            "Dog is Valid" : "Dog is Invalid");
        }
    }

    // Custom attribute
    public class Validator
    {
        public bool Validate(object obj)
        {
            var type = obj.GetType();
            var propertiesToValidate = type
                .GetProperties()
                .Where(property => Attribute.IsDefined(
                    property, typeof(StringLengthValidateAttribute)));

            foreach(var property in propertiesToValidate)
            {
                object? propertyValue = property.GetValue(obj);
                if(propertyValue is not string)
                {
                    throw new InvalidOperationException(
                        $"Attribute {nameof(StringLengthValidateAttribute)}" +
                        $" can only be applied to strings.");
                }

                var value = (string)propertyValue;
                var attribute = (StringLengthValidateAttribute)property.GetCustomAttributes(
                    typeof(StringLengthValidateAttribute), true).First();

                if(value.Length < attribute.Min || value.Length > attribute.Max)
                {
                    Console.WriteLine($"Property {property.Name} is invalid.\nValue is {value}");
                    return false;
                }
            }

            return true;
        }
    }

    public class Dog 
    {
        [StringLengthValidate(2,10)]
        public string? Name { get; set; }
        public Dog(string name) => Name = name;
        
    }

    public class Person
    {
        [StringLengthValidate(2, 25)]
        public string? Name { get; set; }
        public int YearOfBirth { get; set; }

        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        public Person(string name) => Name = name;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthValidateAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }

        public StringLengthValidateAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
