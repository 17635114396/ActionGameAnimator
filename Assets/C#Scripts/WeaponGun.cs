using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : MonoBehaviour
{
    public Transform BulletPos;
    public GameObject bulletPrefab;
    public float attack = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot() {
      GameObject go=  GameObject.Instantiate(bulletPrefab, BulletPos.position, transform.rotation) as GameObject;
      go.GetComponent<BulletMove>().attack = attack;
    }
}
