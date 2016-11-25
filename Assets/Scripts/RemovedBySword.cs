using UnityEngine;
using System.Collections;

public class RemovedBySword : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
            Destroy(this.gameObject);
    }
}
