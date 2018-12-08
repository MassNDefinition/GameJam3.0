using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour {
    public GameObject player;
    public float offsetModifier;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionVector = (mousePosition - player.transform.position).normalized;

        transform.position = player.transform.position + offset + directionVector * offsetModifier;
	}
}
