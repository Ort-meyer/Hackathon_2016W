using UnityEngine;
using System.Collections;

public class RandomDrop : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
	void Start () {
        //Debug.log();
        Debug.Log(this.transform.position.x);
        Instantiate(cube, new Vector3(1,1,1), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
