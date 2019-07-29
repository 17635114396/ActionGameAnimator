using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATKAndDamage : ATKAndDamage 
{
    public float attackB = 80f;
    public float attackRange = 100f;
    // Start is called before the first frame update
    public void AttackA() {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemylist) {
            float temp = Vector3.Distance(go.transform.position, transform.position); 
            if (temp< distance) {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPosition = enemy.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(normalAttack);
        }
    }
    public void AttackB() {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemylist)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < distance)
            {
                enemy = go;
                distance = temp;
            }
        }
        if (enemy != null)
        {
            Vector3 targetPosition = enemy.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            enemy.GetComponent<ATKAndDamage>().TakeDamage(attackB);
        }
    }
    
    public void AttackRange() {
        List<GameObject> enemylist = new List<GameObject>();
        foreach (GameObject go in SpawnManager._instance.enemylist)
        {
            float temp = Vector3.Distance(go.transform.position, transform.position);
            if (temp < attackDistance)
            {
                enemylist.Add(go);
                //go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
            }
        }
        foreach (GameObject go in enemylist) {
            go.GetComponent<ATKAndDamage>().TakeDamage(attackRange);
        }
    }
    public void AttackGun()
    {

    }



}
