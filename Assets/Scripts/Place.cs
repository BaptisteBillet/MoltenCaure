 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Place : MonoBehaviour {

    public GameObject Panel_place_prefab; // Le menu de pose
    private GameObject Panel_place;
    public string layerMaskName = "place";
    private int layerMaskClic;

    public bool libre;//Si la place n'as pas de tour (true);
    //public bool menu; // Si le menu est affiché

    public GameObject Canvas;
    private MainCanvas Canvas_script;
    
    /*public GameObject Panel;
    private MainCanvas Panel_script; */

    public MainCanvas Panel_place_libre;

    //ANTO
    Color couleur;

    Renderer renderer;
    Material material;
    public Creation_script creation_script;

    //La tour 1
    public int xRow;
    public int yCol;

    public int haut;
    public int gauche;
    public int bas;
    public int droite;

    //La Tour 2
    private int xRow2;
    private int yCol2;

    //La Tour 3
    private int xRow3;
    private int yCol3;
    //

    private bool mouseOver;
    private bool fusionné;



    //

    //UI
    public GameObject panelUI;

    void Start()
    {

        material = this.GetComponent<Renderer>().material;
        libre = true;
        //menu = false;
        layerMaskClic = LayerMask.NameToLayer(layerMaskName);
        mouseOver = true;
        fusionné = false;
        couleur = gameObject.GetComponent<Renderer>().material.color;
        couleur.a = 0.05f;
        material.color = couleur;
    }

    void OnMouseOver()
    {
        if (mouseOver == true)
        {
            //Debug.Log(xRow + " " + yCol + " " + libre);
            couleur.a = 0.3f;
            material.color = couleur;
            mouseOver = false;
        }
    }

    void OnMouseExit()
    {
        mouseOver = true;
        couleur.a = 0.05f;
        material.color = couleur;
    }


    int check_nearly(int dir, int i, int j)
    {

       
        if (j + 1 < 5)
        {

            if (creation_script.plateau[i, j + 1] != null && dir == 1) //Si il y a une tour en haut
            {
                Debug.Log("haut");
                return 1;
            }
        }
        if (i + 1 < 5)
        {
            if (creation_script.plateau[i + 1, j] != null && dir == 2) //Si il y a une tour à droite
            {
                Debug.Log("droite");
                return 2;
            }
        }
        if (j - 1 >= 0)
        {
            if (creation_script.plateau[i, j - 1] != null && dir == 3) //Si il y a une tour en bas
            {
                Debug.Log("bas");
                return 3;
            }
        }
        if (i - 1 >= 0)
        {
            if (creation_script.plateau[i - 1, j] != null && dir == 4) //Si il y a une tour à gauche
            {
                Debug.Log("gauche");
                return 4;
            }
        }

        return 0;
    }

    void verification_L()
    {

    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //on crée un ray qui va pointer de la sourie (3d) vers l'infini
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //hit est la variable dans laquelle on stock le collider rencontré
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))  //Si on touche quelquechose...          
            {
                if (hit.collider.tag == "place" && hit.collider.gameObject == this.gameObject && libre == true)   //... Et que cette chose est taggée comme une "place" ...
                {
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        Canvas = GameObject.FindWithTag("Canvas");
                        Canvas_script = (MainCanvas)Canvas.GetComponent(typeof(MainCanvas));
                        Canvas_script.Place_click = this.gameObject; // On place une copie de l'objet touché (une place) dans la variable gameObject Place_click
                        panelUI.GetComponent<Pose_tour>().place_script = this;
						panelUI.GetComponent<Pose_tour>().place_touch = this.gameObject;
                        panelUI.SetActive(true);
                        /*Panel = GameObject.FindWithTag("Canvas");
                        Panel_script = (MainCanvas)Panel.GetComponent(typeof(MainCanvas));
                        Panel_script.("Anim_Button_Canon");*/
                        Vector3 vecPozUI = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                        panelUI.transform.position = Camera.main.WorldToScreenPoint(vecPozUI);
                        libre = false;
                    }
                    /*Canvas = GameObject.FindWithTag("Canvas");
                    Canvas_script = (MainCanvas)Canvas.GetComponent(typeof(MainCanvas));
                    Canvas_script.Place_click = this.gameObject;

                    //On affiche un menu
                    Panel_place = Instantiate(Panel_place_prefab) as GameObject; // On instancie l'objet Panel_Place
                    Panel_place.transform.SetParent(MainCanvas.instance.transform, false); // L'instance de Panel_place devient l'enfant du Canvas
                    Panel_place.transform.localPosition = this.gameObject.transform.position; // Le panel instancé prend les valeurs de position du gameobject touché
                    Panel_place.transform.localScale = new Vector3(1, 1, 1);

                    Panel_place.GetComponent<Pose_tour>().place_script = this;

                    menu = true; //on a ouvert le menu
                    */
                }
                else if (hit.collider.tag != "place" && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    panelUI.gameObject.SetActive(false);
                }
            }
        }
    }
}