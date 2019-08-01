using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NuevoCambiarImagen : MonoBehaviour
{

    public Image anim1, anim2, anim3, anim4;
    private db objdb;

    private string monoBase, rataBase, osoBase, venadoBase;


    string[] rutas = {
         "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/mono%20capuchino_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/rata%20espinosa_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/oso%20perezoso_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/venado%20cola%20blanca-01.png"
    };


    // The output of the image
    public Image img;

    // The source image
     string url = "https://clipground.com/images/monkey-baby-clipart-14.jpg";

    IEnumerator Start()
    {

        


        //Asignar cada game object
        anim1 = GameObject.Find("Mono").GetComponent<Image>();
        anim2 = GameObject.Find("Raton").GetComponent<Image>();
        anim3 = GameObject.Find("Oso").GetComponent<Image>();
        anim4 = GameObject.Find("Venado").GetComponent<Image>();


        //Cargar las imagenes locales
        //objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");

        objdb = new db();

        Debug.Log("CONSULTA" + objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'"));

        monoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '1'");
        rataBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '2'");
        osoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '3'");
        venadoBase = objdb.sqlite_consulta("SELECT * FROM especie WHERE id = '4'");



        anim1.sprite = Resources.Load<Sprite>(monoBase); //"Sprites/oso perezoso_1"
        anim2.sprite = Resources.Load<Sprite>(rataBase); //"Sprites/rata espinosa_1"
        anim3.sprite = Resources.Load<Sprite>(osoBase); //"Sprites/mono capuchino_1"
        anim4.sprite = Resources.Load<Sprite>(venadoBase); //"Sprites/venado cola blanca-01"

        Debug.Log("monooo" + monoBase);

        //  Debug.Log("anim sql" + objdb.reader.GetString(3));


        // Generate a random index less than the size of the array.  
        System.Random rand = new System.Random();
        int index = rand.Next(rutas.Length);


        //Cargar imágenes desde url
        WWW www = new WWW((rutas[index]));
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 1);
    }

    public void Update()
    {


        // anim1.sprite = Resources.Load<Sprite>("Sprites/mono capuchinoNegro");  //Cargar en ejecucion el animal










        //Método con www cargar imagenes
        //WWW anim1_tex = new WWW("Sprites/mono capuchinoNegro");
        //anim1.sprite = Sprite.Create(anim1_tex.texture, new Rect(0, 0, anim1.sprite.rect.width,anim1.sprite.rect.height), new Vector2(0, 0), 1); 
    }





}
