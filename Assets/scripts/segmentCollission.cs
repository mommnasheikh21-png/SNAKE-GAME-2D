using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class segmentCollission : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} (Layer {gameObject.layer}, Tag {gameObject.tag}) " +
              $"collided with {other.name} (Layer {other.gameObject.layer}, Tag {other.tag})");


        if (other.CompareTag("snake"))
        {

            Debug.Log("Snake hit a segment ? Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
