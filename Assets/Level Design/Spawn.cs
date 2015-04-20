using UnityEngine;

using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                        //
//  Pour l'instant, le spawn n'envoi qu'un ennemy à la fois.                              //
//  Il faudrait qu'a termes, il instantie des Vagues, vagues qui se composent d'ennemies  //
//  en fonction du numero_vague                                                           //
//                                                                                        //
////////////////////////////////////////////////////////////////////////////////////////////

public class Spawn : MonoBehaviour
{

    //Temps pour le spawn

    public float interval;
    public float frequenceSpawnDifferent;
    private float timeLeft;

    //Numéro de l'ennemi généré
    private int numero_ennemi;

    // L'objet que l'on doit faire spawner
    public GameObject ennemy;
    public GameObject boostaure;

    // destination 
    public Transform destination = null;

    void Start()
    {
        //Initialisation des variables
        timeLeft = 0;
        numero_ennemi = 0;
    }

    void Update()
    {

        // time to spawn the next one?
        timeLeft -= Time.deltaTime;

        //Simple timer, a améliorer
        if (timeLeft <= 0.0f)
        {
            timeLeft = interval;

            GameObject spawner = null;
            // spawn
            if (numero_ennemi >= frequenceSpawnDifferent)
            {
                spawner = (GameObject)Instantiate(boostaure, transform.position, Quaternion.identity);
                numero_ennemi = 0;
            }
            else
            {
                spawner = (GameObject)Instantiate(ennemy, transform.position, Quaternion.identity);
            }
            

            // get access to the navmesh agent component
            NavMeshAgent nav_ennemy = spawner.GetComponent<NavMeshAgent>();

            nav_ennemy.destination = destination.position;

            // on incrémente le nombre d'ennemis créés
            numero_ennemi++;
        }

    }

}