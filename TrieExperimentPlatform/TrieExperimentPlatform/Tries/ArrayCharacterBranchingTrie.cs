using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieExperimentPlatform.Tries
{
    // Andrew Implement:
    class ArrayCharacterBranchingTrie : ITrie
    {
        public void InsertWithPriority(string value, double priority)
        {
            throw new NotImplementedException();
        }

        public string FindWithPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public IList<string> FindTopNWithPrefix(string prefix, int n)
        {
            throw new NotImplementedException();
        }

        public ArrayCharacterBranchingTrie()
        {

        }


        class ArrayNode
        {
            public string Value { get; set; }

            public double Priority { get; set; }

            public ArrayNode[] Children { get; set; }

            public ArrayNode(string value, double priority)
            {
                Value = value;
                Priority = priority;
                Children = new ArrayNode[27]; // # lowercase chars + space
            }
        }



    }
}
