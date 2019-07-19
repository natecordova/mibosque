using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;


public class NuevoCargarImagen : MonoBehaviour
{
    // The output of the image
    public Image img;
    public int referenceId;


    string[] rutas = {
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/rata%20espinosa_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/mono%20capuchino_1.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/venado%20cola%20blanca-01.png",
        "https://raw.githubusercontent.com/natecordova/mibosque/master/Assets/Sprites/oso%20perezoso_1.png"
    };




    // The source image
    






    IEnumerator Start()
    {

        System.Random rand = new System.Random();
        // Generate a random index less than the size of the array.  
        int index = rand.Next(rutas.Length);



        
            WWW www = new WWW( sqlite_conexion() );  //cambiar (url) por (rutas[index]) para que sea random 
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height),
            new Vector2(0.5f, 0.5f), 40);
        

        //Debug.Log("Randomly selected author is " + rutas[index]);



    }


    public String sqlite_conexion()
    {

        string url = "";

        

        string conn = "URI=file:" + Application.dataPath + "/Plugins/mibosque.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand(); //Variable que almacena la consulta a la base
        string sqlQuery = "SELECT * FROM especie where id =" + referenceId;
        Debug.Log(referenceId);
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
           
            url = reader.GetString(3);

            //int rand = reader.GetInt32(2);
            
            Debug.Log("Cargar Imagen url =" + url);
        }

        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;


        return url;

    } 






}
