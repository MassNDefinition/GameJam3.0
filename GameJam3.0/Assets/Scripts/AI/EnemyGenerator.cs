using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public int iNumberOfEnemies = 10;
    public int radius = 5;

    public GameObject enemyObject;

	// Use this for initialization
	void Start ()
    {
        for( int enemyIndex = 0; enemyIndex < iNumberOfEnemies; ++enemyIndex)
        {
            int iPosX = Mathf.RoundToInt(transform.position.x + Random.Range(-radius, radius));
            int iPosY = Mathf.RoundToInt(transform.position.y + Random.Range(-radius, radius));

            Instantiate(enemyObject, new Vector3(iPosX, iPosY) , Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
