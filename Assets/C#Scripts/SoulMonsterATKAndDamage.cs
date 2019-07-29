using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonsterATKAndDamage :ATKAndDamage
{
    private Transform player;

     private new void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MonsterAttack() {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            player.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
}
