using System;
using System.Collections.Generic;

namespace GenericLinkedList
{
    public class CustomLinkedList<T>
    {
        //allowed head to be public in order to initiate
        //data from Program.cs for console demonstration
        public Node<T> head;
        private Node<T> tail;
        private const string IndexOutOfRangeExMessage = "Index is out of range";
        private const string ListIsEmptyMessage = "List is Empty";

        public void InitializeData(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (head == null)
                {
                    head = tail = new Node<T>(item);
                }
                else
                {
                    tail = tail.Next = new Node<T>(item);
                }
            }
        }

        public void Insert(T item, int position)
        {
            if (IsIndexOutOfRange(position) == true)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeExMessage);
            }
            Node<T> newNode = new(item);
            Node<T> currentNode = head;

            if (position == 1)
            {
                head = newNode;
                head.Next = currentNode;
                newNode = currentNode.Next;
            }
            else
            {
                for (int i = 1; i < position - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                newNode.Next = currentNode.Next;
            }
            currentNode.Next = newNode;
        }

        public void Delete(int position)
        {
            if (IsIndexOutOfRange(position) == true)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeExMessage);
            }

            Node<T> currentNode = head;

            if (position == 1)
            {
                head = currentNode.Next;
                return;
            }

            for (int i = 1; currentNode != null && i < position - 1; i++)
            {
                currentNode = currentNode.Next;
            }

            Node<T> NextNode = currentNode.Next.Next;
            currentNode.Next = NextNode;
        }

        public string PrintList()
        {
            Node<T> currentNode = head;

            if (IsListEmpty() == true)
            {
                return ListIsEmptyMessage;
            }

            List<string> printedNodeList = new();

            while (currentNode != null)
            {
                //for console representation
                Console.Write(currentNode.Data + "->");

                //for unit test checks
                printedNodeList.Add(currentNode.Data + "->");
                currentNode = currentNode.Next;
            }
            string printedNodes = string.Join("", printedNodeList.ToArray());
            return printedNodes;
        }

        #region helper methods
        private bool IsIndexOutOfRange(int index)
        {
            int numberOfNodes = CountNodes();

            if (index < 1 || index > numberOfNodes + 1)
            {
                return true;

            }
            return false;
        }
        private bool IsListEmpty()
        {
            int numberOfNodes = CountNodes();

            if (numberOfNodes == 0)
            {
                return true;

            }
            return false;
        }

        private int CountNodes()
        {
            Node<T> currentNode = head;
            int count = 0;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }
        #endregion
    }
}