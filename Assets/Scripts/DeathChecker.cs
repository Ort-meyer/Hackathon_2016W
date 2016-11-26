using UnityEngine;
using System.Collections;

public class DeathChecker : MonoBehaviour {
    GameObject waterObject;
    public float maxTimeUnderWater = 0.5f;
    private float timeUnderWater = 0;

    // Use this for initialization
    void Start () {
        waterObject = GameObject.Find("WaterProDaytime");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Water Y = " + waterObject.transform.position.y + " Head Y = " + transform.position.y);
        if (transform.position.y < waterObject.transform.position.y)
        {
            timeUnderWater += Time.deltaTime;
            if (timeUnderWater >= maxTimeUnderWater)
            {
                Debug.Log("U DED!!");
            }
            return;
        }
        timeUnderWater = 0;
	}
}
