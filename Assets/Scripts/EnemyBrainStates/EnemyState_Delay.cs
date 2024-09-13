using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Delay : IState
{
    private float waitForSeconds;
    private float deadLine;

    public EnemyState_Delay(float waitForSeconds)
    { 
        this.waitForSeconds = waitForSeconds;
    }

    public void OnEnter()
    { 
        deadLine = Time.time + waitForSeconds;
    }

    public void OnExit()
    {
        Debug.Log("EnemyDelay onExit");
    }

    public void Tick()
    { 

    }

    public bool IsDone()
    {
        return Time.time >= deadLine;
    }
}
