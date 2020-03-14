using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IAStomp : MonoBehaviour
{
    public float maxEnergia;
    public float energia=50;
    public Image bar;
    public Animator stompAnimator;
    public Transform home,chao;
    private Rigidbody2D stomp;
    public bool esmagar, isGround, subir;
    public float force=5000;
    public Player scriptPlayer;
    public Rigidbody2D iniCong;
    public GameObject explosao1;
    void Start()
    {
        
        maxEnergia = energia;
        stomp= GetComponent<Rigidbody2D>();
        //home.position = stomp.position;
        stompAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGround && esmagar)
        {
            isGround = false;
            esmagar=false;
        }

        calcHP();
        if (Physics2D.Linecast(transform.position, home.position, 1 << LayerMask.NameToLayer("ceu")))
            isGround = false;
        if (Physics2D.Linecast(transform.position, chao.position, 1 << LayerMask.NameToLayer("ground")))
        {
            isGround = true;
            subir = true;
        }
        if (stomp.position.y >= home.position.y)
            subir = false;
        if (isGround)
            Voltar();
        if (esmagar)
            Esmagar();
        if (!isGround && !esmagar && !subir)
        {
            stomp.position = home.position;
            stompAnimator.SetBool("subir", false);

        }   

    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Pot" && energia >= 0)
        {
            energia -= 10;
            stompAnimator.SetTrigger("hit");
            if (energia <= 0)
            {
                Destroy(gameObject);
                if(col.name== "Ni2(Clone)")
                    Instantiate(iniCong, transform.position, transform.rotation);
                else
                    Instantiate(explosao1, col.transform.position, col.transform.rotation);
            }
                

        }            
        if (col.tag == "Player")
        {
            stomp.AddForce(new Vector2(0, 10*force * Time.deltaTime));
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
    //Player na area
    public void Esmagar()
    {
        stomp.AddForce(new Vector2(0, -force * Time.deltaTime));
        stomp.gravityScale = 1;
        esmagar = true;
        stompAnimator.SetBool("esmagar", true);
    }
    public void Voltar()
    {
        stomp.AddForce(new Vector2(0, force * Time.deltaTime));
        esmagar = false;
        stomp.gravityScale = 0;
        stompAnimator.SetBool("esmagar", false);
        stompAnimator.SetBool("subir", true);

    }
}
