using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//////////////////////////////////////////////////////////
//                                                      //
//  Cette classe est la classe parent de tout les tirs  //
//                                                      //
//////////////////////////////////////////////////////////

public class Tir : MonoBehaviour {

    // La cible fournit par la Tour
    public GameObject cible;

    // La cible fournit par la Tour Canon
    public Vector3 cibleTirCanon; 

    // On accède au script de la cible
    private Ennemy cible_script;

    //Delay de tir
    public float delay;

    //Les dégâts qu'inflige ce tir
    public int degats;

    //L'accélération de la tour
    public float acceleration;

    //Le tir de la TOUR CANON sait où se diriger
    public bool GetDestination;

    // File d'attente de la tour. Les ennemis qui rentre dans la zone de detection y sont stockés
    List<GameObject> file = new List<GameObject>();

    public bool canon;
    public bool canon_explose;

    public float temps_explosion_canon;

    void Start()
    {
        if(canon)
        {
            cibleTirCanon = cible.transform.position;
        }
        else
        {
            cibleTirCanon = Vector3.zero;
        }

        //On vide la file d'attente de la tour, on s'assure qu'elle commence à vide.
        file.Clear();
    }


    void OnTriggerExit(Collider ennemy)
    {
        if (ennemy.tag == "ennemy")
        {
            for (int i = 0; i < file.Count; i++)
            {
                if (file[i] == ennemy.gameObject)
                {
                    file.RemoveAt(i);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter(Collider touch)
    {
        if(canon==true)
        {
            if (touch.tag == "ennemy")
            {
                //On ajoute l'ennemi qui est detecté dans la file d'attente de la tour
                file.Add(touch.gameObject);
            }
        }
        else
        {
            if (touch.gameObject == cible) //Si la chose que le projectile à touché est bien la cible
            {

                //On établi l'accès entre ce script et celui du GameObject cible
                cible_script = (Ennemy)cible.GetComponent(typeof(Ennemy));

                //On applique les dégâts à la cible
                cible_script.vie -= degats;

                //Le tir se détruit à l'impact
                Destroy(this.gameObject);
            }
        }

    }

    IEnumerator tir_canon()
    {

        yield return new WaitForSeconds(temps_explosion_canon);
        for (int i = 0; i < file.Count; i++) // Pour chaque ennemis dans la liste, lui infligé les dégats du tir
        {
            cible_script = file[i].GetComponent<Ennemy>();
            cible_script.vie -= degats;
            Debug.Log("Explosion_canon");
        }

        Destroy(this.gameObject); //on détruit cet objet, il n'a plus d'utilité


    }


	// Update is called once per frame
	void Update () 
    {
        if (cibleTirCanon != null)
        {
            GetDestination = true;
        }

        if (canon==true) //Si le tir provient de la tour canon
        {
            transform.position = Vector3.Lerp(transform.position, cibleTirCanon, delay * Time.deltaTime * acceleration); // Celui ci se déplace vers une coordonnée mais pas vers un ennemis
            if (this.transform.position == cibleTirCanon && canon_explose==false) // Une fois le tir arrivé au coordonées
            {
                canon_explose = true;
                StartCoroutine(tir_canon());
                
            }
        }
        else
        {
            if (cible != null) //Si la cible existe 
            {
                //On se déplace vers la cible
                transform.position = Vector3.Lerp(transform.position, cible.transform.position, delay * Time.deltaTime * acceleration);
                //On la regarde en avançant
                transform.LookAt(cible.transform);
            }
            else //Si la cible est détruite et que le tir est déjà lancé
            {
                Destroy(this.gameObject); //on détruit cet objet, il n'a plus d'utilité
            }
        }

        

	}
}
