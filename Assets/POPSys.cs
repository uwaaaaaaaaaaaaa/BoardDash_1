using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POPSys : MonoBehaviour
{
    public GameObject clouds;
    public GameObject trash;
    public float minY = 0f;
    public float maxY = 0.6f;
    public float minspawnInterval = 1f;
    public float maxspawnInterval = 5f;
    public float minspawnIntT = 1f;
    public float maxspawnIntT = 3f;
    public float spawnX = 1f;
    public float spawnY = -0.309f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
        StartCoroutine(SpawnTrash());
    }

    // Update is called once per frame
    System.Collections.IEnumerator SpawnClouds()
    {
        while (true) { 
            float delay = Random.Range(minspawnInterval, maxspawnInterval);
            yield return new WaitForSeconds(delay);
            float y = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(spawnX, y, 0);
            Instantiate(clouds, spawnPos, Quaternion.identity);
        }
    }
    System.Collections.IEnumerator SpawnTrash()
    {
        while (true)
        {
            if (!UISys.GameOver) { 
                float delayT = Random.Range(minspawnIntT, maxspawnIntT);
                yield return new WaitForSeconds(delayT);
                Vector3 spawnPosT = new Vector3(spawnX, spawnY, 0);
                Instantiate(trash, spawnPosT, Quaternion.identity);
            }
            else
            {
                yield return null;
            }
        }
    }
}
