using UnityEngine;
using System.Collections;

//  Cette tour type est le modele d'une tour standard


public class Tour_type : Tour {

    void Start()
    {
        cooldown = 1;
        //Le mode_attaque devrait toujours être en false
        mode_attaque = false;
        aoe = false;
    }


}
