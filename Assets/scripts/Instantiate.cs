using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public GameObject applePrefab;  
    public float xMin = -8f, xMax = 8f;
    public float yMin = -4f, yMax = 4f; 
   

    private GameObject currentApple;

    void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
      
        if (currentApple != null)
        {
            Destroy(currentApple);
           
        }

    
        float randomX = Mathf.Round(Random.Range(xMin, xMax));
        float randomY = Mathf.Round(Random.Range(yMin, yMax));

        Vector2 spawnPos = new Vector2(randomX, randomY);

       
        currentApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);
    }
}
