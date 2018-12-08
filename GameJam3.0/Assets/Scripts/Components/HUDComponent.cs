using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDComponent : MonoBehaviour {

    public Text ammo;
    public Text health;

    private PlayerHealthComponent playerHealthComponent;
    private WeaponComponent weaponComponent;

	// Use this for initialization
	void Start () {
        playerHealthComponent = gameObject.GetComponent<PlayerHealthComponent>();
        weaponComponent = gameObject.GetComponent<WeaponComponent>();
        health.text = "HP: " + playerHealthComponent.GetCurrentHealth();
        ammo.text = "AMMO: " + weaponComponent.GetCurrentAmmo();
	}

    // Update is called once per frame
    void Update()
    {
        if (health != null && ammo != null)
        {
            health.text = "HP: " + playerHealthComponent.GetCurrentHealth();
            ammo.text = "AMMO: " + weaponComponent.GetCurrentAmmo();
        }
    }
}
