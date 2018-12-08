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

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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
