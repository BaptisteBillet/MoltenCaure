using UnityEngine;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

    public static int ressourceX;
    public int ressourceY;
    public bool gameover; // False par défaut durant la partie

	// Use this for initialization
	void Start () 
    {
        gameover = false;
	    ressourceX = 0;
        ressourceY = 0;

        StartCoroutine( gain_x());
	}

    IEnumerator gain_x()
    {
        while(gameover == false)
        {
            ressourceX++;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

}
