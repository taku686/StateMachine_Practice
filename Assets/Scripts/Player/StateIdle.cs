using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Player
{
    public class StateIdle : PlayerStateBase
    {
        private const int ShotIntervalTime = 1;
        private float countTime = 0f;

        public override void OnUpdate(Player player)
        {
            countTime += Time.fixedDeltaTime;
            player.transform.LookAt(player.target.transform, Vector3.forward);
            if (countTime > ShotIntervalTime)
            {
                Shot(player.shell, player.transform, player.shotPos, player.shellSpeed);
                countTime = 0;
            }

        }

        private void Shot(GameObject shell, Transform player, Transform shotPos, float shellSpeed)
        {
            GameObject shellClone = Instantiate(shell);
            shellClone.transform.position = shotPos.position;
            shellClone.GetComponent<Rigidbody>().AddForce(player.forward * shellSpeed, ForceMode.Impulse);

        }
    }
}
