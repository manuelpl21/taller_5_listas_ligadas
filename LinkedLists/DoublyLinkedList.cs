using System;

namespace LinkedLists
{
    public class DoublyLinkedList<T> where T : IComparable<T> // Interfaz que permite comparar los elementos
    {
        private DoubleNode<T> head;
        private DoubleNode<T> tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void InsertInOrder(T data) // Método nuevo para insertar en orden ascendente
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            if (data.CompareTo(head.Data) <= 0)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                return;
            }

            DoubleNode<T> current = head;
            while (current != null && current.Data.CompareTo(data) < 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
        }

        public void InsertAtBeginning(T data) // Método existente para insertar al inicio de la lista
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        public void InsertAtEnd(T data) // Método existente para insertar al final de la lista
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void PrintForward() // Método existente para imprimir la lista de forma ascendente
        {
            DoubleNode<T> current = head;
            if (current == null)
            {
                Console.Write("La lista está vacía.");
                return;
            }
                
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null)
                {
                    Console.Write(" <-> ");
                }
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void PrintBackward() // Método existente para imprimir la lista de forma descendente
        {
            DoubleNode<T> current = tail;
            if (current == null)
            {
                Console.Write("La lista está vacía.");
                return;
            }

            while (current != null)
            {
                Console.Write(current.Data);

                if (current.Prev != null)
                {
                    Console.Write(" <-> ");
                }
                current = current.Prev;
            }
            Console.WriteLine();
        }

        public void Remove(T data) // Método existente para eliminar un nodo específico
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        tail = current.Prev;

                    break;
                }
                current = current.Next;
            }
        }

        public void Reverse() // Nuevo método para invertir la lista
        {
            DoubleNode<T> current = head;
            DoubleNode<T> temp = null;

            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;

                current = current.Prev;
            }

            if (temp != null)
            {
                tail = head;
                head = temp.Prev;
            }
        }

        public List<T> GetModes() // Nuevo método para obtener la(s) moda(s) de la lista
        {
            var frequencies = GetFrequencies();
            if (frequencies.Count == 0) return new List<T>();

            int maxFreq = frequencies.Values.Max();
            return frequencies.Where(kvp => kvp.Value == maxFreq).Select(kvp => kvp.Key).ToList();
        }

        public void PrintGraph() // Nuevo método para imprimir un gráfico basado en las frecuencias de los elementos
        {
            var frequencies = GetFrequencies();
            if (frequencies.Count == 0)
            {
                Console.WriteLine("La lista está vacía, no hay gráfico para mostrar.");
                return;
            }

            foreach (var kvp in frequencies)
            {
                Console.WriteLine($"{kvp.Key} {new string('*', kvp.Value)}");
            }
        }

        public bool Contains(T data) // Método nuevo para verificar si un elemento está presente en la lista
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveFirst(T data) // Método nuevo para eliminar solo la primera ocurrencia de un elemento específico
        {
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev != null) current.Prev.Next = current.Next;
                    else head = current.Next;

                    if (current.Next != null) current.Next.Prev = current.Prev;
                    else tail = current.Prev;

                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int RemoveAll(T data) // Método nuevo para eliminar todas las ocurrencias de un elemento específico y devolver la cantidad eliminada
        {
            int count = 0;
            DoubleNode<T> current = head;
            while (current != null)
            {
                DoubleNode<T> nextNode = current.Next;

                if (current.Data.Equals(data))
                {
                    if (current.Prev != null) current.Prev.Next = current.Next;
                    else head = current.Next;

                    if (current.Next != null) current.Next.Prev = current.Prev;
                    else tail = current.Prev;

                    count++;
                }
                current = nextNode;
            }
            return count;
        }

        private Dictionary<T, int> GetFrequencies() // Método auxiliar para obtener frecuencias
        {
            Dictionary<T, int> freq = new Dictionary<T, int>();
            DoubleNode<T> current = head;
            while (current != null)
            {
                if (freq.ContainsKey(current.Data))
                    freq[current.Data]++;
                else
                    freq[current.Data] = 1;

                current = current.Next;
            }
            return freq;
        }
    }
}
