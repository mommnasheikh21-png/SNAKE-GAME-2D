using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SnakeMovement : MonoBehaviour
{
    public Transform SegmentPrefab;
    public float moveDelay = 0.1f;

    private Vector2 moveDirection = Vector2.right;
    private List<Transform> _segments;
    private float timer;

    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveDirection != Vector2.down)
            moveDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && moveDirection != Vector2.up)
            moveDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && moveDirection != Vector2.right)
            moveDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && moveDirection != Vector2.left)
            moveDirection = Vector2.right;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= moveDelay)
        {
            timer = 0f;

          
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + moveDirection.x,
                Mathf.Round(this.transform.position.y) + moveDirection.y,
                0f);
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.SegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }


    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
    IEnumerator DelayGrow()
    {
        yield return new WaitForFixedUpdate();
        Grow();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("apple"))
        {
            Destroy(other.gameObject);

           
            StartCoroutine(DelayGrow());
        }
    }
}

    



