using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float fSpeed;

    public Vector3 target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, fSpeed * Time.deltaTime);
        }
	}
}
