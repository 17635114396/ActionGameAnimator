using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossATKAndDamage :ATKAndDamage
{
    private Transform player;
    private new void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    public void Attack01() {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
    public void Attack02() {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
