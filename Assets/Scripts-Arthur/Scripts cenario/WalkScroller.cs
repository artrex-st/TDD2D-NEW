using UnityEngine;
using System.Collections;

public class WalkScroller : MonoBehaviour {

    public float speed = 0;
    private Material mat; // faz girar o cenario "andar"

    //private GameObject pl; //referencia ao jogador para saber qual lado ele está segundo


    private float pos = 0; // posição -- faz a posição do fundo seguir o personagem
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material; //

	
	}
	
	// Update is called once per frame
	void Update () {
        
        pos += speed * Time.deltaTime;

        mat.mainTextureOffset = new Vector2(pos, 0);
	
	}
}
