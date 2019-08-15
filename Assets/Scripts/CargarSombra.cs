using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarSombra : MonoBehaviour
{
    public Image sombra;
    public string animal;
    private db objdb;    
    private string monoBase, rataBase, osoBase, venadoBase;


    string[] rutasX = {
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/mono%20capuchino_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/rata%20espinosa_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/oso%20perezoso_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/venado%20cola%20blanca-01.png"
    };

    string[] rutas = {
        "Sprites/mono_capuchino-sombra",
        "Sprites/rata_espinosa-sombra",
        "Sprites/oso_perezoso-sombra",
        "Sprites/venado_cola_blanca-sombra",
    };


    // The output of the image
    public Image img;

    IEnumerator Start()
    {

        
        if (name == "S1"){
            sombra = GameObject.Find("S1").GetComponent<Image>();
        }
        if (name == "S2"){
            sombra = GameObject.Find("S2").GetComponent<Image>();
        }
        if (name == "S3"){
            sombra = GameObject.Find("S3").GetComponent<Image>();
        }
        if (name == "S4"){
            sombra = GameObject.Find("S4").GetComponent<Image>();
        }
        Debug.Log("Nombre Soy: " + name);

        //Cargar las imagenes locales
        //objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");

        objdb = new db();

        Debug.Log("CONSULTA" + objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'"));

        /*monoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'");
        rataBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");
        osoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '3'");
        venadoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '4'");*/


        System.Random rand = new System.Random();
        int index = rand.Next(rutas.Length);
        string rd = rutas[index];
        string ruta = rutas[index];
        Debug.Log("aleatorio SOMBRA "+name+": " + ruta);
        string[] dir = ruta.Split('/');        
        string etiqueta = dir[dir.Length-1];        
        string[] et = etiqueta.Split('-'); 
        if(et[0].Contains(".png")){
            string[] lab = et[0].Split('.'); 
            tag = lab[0];
            name = lab[0]+"_sombra";
            //Debug.Log("Contiene PNG");
            Debug.Log("etiqueta final asignada: " + lab[0]);
            Debug.Log("nombre final asignada: " + name);
        }else{
            tag = et[0];
            Debug.Log("etiqueta asignada 1: " + et[0]);
        }
        sombra.sprite = Resources.Load<Sprite>(ruta);
        animal = ruta.Replace("sombra","color");
		Debug.Log("animal : "+ animal);

        WWW www = new WWW((rutas[index])); 
        yield return www;
        //img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 1);
        /*
        String etiqueta = dir[1];
        Debug.Log("pedazo de cadena: " + etiqueta);*/
    }

    public void Update()
    {
 
    }


}
