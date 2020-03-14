using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {

    //private Rigidbody2D bullet;
    public float aleat,t;
    public BOSSIA script;
    // Use this for initialization
    void Start () {
        script = (BOSSIA)GetComponentInParent(typeof(BOSSIA));
    }
	
	// Update is called once per frame
	void Update () {
        aleat = Random.Range(1, 5);
        t += Time.deltaTime;
        if(t==2.76f)
            GetComponent<Animator>().SetTrigger("hit");
        Destroy(gameObject, 3);
        if (aleat <= 3)
            GetComponent<Rigidbody2D>().gravityScale = 0.4f;
        else
            GetComponent<Rigidbody2D>().gravityScale = -0.3f;
    }

    void OnTriggerEnter2D(Collider2D col) //quando colidir (entrar)
    {
        if (col.name == "Player" || col.tag=="Inimigo" || col.tag=="Pot")
        {
            GetComponent<Animator>().SetTrigger("hit");
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.27f);
        }
        

    }

}
