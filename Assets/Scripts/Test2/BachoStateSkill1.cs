using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = StateMachine<Bacho>.State;
public partial class Bacho
{
    public class BachoStateSkill1 : State
    {
        private const float ANIMATION_WAIT_TIME = 0.6f;
        protected override void OnEnter(State prevState)
        {
            Owner.StartCoroutine(Skill1());
        }

        IEnumerator Skill1()
        {
            Owner.animator.SetBool(SKILL1, true);
            yield return new WaitForSeconds(ANIMATION_WAIT_TIME);
            StateMachine.Dispatch((int)Event.Idle);
        }


    }
}
