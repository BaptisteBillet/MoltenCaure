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

    private float interval;

    private float timeLeft;

    private int seconde;

    //Numéro de la vague
    public int numero_vague;

    // L'objet que l'on doit faire spawner
    public GameObject ennemy;

    // destination 
    public Transform destination = null;

    void Start()
    {
        //Initialisation des variables
        interval = 10;
        timeLeft = 0;
        seconde = 0;
        numero_vague = 0;
    }

    void Update()
    {

        // time to spawn the next one?
        timeLeft -= Time.deltaTime;

        //Simple timer, a améliorer
        if (timeLeft <= 0.0f)
        {
            seconde++;
            timeLeft = interval;

            
            // spawn
            GameObject spawner = (GameObject)Instantiate(ennemy, transform.position, Quaternion.identity);

            // get access to the navmesh agent component

            NavMeshAgent nav_ennemy = spawner.GetComponent<NavMeshAgent>();

            nav_ennemy.destination = destination.position;

            // reset time
            seconde = 0;

            // on ajoute une vague
            numero_vague++;
        }

    }

}