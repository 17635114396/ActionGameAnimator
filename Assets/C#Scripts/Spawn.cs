using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //该脚本只写一个生成函数，但是不会运行，不负责控制，相当于提前规则，并声明。
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject MySpawn() {//生成预制体函数
        return GameObject.Instantiate(prefab, transform.position, transform.rotation) as GameObject; 
        //用Instantiate方法生成，并返回该预制体，后期可以用来删除，因为有返回，所以函数类型为GameObject;
    }
    //脚本写完后，挂载在每一个生成的位置点上。
}
