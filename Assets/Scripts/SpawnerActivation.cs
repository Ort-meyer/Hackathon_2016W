using UnityEngine;
using System.Collections;

public class SpawnerActivation : MonoBehaviour {
    public Vector3 gravity = new Vector3(0, -1.0f, 0);
    public float startupDelay = 3;
    public float delayBetweenStartups = 0.2f;
    public float secondsBetweenLaunch = 2;
    public float spawnTimeReductionPerSecond;
    public float chanceToSpawn;
    private float startupTimer;
    private float launchTimer;
    private RandomDrop[] spawners;
    private int numberOfSpawners;
    public float forceToApply;
    public float minSecondsBetweenLaunch = 0.5f;

    static private System.Random random;

    // Use this for initialization
    void Start () {
        // Shouldnt be here, we set a wierd gravity...
        Physics.gravity = gravity;
        spawners = GetComponentsInChildren<RandomDrop>();
        numberOfSpawners = spawners.GetLength(0);
        Debug.Log(numberOfSpawners);
        random = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
        startupTimer += Time.deltaTime;
        if (startupTimer > startupDelay)
        {
            launchTimer += Time.deltaTime;
            float chance = (float)random.NextDouble();
            if (secondsBetweenLaunch >= minSecondsBetweenLaunch)
            {
                secondsBetweenLaunch = secondsBetweenLaunch - Time.deltaTime * spawnTimeReductionPerSecond;
                if (secondsBetweenLaunch < minSecondsBetweenLaunch)
                {
                    secondsBetweenLaunch = minSecondsBetweenLaunch;
                }
            }

            if (chance <= chanceToSpawn)
            {
                int spawnerToLaunchFrom = random.Next(0, numberOfSpawners);
                spawners[spawnerToLaunchFrom].LaunchABox(forceToApply);
            }
            
            if (launchTimer > secondsBetweenLaunch)
            {
                int spawnerToLaunchFrom = random.Next(0, numberOfSpawners);
                spawners[spawnerToLaunchFrom].LaunchABox(forceToApply);
                launchTimer = 0;
            }
        }

    }
}
