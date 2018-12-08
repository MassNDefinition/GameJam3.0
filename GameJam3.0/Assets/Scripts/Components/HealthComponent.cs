using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    public Sprite[] blood;

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameObject.Find("Player") == col.gameObject || gameObject.tag == col.gameObject.tag)
        {
            return;
        }
        currentHealth -= GameManager.GM.bulletDamage;
        Destroy(col.gameObject);


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
