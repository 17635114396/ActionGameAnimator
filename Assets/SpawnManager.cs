using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Spawn[] monsterArry;
    public Spawn[] bossArry;

    public List<GameObject> enemylist = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawn() {
        //第一波敌人的生成
        foreach (Spawn s in monsterArry) {
          enemylist.Add( s.MySpawn());
        }
        while (enemylist.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        // 第二波敌人的生成
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());
        }
        while (enemylist.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        //第三波敌人的生成
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());
        }
        while (enemylist.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        // 第二波敌人的生成
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Spawn s in bossArry) {
            enemylist.Add(s.MySpawn());
        }
    }
}
