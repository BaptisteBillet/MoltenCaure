using UnityEngine;
using System.Collections;

//Ceci est un ennemy_type

public class Ennemy_type : Ennemy 

{

   // bool estEnCollision;

    public override void Start()
    {
		base.Start();
		this.nav_ennemy.speed = speed;
    }

    /*
    public override void Update()
    {
		base.Update();
		/*
        if (estEnCollision)
        {
            this.GetComponent<NavMeshAgent>().speed =  50;
        }
        else
        {
            this.GetComponent<NavMeshAgent>().speed = speed;
        }

    }*/


    //POUR LES BOOSTAURES : tester la collision sur un ennemi AUTRE QUE BOOSTAURE avec un gameobject rond disposé autour d'un boostaure.
    // SI est en collision (dans l'update donc), alors on augmente la vitesse de base du monstre en question
    // SI il n'est pas en collision avec, sa vitesse est normale
	/*
    void OnTriggerEnter(Collider touch)
    {

        if (touch.tag == "boostaure")       //Si cet ennemi touche le collider d'un boostaure, alors quelque chose se passe
        {
            //ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            //ennemy_script.agent.speed += boost_speed;
            Debug.Log("COllision avec Boostaure");
            estEnCollision = true;
            
        }

    }


    void OnTriggerExit(Collider touch)
    {

        if (touch.tag == "boostaure")           // Si cet ennemi sort du collider d'un 
        {
            //ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            //ennemy_script.agent.speed -= boost_speed;
            Debug.Log("FIN DE LA COLLISION");
            estEnCollision = false;
        }

    }
	*/

}
