using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{
    public float exitTime=1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, exitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
