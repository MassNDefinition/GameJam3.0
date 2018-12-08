using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Pathfinding : ComponentSystem
{

    public Grid grid;

    public EnemyMovement seeker;
    public GameObject target;

    private int iOldTargetX = 0;
    private int iOldTargetY = 0;

    struct EnemyComponents
    {
        public EnemyMovement enemyMovement;
    }

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        grid = GameObject.Find("Terrain").GetComponent<Grid>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        grid = GameObject.Find("Terrain").GetComponent<Grid>();
        target = GameObject.Find("Player");
        if (target != null && grid != null)
        {
            Node currentNode = grid.NodeFromWorldPosition(target.transform.position);

            foreach (EnemyComponents entity in GetEntities<EnemyComponents>())
            {
                seeker = entity.enemyMovement;

                if (currentNode.iX != iOldTargetX || currentNode.iY != iOldTargetY)
                {
                    FindPath(entity.enemyMovement.transform.position, target.transform.position);
                }
            }
            iOldTargetX = currentNode.iX;
            iOldTargetY = currentNode.iY;
        }
    }

    void FindPath(Vector3 _startPoint, Vector3 _endPoint)
    {
        Node startNode = grid.NodeFromWorldPosition(_startPoint);
        Node endNode = grid.NodeFromWorldPosition(_endPoint);

        Heap<Node> openSet = new Heap<Node>(grid.iGridSizeX * grid.iGridSizeY);
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);
        while(openSet.Count > 0)
        {
            Node currentNode = openSet.RemoveFirstItem();

            closedSet.Add(currentNode);

            if(currentNode == endNode)
            {
                RetracePath(startNode, endNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if((!neighbour.bWalkable && neighbour != endNode) || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCost = currentNode.iGCost + GetDistance(currentNode, neighbour);

                if(newMovementCost < neighbour.iGCost || !openSet.Contains(neighbour))
                {
                    neighbour.iGCost = newMovementCost;
                    neighbour.iHCost = GetDistance(neighbour, endNode);
                    neighbour.parent = currentNode;

                    if(!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                    else
                    {
                        openSet.UpdateItem(neighbour);
                    }
                }

            }
        }
    }

    public void RetracePath(Node _startNode, Node _targetNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = _targetNode;
        while (currentNode != _startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        if(path.Count > 1)
        {
            path.Reverse();
            seeker.targetPath = path;

            grid.path = path;
        }
        //else
        //{
        //    seeker.target = target.transform.position;
        //}
        
    }

    public int GetDistance(Node _nodeFrom, Node _nodeTo)
    {
        int distX = Mathf.Abs(_nodeFrom.iX - _nodeTo.iX);
        int distY = Mathf.Abs(_nodeFrom.iY - _nodeTo.iY);

        if(distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }

        return 14 * distX + 10 * (distY - distX);
    }
}
