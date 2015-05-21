using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieExperimentPlatform.Tries
{
    interface ITrie
    {
        void InsertWithPriority(string value, double priority);

        string FindWithPrefix(string prefix);

        IList<string> FindTopNWithPrefix(string prefix, int n);
    }
}
