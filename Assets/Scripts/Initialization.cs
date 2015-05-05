using UnityEngine;
using System.Collections;

public class Initialization : MonoBehaviour {

    public GameObject Main;
    private GameObject main;

	// Use this for initialization
	void Start () 
    {
        main = Instantiate(Main) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
