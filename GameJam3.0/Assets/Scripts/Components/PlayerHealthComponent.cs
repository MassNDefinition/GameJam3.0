using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : MonoBehaviour {
    
    public float invulnerabilityDuration;
    public float maxHealth;

    private float invulnerabilityTimer;
    private float currentHealth;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Enemy")
        {
            return;
        }
        if (invulnerabilityTimer > 0)
        {
            return;
        }
        currentHealth -= GameManager.GM.enemyDamage;

        invulnerabilityTimer = invulnerabilityDuration;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag != "Enemy")
        {
            return;
        }
        if (invulnerabilityTimer > 0)
        {
            return;
        }
        currentHealth -= GameManager.GM.enemyDamage;

        invulnerabilityTimer = invulnerabilityDuration;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
