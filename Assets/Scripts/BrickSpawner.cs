using System.Security.Claims;
using UnityEditor;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public int xCount;
    public int yCount;

    public int xSeparation;
    public int ySeparation;

    public int xSpawnStart;
    public int ySpawnStart;

    public GameObject[] Bricks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int x = 0; x < xCount; x+= 4)
        {
            for (int y = 0; y <= yCount; y += 2)
            {
                Vector2 spawnPosition = new Vector2(xSpawnStart + x, ySpawnStart - y);
                GameObject t_BrickToSpawn = Bricks[Random.Range(0, Bricks.Length)];
                Instantiate(t_BrickToSpawn, spawnPosition, Quaternion.identity);
            }
            FindFirstObjectByType<GameManagerScript>().WINBRKCOUNT = + 24;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
