using UnityEngine;
using System.Collections;

public class Flutuar : MonoBehaviour {


    public float boiar=900;
    public float aleat;
    public bool cforce;
    public Rigidbody2D gelo;
    public Transform fundo;
    public float force=0;

	void Start () {
        gelo = GetComponent<Rigidbody2D>();
        fundo = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.Linecast(transform.position, fundo.position, 1 << LayerMask.NameToLayer("fundo")))
        {
            gelo.AddForce(new Vector2(0, boiar * Time.deltaTime));
            force+=boiar * Time.deltaTime;
        }

        if (force > 0 && !Physics2D.Linecast(transform.position, fundo.position, 1 << LayerMask.NameToLayer("fundo")))
        {
            gelo.AddForce(new Vector2(0, -force*1.2f * Time.deltaTime));
            force = 0;
        }
       /* 
        if (transform.rotation.z > 0)
            transform.Rotate(0, 0, Time.deltaTime * 4);
        else
            transform.Rotate(0, 0, Time.deltaTime * -4);
            */
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "agua")
        {
            aleat = Random.Range(1, 100);
            gelo.gravityScale = aleat*0.01f;
        }
        

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "objetivo")
        {
            Destroy(gameObject);
        }


    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "agua")
        {
            gelo.gravityScale = 1;
        }
    }
}
