using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class WeaponComponent : MonoBehaviour {
    public int weaponFiringRate;
    public float cameraShakeDuration;
    private float bulletCooldown;
    private float bulletTimer;
    private int currentAmmoCount;
    public AudioClip shot;

    // Use this for initialization
    void Start () {
        bulletCooldown = GameManager.GM.bulletCooldown;
        bulletTimer = 0;
        currentAmmoCount = GameManager.GM.maxAmmoCount;
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

    private void FireBullets(int numberOfBullets)
    {
        if (currentAmmoCount > 0)
        {
            CameraShake();
            gameObject.GetComponent<AudioSource>().PlayOneShot(shot);
        }
        else
        {
            return;
        }

        for (int i=0; i<numberOfBullets; i++)
        {
            if (currentAmmoCount <= 0)
            {
                return;
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float directionOffset = GameManager.GM.bulletPositionOffset;
            mousePosition.x += Random.Range(-directionOffset, directionOffset);
            mousePosition.y += Random.Range(-directionOffset, directionOffset);
            mousePosition.z = 0;

            Vector3 directionVector = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(-directionVector.y, -directionVector.x) * Mathf.Rad2Deg;

            var obj = Instantiate(GameManager.GM.bulletPrefab, transform.position + directionVector, Quaternion.Euler(new Vector3(0, 0, angle))) as GameObject;

            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(directionVector.x * GameManager.GM.bulletSpeed, directionVector.y * GameManager.GM.bulletSpeed);

            --currentAmmoCount;
        }
    }

    private void CameraShake()
    {
        GameObject camera = GameObject.Find("Main Camera");
        camera.GetComponent<CameraComponent>().shakeDuration = cameraShakeDuration;
    }
}
