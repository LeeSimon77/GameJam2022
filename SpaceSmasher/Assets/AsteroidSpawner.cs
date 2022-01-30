using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float minX = -518.9f;
    private float maxX = -128.9f;
    private float maxY = -44.5f;
    private float minY = -287.5f;

    public int maxSize0;
    public int minSize0;
    private int numSize0;
    [SerializeField] private GameObject size0Prefab;

    public int maxSize5;
    public int minSize5;
    private int numSize5;
    [SerializeField] private GameObject size5Prefab;

    private float asteroidMinSpeed = -5f;
    private float asteroidMaxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        numSize0 = 0;
        while(numSize0 < maxSize0)
            spawnAsteroid(0);

        numSize5 = 0;
        while (numSize5 < maxSize5)
            spawnAsteroid(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroyAsteroid(int size)
    {
        if (size == 0)
        {
            numSize0--;
            if (numSize0 <= minSize0)
            {
                while (numSize0 < maxSize0)
                    spawnAsteroid(0);
            }
        }
        else if (size == 5)
        {
            numSize5--;
            if (numSize5 <= minSize5)
            {
                while (numSize5 < maxSize5)
                    spawnAsteroid(5);
            }
        }
    }

    private void spawnAsteroid(int size)
    {
        if(size == 0)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject newAsteroid = Instantiate(size0Prefab, position, Quaternion.identity);
            newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(asteroidMinSpeed, asteroidMaxSpeed), Random.Range(asteroidMinSpeed, asteroidMaxSpeed));
            numSize0++;
        }
        else if (size == 5)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject newAsteroid = Instantiate(size5Prefab, position, Quaternion.identity);
            newAsteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(asteroidMinSpeed, asteroidMaxSpeed), Random.Range(asteroidMinSpeed, asteroidMaxSpeed));
            numSize5++;
        }
    }
}
