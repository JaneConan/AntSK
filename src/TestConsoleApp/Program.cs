namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(JwtGenerator.GetToken("tccai", "eisoo.com"));
        }
    }
}
