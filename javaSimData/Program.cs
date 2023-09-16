using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace javaSimData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kiekis?");
            int count = int.Parse(Console.ReadLine());
            string[] output = new string[count];
            for (int x = 0; x < count; x++)
            {
                output[x] = "";
            }
            string[] lines = File.ReadAllLines("..//..//..//arg.txt", Encoding.UTF8);
            Console.WriteLine("Rasta {0} argumentu/ai", lines.Count());
            for (int i = 0; i < lines.Count(); i++)
            {
                string[] line = lines[i].Split(';');

                for (int x = 0; x < count; x++)
                {
                    //Console.WriteLine("DEBUG {0}", line.Length);
                    var randomIndex = StaticRandom.Instance.Next(0, line.Length);
                    //Console.WriteLine(randomIndex);
                    output[x] = output[x] + line[randomIndex] + ";";
                }
            }
            using (StreamWriter writer = new StreamWriter("..//..//..//output.txt"))
            {
                for (int x = 0; x < count; x++)
                {
                    Console.WriteLine(output[x]);
                    writer.WriteLine(output[x]);
                }
            }
        }
        // https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
        public static class StaticRandom
        {
            private static int seed;

            private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
                (() => new Random(Interlocked.Increment(ref seed)));

            static StaticRandom()
            {
                seed = Environment.TickCount;
            }

            public static Random Instance { get { return threadLocal.Value; } }
        }
    }
}
