using UnityEngine;
using System.Collections;

public class StartRandomSpin : MonoBehaviour {


    // Random variable to generate our starting torque
    System.Random r = new System.Random();

    // Use this for initialization
    void Start ()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(GetRandomFloat(), GetRandomFloat(), GetRandomFloat()));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Gets individual random float between hard coded min and max values
    float GetRandomFloat()
    {
        double min = 0;
        double max = 5;
        return (float)(min + r.NextDouble() * (max - min));
    }
}
