using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSpriteBehavior : MonoBehaviour
{
    SpriteRenderer sp;
    byte tran = 255;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        StartCoroutine(startColorChange());
    }
    IEnumerator startColorChange()
    {
        yield return new WaitForSeconds(12);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            tran -= 8;
            sp.color = new Color32(255, 255, 255, tran);
        }

    }

}
