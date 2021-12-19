using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping=false;

    int startingWave = 0;


    //Start ı IEnumerator yaparak bır loop yapmak ıcın kullandık. Inspectorda loopıng tıklı olursa waveler bır loopa baglanarak durmadan gelıcektır.
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int WaveIndex =startingWave; WaveIndex < waveConfigs.Count; WaveIndex++)
        {
            var currentWave = waveConfigs[WaveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int EnemyCount = 0; EnemyCount <waveConfig.GetNumberOfEnemies() ; EnemyCount++)
        {
            var newEnemy=Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetBetweenSpawn());
        }
        
    }
}
