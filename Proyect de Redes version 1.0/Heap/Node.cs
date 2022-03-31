using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeap
{
    public class Node<T> where T : IComparable<T>
    {

        public int Index { get; set; }
        public T Value { get; set; }
        public Node(int index, T value)
        {
            Index = index;
            Value = value;
        }
    }
}
