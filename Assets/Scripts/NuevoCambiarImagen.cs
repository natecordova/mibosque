using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NuevoCambiarImagen : MonoBehaviour
{

    public Image anim;
    public Image i1,i2,i3,i4;
    private db objdb;    
    private string monoBase, rataBase, osoBase, venadoBase;
    public CargarAnimales charge;
    //public GameObject comp1,comp2,comp3;
    public string miruta;

    string[] rutas2 = {
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/mono_capuchino-color.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/rata_espinosa-color.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/oso_perezoso-color.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/venado_cola_blanca-color.png"
    };

    string[] rutas = {
        "Sprites/mono_capuchino-color",
        "Sprites/rata_espinosa-color",
        "Sprites/oso_perezoso-color",
        "Sprites/venado_cola_blanca-color",
    };


    // The output of the image
    public Image img;

    // The source image
    string url = "https://clipground.com/images/monkey-baby-clipart-14.jpg";     

    IEnumerator Start()
    {    
        int index = 0;
        bool rep = true;
        
            if (name == "A1"){
                //string rrr = charge.aleatorias[0];
                //Debug.Log("DENTRO DE A1"+rrr);
                anim = GameObject.Find("A1").GetComponent<Image>();
                i1 = GameObject.Find("A1").GetComponent<Image>();
                i2 = GameObject.Find("A2").GetComponent<Image>();
                i3 = GameObject.Find("A3").GetComponent<Image>();
                i4 = GameObject.Find("A4").GetComponent<Image>();
            }
            if (name == "A2"){
                anim = GameObject.Find("A2").GetComponent<Image>();
                i1 = GameObject.Find("A1").GetComponent<Image>();
                i2 = GameObject.Find("A2").GetComponent<Image>();
                i3 = GameObject.Find("A3").GetComponent<Image>();
                i4 = GameObject.Find("A4").GetComponent<Image>();
            }
            if (name == "A3"){
                anim = GameObject.Find("A3").GetComponent<Image>();
                i1 = GameObject.Find("A1").GetComponent<Image>();
                i2 = GameObject.Find("A2").GetComponent<Image>();
                i3 = GameObject.Find("A3").GetComponent<Image>();
                i4 = GameObject.Find("A4").GetComponent<Image>();
            }
            if (name == "A4"){
                anim = GameObject.Find("A4").GetComponent<Image>();
                i1 = GameObject.Find("A1").GetComponent<Image>();
                i2 = GameObject.Find("A2").GetComponent<Image>();
                i3 = GameObject.Find("A3").GetComponent<Image>();
                i4 = GameObject.Find("A4").GetComponent<Image>();
            }
            Debug.Log("Nombre Soy: " + name);
            Debug.Log("ANIMAL: " + anim.sprite);
            Debug.Log("I1: " + i1.sprite);
            Debug.Log("I2: " + i2.sprite);
            Debug.Log("I3: " + i3.sprite);
            Debug.Log("I4: " + i4.sprite);

            //Cargar las imagenes locales
            //objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");

            objdb = new db();

            Debug.Log("CONSULTA" + objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'"));

            /*monoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'");
            rataBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");
            osoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '3'");
            venadoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '4'");*/

        while(rep == true){
            rep = false;
            System.Random rand = new System.Random();
            index = rand.Next(rutas.Length);
            string rd = rutas[index];
            string ruta = rutas[index];
            Debug.Log("aleatorio "+name+": " + ruta);
            string[] dir = ruta.Split('/');        
            string etiqueta = dir[dir.Length-1];        
            string[] et = etiqueta.Split('-'); 
            if(et[0].Contains(".png")){
                string[] lab = et[0].Split('.'); 
                tag = lab[0];
                name = lab[0];
                //Debug.Log("Contiene PNG");
                Debug.Log("etiqueta final asignada: " + lab[0]);
            }else{
                tag = et[0];
                Debug.Log("etiqueta asignada 1: " + et[0]);
            }
            anim.sprite = Resources.Load<Sprite>(ruta); //"Sprites/oso perezoso_1"

            Debug.Log("ANIMAL DESPUES: " + anim.sprite);
            if(name == "A1"){
                i1 = GameObject.Find("A1").GetComponent<Image>();
                if (i1.sprite == i2.sprite || i1.sprite== i3.sprite || i1.sprite == i4.sprite){
                rep = true;
                Debug.Log("ANIMAL REPETIDO :" +rep);  
                }
            }
            if(name == "A2"){
                i2 = GameObject.Find("A2").GetComponent<Image>();
                if (i2.sprite == i1.sprite || i2.sprite== i3.sprite || i2.sprite == i4.sprite){
                rep = true;
                Debug.Log("ANIMAL REPETIDO :" +rep);  
                }
            }
            if(name == "A3"){
                i3 = GameObject.Find("A3").GetComponent<Image>();
                if (i3.sprite == i1.sprite || i3.sprite== i2.sprite || i3.sprite == i4.sprite){
                rep = true;
                Debug.Log("ANIMAL REPETIDO :" +rep);  
                }
            }
            if(name == "A4"){
                i4 = GameObject.Find("A4").GetComponent<Image>();
                if (i4.sprite == i1.sprite || i4.sprite== i2.sprite || i4.sprite == i3.sprite){
                rep = true;
                Debug.Log("ANIMAL REPETIDO :" +rep);                
                }
            }
            
            Debug.Log("ANIMAL estado :" +rep);  
            Debug.Log("ANIMAL 1 : " + i1.sprite);
            Debug.Log("ANIMAL 2 : " + i2.sprite);
            Debug.Log("ANIMAL 3 : " + i3.sprite);
            Debug.Log("ANIMAL 4 : " + i4.sprite);
        
        }

        WWW www = new WWW((rutas[index]));    
               
        yield return www;
        //img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 1);
       
    }

    /*public void Start(){
        GameObject.tag = ("elemento_1");
    }*/

    public void Update()
    {

        
        // anim1.sprite = Resources.Load<Sprite>("Sprites/mono capuchinoNegro");  //Cargar en ejecucion el animal

        //Método con www cargar imagenes
        //WWW anim1_tex = new WWW("Sprites/mono capuchinoNegro");
        //anim1.sprite = Sprite.Create(anim1_tex.texture, new Rect(0, 0, anim1.sprite.rect.width,anim1.sprite.rect.height), new Vector2(0, 0), 1); 
    }


}
