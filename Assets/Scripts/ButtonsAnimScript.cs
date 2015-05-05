using UnityEngine;
using System.Collections;

public class ButtonsAnimScript : MonoBehaviour {

    public bool activeSelf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(this.activeSelf == true)
        {
            Debug.Log(activeSelf);
        }
	}



}
