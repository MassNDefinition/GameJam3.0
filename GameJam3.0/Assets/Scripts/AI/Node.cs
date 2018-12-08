using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool bWalkable;
    public Vector3 worldPosition;

    public int iX;
    public int iY;

    public int iGCost;
    public int iHCost;

    public Node parent;

    public int iFCost
    {
        get
        {
            return iGCost + iHCost;
        }
    }

    public Node(bool _bWalkable, Vector3 _transform, int _iGridX, int _iGridY)
    {
        bWalkable = _bWalkable;
        worldPosition = _transform;
        iX = _iGridX;
        iY = _iGridY;
    }
}
