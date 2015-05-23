using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayMenuTour : MonoBehaviour {

    public Text text_display_cout;
    public Pose_tour pose_tour_script;
    public string type_name_tour;

    public GameObject tour;
    //public GameObject tour_Sniper;
    //public GameObject tour_Canon;


    public Tir tour_Rafale_script;
    public Tour_Sniper tour_Sniper_script;
    public Tour_Canon tour_Canon_script;

	// Use this for initialization
	void Start () {
        /*switch(type_name_tour)
        {
            case "rafale":
                tour_Rafale_script = tour.gameObject.GetComponent<Tour_Rafale>().gameObject.GetComponent<Tir>();
                break;

            case "sniper":

                break;

            case "canon":

                break;
        }*/
        pose_tour_script = GetComponentInParent<Pose_tour>();
	}
	
	// Update is called once per frame
	void Update () {
        switch(type_name_tour)
        {
            case "rafale" :
                text_display_cout.text = "COST : " + pose_tour_script.coutRafale.ToString();
                /*+ 
                "ATK : " + tour_Rafale_script.degats + 
                "RATE : " + tour_Rafale_script.delay;*/
            break;

            case "sniper" :
            text_display_cout.text = "COST : " + pose_tour_script.coutSniper.ToString() ;
            break;

            case "canon":
            text_display_cout.text = "COST : " + pose_tour_script.coutCanon.ToString();
            break;
        }
	}
}
