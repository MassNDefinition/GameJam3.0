using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    Grid grid;

    public int iNumberOfEnemies = 10;

    public GameObject enemyObject;

	// Use this for initialization
	void Start () {
        grid = GetComponent<Grid>();

        for( int enemyIndex = 0; enemyIndex < iNumberOfEnemies; ++enemyIndex)
        {
            int iPosX = Mathf.RoundToInt(Random.Range(-grid.gridWorldSize.x / 2, grid.gridWorldSize.x / 2));
            int iPosY = Mathf.RoundToInt(Random.Range(-grid.gridWorldSize.y / 2, grid.gridWorldSize.y / 2));

            Instantiate(enemyObject, new Vector3(iPosX, iPosY) , Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
