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
	
	}

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
    }

    public bool isDestroyable()
    {
        return this.destroyable;
    }
}
