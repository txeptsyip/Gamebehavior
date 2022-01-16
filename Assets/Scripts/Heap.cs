using System;

public class Heap<T> where T : IHeapItem<T>
{
    //code adapted from https://www.youtube.com/watch?v=3Dw5d7PlcTM
    // basically creates a binary tree in an array where position 0 is the parent node of positions 1 and 2

    //parent = (n-1)/2 Lchild = 2n+1 Rchild = 2n+2 so node 14 is the child of 6 and the parent of 29 and 30 (2X14 = 28 +1 for 29 and +2 for 30)

    // for some reason this causes the path to meander about I think its a problem with how I find the next nodes
    //(i'm thinking its getting the very first F value thats low and is not checking for the H value if two are the same but I did not have enough time to work this out)
    T[] items;
    int currentCount;

    public Heap(int maxSize)
    {
        items = new T[maxSize];
    }
    
    public void Add(T item)
    {
        item.HeapIndex = currentCount;
        items[currentCount] = item;
        SortUp(item);
        currentCount++;
    }

    public T RemoveFirst()
    {
        T firstItem = items[0];
        currentCount--;
        items[0] = items[currentCount];
        items[0].HeapIndex = 0;
        sortDown(items[0]);
        return firstItem;
    }
    void sortDown(T item)
    {
        while (true)
        {
            int childindexleft = item.HeapIndex * 2 + 1;
            int childindexright = item.HeapIndex * 2 + 2;
            int swapindex = 0;

            if (childindexleft < currentCount)
            {
                swapindex = childindexleft;

                if (childindexright < currentCount)
                {
                    if (items[childindexleft].CompareTo(items[childindexright]) < 0)
                    {
                        swapindex = childindexright;
                    }
                }
                if (item.CompareTo(items[swapindex]) < 0)
                {
                    swap(item, items[swapindex]);
                }
                else
                {
                    return;
                }
            }
            else return;
        }
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
        sortDown(item);
    }

    public int Count
    {
        get
        {
            return currentCount;
        }
    }

    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }
    void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex - 1) / 2;

        while (true)
        {
            T parentItem = items[parentIndex];
            if (item.CompareTo(parentItem) > 0)
            {
                swap(item, parentItem);
            }
            else
            {
                break;
            }
        }
    }

        void swap(T itemA, T itemB)
        {
            items[itemA.HeapIndex] = itemB;
            items[itemB.HeapIndex] = itemA;
            int itemAIndex = itemA.HeapIndex;
            itemA.HeapIndex = itemB.HeapIndex;
            itemB.HeapIndex = itemAIndex;
        }
}


    public interface IHeapItem<T> : IComparable<T>
    {
        int HeapIndex
        {
            get;
            set;
        }
}