using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;

public class Spawn2 : MonoBehaviour {


	[Range(0, 100)]
	public int standardNumberOfStandard;
	[Header("Temps")]
	
	public float timeBeforeNextWave;
	public float starttimeBeforeNextWave;
	public float minTimeBeforeNextWave;

	// destination 
	[Header("NavMesh")]
	public Transform destination = null;
	public Transform destiRetour = null;
	

	private GameObject spawner;


	[Header("Ennemis")]
	
	public GameObject standard;

	public GameObject boostaure;

	public GameObject gropaure;

	public GameObject mordaure;

	public GameObject sprintaure;

	[Header("Tweek Aleatoire")]
	[Range(0, 100)]
	public int minimum_Vague_Sprintaure;
	 [Range(0, 100)]
	public int maximum_Vague_Sprintaure;
	[Space(10)]
	[Range(0, 100)]
	public int minimum_Vague_Standard;
	 [Range(0, 100)]
	public int maximum_Vague_Standard;
	[Space(10)]
	[Range(0, 100)]
	public int minimum_Vague_Boostaure;
	 [Range(0, 100)]
	public int maximum_Vague_Boostaure;
	[Space(10)]
	[Range(0, 100)]
	public int minimum_Vague_Gropaure;
	 [Range(0, 100)]
	public int maximum_Vague_Gropaure;
	[Space(10)]
	[Range(0, 100)]
	public int minimum_Vague_Mordaure;
	[Range(0, 100)]
	public int maximum_Vague_Mordaure;
	[Space(20)]
	public List<GameObject> vague;
	public int level;

	private int vague_Standard;
	private int vague_Sprintaure;
	private int vague_Boostaure;
	private int vague_Gropaure;
	private int vague_Mordaure;

	private int vague_alea_Standard;
	private int vague_alea_Sprintaure;
	private int vague_alea_Boostaure;
	private int vague_alea_Gropaure;
	private int vague_alea_Mordaure;



	// Use this for initialization
	void Start () {
		level = 0;

		vague_Standard=standardNumberOfStandard;;
		vague_Sprintaure=0;
		vague_Boostaure=0;
		vague_Gropaure=0;
		vague_Mordaure=0;
		vague_alea_Standard = 0;
		vague_alea_Sprintaure = 0;
		vague_alea_Boostaure = 0;
		vague_alea_Gropaure = 0;
		vague_alea_Mordaure = 0;

		StartCoroutine(waitForWave());
		ConstructNexWave();
	}

	IEnumerator waitForWave()
	{
		while(true)
		{
			while(timeBeforeNextWave>0)
			{
				yield return new WaitForSeconds(0.2f);
				timeBeforeNextWave-=0.2f;
			}
			starttimeBeforeNextWave--;
			if (starttimeBeforeNextWave < minTimeBeforeNextWave)
			{
				starttimeBeforeNextWave = minTimeBeforeNextWave;
			}
			timeBeforeNextWave = starttimeBeforeNextWave;
			level++;
			ConstructNexWave();
		}
	}

	void ConstructNexWave()
	{
		vague.Clear();

		//
		if(vague_alea_Standard>=minimum_Vague_Standard && vague_alea_Standard<=maximum_Vague_Standard)
		{
			if(Random.Range(vague_alea_Standard, maximum_Vague_Standard)>=maximum_Vague_Standard)
			{
				vague_Standard++;
				vague_alea_Standard = 0;
			}
			else
			{
				vague_alea_Standard++;
			}
		}
		else
		{
			vague_alea_Standard++;
		}
		if (vague_alea_Sprintaure >= minimum_Vague_Sprintaure && vague_alea_Sprintaure <= maximum_Vague_Sprintaure)
		{
			Debug.Log("a");
			if (Random.Range(vague_alea_Sprintaure, maximum_Vague_Sprintaure) >= maximum_Vague_Sprintaure)
			{
				vague_Sprintaure++;
				vague_alea_Sprintaure = 0;
			}
			else
			{
				vague_alea_Sprintaure++;
			}
		}
		else
		{
			vague_alea_Sprintaure++;
		}
		if (vague_alea_Boostaure >= minimum_Vague_Boostaure && vague_alea_Boostaure <= maximum_Vague_Boostaure)
		{
			if (Random.Range(vague_alea_Boostaure, maximum_Vague_Boostaure) >= maximum_Vague_Boostaure)
			{
				vague_Boostaure++;
				vague_alea_Boostaure = 0;
			}
			else
			{
				vague_alea_Boostaure++;
			}
		}
		else
		{
			vague_alea_Boostaure++;
		}
		if (vague_alea_Gropaure >= minimum_Vague_Gropaure && vague_alea_Gropaure <= maximum_Vague_Gropaure)
		{
			if (Random.Range(vague_alea_Gropaure, maximum_Vague_Gropaure) >= maximum_Vague_Gropaure)
			{
				vague_Gropaure++;
				vague_alea_Gropaure = 0;
			}
			else
			{
				vague_alea_Gropaure++;
			}
		}
		else
		{
			vague_alea_Gropaure++;
		}
		if (vague_alea_Mordaure >= minimum_Vague_Mordaure && vague_alea_Mordaure <= maximum_Vague_Mordaure)
		{
			if (Random.Range(vague_alea_Mordaure, maximum_Vague_Mordaure) >= maximum_Vague_Mordaure)
			{
				vague_Mordaure++;
				vague_alea_Mordaure = 0;
			}
			else
			{
				vague_alea_Mordaure++;
			}
		}
		else
		{
			vague_alea_Mordaure++;
		}
		//

		for (int i = 0; i < vague_Standard; i++) { vague.Add(standard); }
		for (int i = 0; i < vague_Sprintaure; i++) { vague.Add(sprintaure); }
		for (int i = 0; i < vague_Boostaure; i++) { vague.Add(boostaure); }
		for (int i = 0; i < vague_Gropaure; i++) { vague.Add(gropaure); }
		for (int i = 0; i < vague_Mordaure; i++) { vague.Add(mordaure); }
		
		
		
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
		timeBeforeNextWave = 0;
	}
	



}
