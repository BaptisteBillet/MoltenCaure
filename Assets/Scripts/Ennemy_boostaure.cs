using UnityEngine;
using System.Collections;

//boostaure augmentent la vitesse de déplacement des ennemis autour d'eux. Ils ont peu de points de vie.

public class Ennemy_boostaure : Ennemy 
{
    private Ennemy ennemy_script;

    public float boost_speed;


    public override void Start()
    {
        base.Start();
		this.nav_ennemy.speed = speed;
    }

    void OnTriggerEnter(Collider touch)
    {

        if (touch.tag == "ennemy" && touch.gameObject!=this.gameObject)
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
			ennemy_script.nav_ennemy.speed += boost_speed;
            Debug.Log("COllision avec Boostaure");
            

        }

    }

    
    void OnTriggerExit(Collider touch )
    {

		if (touch.tag == "ennemy" && touch.gameObject != this.gameObject)
        {
            ennemy_script = (Ennemy)touch.gameObject.GetComponent(typeof(Ennemy));
			ennemy_script.nav_ennemy.speed -= boost_speed;
            Debug.Log("FIN DE LA COLLISION");
			
        }

    }
    

}

