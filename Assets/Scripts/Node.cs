using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public bool hasobstacle;
    public Vector3 positioninworld;
    public int gridx;
    public int gridy;

    public int g;
    public int h;
    public Node parent;
    int heapIndex;

    public Node(bool _hasobstacle, Vector3 _positioninworld, int _gridx, int _gridy)
    {
        hasobstacle = _hasobstacle;
        positioninworld = _positioninworld;
        gridx = _gridx;
        gridy = _gridy;
    }

    public int f {get{return g + h;}}

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodetocompare)
    {
        int compare = f.CompareTo(nodetocompare.f);
        if(compare == 0)
        {
            compare = h.CompareTo(nodetocompare.h);
        }
        return -compare;
    }
}
