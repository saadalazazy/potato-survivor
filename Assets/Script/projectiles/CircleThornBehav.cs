using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleThornBehav : MonoBehaviour
{
    GameObject playerCenterOfRotation;
    [SerializeField] float radius;
    [SerializeField] float speed;
    [SerializeField] float timeForAAppear;
    [SerializeField] float timeFordisAppear;
    float posX , posY , angel = 0;
    Vector3 scaleObject;
    bool work = true;
    private void Start()
    {
        StartCoroutine(timeForAppear());
        playerCenterOfRotation = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        behaviorProjectile();
    }

    private void behaviorProjectile()
    {
        scaleObject = transform.localScale;
        if (work)
        {
            if (scaleObject.magnitude < new Vector3(1, 1, 1).magnitude)
                scaleObject += new Vector3(1, 1, 1) * Time.deltaTime;
        }
        else
        {
            if (scaleObject.x > 0)
                scaleObject -= new Vector3(1, 1, 1) * Time.deltaTime;
        }
        transform.localScale = scaleObject;
        if(scaleObject.x > 0)
            rotationMovment();
    }

    private void rotationMovment()
    {
        if (playerCenterOfRotation != null)
        {
            posX = playerCenterOfRotation.transform.position.x + Mathf.Cos(angel) * radius;
            posY = playerCenterOfRotation.transform.position.y + Mathf.Sin(angel) * radius;
            transform.position = new Vector2(posX, posY);
        }
        angel += Time.deltaTime * speed;
    }

    IEnumerator timeForAppear()
    {
        while (true)
        {
            work = true;
            yield return new WaitForSeconds(timeForAAppear);
            work = false;
            yield return new WaitForSeconds(timeFordisAppear);
        }
    }

}
