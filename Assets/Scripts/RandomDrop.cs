using UnityEngine;
using System.Collections;

public class RandomDrop : MonoBehaviour {

    public GameObject cube;
    public float spawnTimer;
    public float spawnTimeReductionPerSecond;
    public float chanceToSpawn;
    public int maxSpawnAtSameTime;
    public float forceToApply;
    public Vector3 forceApplyVector;


    private float width;
    private float height;
    private float depth;
    private float posX;
    private float posY;
    private float posZ;

    static private System.Random random;
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
        random = new System.Random();
        this.timer = 0;


        //testFunc();
    }
	
	// Update is called once per frame
	void Update () {
        this.width = this.transform.localScale.x;
        this.height = this.transform.localScale.y;
        this.depth = this.transform.localScale.z;
        this.posX = this.transform.position.x;
        this.posY = this.transform.position.y;
        this.posZ = this.transform.position.z;
        float chance = (float)random.NextDouble();
        spawnTimer = spawnTimer - Time.deltaTime * spawnTimeReductionPerSecond;
        if (chance <= chanceToSpawn)
        {
            GameObject newObject = (GameObject)Instantiate(cube, randomObjectPosVector(cube), Quaternion.identity);
            newObject.GetComponent<Rigidbody>().AddForce(transform.forward*forceToApply, ForceMode.Impulse);
        }

        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            GameObject newObject = (GameObject)Instantiate(cube, randomObjectPosVector(cube), Quaternion.identity);
            newObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceToApply, ForceMode.Impulse);
            this.timer = spawnTimer;
        }

    }

    //Random float
    float randomFloat(double min, double max)
    {
        return (float) (random.NextDouble() * (max - min) + min);
    }

    float randomPosition(float number)
    { 
        return randomFloat(number / 2.0f, (-(number / 2.0f))) ;
    }

    Vector3 randomObjectPosVector(GameObject obj)
    {
        float x = this.posX + randomPosition((this.width - obj.transform.localScale.x) / 2.0f);
        float y = this.posY + randomPosition((this.height - obj.transform.localScale.y) / 2.0f);
        float z = this.posZ + randomPosition((this.depth - obj.transform.localScale.z) / 2.0f);
        return new Vector3(x, y, z);
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
