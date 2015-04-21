using UnityEngine;
using System.Collections;

//boostaure augmentent la vitesse de déplacement des ennemis autour d'eux. Ils ont peu de points de vie.

public class Ennemy_boostaure : Ennemy 
{
    private Ennemy ennemy_script;

    private float boost_speed;

    void Start()
    {
        vie = 100;
        boost_speed = 2;
    }

    void OnTriggerEnter(Collider touch)
    {

        if (touch.tag == "ennemy")
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            //ennemy_script.agent.speed += boost_speed;
            Debug.Log("COllision avec Boostaure");

        }

    }

    
    void OnTriggerExit(Collider touch)
    {

        if (touch.tag == "ennemy")
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
            //ennemy_script.agent.speed -= boost_speed;
            Debug.Log("FIN DE LA COLLISION");
        }

    }
    

}

