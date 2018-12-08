using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightComponent : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMousePosition = Input.mousePosition;
        inputMousePosition.z = 0;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(inputMousePosition);


        mousePosition += player.transform.position - Camera.main.transform.position;

        Vector3 directionVector = (mousePosition - player.transform.position).normalized;

        float angleOffset = GameManager.GM.bulletPositionOffset;
        mousePosition.x += Random.Range(-angleOffset, angleOffset);
        mousePosition.y += Random.Range(-angleOffset, angleOffset);
        mousePosition.z = 0;

        float angle = Mathf.Atan2(-directionVector.y, -directionVector.x) * Mathf.Rad2Deg + 90;
        
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
