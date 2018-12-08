using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletCooldown;
    public float bulletPositionOffset;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
    }
    
    void Start () {
		
	}
	
	void Update () {
		
	}

}
