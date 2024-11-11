using System.Threading;
namespace Lab06
{
    internal class Program
    {
        static double geom = 1;
        static double average = 0;
        static int[] massive = new int[20];
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random r = new Random();

            Console.Write($"Масив: ");
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = r.Next(1,10);
                Console.Write(massive[i] + " ");
            }

            Thread T0 = new Thread(Average);
            Thread T1 = new Thread(Geom);

            T0.Start();
            T1.Start();

            T0.Join();
            T1.Join();

            Console.WriteLine($"\nСереднє арифметичне: {average}");
            Console.WriteLine($"Середнє геометричне: {geom}");
        }
        static void Average()
        {
            for (int i = 0; i < massive.Length; i++)
            {
                average += massive[i];
            }
            average = Math.Round(average / massive.Length, 1);
        }

        static void Geom()
        {
            for (int i = 0; i < massive.Length; i++)
            {
                geom *= massive[i];
            }
            geom = Math.Round(Math.Pow(geom, 1.0 / massive.Length), 1);
        }
    }
}
