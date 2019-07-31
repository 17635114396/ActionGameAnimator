using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType {
Gun,
DualSword
}
public class AwardItem : MonoBehaviour
{
    public AwardType type;
    Rigidbody rb;

    private bool startMove;
    private Transform player;
    public float speed=8f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
    private void Update()
    {
        if (startMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position+Vector3.up,speed*Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position+Vector3.up) < 0.3f)
            {
                player.GetComponent<PlayerAward>().GetAward(type);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.ground)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            SphereCollider col = this.GetComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = 2;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.player)
        {
            startMove = true;
            player = other.transform;
        }
    }
}
