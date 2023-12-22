using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawner : MonoBehaviour
{
    GameObject playerCenter;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] float deleyTime;
    AudioPlayer effect;
    void Start()
    {
        playerCenter = GameObject.FindGameObjectWithTag("Player");
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
        StartCoroutine(rockSpawnerManger());
    }

    void Update()
    {
        if (playerCenter != null)
        {
            transform.position = playerCenter.transform.position;
        }
    }
    IEnumerator rockSpawnerManger()
    {
        while (true) 
        {
            yield return new WaitForSeconds(deleyTime);
            Instantiate(rockPrefab , transform.position , Quaternion.identity);
            effect.playShootingRockEffect();
            yield return new WaitForEndOfFrame();
        }
    }
}
