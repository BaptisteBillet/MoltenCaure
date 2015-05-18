using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private Ennemy ennemy_script;

    public int life_max;

    private float pixel_pourcentage;

    public GameObject vie;
    public float placement;
public void Start () 
{
    pixel_pourcentage = -0.1f;
    ennemy_script = this.transform.parent.GetComponent<Ennemy>();
    life_max =(int)ennemy_script.vie;
}

public void Update ()
    {
        transform.forward = Camera.main.transform.forward;
        placement = ((((int)ennemy_script.vie* 100) / life_max) * pixel_pourcentage)+10;
        if (placement < 0.000001) { placement = 0; }
        vie.transform.localPosition = new Vector3(placement*-1, 0, 0);
		vie.transform.eulerAngles = new Vector3(35.0f, 0f, 0f);
    }



}
  
