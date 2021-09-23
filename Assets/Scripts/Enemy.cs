using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    GameObject shell;
    [SerializeField]
    float shellSpeed;
    [SerializeField]
    Transform shotPos;


    private Rigidbody rb;
    private const float ShotIntrvalTime = .5f;
    private float countTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var hori = Input.GetAxis("Horizontal") * moveSpeed;
        var vert = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector3(hori, 0, vert);
    }
    private void Update()
    {
        countTime += Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space) && countTime > ShotIntrvalTime)
        {
            Shot(shell, this.transform, shotPos, shellSpeed);
            countTime = 0f;
        }
    }

    private void Shot(GameObject shell, Transform player, Transform shotPos, float shellSpeed)
    {
        GameObject shellClone = Instantiate(shell);
        shellClone.transform.position = shotPos.position;
        shellClone.GetComponent<Rigidbody>().AddForce(player.forward * shellSpeed, ForceMode.Impulse);

    }
}
