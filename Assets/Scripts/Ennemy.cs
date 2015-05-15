using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////
//                                                          //
//  Cette classe est la classe parent de tout les ennemies  //
//                                                          //
//////////////////////////////////////////////////////////////

public class Ennemy : MonoBehaviour {

    //Vitesse de l'ennemi
    public float speed;
	private float base_speed;
    //Vie de l'ennemi
    public float vie;

	[HideInInspector]
	public Vector3 start;

	public bool objectif_artefact;

	public NavMeshAgent nav_ennemy;

	public bool IsPoison;
	public int poison_time;
	public bool IsGel;
	public int gel_time;
	public bool IsRadia;
	public int Radia_pourcentage;
	public int Degat_Radia=5;

	public virtual void Start()     //Virtual permet à la fonction d'être appelée par ses enfants
	{
		base_speed = speed;
		//On attribue le navmesh à l'ennemi créé
		nav_ennemy = this.gameObject.GetComponent<NavMeshAgent>();
	}

	public virtual void Update() 
    {

        //Si l'ennemi n'a plus de vie, on détruit l'objet
        if(vie<=0)
        {
            RessourcesManager.ressourceX++;
            Destroy(this.gameObject);
        }

		if(Artefact_Script.instance.hold==false)
		{
			objectif_artefact = false;
		}


		if(objectif_artefact==true)
		{
			//On attribue la destination à l'ennemi créé
			nav_ennemy.destination = Artefact_Script.instance.start_point.transform.position;
		}
		else 
		{
			//On attribue la destination à l'ennemi créé
			nav_ennemy.destination = Artefact_Script.instance.artefact.transform.position;
		}

	}

	public void SetDegat(int degat)
	{
		if(Radia_pourcentage>0)
		{
			vie -= degat * (Radia_pourcentage * Degat_Radia);
		}
		else
		{
			vie -= degat;
		}
	}

	public IEnumerator Poison(int degats, int time)
	{
		if(!IsPoison)
		{
			IsPoison = true;
			poison_time = 0;
			while (poison_time < time)
			{
				SetDegat(degats);
				yield return new WaitForSeconds(1);
				poison_time++;
			}
			IsPoison = false;
		}
		else
		{
			poison_time = 0;
		}
	}

	public IEnumerator Gel(int slow, int time)
	{
		if(!IsGel)
		{
			IsGel = true;
			gel_time = 0;
			while(gel_time!=time)
			{
				speed -= slow;
				yield return new WaitForSeconds(1);
				gel_time++;
			}
			speed = base_speed;
			IsGel = false;
		}
		else
		{
			gel_time = 0;
		}
		
	}
	public IEnumerator Radia(int time)
	{
			Radia_pourcentage++;
			int radia_time = 0;
			while (radia_time != time)
			{
				yield return new WaitForSeconds(1);
				radia_time++;
			}
			Radia_pourcentage--;
	}

}
