using UnityEngine;
using System.Collections;

public class Ni2 : MonoBehaviour {
	public float lifetime = 1f;
    private Player scriptPlayer;
    public Rigidbody2D /*Inimigo congelado*/gelo;
    // Use this for initialization
    void Start () {
        scriptPlayer = (Player)GetComponentInParent(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {

		Destroy(gameObject, lifetime);
        
        transform.Rotate(0, 0, Time.deltaTime * 40);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Inimigo")
        {
            Debug.Log("Inimigo atingido por Nitrogenio Liquido!");
            Destroy(gameObject);

        }
        if (col.tag == "agua") //agua ta com tag minuscula
        {
            Debug.Log("Agua!");
            Destroy(gameObject);
            Rigidbody2D bullet = Instantiate(gelo, transform.position, transform.rotation) as Rigidbody2D;

        }

    }
}
