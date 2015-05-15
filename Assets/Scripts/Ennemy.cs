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
    //Vie de l'ennemi
    public float vie;

	[HideInInspector]
	public Vector3 start;

	public bool objectif_artefact;

	public NavMeshAgent nav_ennemy;



	public virtual void Start()     //Virtual permet à la fonction d'être appelée par ses enfants
	{
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
}
