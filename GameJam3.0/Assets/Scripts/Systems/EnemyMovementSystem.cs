using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EnemyMovementSystem : ComponentSystem {

    struct Components
    {
        public EnemyMovement enemyMovement;
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    protected override void OnUpdate()
    {
        foreach (Components entity in GetEntities<Components>())
        {
            entity.enemyMovement.ProcessMoving();
        }
    }
}
