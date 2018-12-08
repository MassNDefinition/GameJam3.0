using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class InputSystem : ComponentSystem
{

	struct Components
    {
        public InputEffectedComponent inputComponent;
    }
	
	// Update is called once per frame
	protected override void OnUpdate ()
    {
		foreach (var entity in GetEntities<Components>())
        {

        }
	}
}
