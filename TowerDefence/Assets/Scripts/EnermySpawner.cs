using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform START;
    public float waveRate;
    public static int EnermyAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnermy());
    }
    IEnumerator SpawnEnermy()
    {
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.Enermy,START.position,Quaternion.identity);
                EnermyAlive++;
                if(i<wave.count-1)
                    yield return new WaitForSeconds(wave.speed);
            }
            while (EnermyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
    }
}
