using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBinaryHeap : MonoBehaviour {

    public Node[] items;
    public int currentItemCount;

    public NodeBinaryHeap(int maxHeapSize)
    {
        items = new Node[maxHeapSize];
        currentItemCount = 0;
    }

    public void Clear()
    {

        int size = items.Length;
        items = new Node[size];
        currentItemCount = 0;
    }

    public void Add(Node item)
    {
        items[currentItemCount] = item;

        int bubbleIndex = currentItemCount;
        while (bubbleIndex != 0)
        {
            int parentIndex = bubbleIndex / 2;
            if (items[bubbleIndex] <= items[parentIndex])
            {
                Node tmpValue = items[parentIndex];
                items[parentIndex] = items[bubbleIndex];
                items[bubbleIndex] = tmpValue;
                bubbleIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
        this.currentItemCount++;
    } /* Add */

    public Node Remove()
    {
        this.currentItemCount--;
        Node returnItem = items[0];

        items[0] = items[this.currentItemCount];

        int swapItem = 1, parent = 1;
        do
        {
            parent = swapItem;
            if ((2 * parent + 1) <= this.currentItemCount)
            {
                // Both children exist
                if (items[parent] >= items[2 * parent])
                {
                    swapItem = 2 * parent;
                }
                if (items[swapItem] >= items[2 * parent + 1])
                {
                    swapItem = 2 * parent + 1;
                }
            }
            else if ((2 * parent) <= this.currentItemCount)
            {
                // Only one child exists
                if (items[parent] >= items[2 * parent])
                {
                    swapItem = 2 * parent;
                }
            }
            // One if the parent's children are smaller or equal, swap them
            if (parent != swapItem)
            {
                Node tmpIndex = items[parent];
                items[parent] = items[swapItem];
                items[swapItem] = tmpIndex;
            }
        } while (parent != swapItem);
        return returnItem;
    } /* Remove */


}
