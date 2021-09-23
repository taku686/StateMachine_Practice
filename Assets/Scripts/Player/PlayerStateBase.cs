using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase
{
    public virtual void OnEnter(Player player, PlayerStateBase prevState) { }
    public virtual void OnUpdate(Player player) { }
    public virtual void OnExit(Player player, PlayerStateBase nextState) { }

}
