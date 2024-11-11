namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread myThread = new Thread(Print);
            myThread.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Головний потік: {i}");
                Thread.Sleep(300);
            }
        }
        static void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Другий потік: {i}");
                Thread.Sleep(400);
            }
        }
    }
}
