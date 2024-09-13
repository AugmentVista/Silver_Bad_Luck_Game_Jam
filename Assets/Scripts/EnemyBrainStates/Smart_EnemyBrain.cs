using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

public class Smart_EnemyBrain : MonoBehaviour
{
    private EnemyReferences enemyReferences;
    private StateMachine stateMachine;

    [SerializeField]
    private CoverArea coverArea; 
    void Start()
    {
        enemyReferences = GetComponent<EnemyReferences>();

        stateMachine = new StateMachine();

        Cover randomCover = coverArea.GetRandomCover(transform.position);

        // STATES

        var runToCover = new EnemyState_RuntToCover(enemyReferences, coverArea);
        var delayAfterRun = new EnemyState_Delay(2f);
        var cover = new EnemyState_Cover(enemyReferences);

        //TRANSITIONS

        At(runToCover, delayAfterRun, () => runToCover.HasArrivedAtDestination());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());

        //START STATE

        stateMachine.SetState(runToCover);

        //FUNCTIONS AND CONDITIONS

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    void Update()
    {
        stateMachine.Tick();
    }

}
