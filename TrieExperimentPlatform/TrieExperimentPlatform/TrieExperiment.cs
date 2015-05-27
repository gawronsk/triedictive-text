using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieExperimentPlatform
{
    class TrieExperiment
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Data\count_1w_small.txt");
            Console.WriteLine("Read {0} lines from file", lines.Length);

            Stopwatch s = Stopwatch.StartNew();

            // build trie
            foreach(var line in lines)
            {
                var word = line.Split('\t').FirstOrDefault();
                if (word != null)
                {
                    // add to trie
                }
            }

            s.Stop();
            Console.WriteLine("Elapsed Time Building Tree: {0} ms", s.ElapsedMilliseconds);

            s = Stopwatch.StartNew();

            //run experiment

            s.Stop();
            Console.WriteLine("Elapsed Time Running Experiment: {0} ms", s.ElapsedMilliseconds);

            Console.Read();
        }
    }
}
