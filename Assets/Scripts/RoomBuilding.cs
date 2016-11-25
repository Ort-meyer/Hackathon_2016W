using UnityEngine;
using System.Collections;

public class RoomBuilding : MonoBehaviour {
    public GameObject VRCamera;
    public GameObject box;
	// Use this for initialization
	void Start () {
        SteamVR_PlayArea playAreaScript = VRCamera.GetComponent<SteamVR_PlayArea>();
        Valve.VR.HmdQuad_t quad = new Valve.VR.HmdQuad_t();
        SteamVR_PlayArea.GetBounds(playAreaScript.size, ref quad);

        // Calc width of room
        float sizeX = quad.vCorners0.v0 - quad.vCorners1.v0;
        float sizeZ = quad.vCorners0.v2 - quad.vCorners2.v2;
        //Instantiate(box, new Vector3(quad.vCorners0.v0, quad.vCorners0.v1, quad.vCorners0.v2), Quaternion.identity);
        //Instantiate(box, new Vector3(quad.vCorners1.v0, quad.vCorners1.v1, quad.vCorners1.v2), Quaternion.identity);
        //Instantiate(box, new Vector3(quad.vCorners2.v0, quad.vCorners2.v1, quad.vCorners2.v2), Quaternion.identity);
        //Instantiate(box, new Vector3(quad.vCorners3.v0, quad.vCorners3.v1, quad.vCorners3.v2), Quaternion.identity);
        Vector3 center = VRCamera.transform.position;

        //Vector3 FrontWallPosition = ;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
