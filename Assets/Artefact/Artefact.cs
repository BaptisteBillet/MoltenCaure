using UnityEngine;
using System.Collections;

public class Artefact : MonoBehaviour {

	public bool hold;
	private Vector3 start_position;

	public GameObject destination;

	NavMeshAgent nav_artefact;

	[HideInInspector]
	public GameObject holder;

	// Use this for initialization
	void Start () {
		nav_artefact=GetComponent<NavMeshAgent>();
		start_position= this.transform.position;
		nav_artefact.destination = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(hold==false && this.transform.position!=start_position)
		{
			nav_artefact.enabled = true;
		}
		else
		{
			nav_artefact.enabled = false;
		}
		
		if(hold==true)
		{
			if(holder == null)
			{
				hold = false;
			}
		}

	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="ennemy")
		{
			hold = true;
			holder = other.gameObject;
		}
	}


}
