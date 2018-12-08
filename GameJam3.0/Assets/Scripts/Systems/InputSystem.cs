using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public enum EDirections
{
    Up,
    Down,
    Left,
    Right,
}

public enum ECommands
{
    Left,
    Right,
    Up,
    Down,
    Action,
    Invalid,
}

public class InputSystem : ComponentSystem
{
    public Dictionary<KeyCode, ECommands> bindings = new Dictionary<KeyCode, ECommands>()
    {
        { KeyCode.W, ECommands.Up },
        { KeyCode.A, ECommands.Left },
        { KeyCode.D, ECommands.Right },
        { KeyCode.S, ECommands.Down },
        { KeyCode.Space, ECommands.Action },
    };

    struct Components
    {
        public InputEffectedComponent inputComponent;
        public Transform transform;
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        foreach (Components entity in GetEntities<Components>())
        {
            ECommands currentCommand = ECommands.Invalid;
            if (!bindings.TryGetValue(DetectPressedKeyOrButton(), out currentCommand))
            {
                return;
            }

            switch (currentCommand)
            {
                case ECommands.Up:
                    MovePlayer(entity, EDirections.Up);
                    break;
                case ECommands.Left:
                    MovePlayer(entity, EDirections.Left);
                    break;
                case ECommands.Right:
                    MovePlayer(entity, EDirections.Right);
                    break;
                case ECommands.Down:
                    MovePlayer(entity, EDirections.Down);
                    break;
                case ECommands.Action:
                    break;
            }
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

    private void MovePlayer(Components entity, EDirections eDirection)
    {
        switch (eDirection)
        {
            case EDirections.Up:
                entity.transform.position += new Vector3(0, 1);
                break;
            case EDirections.Down:
                entity.transform.position += new Vector3(0, -1);
                break;
            case EDirections.Left:
                entity.transform.position += new Vector3(-1, 0);
                break;
            case EDirections.Right:
                entity.transform.position += new Vector3(1, 0);
                break;
        }

    }
}
