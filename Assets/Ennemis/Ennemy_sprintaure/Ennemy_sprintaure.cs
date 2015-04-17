using UnityEngine;
using System.Collections;

//sprintaure rapide mais faible

public class Ennemy_sprintaure : Ennemy 
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
