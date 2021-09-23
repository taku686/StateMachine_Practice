using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class Player
{
    public class StateSpiralShell : PlayerStateBase
    {
        private bool isMoving = false;
        private const float ShotIntervalTime = 0.1f;
        private float countTime = 0f;
        public override void OnEnter(Player player, PlayerStateBase prevState)
        {
            player.StartCoroutine(Move(player.rb, player.moveSpeed, Vector3.zero, player.transform));
        }

        public override void OnUpdate(Player player)
        {
            if (!isMoving)
            {
                return;
            }
            countTime += Time.fixedDeltaTime;
            player.transform.eulerAngles += new Vector3(0, 200, 0) * Time.fixedDeltaTime;
            if (countTime > ShotIntervalTime)
            {
                Shot(player.shell, player.transform, player.shotPos, player.shellSpeed);
                countTime = 0;
            }
        }

        IEnumerator Move(Rigidbody rb, float moveSpeed, Vector3 targetPos, Transform playerTransform)
        {
            var dir = playerTransform.position - targetPos;
            rb.velocity = -dir.normalized * moveSpeed;
            while (dir.magnitude > 0.1f)
            {
                dir = targetPos - playerTransform.position;
                yield return null;
            }
            rb.velocity = Vector3.zero;
            playerTransform.position = targetPos;
            isMoving = true;
        }

        private void Shot(GameObject shell, Transform player, Transform shotPos, float shellSpeed)
        {
            GameObject shellClone = Instantiate(shell);
            shellClone.transform.position = shotPos.position;
            shellClone.GetComponent<Rigidbody>().AddForce(player.forward * shellSpeed, ForceMode.Impulse);

        }
    }


}
