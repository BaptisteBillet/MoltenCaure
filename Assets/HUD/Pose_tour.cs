using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pose_tour : MonoBehaviour {
    public GameObject[] tour_rafale;           //Chaque gameobject a un tableau pour renseigner le niveau de la tour en question
    public GameObject[] tour_sniper;
    public GameObject[] tour_canon;
    public GameObject tour_L;

    //Quand y aura plusieurs niveaux :
    //public GameObject[] tour_rafale;
    //Quand on instancie la tour on note : tour_rafale[level-1]

    private MainCanvas cible_script;
    public Place place_script;

    public void quitter()
    {
        this.gameObject.SetActive(false);
    }

    public void sniper()            //Se produit lorsqu'on clique sur le bouton de pose de tour Sniper
    {
        createTourSniper(1);        //On lance la fonction de création de tour Sniper de niveau 1
        Destroy(this.gameObject);   //On détruit l'interface du menu car la tour est en cours de création
    }

    public void createTourSniper(int level)         //Cette fonction permet de créer une tour Sniper d'un niveau dépendant de s'il y a eu une fusion avant son exécution ou non.
    {
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));
        GameObject nouvelleTour_sniper = Instantiate(tour_sniper[level-1]) as GameObject;       //On crée la tour Sniper contenue dans le tableau à la case level-1 (pour correspondre au tableau qui commence à 0)
        nouvelleTour_sniper.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);   //On place la tour aux coordonnées de la tuile cliquée

        Tour nouvelleTour = nouvelleTour_sniper.GetComponent<Tour>();                   //On crée un gameobject dans lequel on met la tour que l'on a crée juste avant
        nouvelleTour.type = "sniper";                                                   //On attribue le type Sniper à la tour que l'on vient de créer
        nouvelleTour.level = level;                                                     //On attribue un niveau à la tour que l'on vient juste de créer à partir. Ce niveau dépend de s'il y a eu une fusion ou non
        place_script.                       creation_script.                        plateauTour[place_script.xRow, place_script.yCol] = nouvelleTour;
        //On accède au script de la tuile PUIS au script de la création du plateau (où sont les variables de positions des tuiles et des tours) PUIS à la position des tours pour attribuer les coordonnées de la nouvelle tour
        
        if (!(level >= 3))          //Si le niveau de la tour créée n'est pas supérieur ou égal au niveau maximum alors on vérifie si une fusion est possible
        {
            checkFusionSup(nouvelleTour, "sniper", level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }
        else if (level == 3)    //Si la tour créée est de niveau maximum on vérifie si une fusion est possible avec d'autres tours différentes et de niveau maximum
        {
            checkFusionSupL(nouvelleTour, level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }

        nouvelleTour.place_tour = place_script.gameObject;

        this.gameObject.SetActive(false);   //Désactive le panel après que tous les tests de fusion aient été effectués
    }

    public void rafale()            //Se produit lorsqu'on clique sur le bouton de pose de tour Rafale
    {
        createTourRafale(1);        //On lance la fonction de création de tour Rafale de niveau 1
        Destroy(this.gameObject);   //On détruit l'interface du menu car la tour est en cours de création
    }

    public void createTourRafale(int level)         //Cette fonction permet de créer une tour Rafale d'un niveau dépendant de s'il y a eu une fusion avant son exécution ou non.
    {
        Debug.Log("tour rafale posée");
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));
        Debug.Log(level);
        Debug.Log(tour_rafale[level - 1]);
        GameObject nouvelleTour_rafale = Instantiate(tour_rafale[level - 1]) as GameObject;       //On crée la tour Rafale contenue dans le tableau à la case level-1 (pour correspondre au tableau qui commence à 0)
        
        nouvelleTour_rafale.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);   //On place la tour aux coordonnées de la tuile cliquée

        Tour nouvelleTour = nouvelleTour_rafale.GetComponent<Tour>();                   //On crée un gameobject dans lequel on met la tour que l'on a crée juste avant
        nouvelleTour.type = "rafale";                                                   //On attribue le type Rafale à la tour que l'on vient de créer
        nouvelleTour.level = level;                                                     //On attribue un niveau à la tour que l'on vient juste de créer à partir. Ce niveau dépend de s'il y a eu une fusion ou non
        place_script.creation_script.plateauTour[place_script.xRow, place_script.yCol] = nouvelleTour;
        //On accède au script de la tuile PUIS au script de la création du plateau (où sont les variables de positions des tuiles et des tours) PUIS à la position des tours pour attribuer les coordonnées de la nouvelle tour

        if (!(level >= 3))          //Si le niveau de la tour créée n'est pas supérieur ou égal au niveau maximum alors on vérifie si une fusion est possible
        {
            checkFusionSup(nouvelleTour, "rafale", level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }
        else if (level == 3)    //Si la tour créée est de niveau maximum on vérifie si une fusion est possible avec d'autres tours différentes et de niveau maximum
        {
            checkFusionSupL(nouvelleTour, level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }
        Debug.Log(nouvelleTour);
        //nouvelleTour.place_tour = place_script.gameObject;
        this.gameObject.SetActive(false);
    }

    public void canon()
    {
        createTourCanon(1);        //On lance la fonction de création de tour Canon de niveau 1
        Destroy(this.gameObject);   //On détruit l'interface du menu car la tour est en cours de création
    }

    public void createTourCanon(int level)         //Cette fonction permet de créer une tour Canon d'un niveau dépendant de s'il y a eu une fusion avant son exécution ou non.
    {
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));
        GameObject nouvelleTour_canon = Instantiate(tour_canon[level - 1]) as GameObject;       //On crée la tour Canon contenue dans le tableau à la case level-1 (pour correspondre au tableau qui commence à 0)
        nouvelleTour_canon.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);   //On place la tour aux coordonnées de la tuile cliquée

        Tour nouvelleTour = nouvelleTour_canon.GetComponent<Tour>();                   //On crée un gameobject dans lequel on met la tour que l'on a crée juste avant
        nouvelleTour.type = "canon";                                                   //On attribue le type Canon à la tour que l'on vient de créer
        nouvelleTour.level = level;                                                     //On attribue un niveau à la tour que l'on vient juste de créer à partir. Ce niveau dépend de s'il y a eu une fusion ou non
        place_script.creation_script.plateauTour[place_script.xRow, place_script.yCol] = nouvelleTour;
        //On accède au script de la tuile PUIS au script de la création du plateau (où sont les variables de positions des tuiles et des tours) PUIS à la position des tours pour attribuer les coordonnées de la nouvelle tour

        if (!(level >= 3))          //Si le niveau de la tour créée n'est pas supérieur ou égal au niveau maximum alors on vérifie si une fusion est possible
        {
            checkFusionSup(nouvelleTour, "canon", level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }
        else if (level == 3)    //Si la tour créée est de niveau maximum on vérifie si une fusion est possible avec d'autres tours différentes et de niveau maximum
        {
            checkFusionSupL(nouvelleTour, level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }
        //nouvelleTour.place_tour = place_script.gameObject;
        this.gameObject.SetActive(false);
    }

    public void checkFusionSup(Tour nouvelleTour, string typeDeTour, int level)         //On vérifie s'il est possible de fusionner une tour nouvelleTour avec des tours de son typeDeTour et de son Level
    {
        List<Tour> tourTrouves = new List<Tour>();      //Comme on va effectuer ce test pour chaque tour détectée pendant le test, on stocke chaque tour valide à la fusion dans une liste pour savoir combien de tours on doit supprimer à la fin du test
        tourTrouves.Add(nouvelleTour);                  //On commence par ajouter la tour qui vient d'être posée car c'est à partir de sa position que l'on teste si d'autres tours similaires sont présentes

        checkFusion(ref tourTrouves, place_script.xRow, place_script.yCol, typeDeTour, level);      //On lance la fonction qui teste si des tours similaires sont présentes autour de la tour qui vient d'être posée

        if (tourTrouves.Count >= 3)                     //Si on a trouvé au moins 3 tours similaires alors on peut effectuer une fusion
        {
            Debug.Log("tour Fusionnée !");
            foreach(Tour tour in tourTrouves)           //Pour chaque tour que l'on a trouvé, on effectue une action
            {
                //tour.place_tour.GetComponent<Place>().libre = true; //La place sur laquelle était posée la tour redevient vide
                DestroyImmediate(tour.gameObject);      //On détruit immédiatement (pour ne pas gêner la détection des autres tours) chaque tour trouvée lors du test de fusion
                            
            }
            level++;                                    //On incrémente le niveau de la tour qui a été posée (puis détruite) pour en créer une autre de niveau supérieur
            switch(typeDeTour)                          //On crée une nouvelle tour d'un type correspondant aux tours fusionnées qui ont été détruites
            {
                case "sniper":                          //Si la tour était du type Sniper, on lance la fonction de création de tour avec cette fois-ci un niveau supplémentaire
                    createTourSniper(level);
                    break;
                case "rafale":
                    createTourRafale(level);
                    break;
                case "canon":
                    createTourCanon(level);
                    break;
            }
        }
    }



    public void checkFusion(ref List<Tour> tourTrouves, int x, int y, string typeDeTour, int level)     //Cette fusion vérifie s'il y a des tours similaires sur les cases adjacentes à la tour concernée
    {
        int Row = place_script.creation_script.ROW;
        int Col = place_script.creation_script.COL;
        Tour tourDroite = null;
        Tour tourGauche = null;
        Tour tourHaut = null;
        Tour tourBas = null;

        if (x + 1 < Row)
        {
            tourDroite = place_script.creation_script.plateauTour[x + 1, y];            //Correspond à la tour potentiellement présente sur la case à droite de la tour concernée
        }

        if (x - 1 > 0)
        {
            tourGauche = place_script.creation_script.plateauTour[x - 1, y];           //Correspond à la tour potentiellement présente sur la case à gauche de la tour concernée
        }
        
        if (y - 1 > 0)
        {
            tourHaut = place_script.creation_script.plateauTour[x, y - 1];             //Correspond à la tour potentiellement présente sur la case au dessus de la tour concernée
        }

        if (y + 1 < Col)
        {
            tourBas = place_script.creation_script.plateauTour[x, y + 1];              //Correspond à la tour potentiellement présente sur la case en dessous de la tour concernée
        }
        

        if (tourDroite && tourDroite.type == typeDeTour && tourDroite.level == level)       //Si il y a une tour dans la case à droite de la tour concernée et qu'elle est de même niveau
        {
            if(tourTrouves.Contains(tourDroite) == false)       //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourDroite);                    //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusion(ref tourTrouves, x + 1, y, typeDeTour, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée à droite de la tour concernée
            }
        }
        if (tourGauche != null && tourGauche.type == typeDeTour && tourGauche.level == level)       //Si il y a une tour dans la case à gauche de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourGauche) == false)      //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourGauche);                    //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusion(ref tourTrouves, x - 1, y, typeDeTour, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée à gauche de la tour concernée
            }
        }
        if (tourBas != null && tourBas.type == typeDeTour && tourBas.level == level)                //Si il y a une tour dans la case en dessous de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourBas) == false)         //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourBas);                       //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusion(ref tourTrouves, x, y + 1, typeDeTour, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée en dessous de la tour concernée
            }
        }
        if (tourHaut != null && tourHaut.type == typeDeTour && tourHaut.level == level)             //Si il y a une tour dans la case au dessus de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourHaut) == false)        //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourHaut);                      //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusion(ref tourTrouves, x, y - 1, typeDeTour, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée au dessus de la tour concernée
            }
        }
    }



    public void checkFusionSupL(Tour nouvelleTour, int level)         //On vérifie s'il est possible de fusionner une tour nouvelleTour avec des tours de son typeDeTour et de son Level
    {
        List<Tour> tourTrouves = new List<Tour>();      //Comme on va effectuer ce test pour chaque tour détectée pendant le test, on stocke chaque tour valide à la fusion dans une liste pour savoir combien de tours on doit supprimer à la fin du test
        tourTrouves.Add(nouvelleTour);                  //On commence par ajouter la tour qui vient d'être posée car c'est à partir de sa position que l'on teste si d'autres tours similaires sont présentes

        checkFusionL(ref tourTrouves, place_script.xRow, place_script.yCol, level);      //On lance la fonction qui teste si des tours similaires sont présentes autour de la tour qui vient d'être posée

        if (tourTrouves.Count >= 3)                     //Si on a trouvé au moins 3 tours similaires alors on peut effectuer une fusion
        {
            Debug.Log("tour L CREEE !");
            foreach (Tour tour in tourTrouves)           //Pour chaque tour que l'on a trouvé, on effectue une action
            {
                DestroyImmediate(tour.gameObject);      //On détruit immédiatement (pour ne pas gêner la détection des autres tours) chaque tour trouvée lors du test de fusion
            }                                   
            createTourL();
        }
    }


    public void checkFusionL(ref List<Tour> tourTrouves, int x, int y, int level)     //Cette fusion vérifie s'il y a des tours similaires sur les cases adjacentes à la tour concernée
    {
        int Row = place_script.creation_script.ROW;
        int Col = place_script.creation_script.COL;
        Tour tourDroite = null;
        Tour tourGauche = null;
        Tour tourHaut = null;
        Tour tourBas = null;

        if (x + 1 < Row)
        {
            tourDroite = place_script.creation_script.plateauTour[x + 1, y];            //Correspond à la tour potentiellement présente sur la case à droite de la tour concernée
        }

        if (x - 1 > 0)
        {
            tourGauche = place_script.creation_script.plateauTour[x - 1, y];           //Correspond à la tour potentiellement présente sur la case à gauche de la tour concernée
        }

        if (y - 1 > 0)
        {
            tourHaut = place_script.creation_script.plateauTour[x, y - 1];             //Correspond à la tour potentiellement présente sur la case au dessus de la tour concernée
        }

        if (y + 1 < Col)
        {
            tourBas = place_script.creation_script.plateauTour[x, y + 1];              //Correspond à la tour potentiellement présente sur la case en dessous de la tour concernée
        }


        if (tourDroite && tourDroite.level == level)       //Si il y a une tour dans la case à droite de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourDroite) == false)       //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourDroite);                    //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusionL(ref tourTrouves, x + 1, y, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée à droite de la tour concernée
            }
        }
        if (tourGauche != null && tourGauche.level == level)       //Si il y a une tour dans la case à gauche de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourGauche) == false)      //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourGauche);                    //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusionL(ref tourTrouves, x - 1, y, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée à gauche de la tour concernée
            }
        }
        if (tourBas != null  && tourBas.level == level)                //Si il y a une tour dans la case en dessous de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourBas) == false)         //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourBas);                       //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusionL(ref tourTrouves, x, y + 1, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée en dessous de la tour concernée
            }
        }
        if (tourHaut != null && tourHaut.level == level)             //Si il y a une tour dans la case au dessus de la tour concernée et qu'elle est de même niveau
        {
            if (tourTrouves.Contains(tourHaut) == false)        //On vérifie que cette tour n'a pas déjà été détectée dans le cadre de ce test de fusion
            {
                tourTrouves.Add(tourHaut);                      //Si ce n'est pas le cas, on l'ajoute à la liste des tours qui ont déjà été détectées pour la fusion
                checkFusionL(ref tourTrouves, x, y - 1, level);      //On actualise la liste de tours détectées grâce à REF et on effectue à nouveau le test de fusion à partir de la tour détectée au dessus de la tour concernée
            }
        }
    }


    public void createTourL()         //Cette fonction permet de créer une tour L d'un niveau dépendant de s'il y a eu une fusion avant son exécution ou non.
    {
        Debug.Log("fusion IMBA");
        cible_script = (MainCanvas)transform.parent.gameObject.GetComponent(typeof(MainCanvas));
        GameObject nouvelleTour_L = Instantiate(tour_L) as GameObject;       //On crée la tour L contenue dans le tableau à la case level-1 (pour correspondre au tableau qui commence à 0)
        nouvelleTour_L.transform.position = new Vector3(cible_script.Place_click.transform.position.x, 2.5f, cible_script.Place_click.transform.position.z);   //On place la tour aux coordonnées de la tuile cliquée

        Tour nouvelleTour = nouvelleTour_L.GetComponent<Tour>();                   //On crée un gameobject dans lequel on met la tour que l'on a crée juste avant
        nouvelleTour.type = "L";                                                   //On attribue le type Sniper à la tour que l'on vient de créer
        place_script.creation_script.plateauTour[place_script.xRow, place_script.yCol] = nouvelleTour;
        //On accède au script de la tuile PUIS au script de la création du plateau (où sont les variables de positions des tuiles et des tours) PUIS à la position des tours pour attribuer les coordonnées de la nouvelle tour

        /*if (!(level >= 3))          //Si le niveau de la tour créée n'est pas supérieur ou égal au niveau maximum alors on vérifie si une fusion est possible
        {
            checkFusionSup(nouvelleTour, "L", level);      //On vérifie si une fusion est possible à partir de la nouvelle tour avec des tours de son type et de son niveau
        }*/

        this.gameObject.SetActive(false);   //Désactive le panel après que tous les tests de fusion aient été effectués
    }
}
