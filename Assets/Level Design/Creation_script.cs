using UnityEngine;
using System.Collections;

public class Creation_script : MonoBehaviour
{

    public GameObject[,] plateau= new GameObject[18,13]; 
    public GameObject place_prefab;
    private GameObject place;

    public static bool menu; // Si le menu est affiché
    //public GameObject chemin_prefab;
    //private GameObject chemin;
    
    public int ROW ;
    public int COL ;
    public float marge;

    private Place place_script;
    
    /*public enum ETATCASE {
		VIDE,
		TOUR,
		CHEMIN,
		BONUS
	}*/

	// Use this for initialization
	void Start () 
    {
        //chemin = Instantiate(chemin_prefab) as GameObject;//On instancie le chemin sur lequel se déplacent les ennemis


        ROW = 18;
        COL = 13;

        plateau = new GameObject[ROW, COL];                     //On créé un tableau dans lequel on stocke les dalles 
        marge = 4f;                                          //La marge permet d'avoir un décallage entre chaque dalle




        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {

                //GameObject dalle = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                place = Instantiate(place_prefab) as GameObject;
                place.transform.SetParent(this.gameObject.transform, false);
                place_script = (Place)place.GetComponent(typeof(Place));    //On attribue le script de dalle à la variable dalle_script pour accéder et modifier les variables locales
               
                place_script.xRow = i;      //On attribue les valeurs i et j à la dalle pour conserver son emplacement
                place_script.yCol = j;

                place.transform.position = new Vector3(transform.position.x + i + (i * marge), 0, transform.position.z+j + (j * marge));     //On place la dalle dans l'espace par rapport aux valeurs i et j

                //dalle.AddComponent<Rigidbody>();  
            }
        }

	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
