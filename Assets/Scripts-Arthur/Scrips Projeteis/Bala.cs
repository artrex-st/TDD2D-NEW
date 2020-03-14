using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

    //variaveis
	public float lifetime = 1f;
    public Rigidbody2D iniCong;
    public GameObject impacto;

    void Start () {
        //scriptPlayer = (Player)GetComponentInParent(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, lifetime);


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Inimigo")
        {
            Destroy(gameObject);
            //Rigidbody2D bullet = Instantiate(iniCong, col.transform.position, col.transform.rotation) as Rigidbody2D;
        }
    }
}
