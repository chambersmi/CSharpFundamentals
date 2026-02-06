namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myArr = new[] { "a", "b", "c" };
            var myArr2 = new int[5];
            var matrix = new int[3, 5]; // two dimensenial, holds up to 15 elements
            matrix[2, 3] = 10;
                                       // 0   1  2
            var jagged = new int[3][]; // [] [] []
            jagged[0] = new int[2];    // []    []
            jagged[1] = new int[1];    //       []
            jagged[2] = new int[3];

            for(int row=0; row < jagged.Length; row++)
            {
                for(int col = 0; col < jagged[row].Length; col++)
                {
                    Console.WriteLine(jagged[row][col]);
                }
            }
        }
    }
}
