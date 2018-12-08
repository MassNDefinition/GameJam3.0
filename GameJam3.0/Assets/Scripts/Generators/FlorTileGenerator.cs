using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorTileGenerator : MonoBehaviour {

    public GameObject tilePrefab;
    private Grid grid;
    private bool bIsTiled = false;
	// Use this for initialization
	void Update ()
    {
        if (!bIsTiled)
        {
            grid = GetComponent<Grid>();
            if (grid.grid != null && grid.bCanTile)
            {
                foreach (Node node in grid.grid)
                {
                    Instantiate(tilePrefab, new Vector3(node.worldPosition.x, node.worldPosition.y), Quaternion.identity);
                }
                bIsTiled = true;
            }
        }
	}
}
