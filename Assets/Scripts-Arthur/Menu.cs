using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour {
    public Text texMap;

	// Update is called once per frame
	void Update () {
        int num;
        num = Data.cont + 1;
        texMap.text = "Nº"+num;

    }

	public void Bt_Play(){
        //Application.LoadLevel(Data.map + Data.cont); 03/2020
        SceneManager.LoadScene(Data.map + Data.cont);
    }
    public void Bt_AddMap()
    {
        if (Data.cont > 4)
            Data.cont = 0;
        else
            Data.cont++;
    }
    public void Bt_NovoJogo()
    {
        //delet salves
        PlayerPrefs.DeleteKey("intmap");
        //cria salve
        PlayerPrefs.GetString("map", Data.map);
        Data.cont = 0;
        PlayerPrefs.SetInt("intmap", Data.cont);
        //load level
        //Application.LoadLevel(Data.map+Data.cont); // 03/2020
        SceneManager.LoadScene(Data.map+Data.cont);
    }

    public void Bt_Exit(){
		Application.Quit();
	}
}
