using UnityEngine;
using System.Collections;

//sprintaure rapide mais faible

public class Ennemy_sprintaure : Ennemy 
{

    public override void Start()
    {
        base.Start();   // base. permet de récupérer les informations contenues dans le Start du parent car si deux fonctions ont le même nom le script exécute sa fonction et pas celle du parent
		this.nav_ennemy.speed = speed;
    }

}
