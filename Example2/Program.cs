using System.Net.Sockets;

namespace Example2
{
    internal class Program
    {
        static int x = 0;
        static object locker = new();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }
        static void Print()
        {
            lock (locker)
            {
                x = 1;
                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    x++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
