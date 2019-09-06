using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Parametros : MonoBehaviour
{
    private db objdb;    
    
    public string[] rutas;
    public string[] anim_gen = {"","","",""};
    public string[] sombras = {"","","",""};
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;
    public GameObject S4;
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;

    public void Start()
    {        	
    	gameObject.transform.SetAsFirstSibling();
        Debug.Log("EN PARAMETROS");
        int index = 0;
        bool rep = true;
        
        objdb = new db();
        
        var totalLocal = objdb.sqlite_totalRegistros();
        rutas =new string[totalLocal];

        for (int i = 0;i < rutas.Length; i++)
        {
            string sel = "SELECT * FROM especie WHERE id = '";            
            rutas[i] = objdb.sqlite_consulta(sel + (i+1) + "'");            
        }
        
        foreach (string i in rutas) {           
            Debug.Log("rutas en parámetros " + i);
        }

        
        for (int i = 0;i < anim_gen.Length; i++)
        {
        	rep = true;
	        while (rep == true){
	            rep = false;
	            System.Random rand = new System.Random();
	            index = rand.Next(rutas.Length);
	            anim_gen[i] = rutas[index];
	            //Debug.Log("ALEAT: "+index+ "DE " + anim_gen.Length);
	            if(i == 0){
	                
	                if (anim_gen[0] == anim_gen[1] || anim_gen[0] == anim_gen[2] || anim_gen[0] == anim_gen[3]){
	                rep = true;
	                //Debug.Log("ANIMAL REPETIDO :" +rep);  
	                }
	            }
	            if(i == 1){
	                
	                if (anim_gen[1] == anim_gen[0] || anim_gen[1] == anim_gen[2] || anim_gen[1] == anim_gen[3]){
	                rep = true;
	                //Debug.Log("ANIMAL REPETIDO :" +rep);  
	                }
	            }
	            if(i == 2){
	               
	                if (anim_gen[2] == anim_gen[0] || anim_gen[2] == anim_gen[1] || anim_gen[2] == anim_gen[3]){
	                rep = true;
	                //Debug.Log("ANIMAL REPETIDO :" +rep);  
	                }
	            }
	            if(i == 3){
	                
	                if (anim_gen[3] == anim_gen[0] || anim_gen[3] == anim_gen[1] || anim_gen[3] == anim_gen[2]){
	                rep = true;
	                //Debug.Log("ANIMAL REPETIDO :" +rep);                
	                }
	            }        
	        
	        }
    	}

		foreach (string i in anim_gen) {
           
            Debug.Log("Animal Final" + i);            

        }


        cargar_sombras();
       // WWW www = new WWW((rutas[index]));  
        S1.SetActive(true);
        S2.SetActive(true);
        S3.SetActive(true);
        S4.SetActive(true);
        A1.SetActive(true);
        A2.SetActive(true);
        A3.SetActive(true);
        A4.SetActive(true);  
               
       // yield return www;
        //img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 1);
       
    }

    /*public void Start(){
        GameObject.tag = ("elemento_1");
    }*/

    public string[] aleatorios(){
    	return anim_gen;
    }

    public string[] sombras_al(){
    	return sombras;
    }

    public void cargar_sombras(){
    	string sombra = "";
    	Debug.Log("ASIGNANDO SOMBRA");
        for(int i = 0;i < anim_gen.Length; i++) { 
            sombra = anim_gen[i].Replace("color","sombra");          
            sombras[i] = sombra;
            Debug.Log("SOMBRA : " + sombras[i]);
        }
    }

    public void Update()
    {

    }

}
