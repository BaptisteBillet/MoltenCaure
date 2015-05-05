using UnityEngine;
using System.Collections;

public class CheckCollision : MonoBehaviour {


    void OnTriggerEnter(Collider touch)
    {
        //Debug.Log("Unity TG");
        if (touch.gameObject.tag == "Chemin")
        {
            //Debug.Log("bim détruit");
            Destroy(this.gameObject);
        }
    }
}
