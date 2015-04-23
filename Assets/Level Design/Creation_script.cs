using UnityEngine;
using System.Collections;

public class Creation_script : MonoBehaviour
{

    public GameObject[,] plateau= new GameObject[29,9];
    public Tour[,] plateauTour = new Tour[29, 9]; 
    public GameObject place_prefab;
    private GameObject place;

    //public GameObject chemin_prefab;
    //private GameObject chemin;
    
    public int ROW ;
    public int COL ;
    public float marge;

    private Place place_script;
    public GameObject UIpanel;

    /*public enum ETATCASE {
		VIDE,
		TOUR,
		CHEMIN,
		BONUS
	}*/

	// Use this for initialization
	void Start () 
    {
        //Elie
        UIpanel.SetActive(false);

        //chemin = Instantiate(chemin_prefab) as GameObject;//On instancie le chemin sur lequel se déplacent les ennemis


        ROW = 29;
        COL = 9;

        plateau = new GameObject[ROW, COL];                     //On créé un tableau dans lequel on stocke les dalles 
        plateauTour = new Tour[ROW, COL];
        marge = 4f;                                          //La marge permet d'avoir un décallage entre chaque dalle




        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {

                //GameObject dalle = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                place = Instantiate(place_prefab) as GameObject;
                place.GetComponent<Place>().panelUI = UIpanel; //Elie DID THAT BIATCH
                place.transform.SetParent(this.gameObject.transform, false);
                place_script = (Place)place.GetComponent(typeof(Place));    //On attribue le script de dalle à la variable dalle_script pour accéder et modifier les variables locales
               
                place_script.xRow = i;      //On attribue les valeurs i et j à la dalle pour conserver son emplacement
                place_script.yCol = j;
                place_script.creation_script = this;

                place.transform.position = new Vector3(transform.position.x + i + (i * marge), 0, transform.position.z+j + (j * marge));     //On place la dalle dans l'espace par rapport aux valeurs i et j

                plateau[i, j] = place;
                //dalle.AddComponent<Rigidbody>();  
            }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
