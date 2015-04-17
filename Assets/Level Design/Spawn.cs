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


 /*using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 [System.Serializable]
 public class WaveAction
 {
     public string name;
     public float delay;
     public Transform prefab;
     public int spawnCount;
     public string message;
 }
 
 [System.Serializable]
 public class Wave
 {
     public string name;
     public List<WaveAction> actions;
 }
 
 
 //revoir pour vagues enemy
 public class WaveGenerator : MonoBehaviour
 {
     public float difficultyFactor = 0.9f;
     public List<Wave> waves;
     private Wave m_CurrentWave;
     public Wave CurrentWave { get {return m_CurrentWave;} }
     private float m_DelayFactor = 1.0f;
 
     IEnumerator SpawnLoop()
     {
         m_DelayFactor = 1.0f;
         while(true)
         {
             foreach(Wave W in waves)
             {
                 m_CurrentWave = W;
                 foreach(WaveAction A in W.actions)
                 {
                     if(A.delay > 0)
                         yield return new WaitForSeconds(A.delay * m_DelayFactor);
                     if (A.message != "")
                     {
                         // TODO: print ingame message
                     }
                     if (A.prefab != null && A.spawnCount > 0)
                     {
                         for(int i = 0; i < A.spawnCount; i++)
                         {
                             // TODO: instantiate A.prefab
                         }
                     }
                 }
                 yield return null;  // prevents crash if all delays are 0
             }
             m_DelayFactor *= difficultyFactor;
             yield return null;  // prevents crash if all delays are 0
         }
     }
     void Start()
     {
         StartCoroutine(SpawnLoop());
     }
 
 }
*/