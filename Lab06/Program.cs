using System.Threading;
namespace Lab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            int[] massive = new int[20];
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = r.Next(1,10);
            }

            Thread T0 = new Thread(Average);
            Thread T1 = new Thread(Geom);

            T0.Start();
            T1.Start();

            

            void Average()
            {
                double average = 0;

                for (int i = 0; i < massive.Length; i++)
                {
                    average += massive[i];
                }
                average = average / 2;
            }
            void Geom()
            {
                double geom = 1;

                for (int i = 0; i < massive.Length; i++)
                {
                    geom *= massive[i];
                }
                geom = Math.Pow(geom, 2);
            }


        }
    }
}
