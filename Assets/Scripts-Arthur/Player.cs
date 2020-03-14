using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;  //controle virtual assets storm free
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {


	public Animator PlayerAnimator;
    public float timeDead = 2f;
    public float axis;
    //
    //
    //
    //
    //novo pulo
    private float raio = 0.449435f;
    //variaveis bool
    public bool chao = true;
    //movimento
    public float speed=50, maxSpeed=75, speedJump, maxSpeedJump, cooldown;
	//rotaçao
	public bool lookToRight = true;
	private Vector3 positionRight;
	private Vector3 positionLeft;
    //pulo
    public LayerMask terra,agua;
    private bool isGround,isWater; //esta no chao? Ou na agua?
	public Transform footColider, jump_Fix,jumpAnimator; //  Empy obj link
	//Player status
	public float HP=100,maxHP=100;
    public Image barVida;
    public bool death = false;
    public int elementoAtual = 1;
    // inimigos e orientação
    public float hitJump, hitJumpLeanght, hitJumpCont;
    public bool hitJumpR;
    //UI
    public Text textoPot;
    //
    private Transform fixJtransform;
    private float jumpcd=0;
    private Rigidbody2D bodyPlayer;
    //sprite
    public Transform hpPlus, hpLess;
    //
    
    //public Texture btnTexture; // pega imagem do botao
	void Start () {
        bodyPlayer = GetComponent<Rigidbody2D> ();
		
		positionRight = transform.localScale; //rotaçao do persona - - Scale-transform
		positionLeft = transform.localScale; //rotaçao do persona
		positionLeft.x *= -1;
        //UI
        textoPot.text = "Pot";
        //textoHP = GetComponent<Text>();
        PlayerAnimator.SetTrigger("jumpFix");
        Troca();
    }

    //
    /* 	 
	 * Vector2 inputDirection = new Vector2(CrossPlatformInputManager.GetAxis ("Horizontal"),CrossPlatformInputManager.GetAxis ("Vertical")*speed*Time.deltaTime);
		//Vector2 inputDirection = new Vector2(Input.GetAxis ("Horizontal")*speed*Time.deltaTime,0); // key
		//
		bool isBoosting = CrossPlatformInputManager.GetButtonDown ("Boost"); // multiplicar a velocidade
		rigidybodyPlayer.AddForce(inputDirection*(isBoosting ? maxSpeed : 1));
		rigidybodyPlayer.velocity = new Vector2(inputDirection.x,rigidybodyPlayer.velocity.y);
	 * 
	 * 
	*/
    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(footColider.transform.position, raio);
    }
    */
    void FixedUpdate() {
        //movimentos

        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 && death == false)
            Move_Mobile();
        else
            if (death == false)
            Move_Key();
        cooldown -= Time.deltaTime;

        // fim do movimento
        // pulo
        //ray cast
        chao = Physics2D.OverlapCircle(footColider.transform.position, raio, terra);

        if (chao)
        {
            isGround = true;
            PlayerAnimator.SetBool("pulo", false);
            bodyPlayer.gravityScale = 1;
        }
        else
        {
            isGround = false;
            PlayerAnimator.SetBool("pulo", true);
        }
        if (chao && Input.GetKey(KeyCode.Space) || CrossPlatformInputManager.GetButton("Jump")) //DOWN
        {
            Jump();
        }

        //animação ataque
     /* movido para dentro do script de shoter
        if (Data.recarga <= 0 && CrossPlatformInputManager.GetButtonDown("B_Fire"))
        {
            PlayerAnimator.SetTrigger("attack");
        }
     */
        // fim do disparo
        //UI
        
        //fim da UI
        // Esc para menu
        if (Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene("Menu"); //Application.LoadLevel ("Menu"); 03/2020
        //morte
        if (death==true)
            Game_Over();
        //troca de bala
        if (CrossPlatformInputManager.GetButtonDown("B_Troca"))
            Troca();
        calcHP(); //HP
    }
    // movimento por axix virtuais
	public void Move_Mobile(){
		// movimento
		Vector2 inputDirection = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal")*speed*10*Time.deltaTime,0);
        if(hitJumpCont<=0)
            bodyPlayer.velocity = new Vector2(inputDirection.x,bodyPlayer.velocity.y); //
        else
        {
            if (hitJumpR)
                bodyPlayer.velocity = new Vector2(-hitJump, hitJump);
            if (!hitJumpR)
                bodyPlayer.velocity = new Vector2(hitJump, hitJump);
            hitJumpCont -= Time.deltaTime;

        }
        
        // velocity

        // direction
        if (inputDirection.x < 0)
			lookToRight = false;
		if (inputDirection.x > 0)
			lookToRight = true;
		if (lookToRight)
			transform.localScale = positionRight;
		else
			transform.localScale = positionLeft;
		
		//    \direction
		
		if (bodyPlayer.velocity.x > maxSpeed) {
			bodyPlayer.velocity = new Vector2(maxSpeed,bodyPlayer.velocity.y);
		}
		if (bodyPlayer.velocity.x < -maxSpeed) {
			bodyPlayer.velocity = new Vector2(-maxSpeed,bodyPlayer.velocity.y);
		} 
		//
		
		PlayerAnimator.SetFloat("velo",Mathf.Abs (inputDirection.x)); //valor inteiro
		
		// \movimento


	}
    //Move axix Key
    public void Move_Key()
    {
        // movimento
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal") * speed * 10 * Time.deltaTime, 0);
        if (hitJumpCont <= 0)
            bodyPlayer.velocity = new Vector2(inputDirection.x, bodyPlayer.velocity.y); //
        else
        {
            if (hitJumpR)
                bodyPlayer.velocity = new Vector2(-hitJump*1.2f, hitJump/1.2f);
            if (!hitJumpR)
                bodyPlayer.velocity = new Vector2(hitJump*1.2f, hitJump/1.2f);
            hitJumpCont -= Time.deltaTime;
        }
        //rigidybodyPlayer.AddForce(inputDirection);
        // velocity
        if (bodyPlayer.velocity.y > bodyPlayer.velocity.y + speedJump)
            bodyPlayer.velocity= new Vector2(inputDirection.x, bodyPlayer.velocity.y-speedJump);
        // direction
        if (inputDirection.x < 0)
            lookToRight = false;
        if (inputDirection.x > 0)
            lookToRight = true;
        if (lookToRight)
            transform.localScale = positionRight;
        else
            transform.localScale = positionLeft;

        //    \direction

        if (bodyPlayer.velocity.x >= maxSpeed)
        {
            bodyPlayer.velocity = new Vector2(maxSpeed, bodyPlayer.velocity.y);
        }
        if (bodyPlayer.velocity.x < -maxSpeed)
        {
            bodyPlayer.velocity = new Vector2(-maxSpeed, bodyPlayer.velocity.y);
        }
        //
        
        PlayerAnimator.SetFloat("velo", Mathf.Abs(inputDirection.x)); //valor inteiro

        // \movimento


    }
    //pulos
    public void Jump(){
        if (isGround && death == false)
        {
            bodyPlayer.AddForce(new Vector2(0, speedJump));
            //bodiPlayer.velocity += speedJump * Vector2.up;
            PlayerAnimator.SetBool("pulo", true);
        }
		
	}

    //####################################### TROCA ELEMENTO #########################################
    public void Troca()
    {
        if (elementoAtual <= 2)
            elementoAtual++;
        else
            elementoAtual = 1;
        if (elementoAtual == 0)
            elementoAtual++; //elemento 0 era um elemento de teste
        else
        if (elementoAtual == 1)
            textoPot.text = "N2";
        else
            if (elementoAtual == 2)
            textoPot.text = "H";
        else
            textoPot.text = "X";

    }

    void OnTriggerEnter2D(Collider2D col) //enter triger
    {

        if (col.tag == "Inimigo" && death == false && HP>=0)
        {
            if (HP <= 0)
            {
                PlayerAnimator.SetTrigger("Death");
                death = true;
            }
            PlayerAnimator.SetTrigger("hit");
            Debug.Log("Player Atingido"+ HP);
            HP -= 10;
            Transform bullet = Instantiate(hpLess, transform.position, transform.rotation) as Transform;
            Destroy(bullet.gameObject, 0.7f);
            hitJumpCont += 0.2f;
            if (col.transform.position.x < bodyPlayer.transform.position.x)
                hitJumpR = false;
            else
                hitJumpR = true;
                    
        }
        if (col.tag == "limite" && death == false)
        {
            //Debug.Log("ESPINHOS!");
            PlayerAnimator.SetTrigger("Death");
            HP = 0;
            death = true;
        }
        //HP++
        if (col.tag == "HP" && death == false)
        {
            if (HP < 100)
                HP += 10;
            Destroy(col.gameObject);
            Transform maisHP = Instantiate(hpPlus, transform.position, transform.rotation) as Transform;
            Destroy(maisHP.gameObject, 0.7f);

        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "agua")
        {
            bodyPlayer.gravityScale = 0.5f;
        }
        else
            bodyPlayer.gravityScale = 1f;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "agua")
            bodyPlayer.gravityScale = 1;
        if (col.tag == "BoxLimite")
        {
            PlayerAnimator.SetTrigger("Death");
            HP = 0;
            death = true;
        }
            
    }
    public void Game_Over()
    {
        
        timeDead -=Time.deltaTime;
        if (timeDead<=1.7f)
            GetComponent<Rigidbody2D>().isKinematic = true;
        if (timeDead <= 0)
        {
            SceneManager.LoadScene("Perdeu");//Application.LoadLevel("Perdeu"); 03/2020
        }
            
    }
    //Barras de HP
    void calcHP()
    {
        float calc = HP / maxHP;
        SetHealth(calc);
    }
    void SetHealth(float myhealth)
    {
        barVida.fillAmount = myhealth;

    }
    //fim Barras de HP
}









































