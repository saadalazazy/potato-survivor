using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAi : mushroomAi
{
    [SerializeField] float timeBetweentwoShoot;
    [SerializeField] GameObject fireBallPrefab;

    float timeShot;
    Vector3 dir;
    float rot;
    private void Update()
    {
        followPlayer();
        if(player != null)
        {
            if (Time.time > timeShot)
            {
                timeShot = Time.time + timeBetweentwoShoot;
                instatiatFireBall();
            }
        }
       
    }
    void instatiatFireBall()
    {
       GameObject fireball = Instantiate(fireBallPrefab , transform.position , Quaternion.identity);
       dir = transform.position - player.transform.position;
       rot = Mathf.Atan2(-dir.y ,-dir.x) * Mathf.Rad2Deg;
       fireball.transform.rotation = Quaternion.Euler(0, 0, rot - 90);
        effect.playFireBallEffect();
    }
}
