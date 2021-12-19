using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")] 
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactory = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int numberOfEnemies = 5;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWayPoints() 
    {
        var WaveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            WaveWayPoints.Add(child);
        }
        return WaveWayPoints; 
    }
    public float GetBetweenSpawn() { return timeBetweenSpawns; }
    public float GetRandomFactory() { return spawnRandomFactory; }
    public float GetSpeed() { return moveSpeed; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
}
