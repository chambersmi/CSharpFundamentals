namespace DynamicKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello World!";
            var someClass = new SomeClass(text);
        }
    }

    public class  SomeClass
    {
        public string Text { get; }
        public SomeClass(dynamic hopefullyText)
        {
            Text = hopefullyText;
        }
    }
}
