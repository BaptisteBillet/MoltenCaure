using UnityEngine;
using System.Collections;
using System.Collections.Generic;

////////////////////////////////////////////////////////////
//                                                        //
//  Cette classe est la classe parent de tout les tours   //
//                                                        //
////////////////////////////////////////////////////////////

public class Tour : MonoBehaviour {

    // Le GameObject representant le tir
    public GameObject prefab_tir;
    // Accès au script du GameObject
    private Tir prefab_tir_script;

    // File d'attente de la tour. Les ennemis qui rentre dans la zone de detection y sont stockés
    List<GameObject> file = new List<GameObject>();

    // Caractéristiques de la tour
    public float cooldown; //Le temps entre deux tirs en secondes
    
    // Si la tour à une attaque en cours
    public bool mode_attaque=false;

    //Si la tour envoi des tirs de zone (true) ou monocible (false)
    public bool aoe;

    public string type;
    public int level;

    public GameObject place_tour;

    void Start()
    {
        //On établi l'accès entre ce script et celui du GameObject prefab_Tir
        prefab_tir_script = (Tir)prefab_tir.GetComponent(typeof(Tir));

        //On vide la file d'attente de la tour, on s'assure qu'elle commence à vide.
        file.Clear();

        //On fait en sorte que la tour n'attaque pas immédiatement
        mode_attaque = false;
    }

    //En cas de detection d'ennemis
    void OnTriggerEnter(Collider ennemy)
    {
        if(ennemy.tag=="ennemy")
        {
            //On ajoute l'ennemi qui est detecté dans la file d'attente de la tour
            file.Add(ennemy.gameObject);
        }
    }

    void OnTriggerExit(Collider ennemy)
    {
        if (ennemy.tag == "ennemy")
        {
            for (int i = 0; i < file.Count;i++ )
            {
                if (file[i] == ennemy.gameObject)
                {
                    file.RemoveAt(i);
                    break;
                }
            }

            //Enleve de la file l'ennemi qui est sorti
            
        }
    }  

    IEnumerator attack()
    {
        while (file.Count > 0) //Tant que la cible est toujours dans la liste
        {
            if (file[0] != null)
            {
                prefab_tir_script = (Tir)prefab_tir.GetComponent(typeof(Tir));


                //Le projectile vise l'ennemie numero 1 (en position zéro dans la liste)
                prefab_tir_script.cible = file[0].gameObject;

                //Le projectile de la TOUR CANON vise l'ennemie numero 1 (en position zéro dans la liste) S'IL n'as pas déjà une destination
                if(prefab_tir_script.GetDestination == false)
                {
                    prefab_tir_script.cibleTirCanon = file[0].transform.position;
                }

                //La tour tir un nouveau projectile
                Instantiate(prefab_tir, transform.position, transform.rotation);

                //Maintenant on attend le couldown avant de relancer un projectile
                yield return new WaitForSeconds(cooldown);
            }
            else
            {
                break;
            }

        }

        if (file.Count > 0) //Si il y a des éléments dans le tableau
        {
            //Normalement à ce stade la cible est morte, juste pour vérifier on fait ce if
            if (file[0] == null) //Si il y n'y a pas d'élément en 1ère position on refresh la liste pour en trouver un
            {
                refresh();
            }
        }else if(file.Count==0) //Si il n'y a plus de cible après celle qui vient de disparaître
        {
            //Alors on indique à la tour qu'elle est à nouveau prête à tirer
            mode_attaque = false;

            //On efface la dernière cible, elle est loin ou détruite
            prefab_tir_script.cible = null;
        }
        yield return null;
       
    }

    void refresh()
    {

        //On efface la dernière cible, elle est loin ou détruite
        prefab_tir_script.cible = null;

        //Met à jour la file d'attente
        for(int i=1;i<file.Count;i++)   //Chaque élément de la liste est pris en compte
        {
            file[i - 1] = file[i];      //On copie l'élément i dans la position d'avant. 
        }
        file[file.Count-1] = null;      //On efface le dernier i

        mode_attaque = false;            //On dit à la tour qu'elle peut prendre une nouvelle cible
    }
   
	// Update is called once per frame
	void Update () 
    {

        if(file.Count>0) //Si il y a des éléments dans le tableau
        {
           
            if(file[0]!=null) //Si il y a un élément en 1ere position ... 
            {
                //La tour vise 
                //   /!\ A améliorer /!\
                transform.LookAt(file[0].transform);

                if(mode_attaque==false) //... et que la tour n'attaque pas encore, on lance une attaque
                {
                    Debug.Log("attaque");
                    //La tour attaque 
                    StartCoroutine(attack());
                    mode_attaque = true;
                }

            }

        }
	}
}
