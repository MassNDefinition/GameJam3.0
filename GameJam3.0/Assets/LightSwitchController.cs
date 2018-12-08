using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour {

    public MeshRenderer[] lights;
    public AudioSource audio;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)){
            foreach (MeshRenderer renderer in lights)
                if (renderer.enabled == false)
                {
                    renderer.enabled = true;
                    gameObject.GetComponent<AudioSource>().Play();
                }
                else
                {
                    renderer.enabled = false;
                }
                

        }
	}
}
