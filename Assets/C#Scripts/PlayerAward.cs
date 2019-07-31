using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAward : MonoBehaviour
{
    public GameObject singleSword;
    public GameObject dualSword;
    public GameObject gun;
    public float exitTime = 10f;//奖励物品存在时间
    public float dualTime = 0;//不断减少，直到消失
    public float gunTime = 0;

    private void Update()
    {
        if (dualTime > 0) {
            dualTime -= Time.deltaTime;
            if (dualTime < 0)
            {
                TurnToSingleSword();
            }
        }
        if (gunTime > 0)
        {
            gunTime -= Time.deltaTime;
            if (gunTime < 0)
            {
                TurnToSingleSword();
            }
        }
    }
    public void GetAward(AwardType type) {
        if (type == AwardType.DualSword)
        {
            TurnToDualSword();
        }
        else if (type == AwardType.Gun) {
            TurnToGun();
        }
    }
    void TurnToDualSword() {
        singleSword.SetActive(false);
        dualSword.SetActive(true);
        gun.SetActive(false);
        dualTime = exitTime;
        gunTime = 0;
    }
    void TurnToGun()
    {
        singleSword.SetActive(false);
        dualSword.SetActive(false);
        gun.SetActive(true);
        gunTime = exitTime;
        dualTime = 0;
    }
    void TurnToSingleSword() {
        singleSword.SetActive(true);
        dualSword.SetActive(false);
        gun.SetActive(false);
        dualTime = 0;
        gunTime = 0;
    }
}
