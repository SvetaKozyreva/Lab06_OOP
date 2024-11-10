using System.Threading;
namespace Lab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            double geom = 1;
            double average = 0;
            int[] massive = new int[20];

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

            void Average()
            {
                for (int i = 0; i < massive.Length; i++)
                {
                    average += massive[i];
                }
                average /= 2;
            }

            void Geom()
            {
                for (int i = 0; i < massive.Length; i++)
                {
                    geom *= massive[i];
                }
                geom = Math.Round(Math.Sqrt(geom), 1);
            }


        }
    }
}
