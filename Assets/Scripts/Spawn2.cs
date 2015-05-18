using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;

public class Spawn2 : MonoBehaviour {


	public GameObject standard;
	private int standardNumber;
	public GameObject boostaure;
	public GameObject gropaure;
	public GameObject mordaure;
	public GameObject sprintaure;

	public float timeBeforeNextWave;
	public float minTimeBeforeNextWave;

	public List<GameObject> vague;
	public int level;

	private GameObject spawner;

	// destination 
	public Transform destination = null;
	public Transform destiRetour = null;


	public bool standardAlea;
	public int minimum_Vague_Standard;
	public int maximum_Vague_Standard;


	// Use this for initialization
	void Start () {
		level = 0;
		standardNumber = 3;
	}

	IEnumerator waitForWave()
	{
		while(true)
		{
			while(timeBeforeNextWave>0)
			{
				yield return new WaitForSeconds(1);
				timeBeforeNextWave-=0.2f;
			}

			timeBeforeNextWave--;
			if (timeBeforeNextWave < minTimeBeforeNextWave)
			{
				timeBeforeNextWave = minTimeBeforeNextWave;
			}
			ConstructNexWave();
		}
	}

	void ConstructNexWave()
	{
		vague.Clear();

		if(level%2==0)
		{
			standardNumber++;
		}

		NextWave();
	}
	

	void NextWave()
	{
		GameObject spawner = null;

		spawner = null;
		foreach(GameObject go in vague)
		{
			spawner = (GameObject)Instantiate(go, transform.position, Quaternion.identity);
		}

		//On attribue le navmesh à l'ennemi créé
		NavMeshAgent nav_ennemy = spawner.GetComponent<NavMeshAgent>();
		nav_ennemy.destination = destination.position;
		
		spawner.GetComponent<Ennemy>().start = this.transform.position;
	}


	public void launchNextWave()
	{
		//timeBeforeNextWave
	}
	



}
