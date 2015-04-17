using UnityEngine;
using System.Collections;

public class Pose_tour : MonoBehaviour {
    public GameObject tour_rafale;
    public GameObject tour_sniper;
    public GameObject tour_canon;

    private MainCanvas cible_script;
    private Place place_script;


    public void sniper()
    {
        Debug.Log("sniper");
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));
        
        tour_sniper = Instantiate(tour_sniper) as GameObject;
        tour_sniper.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);
        
        place_script = (Place)cible_script.Place_click.GetComponent(typeof(Place)); // On donne à la tour les coordonnées du gameObject Place touché par le raycast dans la classe Place
        place_script.libre = false; // La place sur laquelle vient d'être déposée la tour est considérée comme pleine

        Destroy(this.gameObject);

    }
    public void rafale()
    {
        Debug.Log("rafale");

        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));

        tour_rafale = Instantiate(tour_rafale) as GameObject;
        tour_rafale.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);

        place_script = (Place)cible_script.Place_click.GetComponent(typeof(Place));
        place_script.libre = false;

        Destroy(this.gameObject);
        
    }
    public void canon()
    {
        Debug.Log("canon");
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));

        tour_canon = Instantiate(tour_canon) as GameObject;
        tour_canon.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);

        place_script = (Place)cible_script.Place_click.GetComponent(typeof(Place));
        place_script.libre = false;

        Destroy(this.gameObject);
    }
}
