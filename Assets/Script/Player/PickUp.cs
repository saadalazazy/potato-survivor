using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject pickUpWepon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag == "Player")
            Instantiate(pickUpWepon, transform.position, Quaternion.identity);
    }
}
