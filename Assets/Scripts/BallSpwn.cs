using UnityEngine;

public class BallSpwn : MonoBehaviour
{
    public GameObject ballPrefab;         
    public Transform playerBoard;         
    public float spawnOffsetY = 0.8f;     
    public float launchForce = 10f;        

    private GameObject currentBall;
    private bool ballReady = false;

    void Start()
    {
        SpawnBall();
    }

    void Update()
    {
        if (ballReady)
        {
            
            Vector3 followPos = playerBoard.position + Vector3.up * spawnOffsetY;
            currentBall.transform.position = followPos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
    }

    void SpawnBall()
    {
        Vector3 spawnPos = playerBoard.position + Vector3.up * spawnOffsetY;
        currentBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        if (currentBall.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        ballReady = true;
    }

    void LaunchBall()
    {
        if (currentBall.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.linearVelocity = Vector3.up * launchForce;
            ballReady = false;
        }
        else
        {
            Debug.LogError("Ball does not have a Rigidbody component.");
        }
    }
}