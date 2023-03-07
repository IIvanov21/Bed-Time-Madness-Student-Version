using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeddyBear : Enemy
{
    [SerializeField] Transform shootPosition;
    bool shoot = true;
    [SerializeField] float waitTime = 2.0f;
  
    // Update is called once per frame
    void Update()
    {
        Chase();
        if (agent.stoppingDistance <= 3.0f) Fire();
    }

    void Fire()
    {
        if(shoot) StartCoroutine(CreateBullet());
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        shoot = false;
        yield return new WaitForSeconds(waitTime);
        shoot = true;
    }
}
