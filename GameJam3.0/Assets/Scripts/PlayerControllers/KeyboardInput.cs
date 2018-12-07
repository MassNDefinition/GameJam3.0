using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum EDirections
{
    up,
    down,
    left,
    right,
}

public enum ECommands
{
    left,
    right,
    up,
    down,
    action,
    invalid,
}

public class KeyboardInput : MonoBehaviour {

    public GameObject player;

    public Dictionary<KeyCode, ECommands> bindings = new Dictionary<KeyCode, ECommands>()
    {
        { KeyCode.W, ECommands.up },
        { KeyCode.A, ECommands.left },
        { KeyCode.D, ECommands.right },
        { KeyCode.S, ECommands.down },
        { KeyCode.Space, ECommands.action },
    };

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ECommands currentCommand = ECommands.invalid;
        if (!bindings.TryGetValue(DetectPressedKeyOrButton(), out currentCommand))
        {
            return;
        }

        switch (currentCommand)
        {
            case ECommands.up:
                MovePlayer(EDirections.up);
                break;
            case ECommands.left:
                MovePlayer(EDirections.left);
                break;
            case ECommands.right:
                MovePlayer(EDirections.right);
                break;
            case ECommands.down:
                MovePlayer(EDirections.down);
                break;
            case ECommands.action:
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
            case EDirections.up:
                player.transform.position += new Vector3(0, 1);
                break;
            case EDirections.down:
                player.transform.position += new Vector3(0, -1);
                break;
            case EDirections.left:
                player.transform.position += new Vector3(-1, 0);
                break;
            case EDirections.right:
                player.transform.position += new Vector3(1, 0);
                break;
        }
    }
}
