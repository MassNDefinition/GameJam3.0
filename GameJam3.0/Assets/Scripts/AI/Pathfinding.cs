﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Pathfinding : ComponentSystem
{

    public Grid grid;

    public EnemyMovement seeker;
    public GameObject target;

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
        foreach (EnemyComponents entity in GetEntities<EnemyComponents>())
        {
            seeker = entity.enemyMovement;
            FindPath(entity.enemyMovement.transform.position, target.transform.position);
        }
    }

    void FindPath(Vector3 _startPoint, Vector3 _endPoint)
    {
        Node startNode = grid.NodeFromWorldPosition(_startPoint);
        Node endNode = grid.NodeFromWorldPosition(_endPoint);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);
        while(openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; ++i)
            {
                if (openSet[i].iFCost < currentNode.iFCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == endNode)
            {
                RetracePath(startNode, endNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if(!neighbour.bWalkable || closedSet.Contains(neighbour))
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

        path.Reverse();

        seeker.target = path[1].worldPosition;

        grid.path = path;
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
