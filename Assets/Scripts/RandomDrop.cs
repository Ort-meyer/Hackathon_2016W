using UnityEngine;
using System.Collections;

public class RandomDrop : MonoBehaviour {

    public GameObject cube;
    public float spawnTimer;


    private float width;
    private float height;
    private float depth;
    private float posX;
    private float posY;
    private float posZ;

    private System.Random random;
    private float timer;
    // Use this for initialization
    void Start () {
        //Debug.log();
        //this.transform.position.y
        this.width = this.transform.localScale.x;
        this.height = this.transform.localScale.y;
        this.depth = this.transform.localScale.z;
        this.posX = this.transform.position.x;
        this.posY = this.transform.position.y;
        this.posZ = this.transform.position.z;
        this.random = new System.Random();
        this.timer = this.spawnTimer;
        

        //testFunc();
	}
	
	// Update is called once per frame
	void Update () {
        this.timer -= Time.deltaTime;
        if(this.timer < 0)
        {
            Instantiate(cube, randomObjectPosVector(cube), Quaternion.identity);
            this.timer = spawnTimer;
        }
	
	}

    //Random float
    float randomFloat(double min, double max)
    {
        return (float) (this.random.NextDouble() * (max - min) + min);
    }

    float randomPosition(float number)
    { 
        return randomFloat(number / 2.0f, (-(number / 2.0f))) ;
    }

    Vector3 randomObjectPosVector(GameObject obj)
    {
        return new Vector3(randomPosition((this.width - obj.transform.localScale.x) / 2.0f), this.posY-1, randomPosition((this.depth - obj.transform.localScale.z) / 2.0f));
    }

    void testFunc()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 t = randomObjectPosVector(cube);
            if (t.x > 4.5 || t.x < -4.5 || t.z > 4.5 || t.z < -4.5)
            {
                Debug.Log(t);
            }
        }
        Debug.Log("Done");
    }
}
