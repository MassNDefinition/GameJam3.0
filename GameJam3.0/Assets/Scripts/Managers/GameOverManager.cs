using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public float gameOverDuration;
    private float gameOverTimer;
	// Use this for initialization
	void Start () {
        gameOverTimer = gameOverDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverTimer <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            gameOverTimer -= Time.deltaTime;
        }
	}
}
