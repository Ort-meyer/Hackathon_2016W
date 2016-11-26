using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {

    private int score;
    private int increment;
    //public GameObject scoreText;

	// Use this for initialization
	void Start () {
        this.score = 0;
        this.increment = 10;
	}

    public void addScore()
    {
        this.score += this.increment;
    }

    // Update is called once per frame
    void Update()
    {
        //this.scoreText.GetComponent<TextMesh>().text = this.score.ToString();
    }

    public int getScore()
    {
        return this.score;
    }
}
