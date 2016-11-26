using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public GameObject leftHand;
    public GameObject rightHand;
    public float grabDistance;
    public GameObject destroyObject;
    private SteamVR_Controller.Device LeftController;
    private SteamVR_Controller.Device RightController;
    private bool dropped = false;
    // Use this for initialization
    void Start () {
        LeftController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));
        RightController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost));
    }
	
	// Update is called once per frame
	void Update () {
        LeftController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));
        RightController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost));
        if (LeftController.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            Debug.Log("Pressed left trigger " + (leftHand.transform.position - transform.position).magnitude);
            
            if ((leftHand.transform.position - transform.position).magnitude < grabDistance)
            {
                dropped = true;
                transform.parent = leftHand.transform;
                return;
            }
        }
        else if (RightController.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            Debug.Log("Pressed right trigger " + (rightHand.transform.position - transform.position).magnitude);
            if ((rightHand.transform.position - transform.position).magnitude < grabDistance)
            {
                dropped = true;
                transform.parent = rightHand.transform;
                return;
            }
        }
        if (dropped == true)
        {
            GameObject.Find("BoxSpawnerActivator").GetComponent<SpawnerActivation>().enabled = true;
            dropped = false;
            GameObject explosion = (GameObject)Instantiate(destroyObject, transform.position, transform.rotation);
            Destroy(explosion, 1);
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, this.transform.position);
            Destroy(this.gameObject);
        }
        

    }
}
