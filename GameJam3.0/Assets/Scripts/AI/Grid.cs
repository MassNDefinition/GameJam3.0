using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Vector2 gridWorldSize;
    public float fNodeRadius;
    public LayerMask unwalkableLayer;

    public Transform player;

    public List<Node> path = new List<Node>();

    private Node[,] grid;
    private float fNodeDiameter;
    private int iGridSizeX, iGridSizeY; 



    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 0.5f));
        if(grid != null)
        {
            foreach(Node node in grid)
            {
                Node playerNode = NodeFromWorldPosition(player.position);
                if (playerNode.worldPosition == node.worldPosition)
                {
                    Gizmos.color = Color.cyan;
                }
                else if (path != null && path.Contains(node))
                {
                    Gizmos.color = Color.blue;
                }
                else
                {
                    Gizmos.color = (node.bWalkable ? Color.green : Color.red);
                }
                Gizmos.DrawWireCube(node.worldPosition, Vector3.one * (fNodeDiameter - .1f));
            }
        }
    }*/

    // Use this for initialization
    void Start ()
    {
        fNodeDiameter = fNodeRadius * 2;
        iGridSizeX = Mathf.RoundToInt(gridWorldSize.x / fNodeDiameter);
        iGridSizeY = Mathf.RoundToInt(gridWorldSize.y / fNodeDiameter);
        CreateGrid();
    }

    public List<Node> GetNeighbours(Node _node)
    {
        List<Node> neighbourNodes = new List<Node>();

        for( int x = -1; x < 2; ++x )
            for ( int y = -1; y < 2; ++y )
            {
                if( x == 0 && y == 0 )
                {
                    continue;
                }

                int iCheckX = _node.iX + x;
                int iCheckY = _node.iY + y;
                if (iCheckX >= 0 && iCheckX < iGridSizeX && iCheckY >= 0 && iCheckY < iGridSizeY)
                {
                    neighbourNodes.Add(grid[iCheckX, iCheckY]);
                }
            }

        return neighbourNodes;
    }

    public Node NodeFromWorldPosition(Vector3 _worldPosition)
    {
        float fPercetnX = (_worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float fPercetnY = (_worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;

        fPercetnX = Mathf.Clamp01(fPercetnX);
        fPercetnY = Mathf.Clamp01(fPercetnY);

        int iX = Mathf.RoundToInt((iGridSizeX - 1) * fPercetnX);
        int iY = Mathf.RoundToInt((iGridSizeY - 1) * fPercetnY);
        return grid[iX, iY];
    }

    void CreateGrid()
    {
        grid = new Node[iGridSizeX, iGridSizeY];

        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2 - Vector3.forward * 10;

        for (int x = 0; x < iGridSizeX; ++x)
        {
            for (int y = 0; y < iGridSizeY; ++y)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * fNodeDiameter + fNodeRadius) + Vector3.up * (y * fNodeDiameter + fNodeRadius);
                bool bWalkable = !(Physics.CheckSphere(worldPoint, fNodeRadius, unwalkableLayer));
                grid[x, y] = new Node(bWalkable, worldPoint, x, y);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
