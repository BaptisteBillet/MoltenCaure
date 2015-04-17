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

    void OnTriggerEnter(Collider touch)
    {
        
        //Si l'ennemi atteint l'Artefact
        if (touch.tag == "end")
        {
            //  /!\ Il faut faire en sorte que l'ennemi reviennent en arrière avec l'Artefact
        }
    }

	void Update () 
    {
        //Si l'ennemi n'a plus de vie, on détruit l'objet
        if(vie<=0)
        {
            RessourcesManager.ressourceX++;
            Destroy(this.gameObject);
        }

	}
}
