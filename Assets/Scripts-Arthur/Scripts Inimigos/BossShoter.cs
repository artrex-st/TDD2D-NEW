using UnityEngine;
using System.Collections;

public class BossShoter : MonoBehaviour {
    
    //IMport BulletShooter
    
    //public Rigidbody2D elem;// elem1, elem2, elem3, elem4; //myBulletPrefab -- ou elemento ni2 hirogenio uranio etc
    public float shootForce = 7;
    public Rigidbody2D elem,elem1,elem2; //muniçãoq ue será usada
    private BOSSIA script;
    //
    // Use this for initialization
    void Start () {
        script = (BOSSIA)GetComponentInParent(typeof(BOSSIA));
        elem = elem1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        script.CD += Time.deltaTime;
        //TipoBullet();
        if (script.energia <= 100 && !script.enrage)
        {
            shootForce *= 1.4f;
            
        }
        if (script.enrage)
        {
            if (script.aleat == 1)
                elem = elem1;
            else
                elem = elem2;
        }
        if (script.attack && script.CD >=1f && !script.die)
        {
            Shoot();
            script.CD = 0;
            if (script.enrage)
                script.CD = 0.1f;
            script.boss.SetTrigger("attack");
        }
    }


    //##################    Shoot   ##################
    public void Shoot() //cria munição
    {

        if (script.look)
        {
            Rigidbody2D bullet = Instantiate(elem, new Vector2(transform.position.x -0.2f, transform.position.y), transform.rotation) as Rigidbody2D;
            bullet.velocity = transform.TransformDirection(new Vector2(shootForce, 0));
            //bullet.transform.Rotate(0, 0, Time.deltaTime * 500); rotação
        }
        else
        if (!script.look)
        {
            Rigidbody2D bullet = Instantiate(elem, new Vector2(transform.position.x - 0.2f, transform.position.y), transform.rotation) as Rigidbody2D;
            bullet.velocity = transform.TransformDirection(new Vector2(-shootForce, 0));
            bullet.transform.localScale *= -1; // new Vector3(-1, 1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D col) //quando colidir (entrar)
    {
        if (col.tag == "Player")
        {
            script.boss.SetTrigger("angry");
            script.attack = true;
            script.CD = -1;
            if (script.enrage)
                script.CD = 0.1f;
            script.Lado();
        }
    }
    void OnTriggerExit2D(Collider2D col) //quando sai da area do colider
    {
        if (col.tag == "Player")
        {
            script.boss.SetBool("angry", false);
            script.attack = false;
        }
    }
}
