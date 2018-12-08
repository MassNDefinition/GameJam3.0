using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public bool bWalkable;
    public Vector3 worldPosition;

    public int iX;
    public int iY;

    public int iGCost;
    public int iHCost;

    public Node parent;

    private int iHeapIndex;

    public int iFCost
    {
        get
        {
            return iGCost + iHCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return iHeapIndex;
        }

        set
        {
            iHeapIndex = value;
        }
    }

    public int CompareTo(Node _nodeToCompare)
    {
        int iCompare = iFCost.CompareTo(_nodeToCompare.iFCost);
        if( iCompare == 0)
        {
            iCompare = iHCost.CompareTo(_nodeToCompare.iHCost);
        }

        return -    iCompare;
    }

    public Node(bool _bWalkable, Vector3 _transform, int _iGridX, int _iGridY)
    {
        bWalkable = _bWalkable;
        worldPosition = _transform;
        iX = _iGridX;
        iY = _iGridY;
    }

    
}
