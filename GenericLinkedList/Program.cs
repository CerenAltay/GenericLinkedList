using System;
using System.Collections.Generic;

namespace GenericLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomLinkedList<string> linkedList2 = new CustomLinkedList<string>();

           //initialize data to display on console
            
            Node<string> firstNode = new Node<string>("A");
            Node<string> secondNode = new Node<string>("B");
            Node<string> thirdNode = new Node<string>("C");
            Node<string> fourthNode = new Node<string>("D");
            linkedList2.head = firstNode;
            firstNode.next = secondNode;
            secondNode.next = thirdNode;
            thirdNode.next = fourthNode;

            linkedList2.PrintList();
            linkedList2.Insert("X", 4);
            Console.WriteLine();
            Console.WriteLine("Insert node 'X' on position 4");
            linkedList2.PrintList();
            Console.WriteLine();
            Console.WriteLine("Delete the node on position 1");
            linkedList2.Delete(1);
            linkedList2.PrintList();
        }
    }
}

