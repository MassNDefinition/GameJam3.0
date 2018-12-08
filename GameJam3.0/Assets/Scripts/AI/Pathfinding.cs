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
        if (grid == null)
        {
            grid = GameObject.Find("Terrain").GetComponent<Grid>();
        }

        target = GameObject.Find("Player");

        if (target != null && grid != null)
        {
            Node currentNode = grid.NodeFromWorldPosition(target.transform.position);

            foreach (EnemyComponents entity in GetEntities<EnemyComponents>())
            {
                seeker = entity.enemyMovement;

                if (entity.enemyMovement.bStepCompleted && (currentNode.iX != entity.enemyMovement.iPosX || currentNode.iY != entity.enemyMovement.iPosY))
                {
                    FindPath(entity.enemyMovement.transform.position, target.transform.position);
                    entity.enemyMovement.TryNewPath();
                }
                entity.enemyMovement.iPosX = currentNode.iX;
                entity.enemyMovement.iPosY = currentNode.iY;
            }
           
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

        path = SimplifyPath(path);

        if(path.Count > 0)
        {
            path.Reverse();
            seeker.targetPath = path;

            grid.path = path;
        }
        else
        {
            Node playerNode = grid.NodeFromWorldPosition(target.transform.position);
            path.Add(playerNode);
            seeker.targetPath = path;
        }
        
    }

    public List<Node> SimplifyPath(List<Node> _path)
    {
        List<Node> waypoints = new List<Node>();
        Vector2 directionOld = Vector2.zero;
        int pointTreshold = 0;
        for(int i = 1; i < _path.Count; ++i)
        {
            Vector2 directionNew = new Vector2(_path[i - 1].iX - _path[i].iX, _path[i - 1].iY - _path[i].iY);
            if(directionOld != directionNew || pointTreshold == 5)
            {
                waypoints.Add(_path[i]);
                directionOld = directionNew;
                pointTreshold = 0;
            }

            ++pointTreshold;
        }

        return waypoints;
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
