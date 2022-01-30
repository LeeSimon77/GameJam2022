using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float minX = -518.9f;
    private float maxX = -128.9f;
    private float maxY = -44.5f;
    private float minY = -287.5f;

    public int[] maxSizes;
    public int[] minSizes;
    private int[] numOfSize;

    [SerializeField] private GameObject[] prefabs;

    private float asteroidMinSpeed = -5f;
    private float asteroidMaxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        numOfSize = new int[maxSizes.Length];
        for(int i = 0; i < maxSizes.Length; i++)
        {
            numOfSize[i] = 0;
            while(numOfSize[i] < maxSizes[i])
            {
                spawnAsteroid(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyAsteroid(int size)
    {
        numOfSize[size]--;
        while(numOfSize[size] < maxSizes[0])
        {
            spawnAsteroid(size);
        }
    }

    private void spawnAsteroid(int size)
    {
            Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject newAsteroid = Instantiate(prefabs[size], position, Quaternion.identity);
            newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(asteroidMinSpeed, asteroidMaxSpeed), Random.Range(asteroidMinSpeed, asteroidMaxSpeed));
            numOfSize[size]++;
    }
}
