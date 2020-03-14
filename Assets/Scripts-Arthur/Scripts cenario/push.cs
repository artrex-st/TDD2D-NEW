using UnityEngine;
using System.Collections;

public class push : MonoBehaviour {
    public bool lado,cima;
    public float velo=20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (!cima)
        {
            if (lado)
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(velo, 3));
            if (!lado)
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velo, 3));
        }
        else
        {
            if (lado)
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,velo));
            if (!lado)
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-velo));
        }
    }
}
