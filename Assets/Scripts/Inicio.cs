using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour {
    //public GameObject objeto1;
    // Use this for initialization
  
	void Start () {
        //Estrella.SetActive(false);
        //objeto1 = GameObject.Find("estrella");
        //objeto1.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cambiar()
    {
        //Debug.Log("ddddd");
        SceneManager.LoadScene("menuJuegos");
    }

    public void volverMenu()
    {
        //Debug.Log("ddddd");
        SceneManager.LoadScene("menuJuego1");
    }

    public void cambiarPajaros(int escenaMamiferos)
    {
        //Debug.Log("ddddd");
        SceneManager.LoadScene(escenaMamiferos);
    }

    public void cambiarMamiferos(int escenaPajaros)
    {
        //Debug.Log("ddddd");
        SceneManager.LoadScene(escenaPajaros);
    }

    public void salir()
    {
        //Debug.Log("ddddd");
        Application.Quit();
    }


}
