using UnityEngine;
using System.Collections;

public class RadarStomp : MonoBehaviour {

    public IAStomp script;

	// Use this for initialization
	void Start () {

        //script = (IAStomp)GetComponent(typeof(IAStomp)); // pega o script do OBJ inicial (Pai) inimigo

	}


    void OnTriggerEnter2D(Collider2D col) //quando colidir (entrar)
    {
        if (col.tag == "Player")
            script.esmagar = true;

    }

   void OnTriggerExit2D(Collider2D col) //quando sai da area do colider
    {
       
    }
    void Update () {
        
	
	}
}
