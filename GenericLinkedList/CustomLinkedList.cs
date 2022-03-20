using System;
using System.Collections.Generic;

namespace GenericLinkedList
{
    public class CustomLinkedList<T>
    {
        public Node<T> head;
        private const string IndexOutOfRangeExMessage = "Index is out of range";
        private const string ListIsEmptyMessage = "List is Empty";

        public void InitiateData(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Node<T> newNode = new Node<T>(item);

                newNode.next = head;
                head = newNode;
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

            if (position == 0)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                for (int i = 0; i < position - 1; i++)
                {

                    currentNode = currentNode.next;
                }
            }
            newNode.next = currentNode.next;
            currentNode.next = newNode;
        }

        //index starts at zero correct
        public void Delete(int position)
        {
            if (IsIndexOutOfRange(position) == true)
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeExMessage);
            }

            if (head == null)
            {
                return;
            }
            Node<T> currentNode = head;

            if (position == 0)
            {
                head = currentNode.next;
                return;
            }

            //check double condition
            for (int i = 0; currentNode != null && i < position - 1; i++)
            {
                currentNode = currentNode.next;
            }
            if (currentNode == null || currentNode.next == null)
            {
                return;
            }

            Node<T> nextNode = currentNode.next.next;
            currentNode.next = nextNode;
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
                Console.Write(currentNode.data + "->");
                //for unit test checks
                printedNodeList.Add(currentNode.data + "->");
                currentNode = currentNode.next;
            }
            string printedNodes = string.Join("", printedNodeList.ToArray());
            return printedNodes;
        }

        #region helper methods
        private bool IsIndexOutOfRange(int index)
        {
            int numberOfNodes = CountNodes();

            if (index < 0 || index > numberOfNodes)
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
                currentNode = currentNode.next;
            }
            return count;
        }
        #endregion
    }
}