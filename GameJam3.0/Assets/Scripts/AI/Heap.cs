using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Heap<T> where T : IHeapItem<T> 
{
    T[] items;
    int currentItemCount;

    public Heap(int _maxHeepSize)
    {
        items = new T[_maxHeepSize];
    }

    public void Add(T _item)
    {
        _item.HeapIndex = currentItemCount;
        items[currentItemCount] = _item;
        SortUp(_item);
        ++currentItemCount;
    }

    void SortUp(T _item)
    {
        int iParentIndex = (_item.HeapIndex - 1) / 2;

        while (true)
        {
            T parentItem = items[iParentIndex];
            if( _item.CompareTo(parentItem) > 0)
            {
                Swap(_item, parentItem);
            }
            else
            {
                break;
            }

            iParentIndex = (_item.HeapIndex - 1) / 2;
        }
    }

    void SortDown(T _item)
    {
        while (true)
        {
            int iChildIndexLeft = _item.HeapIndex * 2 + 1;
            int iChildIndexRight = _item.HeapIndex * 2 + 2;
            int iSwapIndex = 0;

            if( iChildIndexLeft < currentItemCount)
            {
                iSwapIndex = iChildIndexLeft;

                if( iChildIndexRight < currentItemCount)
                {
                    if( items[iChildIndexLeft].CompareTo(items[iChildIndexRight]) < 0)
                    {
                        iSwapIndex = iChildIndexRight;
                    }
                }

                if( _item.CompareTo(items[iSwapIndex]) < 0 )
                {
                    Swap(_item, items[iSwapIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    public void UpdateItem(T _item)
    {
        SortUp(_item);
    }

    public int Count
    {
        get
        {
            return currentItemCount;
        }
    }

    public bool Contains(T _item)
    {
        return Equals(items[_item.HeapIndex], _item);
    }

    public T RemoveFirstItem()
    {
        T firstItem = items[0];
        currentItemCount--;
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);

        return firstItem;
    }

    void Swap(T _itemA, T _itemB)
    {
        items[_itemA.HeapIndex] = _itemB;
        items[_itemB.HeapIndex] = _itemA;

        int indexTemp = _itemA.HeapIndex;
        _itemA.HeapIndex = _itemB.HeapIndex;
        _itemB.HeapIndex = indexTemp;
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
