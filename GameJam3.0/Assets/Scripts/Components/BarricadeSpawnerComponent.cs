using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeSpawnerComponent : MonoBehaviour {

    public float barricadeSpawnCooldownDuration;
    public GameObject barricade;

    private float barricadeSpawnCooldownTimer;

    public int GetBarricadeSpawnCooldown()
    {
        int res = (int)barricadeSpawnCooldownTimer;
        return res;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (barricadeSpawnCooldownTimer > 0)
        {
            barricadeSpawnCooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("q") && barricadeSpawnCooldownTimer <= 0)
        {
            Vector3 inputMousePosition = Input.mousePosition;
            inputMousePosition.z = 0;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(inputMousePosition);

            mousePosition += transform.position - Camera.main.transform.position;

            float directionOffset = GameManager.GM.bulletPositionOffset;
            mousePosition.x += Random.Range(-directionOffset, directionOffset);
            mousePosition.y += Random.Range(-directionOffset, directionOffset);
            mousePosition.z = 0;

            Vector3 directionVector = (mousePosition - gameObject.transform.position).normalized;

            float angle = Mathf.Atan2(-directionVector.y, -directionVector.x) * Mathf.Rad2Deg + 90;

            Instantiate(barricade, gameObject.transform.position + directionVector, Quaternion.Euler(new Vector3(0, 0, angle)));

            barricadeSpawnCooldownTimer = barricadeSpawnCooldownDuration;
        }
	}
}
