using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimTiorController : MonoBehaviour
{
    private Animator anim;
    private bool isCanAttackB;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Nor()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB==true)
        {
            anim.SetTrigger("attackB");
        }
        else 
        {
            anim.SetTrigger("attackA");
        }
    }
    public void Ran()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackRange") && isCanAttackB)
        {
            anim.SetTrigger("attackB");
        }
        else
        {
            anim.SetTrigger("attackRange");
        }
    }
    public void Red()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackRange") && isCanAttackB)
        {
            anim.SetTrigger("attackB");
        }
        else
        {
            anim.SetTrigger("attackA");
        }
    }
    public void IsCanattackB1() {
        isCanAttackB = true;
    }
    public void IsCanattackB2() {
        isCanAttackB = false;
    }
}

