using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomAi : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] float speed;
    [SerializeField] float distant;
    protected AudioPlayer effect;
    private void Awake()
    {
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
    }
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        followPlayer();
    }

    protected void followPlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > distant)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    protected bool isMoving()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > distant)
                return true;
            else
                return false;
        }
        return false;
    }
}
