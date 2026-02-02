namespace TupleVsValueTuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Defining an int,string tuple
            var tuple1 = new Tuple<int, string>(1, "aaa");
            var tuple9 = new Tuple<int, string>(1, "aaa");
            // Tuple Create
            var tuple2 = Tuple.Create(1, "bbb", "ccc", "ddd");

            // Access the values
            var number = tuple1.Item1;
            var text = tuple1.Item2;

            Console.WriteLine($"Number: {number}\nText: {text}");
            Console.WriteLine($"Tuple 2: {tuple2.Item1}, {tuple2.Item2}, {tuple2.Item3}, {tuple2.Item4}");

            // Allowed 8 tuple items, but there's a workaround by making it nested
            var tuple3 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(9, 10, 11, 12, 13, 14, 15));

            var valueTuple1 = (2, "bbb");
            var valueTuple2 = (2, "bbb");
            var tuple5 = (2, "bbb");

            Console.WriteLine($"tuple1.Equals(tuple9): {tuple1.Equals(tuple9)}");
            Console.WriteLine($"tuple1==tuple9: {tuple1==tuple9}");
            Console.WriteLine($"valueTuple1==valueTuple2: {valueTuple1 == valueTuple2}");
            Console.WriteLine($"valueTuple1==tuple2: {valueTuple1.Equals(tuple5)}");

            var refTuple = Tuple.Create(1, "immutable");
            //refTuple.Item1 = 1;
            var valTuple = (1, "mutable");
            valTuple.Item1 = 1;

            var valueTuple3 = (number: 123, text: "it's easy as");
            Console.WriteLine(valueTuple3);

            var valueText = valueTuple3.text;
            var valueNumber = valueTuple3.number;
            Console.WriteLine($"value text: {valueText} and value number: {valueNumber}");
            var hugeValueTuple = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            var tuple = (number: 2, "abc");
        }
    }
}
