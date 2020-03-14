using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;  //controle virtual assets storm free

public class BulletShooter : MonoBehaviour {


    public Animator PlayerAnimator;

    public Rigidbody2D elem0,elem1,elem2,elem3,elem4; //myBulletPrefab -- ou elemento ni2 hirogenio uranio etc
	public int shootForce = 7;
    private Rigidbody2D elem; //muniçãoq ue será usada
    private Player scriptPlayer;
	//public float Recarga=1;
	void Start () {
        scriptPlayer = (Player)GetComponentInParent(typeof(Player));

    }
    //###################   VOID    ###################
    void Update () {

        TipoBullet();
        if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.LeftControl)) // || CrossPlatformInputManager.GetButtonDown("B_Fire") )
        {
            if (scriptPlayer.cooldown <= 0 && scriptPlayer.death == false)
            {
                Shoot();
                scriptPlayer.cooldown = 1f;
                PlayerAnimator.SetTrigger("attack");
                print("Atirou");

            }
        }
        
    }


    //##################    Shoot   ##################
    public void Shoot() //cria munição
    {

        Rigidbody2D bullet = Instantiate(elem, transform.position, transform.rotation) as Rigidbody2D;
        bullet.velocity = transform.TransformDirection(new Vector2(shootForce, 0));
  //      if (scriptPlayer.lookToRight == true)
  //      {
		//	Rigidbody2D bullet = Instantiate (elem, transform.position, transform.rotation) as Rigidbody2D;
		//	bullet.velocity = transform.TransformDirection (new Vector2 (shootForce, 0));
  //          //bullet.transform.Rotate(0, 0, Time.deltaTime * 500); rotação
  //      } else
		//if(scriptPlayer.lookToRight == false){
		//	Rigidbody2D bullet = Instantiate (elem, transform.position, transform.rotation) as Rigidbody2D;
		//	bullet.velocity = transform.TransformDirection (new Vector2 (shootForce, 0));
  //      }
	}
    //##################    Tipo   ####################
    public void TipoBullet() //troca munição
    {
        if (scriptPlayer.elementoAtual == 0)
        {
            elem = elem0;
            shootForce = 12;
        }
        else
            if(scriptPlayer.elementoAtual == 1)
        {
            elem = elem1;
            shootForce = 5;
        }
        else
            if (scriptPlayer.elementoAtual == 2)
        {
            elem = elem2;
            shootForce = 18;
        }
        else
            if (scriptPlayer.elementoAtual == 3)
        {
            elem = elem3;
        }


    }
}
