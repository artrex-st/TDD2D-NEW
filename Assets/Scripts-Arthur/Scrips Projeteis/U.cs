using UnityEngine;
using System.Collections;

public class U
    : MonoBehaviour {
	public float lifetime = 1f;
    private Player scriptPlayer;
    public Transform radiacao;
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
            Destroy(col.gameObject);
            Destroy(gameObject);
            //Rigidbody2D bullet = Instantiate(radiacao, col.transform.position, col.transform.rotation) as Rigidbody2D;

        }
       
    }
}
