using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.DataStructures.StringSearch;

namespace TrieExperimentPlatform
{
    class TrieExperiment
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Data\count_1w_small.txt");
            Console.WriteLine("Read {0} lines from file", lines.Length);

            var s = Stopwatch.StartNew();


            var proc = Process.GetCurrentProcess();
            var startMemory = proc.WorkingSet64;

            var SuffixTrie = new SuffixTrie<string>(0);

            // build trie
            foreach(var line in lines)
            {
                var word = line.Split('\t').FirstOrDefault();
                if (word != null)
                {
                    // add to trie
                    SuffixTrie.Add(word, word);
                }
            }

            s.Stop();
            Console.WriteLine("Elapsed Time Building Tree: {0} ms", s.ElapsedMilliseconds);

            s = Stopwatch.StartNew();

            //run experiment
            RandomTestcaseProvider testcase = new RandomTestcaseProvider();
            foreach(var testWord in testcase.GetTestWords())
            {
                var result = SuffixTrie.Retrieve(testWord);
                //Console.WriteLine(String.Join(" ", result));
            }
            
            s.Stop();
            Console.WriteLine("Elapsed Time Running Experiment: {0} ms", s.ElapsedMilliseconds);


            var endMemory = proc.WorkingSet64;

            Console.WriteLine("Memory Usage: {0}", endMemory - startMemory);

            Console.Read();

        }
    }
}
