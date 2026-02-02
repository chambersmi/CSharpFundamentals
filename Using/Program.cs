global using System.Diagnostics; // imports globally
using static System.Console;
namespace Using
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var fs = File.Open("path", FileMode.Open);
            using (var fs2 = File.Open("path", FileMode.Open))
            {
                //operation
            }
        }
    }
}
