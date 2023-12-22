using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] int damage;

    public int getDamage()
    {
        return damage;
    }
}
