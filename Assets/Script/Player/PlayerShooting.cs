using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shotPosition;
    [SerializeField] float timeBetweenShoot;
    [SerializeField] GameObject akmWepon;
    [SerializeField] GameObject somkeEffect;
    float timeShoot;
    Vector2 dirction;
    float rot;
    AudioPlayer effect;
    private void Start()
    {
        effect = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
    }

    void Update()
    {
        dirction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotPosition.position;
        rot = Mathf.Atan2(dirction.y, dirction.x) * Mathf.Rad2Deg;
        if(rot > 90 || rot < -90)
        {
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position) > 1.3f)
                akmWepon.transform.rotation = Quaternion.Euler(0, 0, rot - 135);
            akmWepon.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position) > 1.3f)
                akmWepon.transform.rotation = Quaternion.Euler(0, 0, rot - 45);
            akmWepon.transform.localScale = new Vector3(-1, 1, 1);
        }
       
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= timeShoot)
            {
                Instantiate(somkeEffect, shotPosition.position, Quaternion.Euler(rot - 180 ,-90,-90));
                GameObject bulletIns = Instantiate(bulletPrefab, shotPosition.position, Quaternion.identity);
                bulletIns.transform.rotation = Quaternion.Euler(0 , 0, rot - 90);
                timeShoot = Time.time + timeBetweenShoot;
                effect.playShootingSoundEffect();
            }
        }
    }
}
