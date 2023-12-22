using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class healthPlayer : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject heartPickUpEffect;
    [SerializeField] GameObject PickUpEffect;
    [SerializeField] Animator cameraShake;
    [SerializeField] int health;
    [SerializeField] Animator transitionPanel;
    [SerializeField] Image[] hearts;
    [SerializeField] int heartsUICount;
    AudioPlayer effect;
    [SerializeField] Animator losePanel;
    [SerializeField] GameObject cursor;
    private void Awake()
    {
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>() ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.tag == "heart")
        {
            heartUIInc();
            Instantiate(heartPickUpEffect, transform.position, Quaternion.identity);
            if (health < 5)
                health++;
            effect.playPickUpEffect();
        }
        else if (collision.tag == "pickup")
        {
            Instantiate(PickUpEffect, transform.position, Quaternion.identity);
            effect.playPickUpEffect();
        }
        else
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            heartUIDec();
            if (health > 0)
                health--;
            if (health < 1)
            {
                losePanel.SetTrigger("Lose");
                Destroy(cursor);
                Cursor.visible = true;
                Destroy(gameObject);
            }
            cameraShake.SetTrigger("shake");
            effect.playPlayerHurtEffect();
        }
    }
    private void heartUIDec()
    {
        hearts[heartsUICount].enabled = false;
        if (heartsUICount > 0)
            heartsUICount--;
    }
    private void heartUIInc()
    {
        if (heartsUICount < 4)
            heartsUICount++;
        hearts[heartsUICount].enabled = true;
    }
}
