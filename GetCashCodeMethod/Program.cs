namespace GetHashCodeMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Output: abc hash code is 275303772
            var anyObject1 = "abc";
            Console.WriteLine($"{anyObject1} hash code is {anyObject1.GetHashCode()}");

            // Output: 123 hash code is 123
            var anyObject2 = 123;
            Console.WriteLine($"{anyObject2} hash code is {anyObject2.GetHashCode()}");

            //p1: 54267293
            //p2: 18643596
            Person p1 = new Person("Mike", "Joseph", 1983);
            Person p2 = new Person("Mike", "Joseph", 1983);
            Console.WriteLine($"p1: {p1.GetHashCode()}"); 
            Console.WriteLine($"p2: {p2.GetHashCode()}");

            //point1: 33574638
            //point2: 33736294            
            Point point1 = new Point(20, 20);
            Point point2 = new Point(20, 20);
            Point point3 = new Point(10, 20);
            Console.WriteLine($"point1: {point1.GetHashCode()}");
            Console.WriteLine($"point2: {point2.GetHashCode()}");
            Console.WriteLine($"point3: {point3.GetHashCode()}");
        }
    }

    // change from class to struct creates same hashcodes
    //point1: -1126483566
    //point2: -1126483566
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Implement custom GetHashCode 
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }

        public Person(string fname, string lname, int yob)
        {
            FirstName = fname;
            LastName = lname;
            YearOfBirth = yob;
        }

        // Creates duplicate hashcodes IF they are the same
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, YearOfBirth);
        }
    }
}
