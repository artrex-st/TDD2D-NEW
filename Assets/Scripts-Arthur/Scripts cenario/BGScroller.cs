using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float speed = 0;
    private Material mat; // faz girar o cenario "andar"
    private GameObject pl; //referencia ao jogador para saber qual lado ele está segundo

    public Transform pt; // Player Transform
    public Transform ct; // Camera Transform

    private float pos = 0; // posição -- faz a posição do fundo seguir o personagem
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material; //
        pl = GameObject.FindGameObjectWithTag("Player");

	
	}
	
	// Update is called once per frame
	void Update () {


        ct.position = Vector3.Lerp(
            ct.position,
            new Vector3(pt.position.x, ct.position.y, ct.position.z), 1f);

        var vel = pl.GetComponent<Rigidbody2D>().velocity.x; // pega a velocidade do player


        if(vel > 1 || vel < -1)
        {
            var side = pl.transform.localScale.x;
            pos += speed * side;

            mat.mainTextureOffset = new Vector2(pos, 0);
        }
	
	}
}
