using UnityEngine;
using System.Collections;

public class DrawRange : MonoBehaviour {

	//UI PORTEE
	public SphereCollider portee;

	public GameObject sphere_prefab;
	private GameObject sphere_instance;

	// Use this for initialization
	void Start () 
	{
		portee = this.transform.parent.GetComponent<SphereCollider>();
	}
	void OnMouseEnter()
	{
		Debug.Log("enter");
		sphere_instance = Instantiate(sphere_prefab);
		sphere_instance.transform.position = this.transform.parent.transform.position;
		sphere_instance.transform.localScale = new Vector3(this.transform.parent.localScale.x * portee.radius, this.transform.parent.localScale.x * portee.radius, this.transform.parent.localScale.x * portee.radius);
	}

	void OnMouseExit()
	{
		Debug.Log("exit");
		Destroy(sphere_instance);
	}
}
