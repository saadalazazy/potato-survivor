using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaveManger : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] point;
    [SerializeField] float timeBetweenTwoWaves;
    [SerializeField] Animator panelWin;
    [SerializeField] GameObject cursor;
    Wave currentWave;
    int currentWaveIndex = 0;
    Transform player;
    bool waveFinished =false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }
    private void Update()
    {
        if(waveFinished == true && GameObject.FindGameObjectsWithTag("enemys").Length == 0)
        {
            waveFinished = false;
            currentWaveIndex++;
            if (currentWaveIndex < waves.Length)
                StartCoroutine(StartNextWave(currentWaveIndex));
            else
            {
                panelWin.SetTrigger("win");
                Destroy(cursor);
                Cursor.visible = true;
            }
                

        }
    }
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenTwoWaves);
        StartCoroutine(StartWave(index));
    }
    IEnumerator StartWave(int index)
    {
        currentWave = waves[index];

        for(int i = 0; i < currentWave.getCount(); i++)
        {
            if(player == null)
                yield break;
            Instantiate(currentWave.enemys[i] , point[Random.Range(0 , point.Length)].position , Quaternion.identity);
            if(i == currentWave.getCount() - 1)
            {
                waveFinished = true;
                yield break;
            }
            else
                waveFinished = false;
            yield return new WaitForSeconds(currentWave.getTimeBetweenSpwan());
        }

    }
}
