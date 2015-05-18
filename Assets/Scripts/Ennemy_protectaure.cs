using UnityEngine;
using System.Collections;

//visés en priorité par les Tours dès qu’ils sont à leur portée

public class Ennemy_protectaure : Ennemy 
{

	public override void Start()
    {
		base.Start();
		this.nav_ennemy.speed = speed;
    }


}
