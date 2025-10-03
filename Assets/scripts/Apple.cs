using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject square;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("snake"))
        {
            other.GetComponent<SnakeMovement>().Grow();
            FindObjectOfType<Instantiate>().SpawnApple();
            Destroy(gameObject);
        }
    }
}
