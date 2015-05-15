using UnityEngine;
using System.Collections;

public class LifeTime_Particles : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, lifeTime);
	}
}
