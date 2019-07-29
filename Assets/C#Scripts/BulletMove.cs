using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 10f;
    public float attack = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.soulBoss || other.tag == Tags.soulMonster) {
            other.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
