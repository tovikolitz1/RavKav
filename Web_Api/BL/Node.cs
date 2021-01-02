using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    class Node<T>
    {
        private T value;
        private Node<T> next;
        private Node<T> prev;
        public Node()
        {
            
        }
        public Node(T value)
        {
            this.value = value;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
            this.next.prev = this;
        }
        public T Value()
        {
            return value;
        }
        public void Value(T value)
        {
            this.value = value;
        }
        public Node<T> Next()
        {
            return next;
        }
        public void Next(Node<T> next)
        {
            this.next = next;
        }
        public Node<T> Prev()
        {
            return prev;
        }
        public void Prev(Node<T> prev)
        {
            this.prev = prev;
        }
        public bool HasNext(Node<T> next)
        {
            return next != null;
        }
        public bool HasPrev(Node<T> prev)
        {
            return prev != null;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }

}

