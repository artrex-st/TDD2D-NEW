using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUB : MonoBehaviour {

 
    //GUI
    public Sprite[] pots;
    public Image potUI;

    private Player sPlayer;
    //##### VOID ######
    void Start () {

        sPlayer = (Player)GetComponentInParent(typeof(Player));

        potUI.sprite = pots[sPlayer.elementoAtual];

    }
	
	// Update is called once per frame
	void Update () {

        potUI.sprite = pots[sPlayer.elementoAtual];
    }
}
