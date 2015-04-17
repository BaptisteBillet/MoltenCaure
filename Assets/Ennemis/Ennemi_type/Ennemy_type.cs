using UnityEngine;
using System.Collections;

//Ceci est un ennemy_type

public class Ennemy_type : Ennemy 
{

    void Start()
    {
       base.Start();

       myNavMeshAgent.speed = 5;
        
       
        vie = 100;

        if (vie <= 0)
        {
            RessourcesManager.ressourceX++;
        }
    }
}
