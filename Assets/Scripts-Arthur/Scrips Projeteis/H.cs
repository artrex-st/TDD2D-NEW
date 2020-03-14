using UnityEngine;
using System.Collections;

public class H : MonoBehaviour {
	public float lifetime = 1f;
    private Player scriptPlayer;
    public Transform explosao1/*Inimigo congelado*/;
    // Use this for initialization
    void Start () {
        scriptPlayer = (Player)GetComponentInParent(typeof(Player));

    }
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, lifetime);

	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Inimigo")
        {
            Debug.Log("Inimigo atingido por Nitrogenio Liquido!");
            Destroy(gameObject);
            //Rigidbody2D bullet = Instantiate(explosao1, col.transform.position, col.transform.rotation) as Rigidbody2D;

        }
       
    }
}
