using UnityEngine;
using System.Collections;

public class Tour_Amelioration : MonoBehaviour {

    Tour tour;
    private GameObject canvas;
    int layerMaskClic;
    //public bool pasAmelioree;

	// Use this for initialization
	void Start () {
        layerMaskClic = LayerMask.NameToLayer("Tours");
        tour = this.transform.parent.GetComponent<Tour>();
        //pasAmelioree = true;
	}
	
	// Update is called once per frame
	void Update () {
        //
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskClic))
            {

                

                if (hit.collider.gameObject == this.gameObject/* && level == 3*/)        //Il faudra ajouter une vérification concernant une éventelle amélioration déjà posée
                {
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        
                        tour.Canvas = GameObject.FindWithTag("Canvas");
                        tour.Canvas_script= (MainCanvas)tour.Canvas.GetComponent(typeof(MainCanvas));
                        tour.Canvas_script.Tour_Click = tour.gameObject; // On place une copie de l'objet touché (une place) dans la variable gameObject Place_click
                        tour.panelAmelio.GetComponent<Pose_Amelio>().tour_script = tour;
                        tour.panelAmelio.GetComponent<Pose_Amelio>().tour_touch = tour.gameObject;
                        tour.panelAmelio.SetActive(true);
                        Vector3 vecPozUIAmelio = new Vector3(tour.transform.position.x, tour.transform.position.y, tour.transform.position.z);
                        tour.panelAmelio.transform.position = Camera.main.WorldToScreenPoint(vecPozUIAmelio);

                    }
                }
                else if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (tour.panelAmelio != null)
                    {
                        tour.panelAmelio.gameObject.SetActive(false);
                    }
                }
            }
        }
        //
	}
}
