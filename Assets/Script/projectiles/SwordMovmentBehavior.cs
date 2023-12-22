using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordMovmentBehavior : MonoBehaviour
{
    GameObject playerCenter;
    [SerializeField] GameObject swordPrefab;
    [SerializeField] float speedProjectile;
    [SerializeField] float timeDestroy;
    [SerializeField] float deleyTime;
    Vector2 playerDir;
    Vector2 playerPrevDir = new Vector2(-1 , 0);
    AudioPlayer effect;
    void Start()
    {
        playerCenter = GameObject.FindGameObjectWithTag("Player");
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
        StartCoroutine(spawnSword());
    }

    void Update()
    {
        if (playerCenter != null)
        {
            transform.position = playerCenter.transform.position;
        }
    }
    void OnMovment(InputValue value)
    {
        playerPrevDir = playerDir;
        playerDir = value.Get<Vector2>();
    }
    IEnumerator spawnSword()
    {
        while(true)
        {
            yield return new WaitForSeconds(deleyTime);
            instantiatSword();
            yield return new WaitForEndOfFrame();
        }
    }

    private void instantiatSword()
    {
        GameObject swordIns = Instantiate(swordPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rbSword = swordIns.GetComponent<Rigidbody2D>();
        if (playerDir != Vector2.zero)
        {
            rbSword.velocity = new Vector2(playerDir.x, playerDir.y) * speedProjectile * Time.fixedDeltaTime;
            float rot = Mathf.Atan2(-playerDir.y, -playerDir.x) * Mathf.Rad2Deg;
            swordIns.transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        else
        {
            rbSword.velocity = new Vector2(playerPrevDir.x, playerPrevDir.y) * speedProjectile * Time.fixedDeltaTime;
            float rot = Mathf.Atan2(-playerPrevDir.y, -playerPrevDir.x) * Mathf.Rad2Deg;
            swordIns.transform.rotation = Quaternion.Euler(0, 0, rot);
        }
        Destroy(swordIns, timeDestroy);
        effect.playShootingSwordEffect();
    }
}
