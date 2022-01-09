using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Heap<T> where T : IHeapItem<T>
{
    //code adapted from https://www.youtube.com/watch?v=3Dw5d7PlcTM
    // basically creates a binary tree

    // not used because it actually ends up making long paths slower and causes them to meander about something chronic
    //(path from the top to bottom of an 18 X 200 sized grid with a node size of .3 took 18ms without this and 26 with)
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