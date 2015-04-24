using UnityEngine;
using System.Collections;

//Mordaures sèment derrière eux une traînée de particules noires, ce qui empêche le joueur de voir les ennemis cachés dans le nuage. 
//Les particules se dissipent après quelques secondes, le joueur se retrouve alors dans une situation instable car il n’est pas en mesure d’appréhender la quantité d’ennemis qui se suivent les Mordaures,
//malgré le fait que ses tours continuent à les attaquer.

public class Ennemy_mordaure : Ennemy
{

    public GameObject particule;
    private GameObject particule_instance;

    public override void Start()
    {
        StartCoroutine(fog());
    }
    IEnumerator fog()
    {
        while(this.gameObject)
        {
            particule_instance = Instantiate(particule,this.transform.position,this.transform.rotation) as GameObject;
            yield return new WaitForSeconds(.001f);
        }
           

    }
}