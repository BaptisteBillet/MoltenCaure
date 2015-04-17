using UnityEngine;
using System.Collections;

public class MainCanvas : MonoBehaviour {

    public static MainCanvas instance;

    public GameObject Place_click;


    void Awake()
    {
        if(MainCanvas.instance == null)
        {
            instance = this;
        }

    }


}
