using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miller_LinkedListSearch
{
    class Node
    {
        public Node Previous;
        public Node Next;
        public MetaData Data;
        public Node (MetaData data)
        {
            Next = null;
            Previous = null;
            Data = data;
        }
    }
}
