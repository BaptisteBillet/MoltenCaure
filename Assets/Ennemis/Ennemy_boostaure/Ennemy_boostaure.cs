using UnityEngine;
using System.Collections;

//boostaure augmentent la vitesse de déplacement des ennemis autour d'eux. Ils ont peu de points de vie.

public class Ennemy_boostaure : Ennemy 
{
    private Ennemy ennemy_script;

    private float boost_speed;

    void Start()
    {
        base.Start();

        myNavMeshAgent.speed = 5;
        boost_speed = 2;
       

        vie = 100;
        if (vie <= 0)
        {
            RessourcesManager.ressourceX++;
        }

        
    }

    void OnTriggerEnter(Collider touch)
    {

        if (touch.tag == "ennemy")
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            //ennemy_script.agent.speed += boost_speed;

        }

    }

    /*
    void OnTriggerExit(Collider touch)
    {

        if (touch.tag == "ennemy")
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            ennemy_script.agent.speed -= boost_speed;

        }

    }
    */

}

