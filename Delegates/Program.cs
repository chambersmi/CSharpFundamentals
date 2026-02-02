using System.Data;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print print1 = text => Console.WriteLine(text.ToUpper());
            Print print2 = text => Console.WriteLine(text.ToLower());
            var multicast = print1 + print2;
            multicast("Crocodile");
            //Funcs are built in delegates
            Func<string, string> processString1 = TrimTo5Letters;
            
        }

        static string TrimTo5Letters(string input)
        {
            return input.Substring(0, 5);
        }
        enum CommandType { Start, Stop, Reset }
        delegate void Print(string input);
        delegate string ProcessString(string input);
        delegate bool RunCommand(CommandType commandType);
    }

    public interface ICommandExecutor
    {
        void Execute(Func<CommandType, bool> command);
    }
}
