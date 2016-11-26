using UnityEngine;
using System.Collections;

public class RaiseOverTime : MonoBehaviour {

    public float m_raiseTarget;
    public float m_secondRaiseAmount;
    public float m_raiseFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_raiseTarget > 0)
        {
            float t_raiseThisFrame = m_secondRaiseAmount * Time.deltaTime * (m_raiseTarget / m_raiseFactor);
            transform.position += new Vector3(0, t_raiseThisFrame, 0);
            m_raiseTarget -= t_raiseThisFrame;
        }
	}

    public void RaiseWith(float p_raiseAmount)
    {
        m_raiseTarget += p_raiseAmount;
    }
}
