using UnityEngine;
using System.Collections;

public class SurvolTour : MonoBehaviour {

    public int layerMaskClic;
    public int layerMaskClic2;
   
    
    public Ray rayTour;
    RaycastHit hitTour;
    RaycastHit hitPlace;
    public bool estSurTour;
    public Tour tour_script;
    public GameObject tour_survolee;

    public bool estSurvolee;
    public Place place_script;
    public GameObject place_survolee;

	// Use this for initialization
	void Start () 
    {
	    layerMaskClic = LayerMask.NameToLayer("Tours");
        layerMaskClic2 = LayerMask.NameToLayer("Default");
        Debug.Log(layerMaskClic2);
	}
	
	// Update is called once per frame
	void Update () 
    {
        rayTour = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayTour, out hitTour, Mathf.Infinity, layerMaskClic))
         {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if(hitTour.collider.tag != "hitboxtour")
                {
                    estSurTour = false;
                    if(tour_survolee != null)
                    {
                        tour_script.survolTourOut();
                        tour_survolee = null;
                        
                    }
                }

                if (hitTour.collider.tag == "hitboxtour" && estSurTour == false)
                {
                    //Debug.DrawRay(this.transform.position, hitTour.transform.position, Color.yellow);

                    tour_script = hitTour.collider.transform.parent.GetComponent<Tour>();
                    tour_script.survolTourOn();
                    tour_survolee = tour_script.gameObject;
                    estSurTour = true;
                    
                    //Debug.Log(hitTour.transform.name);
                }
            }
        }
        
        if(Physics.Raycast(rayTour, out hitPlace, Mathf.Infinity, layerMaskClic2))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (hitPlace.collider.tag == "place" && estSurvolee == false)
                {
                    Debug.Log("mmmlol");
                    //Debug.DrawRay(this.transform.position, hitTour.transform.position, Color.yellow);

                    place_script = hitPlace.collider.transform.parent.GetComponent<Place>();
                    place_script.OnSurvolTourOn();
                    place_survolee = place_script.gameObject;
                    estSurvolee = true;
                    
                    //Debug.Log(hitTour.transform.name);
                }

                if (hitPlace.collider.tag != "place")
                {
                    estSurvolee = false;
                    if(place_survolee != null)
                    {
                        place_script.OnSurvolTourOut();
                        place_survolee = null;
                        
                    }
                }


            }
        }
            
    }
}
