using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pose_Amelio : MonoBehaviour {

    private MainCanvas cible_script;        //On accède au script qui contient la cible du clic, à savoir la tour
    public Tour tour_script;                //On accède au script de la Tour
    public GameObject tour_touch;           //On accède à la Tour touchée

    public int coutPoison;
    public int coutGel;
    public int coutRadiation;

	public void Poison()
	{
		if (Artefact_Script.instance.Y >= coutPoison)
        {
            Artefact_Script.instance.DepenseY(coutPoison);
            tour_script = tour_touch.GetComponent<Tour>();
            tour_script.IsPoison = true;
            this.gameObject.SetActive(false);
        }
	}
	public void Gel()
	{
		if(Artefact_Script.instance.Y >= coutGel)
        {
            Artefact_Script.instance.DepenseY(coutGel);
            tour_script = tour_touch.GetComponent<Tour>();
            tour_script.IsGel = true;
            this.gameObject.SetActive(false);
        }
	}
	public void Radiation()
	{
        if (Artefact_Script.instance.Y >= coutRadiation)
        {
            Artefact_Script.instance.DepenseY(coutRadiation);
            tour_script = tour_touch.GetComponent<Tour>();
            tour_script.IsRadiation = true;
            this.gameObject.SetActive(false);
        }
	}



    public void quitter()
    {
        //tour_touch.GetComponent<Tour>. BOOL AMELIORATION POSEE Dire que la tour peut être améliorée
        this.gameObject.SetActive(false);
    }

    //AJOUTER LES DIFFERENTES FONCTIONS DES DIFFERENTS BOUTONS POUR LES DIFFERENTES AMELIORATIONS
	

}
