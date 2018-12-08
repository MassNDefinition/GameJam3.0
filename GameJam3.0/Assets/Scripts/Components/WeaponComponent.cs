using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class WeaponComponent : MonoBehaviour {
    public int weaponFiringRate;
    private float bulletCooldown;
    private float bulletTimer;

    // Use this for initialization
    void Start () {
        bulletCooldown = GameManager.GM.bulletCooldown;
        bulletTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        bulletTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && bulletTimer <= 0)
        {
            bulletTimer = bulletCooldown;
            FireBullets(weaponFiringRate);
        }
	}

    public void FireBullets(int numberOfBullets)
    {
        for (int i=0; i<numberOfBullets; i++)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float offset = GameManager.GM.bulletPositionOffset;
            mousePosition.x += Random.Range(-offset, offset);
            mousePosition.y += Random.Range(-offset, offset);
            mousePosition.z = 0;

            Vector3 directionVector = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(-directionVector.y, -directionVector.x) * Mathf.Rad2Deg;

            var obj = Instantiate(GameManager.GM.bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle))) as GameObject;

            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(directionVector.x * GameManager.GM.bulletSpeed, directionVector.y * GameManager.GM.bulletSpeed);
        }
    }
}
