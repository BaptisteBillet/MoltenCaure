using UnityEngine;
using System.Collections;

public class Menu_interactions : MonoBehaviour {

    public void LoadNextScene ()
    {
        Application.LoadLevel("Game_Baptiste");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Application.LoadLevel("Menu_principal");
    }
}
