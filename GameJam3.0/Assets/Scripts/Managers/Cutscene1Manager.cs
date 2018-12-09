using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1Manager : MonoBehaviour {

    private int mouseClicks;

	// Use this for initialization
	void Start () {
        mouseClicks = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
        {
            switch(mouseClicks)
            {
                case 0:
                    ++mouseClicks;
                    //show first dialog
                    break;
                case 1:
                    ++mouseClicks;
                    //show second dialog
                    break;
                case 2:
                    ++mouseClicks;
                    //show third dialog
                    break;
                case 3:
                    ++mouseClicks;
                    SceneManager.LoadScene("First Swarm");
                    break;
            }
        }
	}
}
