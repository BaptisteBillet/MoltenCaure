using UnityEngine;
using System.Collections;

public class LoadNewScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadNextScene ()
    {
        Application.LoadLevel("Game");
    }
}
