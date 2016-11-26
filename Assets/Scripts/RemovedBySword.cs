using UnityEngine;
using System.Collections;

public class RemovedBySword : MonoBehaviour {
    public float speedHitFactor;
    public float raiseAmount;
    public GameObject destroyObject;
    

    private Vector3 oldPosition;
    private ScoreCount ScoreScript;

    private string whichHand;
    private bool destroyable;
    private AudioSource[] sounds;

	// Use this for initialization
	void Start () {
        this.destroyable = true;
        System.Random random = new System.Random();
        int rand = random.Next(2);
        this.whichHand = rand == 1 ? "Left" : "Right";
        this.GetComponentInChildren<MeshRenderer>().material = Resources.Load(this.whichHand) as Material;


        this.sounds = GetComponents<AudioSource>();
        AudioSource.PlayClipAtPoint(this.sounds[rand].clip, this.transform.position);

        this.ScoreScript = GameObject.Find("Camera (eye)").GetComponent<ScoreCount>();
    }
	
	// Update is called once per frame
	void Update () {
        oldPosition = this.transform.position;
	}



    private void OnCollisionEnter(Collision collision)
    {
        if (this.destroyable)
        {
            if (collision.gameObject.tag == ("Sword" + this.whichHand))
            {
                GameObject explosion = (GameObject)Instantiate(destroyObject, transform.position, transform.rotation);
                Destroy(explosion, 1);
                AudioSource.PlayClipAtPoint(this.sounds[2].clip, this.transform.position);
                Destroy(this.gameObject);
                this.ScoreScript.addScore();
            }
            else if (collision.gameObject.tag == "Floor" || (collision.gameObject.tag == "FallingObject" && !collision.gameObject.GetComponent<RemovedBySword>().isDestroyable()))
            {
                this.destroyable = false;
                this.GetComponentInChildren<MeshRenderer>().material = Resources.Load("Dead") as Material;
                GameObject waterObject = GameObject.Find("WaterProDaytime");
                waterObject.GetComponent<RaiseOverTime>().RaiseWith(raiseAmount);
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
