using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    public float dragBorder;    //C'est la taille de la zone dans laquelle doit être le curseur de la souris pour déclencher le scrolling de la caméra
    public float scrollSpeed;   //C'est le multiplicateur qui définit la vitesse du scrolling de la caméra
    private bool butee = false; //Cette valeur est "false" quand la souris n'est dans aucune des deux zones de drag

    void Update()
    {
        Vector3 pos = Input.mousePosition;                      //On récupère la position en X de la souris 
        float cameraX = this.gameObject.transform.position.x;   //On récupère la position X de la caméra
        float delta = pos.x - (Screen.width - dragBorder);      //Formule servant à déterminer la vitesse croissante de la caméra selon le positionnement de la souris

        if (pos.x > 0 && pos.x < Screen.width)              //Si la souris se trouve à l'écran
        {
            if (pos.x <= Screen.width - dragBorder && pos.x >= dragBorder && cameraX != 75 && cameraX != -20)   //Si la souris se trouve dans la partie extrême gauche 
            {                                                                                                   //ou droite et que la caméra n'est pas en butée 
                butee = false;                                                                           //Alors le scrolling peut avoir lieu
            }
            
            if (pos.x <= dragBorder && butee == false)                                                          //Si la souris est dans la zone gauche et que la caméra n'est pas en butée
            {
                if (cameraX >= -20)                                                                             //On vérifie spécifiquement que la caméra n'est pas en butée à gauche
                {
                    transform.Translate(((pos.x - dragBorder) * scrollSpeed) / dragBorder, 0, 0, Space.World);  //Et on déplace la caméra vers la gauche, avec une vitesse qui varie selon la position de la souris
                }
                else                                                                             //Autrement
                {
                    butee = true;                                                                //On met la butée en true car la caméra est à sa position maximale
                }              
            }

            if (pos.x >= Screen.width - dragBorder && butee == false)                                           //Si la souris est dans la zone droite et que la caméra n'est pas en butée
            {
                if (cameraX <= 75)                                                                              //On vérifie spécifiquement que la caméra n'est pas en butée à droite
                {
                    transform.Translate(delta * scrollSpeed / dragBorder, 0, 0, Space.World);                   //Et on déplace la caméra vers la droite, avec une vitesse qui varie selon la position de la souris
                }
                else                                                                            //Autrement
                {
                    butee = true;                                                               //On met la butée en true car la caméra est à sa position maximale
                }
            }
        }
    }
}

