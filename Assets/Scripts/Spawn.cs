using UnityEngine;

using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                        //
//  Pour l'instant, le spawn n'envoi qu'un ennemy à la fois.                              //
//  Il faudrait qu'a termes, il instantie des Vagues, vagues qui se composent d'ennemies  //
//  en fonction du numero_vague                                                           //
//                                                                                        //
////////////////////////////////////////////////////////////////////////////////////////////

public class Spawn : MonoBehaviour
{
    //Informations concernant les vagues à générer
    public List<GameObject> vague1;
    public List<GameObject> vague2;
    public List<GameObject> vague3; 
    public List<GameObject> vague4;
    public List<GameObject> vague5;
    public List<GameObject> vague6;
	public List<GameObject> vague7;
	public List<GameObject> vague8;

    public List<List<GameObject>> vagues;
	
    //Temps pour le spawn
    public float interval;
    public float frequenceSpawnDifferent;
    private float timeLeft;                 //timer spawn ennemi suivante
    public float timerWait;
    private float valueTimerNextWave;             //On stocke la valeur de timerNextWave pour la lui réattribuer quand la vague est finie
    public float timerNextWave;                    //Valeur de temps de la vague suivante
    //Numéro de l'ennemi généré
    private int numero_ennemi;

    //Indique si une vague est terminée
    private bool vagueTerminee = false;

    //Affichage timer next wave
    public Text text_NextWave;

    // destination 
    public Transform destination = null;
    public Transform destiRetour = null;

	public bool new_vague;
    void Start()
    {

        //Initialisation des variables
        vagues = new List<List<GameObject>>(new List<GameObject>[]{vague1, vague2, vague3, vague4, vague5, vague6, vague7,vague8});
        valueTimerNextWave = timerNextWave;
        timeLeft = 0;
        numero_ennemi = 0;
		//StartCoroutine(calcul_new_vague());
    }

	IEnumerator calcul_new_vague ()
	{
		
        yield return new WaitForSeconds(5);
        new_vague = true;
        //StartCoroutine(calcul_new_vague());
	}

    void Update()
    {
        // time to spawn the next one?
        timeLeft -= Time.deltaTime;
        timerNextWave -= Time.deltaTime;
		
        //text_NextWave.text = "New Wave in " + Mathf.Round(timerNextWave).ToString() + " sec";

        //Fréquence de spawn d'un ennemi
        if (timeLeft <= 0.0f && vagueTerminee == false)
        {
            timeLeft = interval;
            SpawnEnnemi();
        }

        if (timerNextWave <= 0.0f)
        {
            vagueTerminee = true;
            new_vague = true;
            timerNextWave = valueTimerNextWave;
        }

        //Déclenche la vague suivante si la vague précédente a fini d'être envoyée en appuyant sur Espace en attendant que les ennemis puissent être tués
        if ((Input.GetKeyDown("space") && vagueTerminee)||new_vague)
        {
            launchNextWave(0);
            //StartCoroutine(calcul_new_vague());
        }
    }

    void SpawnEnnemi()
    {
        GameObject spawner = null;
        
       /*f (numero_ennemi >= frequenceSpawnDifferent)
        {
            spawner = (GameObject)Instantiate(boostaure, transform.position, Quaternion.identity);
            numero_ennemi = 0;
        }
        else
        {
            spawner = (GameObject)Instantiate(ennemy, transform.position, Quaternion.identity);
        }*/

        if(vagues[0].Count > 0)
        {
            spawner = (GameObject)Instantiate(vagues[0][0], transform.position, Quaternion.identity);
            vagues[0].RemoveAt(0);
            if (vagues[0].Count == 0)
            {
                vagues.RemoveAt(0);
                vagueTerminee = true;
            }
        }


        //On attribue le navmesh à l'ennemi créé
        NavMeshAgent nav_ennemy = spawner.GetComponent<NavMeshAgent>();
        //On attribue la destination à l'ennemi créé
        nav_ennemy.destination = destination.position;

		spawner.GetComponent<Ennemy>().start = this.transform.position;

        // numero_enemi%4 --> index de l'ennemi 

        // on incrémente le nombre d'ennemis créés
        numero_ennemi++;
    }

    public void launchNextWave(float pGainY)
    {
        //Artefact_Script.instance.Y += (int)(Mathf.Round(pGainY - (1.0f - timerNextWave)));
        new_vague = false;
        vagueTerminee = false;
        timerNextWave = valueTimerNextWave;
    }

}