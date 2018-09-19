using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicelleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabMicelle;
    [SerializeField]
    GameObject prefabDirt;

    [SerializeField]
    int dirtAmount = 5;

    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < dirtAmount; i++)
        {
            float spawnLocationX = (float)Random.Range(-100, 101);
            float spawnLocationY = (float)Random.Range(-100, 101);
            Vector2 location = new Vector2(spawnLocationX, spawnLocationY);
            Instantiate(prefabDirt, location, Quaternion.identity);
        }

        for (int j = 0; j < dirtAmount*6 ; j++)
        {
            float spawnLocationX = (float)Random.Range(-100, 101);
            float spawnLocationY = (float)Random.Range(-100, 101);
            Vector2 location = new Vector2(spawnLocationX, spawnLocationY);
            Instantiate(prefabMicelle, location, Quaternion.identity);
        }
    }	
}
