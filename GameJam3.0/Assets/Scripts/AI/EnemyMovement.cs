using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float fSpeed;

    public Grid grid;

    public List<Node> targetPath;
    public int iPosX;
    public int iPosY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPath != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPath[0].worldPosition, fSpeed * Time.deltaTime);
            Node currentNode = grid.NodeFromWorldPosition(transform.position);
            if (currentNode == targetPath[0])
            {
                targetPath.RemoveAt(0);
            }
        }
	}
}
