using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {

    public IA script;

	// Use this for initialization
	void Start () {
        script = (IA)GetComponentInParent(typeof(IA)); // pega o script do OBJ inicial (Pai) inimigo
	}


    void OnTriggerEnter2D(Collider2D col) //quando colidir (entrar)
    {
        if (col.tag == "Player")
        {
            script.CreAnimator.SetTrigger("Buscar");
            script.lostPlayer = false;
            script.canFly = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) //quando sai da area do colider
    {
        if(col.tag == "Player")
        {
            script.BackToHome();
            script.lostPlayer = true;
            script.canFly = true;
        }
    }

    void Update () {
        
	
	}
}
