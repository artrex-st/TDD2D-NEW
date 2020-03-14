using UnityEngine;
using System.Collections;

public class BalaTutorial : MonoBehaviour {
	public float lifetime = 1f;
   // private Player scriptPlayer;
    
    // Use this for initialization
    void Start () {
        //scriptPlayer = (Player)GetComponentInParent(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            
        }
    }
}
