using Microsoft.VisualBasic;

namespace Indexers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 10, 20, 30 };
            var list = new List<decimal> { 5.5m, 3m, 0m };
            var thirdElement = list[2];

            // Instance of a custom List class
            var numbers2 = new MyList<int>(new int[] { 1, 2, 3, 4 });
            numbers2[2] = 0;

            var string1 = numbers2["1"];
        }
    }

    class MyList<T>
    {
        private T[] _elements;

        public MyList(T[] elements)
        {
            _elements = elements;
        }

        // Define an integer indexer
        public T this[int index]
        {
            get => _elements[index];
            set => _elements[index] = value;
        }

        // Define a string indexer
        public T this[string index]
        {
            get => _elements[int.Parse(index)];
            set => _elements[int.Parse(index)] = value;
        }

        // Define indexer with multiple parameters
        public T this[int index1, int index2]
        {
            get => _elements[index1 + index2];
            set => _elements[index1 + index2] = value;
        }
    }
}
