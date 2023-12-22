using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovment : MonoBehaviour
{
    [SerializeField] float speedBullet;
    [SerializeField] float timeDistroy;

    private void Start()
    {
        Destroy(gameObject, timeDistroy);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speedBullet * Time.deltaTime);
    }
}
