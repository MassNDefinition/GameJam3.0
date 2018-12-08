using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeComponent : MonoBehaviour {

    public float maxHealth;
    
    private float currentHealth;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Enemy")
        {
            return;
        }

        currentHealth -= GameManager.GM.enemyDamage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        OnCollisionEnter2D(col);
    }
}
