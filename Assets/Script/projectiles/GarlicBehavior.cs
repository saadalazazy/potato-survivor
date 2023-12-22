using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehavior : MonoBehaviour
{
    float level = 0;
    GameObject playerCenter;
    private void Start()
    {
        playerCenter = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (playerCenter != null)
        {
            transform.position = playerCenter.transform.position;
        }
    }
}
