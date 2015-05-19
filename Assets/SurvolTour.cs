using UnityEngine;
using System.Collections;

public class SurvolTour : MonoBehaviour {

    public int layerMaskClic;
   
    
    public Ray rayTour;
    RaycastHit hitTour;
    public bool estSurTour;
    public Tour tour_script;
    public GameObject tour_survolee;

	// Use this for initialization
	void Start () 
    {
	    layerMaskClic = LayerMask.NameToLayer("Tours");
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

            
    }
}
