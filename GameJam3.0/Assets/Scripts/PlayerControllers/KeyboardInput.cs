using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class KeyboardInput : MonoBehaviour {

    public GameObject player;

    public Dictionary<KeyCode, ECommands> bindings = new Dictionary<KeyCode, ECommands>()
    {
        { KeyCode.W, ECommands.Up },
        { KeyCode.A, ECommands.Left },
        { KeyCode.D, ECommands.Right },
        { KeyCode.S, ECommands.Down },
        { KeyCode.Space, ECommands.Action },
    };

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ECommands currentCommand = ECommands.Invalid;
        if (!bindings.TryGetValue(DetectPressedKeyOrButton(), out currentCommand))
        {
            return;
        }

        switch (currentCommand)
        {
            case ECommands.Up:
                MovePlayer(EDirections.Up);
                break;
            case ECommands.Left:
                MovePlayer(EDirections.Left);
                break;
            case ECommands.Right:
                MovePlayer(EDirections.Right);
                break;
            case ECommands.Down:
                MovePlayer(EDirections.Down);
                break;
            case ECommands.Action:
                break;
        }
    }

    private KeyCode DetectPressedKeyOrButton()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                return keyCode;
            }
        }
        return KeyCode.None;
    }

    private void MovePlayer(EDirections eDirection)
    {
        switch(eDirection)
        {
            case EDirections.Up:
                player.transform.position += new Vector3(0, 1);
                break;
            case EDirections.Down:
                player.transform.position += new Vector3(0, -1);
                break;
            case EDirections.Left:
                player.transform.position += new Vector3(-1, 0);
                break;
            case EDirections.Right:
                player.transform.position += new Vector3(1, 0);
                break;
        }
    }
}
