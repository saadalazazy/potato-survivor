using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoAi : mushroomAi
{
    Animator tomatoAnin;
    [SerializeField] float timeBetweenAttack;
    float timeToAttack;
    [SerializeField] GameObject charryTomato;
    protected override void Start()
    {
        base.Start();
        tomatoAnin = GetComponent<Animator>();
    }
    private void Update()
    {
        followPlayer();
        if(isMoving() == false)
        {
            tomatoAnin.SetBool("isRuning", false);
            if (Time.time > timeToAttack)
            {
                timeToAttack = Time.time + timeBetweenAttack;
                tomatoAnin.SetTrigger("isAttack");
            }
        }
        else
        {
            tomatoAnin.SetBool("isRuning", true);
        }
    }
    protected void instCherryTomato()
    {
        Instantiate(charryTomato, transform.position + new Vector3(0 , -1f , 0), Quaternion.identity);
    }
}
