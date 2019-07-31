using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKAndDamage : MonoBehaviour
{
    public float hp = 100f;//公有血量
    public float normalAttack=50f;//普通攻击
    public float attackDistance = 1f;//攻击距离
    protected Animator anim;//本动画
    // Start is called before the first frame update
    protected void Awake()
    {
        anim = this.GetComponent<Animator>();//动画初始化
    }
    
    public virtual void TakeDamage(float damage) {//受伤，虚函数，可能会复用本函数
        if (hp > 0) {
            hp -= damage;//血量大于0则掉血
        }
        if (hp > 0)
        {
            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                anim.SetTrigger("damage");//受伤动画播放
            }
        }
        else {
            //anim.SetBool("dead", true);
            anim.SetTrigger("death");//血量少于0,死亡
            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                SpawnManager._instance.enemylist.Remove(this.gameObject);
                SpawnAward();
                Destroy(this.gameObject, 1f);
                this.GetComponent<CharacterController>().enabled = false;
            }
        }
        if (this.tag == Tags.soulBoss)//boss对象
        {
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);//实例化受伤特效
        }
        else if (this.tag == Tags.soulMonster)
        {//monster对象
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
        }
    }
    void SpawnAward() {
        int count = Random.Range(1, 3);
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, 2);
            if (index == 0)
            {
                GameObject.Instantiate(Resources.Load("Item_dual"), transform.position + Vector3.up,Quaternion.identity);
            }
            else if (index == 1) {
                GameObject.Instantiate(Resources.Load("Item_gun"), transform.position + Vector3.up, Quaternion.identity);
            }
        }
    } 
}
