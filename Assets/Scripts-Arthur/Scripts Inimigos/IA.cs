using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IA : MonoBehaviour {

    public Transform home; // Posição inicial e de retorno
    private Transform player; // obj do player
    private Vector3 positionPlayerLost; // onde o player foi pego
    private Vector3 positionPlayerFind; // onde o jogador fugiu (volte ao ponto inicial
    // hit
    public int hit = 1;
    private Transform bat; // o inimigo
    //Energia
    public float energia = 40, maxEnergia;
    public Image bar;
    //public Text textEnergia;
    public float speed; //velocidade para voltar ao ponto padrao
    public float speedHunt=0.02f; //velocidade para caçar
    private float startTime, journyLenght; // calculo de tempo e perseguição /\/\ o maximo de area que o inimigo vai correr até o player fugir
    private float cd=0;
    public bool lostPlayer = true, canFly = false; //
    public Animator CreAnimator; //animation
    //
    public Rigidbody2D iniCong;
    public Transform explosao1;
    private Transform sprite;
    private Vector3 positionRight;
    private Vector3 positionLeft;
    public bool look;
    //
    void Start () {
        maxEnergia = energia;
        sprite = GetComponent<Transform>(); //pega a sprite

        bat = GetComponent<Transform>(); //pega obj e joga para variavel
        home = bat.transform.parent; //pega obj pai e joga para variavel
        player = GameObject.FindGameObjectWithTag("Player").transform; //pega o player pela tag e joga a posição no player
        positionPlayerLost = home.position; // como ja está no local padrao setar a casa(ponto padrao) como a  propria posição
        BackToHome();

        //lado
        positionRight = transform.localScale; //rotaçao do persona - - Scale-transform
        positionLeft = transform.localScale; //rotaçao do persona
        positionLeft.x *= -1;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        calcHP(); //HP
        //UI
        //textEnergia.text = "HP:" + energia;
        //fim da UI
        if (cd <= 2)
            cd += Time.deltaTime;

        if (canFly)
            if (lostPlayer)
            {
                float dist = (Time.time - startTime) * speed;
                float journey = dist / journyLenght; //jornada para ponto inicial

                if (bat.position == home.position)
                {
                    canFly = false;
                    CreAnimator.SetTrigger("Casa");
                    speedHunt=0.02f;
                    hit = 1;
                }
                    //canFly = false;
                bat.position = Vector3.Lerp(positionPlayerLost, home.position, journey); //quand player sai do raio ele volta para sua origem
                CreAnimator.SetTrigger("Retornar");
                Ladocasa();
            }
            else //ainda no raio de perseguição
            {
                if (cd >= 2)
                    hit = 0;
                Lado();
                if (hit <= 2)
                {
                    bat.position = Vector3.Lerp(bat.position, player.position, speedHunt); // 0.02f -velocidade boa- da posição que ele está para a posição do player com delay de **Float** 
                    
                    if (cd >= 1)
                    {
                        speedHunt += 0.015f; // corre destroi ou será destruido
                        cd = 0;
                    }
                }
            }
	
	}

    public void BackToHome() {
        startTime = Time.time;
        positionPlayerLost = bat.position;
        journyLenght = Vector3.Distance(positionPlayerLost, home.position);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            lostPlayer = true;
            lostPlayer = false;
            speedHunt = 0.009f;
            hit++;
        }
        if (col.tag == "Pot")
        {
            energia -= 10;
            if (col.name == "Ni2(Clone)")
                speedHunt = 0.009f;
            if (col.name == "H(Clone)")
            {
                energia -= 10;
                Instantiate(explosao1, col.transform.position, col.transform.rotation);
            }
            if (energia <= 0)
            {
                //col.GetComponent<GameObject>().name="Ni2";
                Destroy(gameObject);
                if (col.name == "Ni2(Clone)")
                    Instantiate(iniCong, transform.position, transform.rotation);
                else
                    if(col.name=="H(Clone)")
                    Instantiate(explosao1, transform.position, transform.rotation);
            }
        }

    }
    public void Lado()
    {
        
        if (player.transform.position.x < sprite.transform.position.x)
            look = false;
        if (player.transform.position.x > sprite.transform.position.x)
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
    public void Ladocasa()
    {

        if (player.transform.position.x > home.transform.position.x)
            look = false;
        if (player.transform.position.x < home.transform.position.x)
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
}
