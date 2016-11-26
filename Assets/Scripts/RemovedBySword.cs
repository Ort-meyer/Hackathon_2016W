using UnityEngine;
using System.Collections;

public class RemovedBySword : MonoBehaviour {

    private string whichHand;
    private bool destroyable;
	// Use this for initialization
	void Start () {
        this.destroyable = true;
        System.Random random = new System.Random();
        int rand = random.Next(2);
        this.whichHand = rand == 1 ? "Left" : "Right";
        this.GetComponentInChildren<MeshRenderer>().material = Resources.Load(this.whichHand) as Material;
  
        this.GetComponent<AudioSource>().Play();
        AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, this.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        oldPosition = this.transform.position;
	}

    public float speedHitFactor;

    private Vector3 oldPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (this.destroyable)
        {
            if (collision.gameObject.tag == ("Sword" + this.whichHand))
            {
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "Floor" || (collision.gameObject.tag == "FallingObject" && !collision.gameObject.GetComponent<RemovedBySword>().isDestroyable()))
            {
                this.destroyable = false;
                this.GetComponentInChildren<MeshRenderer>().material = Resources.Load("Dead") as Material;
            }
        }
        // Matrix4x4 swordWorldMat = collision.gameObject.transform.worldToLocalMatrix;
        // Vector3 swordPos = swordWorldMat.MultiplyPoint3x4(collision.gameObject.transform.position);
        // Vector3 thisPos = swordWorldMat.MultiplyPoint3x4(this.transform.position);
        // Vector3 thisOldPos = swordWorldMat.MultiplyPoint3x4(this.oldPosition);
        // Vector3 thisDispVec = thisPos - thisOldPos;
        // //float speedHitFactor = 1;
        // if (swordPos.y < thisDispVec.y)
        // {
        //     Destroy(this.gameObject);
        // }

        //if (collision.relativeVelocity.magnitude > speedHitFactor)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    public bool isDestroyable()
    {
        return this.destroyable;
    }
}
