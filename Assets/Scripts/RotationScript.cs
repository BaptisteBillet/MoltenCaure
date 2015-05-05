using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

    public int VitesseRotation = 40;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * VitesseRotation * Time.deltaTime);
        //transform.Rotate(VitesseRotation * Time.deltaTime, VitesseRotation * Time.deltaTime, 0.0f);
        transform.Rotate(Vector3.down * VitesseRotation * Time.deltaTime, Space.World);
    }
}
