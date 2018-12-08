using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : MonoBehaviour {
    
    public float invulnerabilityDuration;
    public float maxHealth;

    private float invulnerabilityTimer;
    private float currentHealth;
    private bool changingScene;

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        changingScene = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!changingScene && currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
            changingScene = true;
        }

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
    }
}
