using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class iniciar : MonoBehaviour {

	public void Iniciar ()
    {
        SceneManager.LoadScene("menuJuegos");
	}

    public void Juego1()
    {
        SceneManager.LoadScene("menuJuego1");
    }

    public void Juego2()
    {
        SceneManager.LoadScene("principal");
    }

    public void Juego3()
    {
        SceneManager.LoadScene("introBosque");
    }
}
