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
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Data\count_1w.txt");
            Console.WriteLine("Read {0} lines from file", lines.Length);
            var words = lines
                .Select(x => x.Split('\t').FirstOrDefault())
                .Where(x => !String.IsNullOrEmpty(x))
                .ToArray();

            RunExperiment(() => new Trie<string>(), words);
            RunExperiment(() => new PatriciaTrie<string>(), words);
            RunExperiment(() => new SuffixTrie<string>(0), words);

            //RunExperiment(new PatriciaSuffixTrie<string>(0), words);



            Console.Read();

        }

        public static void RunExperiment(Func<ITrie<string>> trieFactory, IEnumerable<string> words)
        {
            
            

            var s = Stopwatch.StartNew();

            var proc = Process.GetCurrentProcess();
            var startMemory = proc.WorkingSet64;

            var trie = trieFactory();
            Console.WriteLine("Running experiment for: " + trie.GetType().ToString());
            // build trie
            foreach (var word in words)
            {
                trie.Add(word, word);
            }

            s.Stop();
            Console.WriteLine("Elapsed Time Building Tree: {0} ms", s.ElapsedMilliseconds);

            s = Stopwatch.StartNew();

            //run experiment
            RandomTestcaseProvider testcase = new RandomTestcaseProvider();
            foreach (var testWord in testcase.GetTestWords())
            {
                var result = trie.Retrieve(testWord);
                //Console.WriteLine(String.Join(" ", result));
            }

            s.Stop();
            Console.WriteLine("Elapsed Time Running Experiment: {0} ms", s.ElapsedMilliseconds);

            proc = Process.GetCurrentProcess();
            var endMemory = proc.WorkingSet64;

            Console.WriteLine("Memory Usage: {0}", (endMemory - startMemory) / 1048576.0);



        }



    }
}
