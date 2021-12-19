using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int musicPlayerCount = FindObjectsOfType(GetType()).Length;
        if (musicPlayerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        
    }
}
