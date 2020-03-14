using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BOSSIA : MonoBehaviour {


    //Variaveis
    public GameObject iniCong, explosao1,elObjetivo;
    public Transform bossT,player;//##   PRIVATE
    private int isDie=0;
    public float CD = 0;
    //aleatorio
    public float aleat,aleatCont;
    public bool enrage;
    //animator
    public Animator boss;
    //Movimento
    public bool look=true;
    public Vector3 positionRight, positionLeft;
    public float speed=2;
    //detect
    public bool die, attack;
    //vida
    public float energia, maxEnergia;
    //UI
    public Image bar;

    void Start () {
        positionRight = GetComponent<Transform>().localScale;

        positionLeft = new Vector2(positionRight.x * -1, positionRight.y);

        bossT = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss= GetComponent<Animator>();
        maxEnergia = energia;
    }
	
	// Update is called once per frame
	void Update () {
        aleat = Random.Range(1, 3);
        if(aleatCont<30)
            aleatCont += aleat*Time.deltaTime;
        calcHP(); //HP
        if (energia <= 100 && !enrage)
        {
            enrage = true;
            speed *= 2;
        }
        if (attack || aleatCont >= 20 && energia > 100)
            idle();
        else
            move();
    }
    //idle
    public void idle()
    {
        boss.SetBool("walk", false);
        if (energia <= 100)
            aleatCont = 0;
        if (aleatCont >= 25)
            aleatCont = 0;
    }
    //move
    public void move()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        boss.SetBool("walk", true);
        if (speed > 0)
        {
            transform.localScale = positionRight;
            GetComponentInChildren<Canvas>().transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = positionLeft;
            GetComponentInChildren<Canvas>().transform.localScale = new Vector2(-1, 1);
        }
    }
       
    //lado
    public void Lado()
    {
        
        if (player.transform.position.x < bossT.transform.position.x)
            look = false;
        if (player.transform.position.x > bossT.transform.position.x)
            look = true;
        if (look)
        {
            transform.localScale = positionRight;
            GetComponentInChildren<Canvas>().transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = positionLeft;
            GetComponentInChildren<Canvas>().transform.localScale = new Vector2(-1, 1);
        }
            
    }
    //UI de Energia
    void calcHP()
    {
        float calc = energia / maxEnergia;
        SetHealth(calc);
    }
    void SetHealth(float myhealth)
    {
        bar.fillAmount = myhealth;

    }
    //fim UI de energia
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "patrulha")
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        if (col.tag == "Pot" && energia >= 0)
        {
            energia -= 10;
            boss.SetTrigger("hit");
            if (col.name == "Ni2(Clone)")
                CD -= 0.5f;
            if(col.name == "H(Clone)" && aleat==2)
            {
                Instantiate(explosao1, col.transform.position, col.transform.rotation);
                energia -= 10;
            }
            
            if (energia <= 0)
            {
                boss.SetBool("die", true);
                Destroy(gameObject, 0.3f);
                if (isDie < 1)
                {
                    isDie++;
                    if (col.name == "Ni2(Clone)")
                    {
                        Instantiate(iniCong, transform.position, transform.rotation);
                    }
                    else
                        Instantiate(explosao1, transform.position, transform.rotation);
                    Instantiate(elObjetivo, transform.position, transform.rotation);
                }
            }
        }
    }
}
