using UnityEngine;
using System.Collections;

public class Tour_Rafale : Tour
{
    //public float cooldown;
    public void Start()
    {
        //cooldown = 0.3f;
        //Le mode_attaque devrait toujours être en false
        mode_attaque = false;
        aoe = false;
    }
}
