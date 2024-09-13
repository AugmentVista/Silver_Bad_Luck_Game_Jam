using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Cover : IState
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    public EnemyState_Cover(EnemyReferences enemyReferences)
    { 
        this.enemyReferences = enemyReferences;

        // TODO: add Another state machine
    }

    public void OnEnter()
    { 
        enemyReferences.animator.SetBool("combat", true);
    }

    public void OnExit()
    {
        enemyReferences.animator.SetBool("combat", false);
    }

    public void Tick()
    { 
    
    }

}
