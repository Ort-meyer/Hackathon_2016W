using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour {
    GameObject waterObject;
    GameObject drownedText;
    private GameObject scoreText;
    private bool once = false;
    public float maxTimeUnderWater = 0.5f;
    private float timeUnderWater = 0;
    private AudioSource[] sounds;
    // Use this for initialization
    void Start () {
        waterObject = GameObject.Find("WaterProDaytime");
        drownedText = GameObject.Find("DrownedText");
        scoreText = GameObject.Find("ScoreText");
        sounds = GetComponents<AudioSource>();
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
                scoreText.GetComponent<TextMesh>().text = GameObject.Find("Camera (eye)").GetComponent<ScoreCount>().getScore().ToString();
                scoreText.GetComponent<MeshRenderer>().enabled = true;
                if (!once)
                {
                    AudioSource.PlayClipAtPoint(this.sounds[3].clip, this.transform.position);
                    sounds[0].enabled = false;
                    once = true;
                }
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
