using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _instance;

    public Spawn[] monsterArry;//怪物数组【孵化位置】
    public Spawn[] bossArry;//boss数组【孵化位置】

    //list<T> boss,列表boss，类型为T
    public List<GameObject> enemylist = new List<GameObject>();//敌人列表
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;//单例模式赋值最好在awake里面进行赋值。
    }
    void Start()
    {
        StartCoroutine(EnemySpawn());//开始协程
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawn() {//协程的具体内容，及其定义。
        //第一波敌人的生成
        foreach (Spawn s in monsterArry) {//实例化生成脚本对象，类型为monster.
          enemylist.Add( s.MySpawn());//每孵化一个怪物，敌人列表添加一个元素，生成的该敌人。
        }

        //第一关过关条件
        while (enemylist.Count > 0)//敌人列表是否为空，是否全部死亡，没死就再等着【yield】
        {
            //yield是协程的核心知识点，返回的值，即为开始执行的值。
            yield return new WaitForSeconds(0.2f);//循环等待，退出值为count !>0;
            
        }


        // 第二波敌人的生成
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());//一组
        }
        yield return new WaitForSeconds(0.5f);//单纯等待一段时间
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());//两组
        }

        //第二关过关条件
        while (enemylist.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }



        //第三波敌人的生成
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());//一组
        }
        while (enemylist.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        foreach (Spawn s in monsterArry)
        {
            enemylist.Add(s.MySpawn());//两组
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Spawn s in bossArry) {
            enemylist.Add(s.MySpawn());//boss
        }
    }
}
