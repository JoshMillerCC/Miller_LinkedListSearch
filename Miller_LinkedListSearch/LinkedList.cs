using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Miller_LinkedListSearch
{
    class LinkedList
    {
        private Node head;
        private Node tail;

        public Node getHead()
        {
            return head;
        }
        public Node Add(MetaData data)
        {
            // if empty add to head
            if (head == null)
            {
                head = new Node(data);
                tail = head;
                return head;
            }

            Node current = head;

            // if is not empty search for add point
            while (current != null)
            {
                Node next = current.Next;
                // if tail is null
                if (next == null)
                {
                    if (current.Data.getName().CompareTo(data.getName()) > 0)
                    {
                        Node temp = new Node(data);
                        temp.Next = head;
                        head = temp;
                        return temp;
                    }
                    else
                    {
                        tail.Next = new Node(data);
                        tail.Next.Previous = tail;
                        tail = tail.Next;
                        return tail;
                    }
                }

                // handle new head
                if (current.Data.getName().CompareTo(data.getName()) > 0)
                {
                    Node temp = new Node(data);
                    temp.Next = head;
                    head = temp;
                    return temp;
                }

                // insert in middle
                if (current.Data.getName().CompareTo(data.getName()) < 0 && next.Data.getName().CompareTo(data.getName()) >= 0)
                {
                    current.Next = new Node(data);
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return current.Next;
                }

                // insert if name/gender are equal
                if (current.Data.getName().CompareTo(data.getName()) == 0 && current.Data.getGender().CompareTo(data.getGender()) == 0)
                {
                    current.Next = new Node(data);
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return current.Next;
                }

                current = current.Next;
            }
            return null;
        }

        public string Print()
        {
            // Remove later for encapsulation
            Node current = head;
            StringBuilder sb = new StringBuilder();

            while (current != null)
            {
                sb.Append(current.Data.getName() + "\n");
                current = current.Next;
            }
            return sb.ToString();
        }

        public Node Search(string data)
        {
            Node front = head;
            Node back = tail;

            while (back != null)
            {
                if (back == null)
                {
                    return null;
                }
                if (front.Data.getName().ToLower().Equals(data.ToLower()))
                {
                    return front;
                }
                else if (back.Data.getName().ToLower().Equals(data.ToLower()))
                {
                    return back;
                }
                front = front.Next;
                back = back.Previous;
            }
            return null;
        }

        public Node MalePopularity()
        {
            Node current = head;
            Node popM = head;

            while (current != null)
            {
                if (current.Data.getGender() == 'M')
                {
                    popM = current;
                    break;
                }
                current = current.Next;
            }
            current = head;
            while (current != null)
            {
                if (current == null)
                {
                    return null;
                }
                if (popM.Data.getRank() <= current.Data.getRank() && current.Data.getGender().Equals('M'))
                {
                    popM = current;
                }
                if (current.Next == null)
                {
                    return popM;
                }
                current = current.Next;
            }
            return null;
        }

        public Node FemalePopularity()
        {
            Node current = head;
            Node popF = head;

            while (current != null)
            {
                if (current.Data.getGender() == 'F')
                {
                    popF = current;
                    break;
                }
                current = current.Next;
            }
            current = head;
            while (current != null)
            {
                if (current == null)
                {
                    return null;
                }
                if (popF.Data.getRank() <= current.Data.getRank() && current.Data.getGender().Equals('F'))
                {
                    popF = current;
                }
                if (current.Next == null)
                {
                    return popF;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
