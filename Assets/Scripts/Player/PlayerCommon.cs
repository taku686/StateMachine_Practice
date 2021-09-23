using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject shell;
    [SerializeField]
    private Transform shotPos;
    [SerializeField]
    private float shellSpeed;
    [SerializeField]
    private float moveSpeed;

    private GameObject target;
    private Rigidbody rb;
    private int hp = 100;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Enemy");
        OnStart();
    }

    private void Update()
    {

        OnUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Shell shell))
        {
            hp -= shell.Damage;
            if (hp == 80)
            {
                ChangeState(stateSpiralShell);
            }
        }
    }
}
