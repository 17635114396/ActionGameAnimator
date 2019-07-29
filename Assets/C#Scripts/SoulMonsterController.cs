using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonsterController : MonoBehaviour
{
    PlayerATKAndDamage playerAtkAD;
   
    private Transform player;
    private CharacterController cc;
    private Animator anim;
    public float attackDistance = 2f;
    public float speed = 1f;
    public float attacktime;//攻击间隔时间
    private float attacktimer;//计时器
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAtkAD = player.GetComponent<PlayerATKAndDamage>();
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAtkAD.hp <= 0) {
            anim.SetBool("walk", false);
            return;  
        }
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance)
        {//攻击距离之内，执行攻击或站立
            attacktimer += Time.deltaTime;
            if (attacktimer > attacktime)//达到计时时间
            {
                anim.SetTrigger("attack");
                attacktimer = 0f;
            }
            else {
                
                anim.SetBool("walk", false);
            }
        }
        else {//攻击距离之外，跑向目标
            attacktimer = attacktime;//第一次攻击不用等三秒
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))//防止跟踪旋转攻击
            {
                transform.LookAt(targetPos);
                cc.SimpleMove(transform.forward * speed);
            }
            anim.SetBool("walk", true);

        }

    }
}
