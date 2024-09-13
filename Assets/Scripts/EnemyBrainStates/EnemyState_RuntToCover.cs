using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyState_RuntToCover : IState
{
    private EnemyReferences enemyReferences;
    private CoverArea coverArea;

    public EnemyState_RuntToCover(EnemyReferences enemyReferences, CoverArea coverArea)
    { 
        this.enemyReferences = enemyReferences;
        this.coverArea = coverArea;
    }

    public void OnEnter()
    {
        Cover nextCover = this.coverArea.GetRandomCover(enemyReferences.transform.position);
        enemyReferences.navMeshAgent.SetDestination(nextCover.transform.position);
        enemyReferences.animator.SetFloat("speed", 1f);
    }

    public void OnExit()
    {
        enemyReferences.animator.SetFloat("speed", 0f);
    }

    public void Tick()
    {
        enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    public bool HasArrivedAtDestination()
    {
        return enemyReferences.navMeshAgent.remainingDistance < 0.1f;
    }

}
