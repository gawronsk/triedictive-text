using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieExperimentPlatform
{
    public class RandomTestcaseProvider
    {
        Random Random { get; set; }
        IEnumerable<string> Words { get; set; }

        public RandomTestcaseProvider()
        {
            Words = System.IO.File.ReadAllLines(@"..\..\Data\test.txt");
            Random = new Random();
        }


        public IEnumerable<string> GetTestWords()
        {
           foreach(var word in Words)
           {
               yield return word.Substring(0, Random.Next(word.Length + 1));
           }
        }


    }
}
