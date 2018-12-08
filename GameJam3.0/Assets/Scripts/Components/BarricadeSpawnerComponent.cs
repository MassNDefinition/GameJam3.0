using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeSpawnerComponent : MonoBehaviour {

    public GameObject barricade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("q"))
        {
            Instantiate(barricade, gameObject.transform.position, Quaternion.identity);
        }
	}
}
