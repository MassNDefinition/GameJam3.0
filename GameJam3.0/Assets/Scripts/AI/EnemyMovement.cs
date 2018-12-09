using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float fSpeed;

    public Grid grid;

    public List<Node> targetPath;
    public int iPosX;
    public int iPosY;

    public GameObject target;

    public bool bStepCompleted = true;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
        grid = GameObject.Find("Terrain").GetComponent<Grid>();
    }
	
    public void ProcessMoving()
    {
        if (targetPath != null && targetPath.Count > 0)
        {
            grid = GameObject.Find("Terrain").GetComponent<Grid>();

            transform.position = Vector2.MoveTowards(transform.position, targetPath[0].worldPosition, fSpeed * Time.deltaTime);
            Node currentNode = grid.NodeFromWorldPosition(transform.position);
            if (currentNode == targetPath[0])
            {
                bStepCompleted = true;
                targetPath.RemoveAt(0);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, fSpeed * Time.deltaTime);
        }
    }

    public void TryNewPath()
    {
        bStepCompleted = false;
    }
}
