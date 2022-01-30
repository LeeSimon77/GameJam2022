using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float minX = -518.9f;
    private float maxX = -128.9f;
    private float maxY = -44.5f;
    private float minY = -287.5f;

    public int maxAsteroids;
    public int minAsteroids;
    private int numAsteroids;

    [SerializeField] private GameObject asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        numAsteroids = 0;

        while(numAsteroids < maxAsteroids)
            spawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyAsteroid()
    {
        numAsteroids--;
        if(numAsteroids <= minAsteroids)
        {
            while (numAsteroids < maxAsteroids)
                spawnAsteroid();
        }
    }

    private void spawnAsteroid()
    {
        Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(asteroidPrefab, position, Quaternion.identity);
        numAsteroids++;
    }
}
