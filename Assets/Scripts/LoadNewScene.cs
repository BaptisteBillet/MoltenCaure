using UnityEngine;
using System.Collections;

public class LoadNewScene : MonoBehaviour {



    public void LoadNextScene ()
    {
        Application.LoadLevel("Game_Antonin_v2");
    }
    public void Menu()
    {
        Application.LoadLevel("Menu_principal");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
