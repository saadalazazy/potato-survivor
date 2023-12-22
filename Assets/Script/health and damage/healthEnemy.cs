using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthEnemy : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] int health;
    [SerializeField] GameObject[] pickups;
    [SerializeField] GameObject bloodSplash;
    AudioPlayer effect;
    DamageEnemy damageEnemy;
    float timevalue = 0;
    float timevBetweentwoDamage = 0.5f;
    float randNum;
    static float countPickUp;
    static int pickupOne = -1 , pickupTwo = -1;
    int pickupIndex;
    int maxHealth;
    private void Awake()
    {
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
        maxHealth = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            damgeGameObject(collision);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "circle")
        {
            damgeGameObject(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "garlic")
        {
           if(Time.time > timevalue)
           {
                timevalue = Time.time + timevBetweentwoDamage;
                damgeGameObject(collision);
           }
        }
    }

    private void damgeGameObject(Collider2D collision)
    {
        damageEnemy = collision.gameObject.GetComponent<DamageEnemy>();
        health -= damageEnemy.getDamage();
        if (health <= 0)
        {
            GameObject blood = Instantiate(bloodSplash, transform.position, Quaternion.identity);
            blood.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Destroy(blood, 15.2f);
            if (maxHealth == 10)
                effect.playDeadSmallEnemyEffect();
            else if (maxHealth == 30)
                effect.playDeadEnemyEffect();
            else
                effect.playDeadBigEnemyEffect();
            randNum = Random.Range(0, 101);
            if (randNum < 5 && countPickUp < 2)
            {
                countPickUp++;
                while (true)
                {
                    pickupIndex = Random.Range(0, pickups.Length - 1);
                    if (pickupIndex != pickupOne && pickupIndex != pickupTwo)
                    {
                        if (pickupOne == -1)
                            pickupOne = pickupIndex;
                        else if (pickupTwo == -1)
                            pickupTwo = pickupIndex;
                        Instantiate(pickups[pickupIndex], transform.position, Quaternion.identity);
                        break;
                    }
                }
            }
            else if (randNum < 15)
            {
                Instantiate(pickups[pickups.Length - 1], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        else
            effect.playEnemyHurtEffect();

        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        
    }
}
