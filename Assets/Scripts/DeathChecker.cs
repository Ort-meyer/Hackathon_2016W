using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour {
    GameObject waterObject;
    GameObject drownedText;
    public float maxTimeUnderWater = 0.5f;
    private float timeUnderWater = 0;

    // Use this for initialization
    void Start () {
        waterObject = GameObject.Find("WaterProDaytime");
        drownedText = GameObject.Find("DrownedText");

    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("Water Y = " + waterObject.transform.position.y + " Head Y = " + transform.position.y);
        if (transform.position.y < waterObject.transform.position.y)
        {
            timeUnderWater += Time.deltaTime;
            if (timeUnderWater >= maxTimeUnderWater)
            {
                //Debug.Log("U DED!!");
                drownedText.GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("BoxSpawnerActivator").GetComponent<SpawnerActivation>().enabled = false;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(1);
                }
            }
            return;
        }
        timeUnderWater = 0;
	}
}
