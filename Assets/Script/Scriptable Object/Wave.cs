using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave" , menuName = "Make a wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemys;
    [SerializeField] int count;
    [SerializeField] float TimeBetweenSpwan;

    public int getCount()
    {
        return count;
    }
    public float getTimeBetweenSpwan()
    {
        return TimeBetweenSpwan;
    }
}
