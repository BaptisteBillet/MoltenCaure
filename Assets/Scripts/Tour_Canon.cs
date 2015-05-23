using UnityEngine;
using System.Collections;


public class Tour_Canon : Tour
{
    //public float cooldown;
    public void Start()
    {
        //cooldown = 1.5f;
        //Le mode_attaque devrait toujours être en false
        mode_attaque = false;
        aoe = false;
        type = "canon";
    }
}
