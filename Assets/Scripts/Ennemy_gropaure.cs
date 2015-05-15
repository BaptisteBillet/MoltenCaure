using UnityEngine;
using System.Collections;

//gropaure lent mais résistant

public class Ennemy_gropaure : Ennemy 
{
    public override void Start()
    {
        base.Start();
        vie = 100;
        speed = 2;
    }

}
