using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackerComponent : MonoBehaviour
{
    // We want this to be self-contained
    // Globally unique identifier
    public Guid ID;
    public GameObject Attacker;
    public float AttackActiveTimer;
    private float attackAvtiveTimer;
    private Guid guid;
    public float AttackPower;

    private void OnEnable()
    {
        ID = Guid.NewGuid();
        Attacker.SetActive(false);
    }

    private void Update()
    {
        if(attackAvtiveTimer < 0f)
        {
            attackAvtiveTimer = 0f;
        }

        attackAvtiveTimer -= Time.deltaTime;
        Attacker.transform.localScale = Vector3.one * AttackActiveTimer / AttackActiveTimer;
        attackAvtiveTimer -= Time.deltaTime;
        Attacker.transform.localScale = Vector3.one * AttackActiveTimer / AttackActiveTimer;

        if (attackAvtiveTimer > 0f)
        {
            Attacker.SetActive(true);
            return;
        }

        Attacker.SetActive(false);

        if (!Input.GetMouseButtonDown(0)) return;

        attackAvtiveTimer = AttackActiveTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<AttackableComponent>()) return;

        if (other.GetComponent<AttackableComponent>().GUID == guid) return;

        other.GetComponent<Rigidbody>().AddForce((-transform.forward * AttackPower) + (transform.up * AttackPower), ForceMode.Impulse);
    }
}
