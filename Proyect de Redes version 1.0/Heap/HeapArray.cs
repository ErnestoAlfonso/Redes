using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeap
{
    public class Heap<T> : IEnumerable<Node<T>> where T : IComparable<T>
    {
        private Node<T>[] _heap = new Node<T>[16];

        #region Properties

        public int Size { get; set; }

        public T Root => _heap[0].Value;

        private bool _min;

        public Node<T> Min { get; set; }

        public Node<T> Max { get; set; }

        #endregion

        #region Builders
        public Heap(bool min)
        {
            _min = min;
            Size = 0;
        }
        public Heap(bool min, params T[] elements)
        {
            Size = elements.Length;
            while (Size > _heap.Length)
                Grow();
            BuildHeap(elements, min);
            _min = min;
        }
        #endregion

        #region Methods

        private static int GetParent(int i)
        {
            return ((i + 1) / 2) - 1;
        }
        private static int GetLeftChild(int i)
        {
            return (2 * i) + 1;
        }
        private static int GetRightChild(int i)
        {
            return (2 * i) + 2;
        }
        private void BuildHeap(T[] elements, bool min)
        {
            for (int i = elements.Length / 2 - 1; i >= 0; i--)
            {
                HeapifyDown(i, min, Size, elements);
            }
        }
        public void Insert(T item)
        {
            if (_heap[0] == null)
            {
                _heap[0] = new Node<T>(0, item);
                Min = _heap[0];
                Max = _heap[0];
                Size++;
            }
            else
            {
                if (Size == _heap.Length)
                    Grow();
                _heap[Size] = new Node<T>(Size, item);
                if (_heap[Size].Value.CompareTo(Min.Value) < 0)
                    Min = _heap[Size];
                else if (_heap[Size].Value.CompareTo(Min.Value) > 0)
                    Max = _heap[Size];
                HeapifyUp(_heap, Size, _min);
                Size++;
            }
            return;
        }
        private void InsertNode(Node<T> node)
        {
            if (_heap[0] == null)
            {
                _heap[0] = node;
                Min = _heap[0];
                Max = _heap[0];
                Size++;
            }
            else
            {
                if (Size == _heap.Length)
                    Grow();
                _heap[Size] = node;
                if (_heap[Size].Value.CompareTo(Min.Value) < 0)
                    Min = _heap[Size];
                else if (_heap[Size].Value.CompareTo(Min.Value) > 0)
                    Max = _heap[Size];
                HeapifyUp(_heap, Size, _min, true);
                Size++;
            }
        }
        public T Pop()
        {
            if (_heap[0] == null)
                return default(T);
            T result = _heap[0].Value;
            _heap[0].Value = _heap[Size - 1].Value;
            _heap[Size - 1] = null;
            Size--;
            HeapifyDown(0, _min, Size);
            return result;
        }
        private Node<T> PopNode()
        {
            Node<T> result = new Node<T>(_heap[0].Index, _heap[0].Value);
            _heap[0] = _heap[Size - 1];
            _heap[Size - 1] = null;
            Size--;
            HeapifyDown(0, _min, Size, null, true);
            return result;
        }
      
        private static void HeapifyUp(Node<T>[] heap, int index, bool min, bool insertNode = false)
        {
            int parent = GetParent(index);
            if (parent < 0 || index >= heap.Length)
                return;
            if (min)
            {
                if (heap[parent].Value.CompareTo(heap[index].Value) > 0)
                {
                    if (insertNode)
                    {
                        var temp1 = heap[parent];
                        heap[parent] = heap[index];
                        heap[index] = temp1;
                    }
                    else
                    {
                        T temp = heap[parent].Value;
                        heap[parent].Value = heap[index].Value;
                        heap[index].Value = temp;
                    }
                }
                else return;
            }
            else
            {
                if (heap[parent].Value.CompareTo(heap[index].Value) < 0)
                {
                    if (insertNode)
                    {
                        var temp1 = heap[parent];
                        heap[parent] = heap[index];
                        heap[index] = temp1;
                    }
                    else
                    {
                        T temp = heap[parent].Value;
                        heap[parent].Value = heap[index].Value;
                        heap[index].Value = temp;
                    }
                }
                else return;
            }
            HeapifyUp(heap, parent, min);
        }
        private void HeapifyDown(int index, bool min, int size, T[] heap = null, bool popNode = false)
        {
            if (index >= size || index < 0)
                return;
            if (_heap[index] == null)
                _heap[index] = new Node<T>(index, heap[index]);
            int left = GetLeftChild(index);
            int right = GetRightChild(index);
            if (left >= size)
            {
                if (right >= size) return;
                if (_heap[right] == null)
                    _heap[right] = new Node<T>(right, heap[right]);
            }
            else if (right >= size)
            {
                if (_heap[left] == null)
                    _heap[left] = new Node<T>(left, heap[left]);
            }
            else
            {
                if (_heap[left] == null && _heap[right] == null)
                {
                    _heap[left] = new Node<T>(left, heap[left]);
                    _heap[right] = new Node<T>(right, heap[right]);
                }
            }
            int aux = index;
            if (min)
            {
                if (left < size && _heap[left].Value.CompareTo(_heap[index].Value) < 0)
                    aux = left;
                if (right < size && _heap[right].Value.CompareTo(_heap[aux].Value) < 0)
                    aux = right;
                if (aux > index)
                {
                    if (popNode)
                    {
                        var temp = _heap[index];
                        _heap[index] = _heap[aux];
                        _heap[aux] = temp;
                    }
                    else
                    {
                        var temp = _heap[index].Value;
                        _heap[index].Value = _heap[aux].Value;
                        _heap[aux].Value = temp;
                    }
                }
                else return;
            }
            else
            {
                if (left < size && _heap[left].Value.CompareTo(_heap[index].Value) > 0)
                    aux = left;
                if (right < size && _heap[right].Value.CompareTo(_heap[aux].Value) > 0)
                    aux = right;
                if (aux > index)
                {
                    if (popNode)
                    {
                        var temp = _heap[index];
                        _heap[index] = _heap[aux];
                        _heap[aux] = temp;
                    }
                    else
                    {
                        var temp = _heap[index].Value;
                        _heap[index].Value = _heap[aux].Value;
                        _heap[aux].Value = temp;
                    }
                }
                else return;
            }
            HeapifyDown(aux, min, size, heap, popNode);
        }
        private void Grow()
        {
            Node<T>[] arrayAux = new Node<T>[_heap.Length * 2];
            Array.Copy(_heap, arrayAux, Size);
            _heap = arrayAux;
        }
        public LinkedList<T> LessThan(T value)
        {
            LinkedList<T> result = new LinkedList<T>();
            if (_heap[0].Value.CompareTo(value) < 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[0].Value));
                LessThan(value, 0, result);
            }
            return result;
        }
        private void LessThan(T value, int root, LinkedList<T> result)
        {
            int left = GetLeftChild(root);
            int right = GetRightChild(root);
            if (left < Size && _heap[left].Value.CompareTo(value) < 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[left].Value));
                LessThan(value, left, result);
            }
            if (right < Size && _heap[right].Value.CompareTo(value) < 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[right].Value));
                LessThan(value, right, result);
            }
            return;
        }
        public LinkedList<T> BiggerThan(T value, int K = default(int))
        {
            LinkedList<T> result = new LinkedList<T>();
            if (_heap[0].Value.CompareTo(value) > 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[0].Value));
                if (K != default(int))
                    BiggerThan(value, 0, result, K);
                else
                    BiggerThan(value, 0, result);
            }
            return result;
        }
        private void BiggerThan(T value, int root, LinkedList<T> result)
        {
            int left = GetLeftChild(root);
            int right = GetRightChild(root);
            if (left < Size && _heap[left].Value.CompareTo(value) > 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[left].Value));
                BiggerThan(value, left, result);
            }
            if (right < Size && _heap[right].Value.CompareTo(value) > 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[right].Value));
                BiggerThan(value, right, result);
            }
        }
        private void BiggerThan(T value, int root, LinkedList<T> result, int K)
        {
            if (result.Count == K) return;
            int left = GetLeftChild(root);
            int right = GetRightChild(root);
            if (left < Size && _heap[left].Value.CompareTo(value) >= 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[left].Value));
                BiggerThan(value, left, result, K);
            }
            if (right < Size && _heap[right].Value.CompareTo(value) >= 0)
            {
                result.AddLast(new LinkedListNode<T>(_heap[right].Value));
                BiggerThan(value, right, result, K);
            }
        }
        public bool K_iBiggerThanX(T value, int k)
        {
            var greater = BiggerThan(value, k);
            return greater.Count >= k;
        }
        public T GetKLarge(int k)
        {
            Heap<T> heapAux = new Heap<T>(false);
            heapAux.InsertNode(_heap[0]);
            T result = default(T);
            for (int i = 0; i < k; i++)
            {
                var node = heapAux.PopNode();
                result = node.Value;
                int left = GetLeftChild(node.Index);
                int right = GetRightChild(node.Index);
                if (left < Size)
                    heapAux.InsertNode(_heap[left]);
                if (right < Size)
                    heapAux.InsertNode(_heap[right]);
            }
            return result;
        }

       

        #endregion

        #region HeapWalker
        public IEnumerator<Node<T>> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return _heap[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
