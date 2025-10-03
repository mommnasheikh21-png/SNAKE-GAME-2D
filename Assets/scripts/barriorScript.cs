using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class barriorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

       
        if (other.CompareTag("snake"))
        {
       
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
