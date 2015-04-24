using UnityEngine;
using System.Collections;

public class Artefact : MonoBehaviour {

	private Vector3 start_position;

	//public GameObject destination;

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
	
		
		if(Artefact_Script.instance.hold==false && this.transform.position!=start_position)
		{
			//On attribue la destination à l'ennemi créé
			nav_artefact.destination = start_position;
		}
		else
		{
			//On attribue la destination à l'ennemi créé
			nav_artefact.destination = Artefact_Script.instance.start_point.transform.position;
		}

		if (Artefact_Script.instance.hold == true)
		{
			if(holder == null)
			{
				Artefact_Script.instance.hold = false;
			}
		}



	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="ennemy")
		{
			Ennemy ennemy_touch = other.GetComponent<Ennemy>();
			ennemy_touch.objectif_artefact = true;
			Artefact_Script.instance.hold = true;
			holder = other.gameObject;
		}
		if (other.gameObject.tag == "Start")
		{
			Debug.Log("stop");

		}
	}


}
