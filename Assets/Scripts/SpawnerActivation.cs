using UnityEngine;
using System.Collections;

public class SpawnerActivation : MonoBehaviour {
    public Vector3 gravity = new Vector3(0, -1.0f, 0);
    public float startupDelay = 3;
    public float delayBetweenStartups = 0.2f;
    private float timer;
    private RandomDrop[] spawners;
    private int numberOfSpawners;
    // Use this for initialization
    void Start () {
        // Shouldnt be here, we set a wierd gravity...
        Physics.gravity = gravity;
        spawners = GetComponentsInChildren<RandomDrop>();
        numberOfSpawners = spawners.GetLength(0);
        Debug.Log(numberOfSpawners);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > startupDelay)
        {
            for (int i = 0; i < numberOfSpawners; i++)
            {
                if (timer > startupDelay+delayBetweenStartups*i && !spawners[i].isActiveAndEnabled)
                {
                    spawners[i].enabled = true;
                }
            }

        }
	}
}
