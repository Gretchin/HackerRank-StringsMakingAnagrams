using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_the_running_median
{
    abstract class Heap
    {
        protected int size;
        protected List<int> items;

        public Heap()
        {
            size = 0;
            items = new List<int>();
        }

        public int Size { get { return size; } }

        /** @param parentIndex The index of the parent element.
        @return The index of the left child.
        **/
        public int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        /** @param parentIndex The index of the parent element.
            @return The index of the right child.
        **/
        public int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        /** @param childIndex The index of the child element.
            @return The index of the parent element.
        **/
        public int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        /** @param index The index of the element you are checking.
            @return true if the Heap contains enough elements to fill the left child index, 
                    false otherwise.
        **/
        public bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }

        /** @param index The index of the element you are checking.
            @return true if the Heap contains enough elements to fill the right child index, 
                    false otherwise.
        **/
        public bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        /** @param index The index of the element you are checking.
            @return true if the calculated parent index exists within array bounds
                    false otherwise.
        **/
        public bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        /** @param index The index of the element whose child you want.
            @return the value in the left child.
        **/
        public int leftChild(int index)
        {
            return items[getLeftChildIndex(index)];
        }

        /** @param index The index of the element whose child you want.
            @return the value in the right child.
        **/
        public int rightChild(int index)
        {
            return items[getRightChildIndex(index)];
        }

        /** @param index The index of the element you are checking.
            @return the value in the parent element.
        **/
        public int parent(int index)
        {
            return items[getParentIndex(index)];
        }

        /** @param indexOne The first index for the pair of elements being swapped.
            @param indexTwo The second index for the pair of elements being swapped.
        **/
        public void swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        public bool isEmpty()
        {
            if (size == 0)
                return true;
            return false;
        }

        /** @return The value at the top of the Heap.
         **/
        public int peek()
        {
            return items[0];
        }


        /** Extracts root element from Heap.
        **/
        public int poll()
        {
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            items.RemoveAt(size);
            heapifyDown();
            return item;
        }        

        /** @param item The value to be inserted into the Heap. **/
        public void add(int item)
        {

            // Insert value at the next open location in heap
            items.Add(item);
            size++;

            // Correct order property
            heapifyUp();
        }

        /** Swap values down the Heap. **/
        public abstract void heapifyDown();

        /** Swap values up the Heap. **/
        public abstract void heapifyUp();


    }
    class MaxHeap : Heap
    {
        public override void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index)
                    && rightChild(index) > leftChild(index)
                )
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (items[index] > items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
        public override void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) < items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }
    }
    class MinHeap : Heap
    {
        public override void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (items[index] < items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
        public override void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }
    }
}
