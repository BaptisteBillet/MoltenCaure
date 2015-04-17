 using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

    public GameObject Panel_place_libre; // Le menu de pose lorsque la tuile est vide
    public GameObject Panel_place_plein; // Menu de pose lorsuze la tuile est pleine
    private GameObject Panel_place;
    public string layerMaskName = "place";
    private int layerMaskClic;

    public bool menu; // Si le menu est affiché
    public bool libre;

    public GameObject Canvas;
    private MainCanvas Canvas_script;

    //ANTO

    private Creation_script tableau_tours;

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

    void Start()
    {
        menu = false;
        libre = true;
        layerMaskClic = LayerMask.NameToLayer(layerMaskName);
        mouseOver = false;
        fusionné = false;
    }

    void MouseOver()
    {
        if (!mouseOver)
        {
            Debug.Log("ok");
            mouseOver = true;
        }
    }

    void MouseExit()
    {
        if(mouseOver)
        {
            mouseOver = false;
            Debug.Log("exit");
        }
        
    }


    int check_nearly(int dir, int i, int j)
    {

        if (j + 1 < 5)
        {

            if (tableau_tours.plateau[i, j + 1] != null && dir == 1) //Si il y a une tour en haut
            {
                Debug.Log("haut");
                return 1;
            }
        }
        if (i + 1 < 5)
        {
            if (tableau_tours.plateau[i + 1, j] != null && dir == 2) //Si il y a une tour à droite
            {
                Debug.Log("droite");
                return 2;
            }
        }
        if (j - 1 >= 0)
        {
            if (tableau_tours.plateau[i, j - 1] != null && dir == 3) //Si il y a une tour en bas
            {
                Debug.Log("bas");
                return 3;
            }
        }
        if (i - 1 >= 0)
        {
            if (tableau_tours.plateau[i - 1, j] != null && dir == 4) //Si il y a une tour à gauche
            {
                Debug.Log("gauche");
                return 4;
            }
        }

        return 0;
    }

    void possibility()
    {

        //On enregistre la proximité de toutes les tours proches de la tour 1

        //HAUT
        if (check_nearly(1, xRow, yCol) == 1 && fusionné == false) //Tour Haut
        {
            //On enregistre les coordonnées de la tour 2
            xRow2 = xRow;
            yCol2 = yCol + 1;

            //On enregistre la proximité de toutes les tours proches de la tour 2
            if (check_nearly(1, xRow2, yCol2) == 1 && fusionné == false) //Tour Haut
            {
                haut = 1;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 + 1;
            }
            if (check_nearly(2, xRow2, yCol2) == 2 && fusionné == false) //Tour Droit
            {
                haut = 2;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 + 1;
                yCol3 = yCol2;
            }

            if (check_nearly(4, xRow2, yCol2) == 4 && fusionné == false) //Tour Gauche
            {
                haut = 4;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 - 1;
                yCol3 = yCol2;
            }

        }
        //DROITE
        if (check_nearly(2, xRow, yCol) == 2 && fusionné == false) //Tour Droite
        {
            //On enregistre les coordonnées de la tour 2
            xRow2 = xRow + 1;
            yCol2 = yCol;

            //On enregistre la proximité de toutes les tours proches de la tour 2
            if (check_nearly(1, xRow2, yCol2) == 1 && fusionné == false) //Tour Haut
            {
                droite = 1;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 + 1;
            }
            if (check_nearly(2, xRow2, yCol2) == 3 && fusionné == false) //Tour Bas
            {
                droite = 3;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 - 1;
            }

            if (check_nearly(4, xRow2, yCol2) == 4 && fusionné == false) //Tour Gauche
            {
                droite = 4;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 - 1;
                yCol3 = yCol2;
            }

        }

        //BAS
        if (check_nearly(3, xRow, yCol) == 3 && fusionné == false) //Tour Bas
        {
            //On enregistre les coordonnées de la tour 2
            xRow2 = xRow;
            yCol2 = yCol - 1;

            //On enregistre la proximité de toutes les tours proches de la tour 2
            if (check_nearly(2, xRow2, yCol2) == 2 && fusionné == false) //Tour Droit
            {
                bas = 2;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 + 1;
                yCol3 = yCol2;
            }

            if (check_nearly(2, xRow2, yCol2) == 3 && fusionné == false) //Tour Bas
            {
                bas = 3;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 - 1;
            }

            if (check_nearly(4, xRow2, yCol2) == 4 && fusionné == false) //Tour Gauche
            {
                bas = 4;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 - 1;
                yCol3 = yCol2;
            }

        }

        //GAUCHE
        if (check_nearly(4, xRow, yCol) == 4 && fusionné == false) //Tour gauche
        {
            //On enregistre les coordonnées de la tour 2
            xRow2 = xRow - 1;
            yCol2 = yCol;

            if (check_nearly(1, xRow2, yCol2) == 1 && fusionné == false) //Tour Haut
            {
                gauche = 1;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 + 1;
            }

            if (check_nearly(2, xRow2, yCol2) == 3 && fusionné == false) //Tour Bas
            {
                gauche = 3;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2;
                yCol3 = yCol2 - 1;
            }

            if (check_nearly(4, xRow2, yCol2) == 4 && fusionné == false) //Tour Gauche
            {
                gauche = 4;
                //On enregistre les coordonnées de la tour 3
                xRow3 = xRow2 - 1;
                yCol3 = yCol2;
            }

        }


    }

    void verification_L()
    {

    }


    Ray ray;
    RaycastHit hit;
    void Update()
    {

         //on crée un ray qui va pointer de la sourie (3d) vers l'infini
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //hit est la variable dans laquelle on stock le collider rencontre

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << layerMaskClic))  //Si on touche quelquechose...          
        {
            if (hit.collider.tag == "place" && hit.collider.gameObject == this.gameObject)
            {
                MouseOver();
                if (Input.GetMouseButtonDown(0) && mouseOver == true)
                {
                    if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && !menu)
                    {
                        if(menu == false && libre == true)   //... Et que cette chose est taggé comme une "place" ...
                        {
                            Canvas = GameObject.FindWithTag("Canvas");
                            Canvas_script = (MainCanvas)Canvas.GetComponent(typeof(MainCanvas));
                            Canvas_script.Place_click = this.gameObject; // On place une copie de l'objet touché (une place) dans la variable gameObject Place_click

                            //On affiche un menu
                            Panel_place = Instantiate(Panel_place_libre) as GameObject; // On instancie l'objet Panel_Place
                            Panel_place.transform.SetParent(MainCanvas.instance.transform, false); // L'instance de Panel_place devient l'enfant du Canvas
                            Panel_place.transform.localPosition = this.gameObject.transform.position; // Le panel instancé prends les valeurs de position du gameObject touché
                            Panel_place.transform.localScale = new Vector3(1, 1, 1);

                            menu = true; //on a ouvert le menu
                        }
                    }
                }
            }
            else
            {
                MouseExit();
            }
        }
        else
        {
            MouseExit();
        }


       
    }

    public void quitter()
    {
        /* NON FONCTIONNEL
        Debug.Log("wtf");
        Destroy(Panel_place.gameObject);
        menu = false;*/
    }
}