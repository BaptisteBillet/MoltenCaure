using UnityEngine;
using System.Collections;

//gropaure lent mais résistant

public class Ennemy_gropaure : Ennemy 
{
    public override void Start()
    {
        base.Start();
		this.nav_ennemy.speed = speed;
    }

}
