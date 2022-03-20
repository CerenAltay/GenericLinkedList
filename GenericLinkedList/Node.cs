using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkedList
{
    public class Node<T>
    {
        public T data { get; set; }


        // public Node<T> Head { get; set; }
        public Node<T> next { get; set; }

        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }

        public Node()
        {
        }
    }
}
