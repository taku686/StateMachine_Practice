using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = StateMachine<Bacho>.State;
public partial class Bacho
{
    public class BachoStateSkill2 : State
    {
        private const float ANIMATION_WAIT_TIME = 1.4f;
        protected override void OnEnter(State prevState)
        {
            Owner.StartCoroutine(Skill2());
        }

        IEnumerator Skill2()
        {
            Owner.animator.SetBool(SKILL2, true);
            yield return new WaitForSeconds(ANIMATION_WAIT_TIME);
            StateMachine.Dispatch((int)Event.Idle);
        }
    }
}
