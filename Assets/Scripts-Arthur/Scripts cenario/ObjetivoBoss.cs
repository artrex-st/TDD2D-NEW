using UnityEngine;
using System.Collections;

public class ObjetivoBoss : MonoBehaviour {

    public int essemap = 1;

    void Awake()
    {
        if (Data.cont >= 5 && Data.cont <= 6)
            DontDestroyOnLoad(transform.gameObject);
        
    }
    void Update()
    {
        if (Application.loadedLevelName == "Fase1")
            Destroy(gameObject);
        if (Data.cont ==0)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && essemap == 1)
        {
            Data.cont++;
            essemap++;
            PlayerPrefs.SetString("map", Data.map);
            PlayerPrefs.SetInt("intmap", Data.cont);
            Application.LoadLevel(Data.map + Data.cont);
            //Debug.Log("Objetivo atingido o Proximo mapa é: " + Data.map +"-"+Data.cont);
        }
    }
}