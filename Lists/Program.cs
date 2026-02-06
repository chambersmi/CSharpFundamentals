namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            Console.WriteLine($"List Capacity is {list.Capacity}");

            list.Add(5);
            Console.WriteLine($"List Capacity is {list.Capacity}"); //4

            list.AddRange(new int[] { 6, 43, 3, 9 });
            Console.WriteLine($"List Capacity is {list.Capacity}"); //8

            list.AddRange(new int[] { 6, 43, 3, 9 });
            Console.WriteLine($"List Capacity is {list.Capacity}"); //16

            list.Clear(); // still shows 16
            Console.WriteLine($"List Capacity after clearing: {list.Capacity}"); //16

            var list2 = new List<int>(1050);
            Console.WriteLine($"Capacity is set to {list2.Capacity}");

            // Resizing is heavy
            list2.AddRange(Enumerable.Range(0, 2000));
            Console.WriteLine($"Capacity after range is set to {list2.Capacity}");
            list2.Clear();
            list2.Add(10);
            list2.TrimExcess();
            Console.WriteLine($"Capacity after trimexcess is set to {list2.Capacity}");
        }
    }
}
