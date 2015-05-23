using UnityEngine;
using System.Collections;

public class Tour_Sniper : Tour
{
    //public float cooldown;
    public void Start()
    {
        //cooldown = 2f;
        //Le mode_attaque devrait toujours être en false
        mode_attaque = false;
        aoe = false;
        type = "sniper";
    }
}
