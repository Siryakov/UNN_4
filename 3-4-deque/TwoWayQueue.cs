using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiryakovHomeWork3Methods
{
    public class TwoWayQueue<T>
    {
        private DoublyNode<T> front;
        private DoublyNode<T> rear;

        public TwoWayQueue()
        {
            front = null;
            rear = null;
        }

        public void AddFront(T data)
        {
            var newNode = new DoublyNode<T>(data);
            if (front == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                newNode.Next = front;
                front.Previous = newNode;
                front = newNode;
            }
        }

        public void AddRear(T data)
        {
            var newNode = new DoublyNode<T>(data);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                newNode.Previous = rear;
                rear.Next = newNode;
                rear = newNode;
            }
        }

        public T RemoveFront()
        {
            if (front == null)
            {
                throw new InvalidOperationException("Дек пуст");
            }

            var data = front.Data;
            front = front.Next;

            if (front == null)
            {
                rear = null;
            }
            else
            {
                front.Previous = null;
            }

            return data;
        }

        public T RemoveRear()
        {
            if (rear == null)
            {
                throw new InvalidOperationException("Дек пуст");
            }

            var data = rear.Data;
            rear = rear.Previous;

            if (rear == null)
            {
                front = null;
            }
            else
            {
                rear.Next = null;
            }

            return data;
        }

        public T GetFront()
        {
            if (front == null)
            {
                throw new InvalidOperationException("Дек пуст");
            }
            return front.Data;
        }

        public T GetRear()
        {
            if (rear == null)
            {
                throw new InvalidOperationException("Дек пуст");
            }
            return rear.Data;
        }

        public int Size()
        {
            int count = 0;
            var current = front;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }
}