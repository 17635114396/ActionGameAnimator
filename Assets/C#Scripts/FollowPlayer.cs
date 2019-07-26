using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    public Color w = Color.white;
    public GameObject c;

    private Transform player;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPos = player.position + new Vector3(0.27f, 1.8f, -6.5f);
        transform.position = Vector3.Lerp(transform.position, TargetPos, speed * Time.deltaTime);

        Quaternion TargetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, speed * Time.deltaTime);
        w = Color.Lerp(Color.white, Color.clear, Time.time*0.2f);
        c.GetComponent<Image>().color = w;
    }
}
