using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rockBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;
    [SerializeField] float timeDestroy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        addForseForRock();
        Destroy(gameObject,timeDestroy);
    }
    void addForseForRock()
    {
        float forceX = Random.Range(-100,100);
        float forceY = Random.Range(-100, 100);
        rb.AddForce(new Vector2(forceX/100 , forceY/100).normalized * force);
    }
}
