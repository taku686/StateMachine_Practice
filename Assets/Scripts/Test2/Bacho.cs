using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = TestStateMachine<Bacho>.State;

public partial class Bacho : MonoBehaviour
{
    private const string SKILL1 = "Attack";
    private const string SKILL2 = "Passive";

    private StateMachine<Bacho> stateMachine;
    private bool isDead = false;
    private Animator animator;

    private enum Event : int
    {
        Idle,
        Skill1,
        Skill2,
        Dead,
    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<Bacho>(this);
        stateMachine.AddTransition<BachoStateIdle, BachoStateSkill1>((int)Event.Skill1);
        stateMachine.AddTransition<BachoStateIdle, BachoStateSkill2>((int)Event.Skill2);
        stateMachine.AddAnyTransition<BachoStateDead>((int)Event.Dead);
        stateMachine.AddAnyTransition<BachoStateIdle>((int)Event.Idle);
        animator = GetComponent<Animator>();
        stateMachine.Start<BachoStateIdle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            stateMachine.Dispatch((int)Event.Dead);
        }

        stateMachine.Update();
        if (Input.GetKey(KeyCode.A))
        {
            stateMachine.Dispatch((int)Event.Skill1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            stateMachine.Dispatch((int)Event.Skill2);
        }

    }
}
