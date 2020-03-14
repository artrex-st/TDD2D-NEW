using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Objetivo : MonoBehaviour {
    public int essemap=1;

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && essemap==1)
        {
            Data.cont++;
            essemap++;
            PlayerPrefs.SetString("map", Data.map);
            PlayerPrefs.SetInt("intmap", Data.cont);
            //Application.LoadLevel(Data.map+Data.cont); 03/2020
            SceneManager.LoadScene(Data.map+Data.cont);
            Debug.Log("Objetivo atingido o Proximo mapa é: " + Data.map +"-"+Data.cont);
        }
    }
}
