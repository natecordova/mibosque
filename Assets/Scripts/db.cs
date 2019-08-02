﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class db : MonoBehaviour
{


    //public GameObject img;
    
    



    private void Start()
    {


        sqlite_conexion();



    }


   


     void sqlite_conexion()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/mibosque.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand(); //Variable que almacena la consulta a la base
        string sqlQuery = "SELECT * FROM especie";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);   // (0) es el primer valor en el array del primer campo de la base (id)
            string nombre = reader.GetString(1);   // (1) es el segundo valor en el array del segundo campo de la base (nombre)
            string tipo = reader.GetString(2);
            string url = reader.GetString(3);

            //int rand = reader.GetInt32(2);

            Debug.Log("id= " + id + "  nombre =" + nombre + "  tipo =" + tipo + "  url =" + url);
        }

        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
    }

    //funcion que recibe una sentencia sql
    // y regresa la url 


    public string sqlite_consulta(String consulta)
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/mibosque.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand(); //Variable que almacena la consulta a la base
        string sqlQuery = consulta;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);   // (0) es el primer valor en el array del primer campo de la base (id)
            string nombre = reader.GetString(1);   // (1) es el segundo valor en el array del segundo campo de la base (nombre)
            string tipo = reader.GetString(2);
            string url = reader.GetString(3);
            string rutaLocal = reader.GetString(4);

            consulta = rutaLocal;  //Asigna la ruta guardada en la base a la consulta que se devuelve
            Debug.Log("La consulta " + consulta);

            //int rand = reader.GetInt32(2);

            Debug.Log("id= " + id + "  nombre =" + nombre + "  tipo =" + tipo + "  url =" + url + "  rutaLocal =" + rutaLocal);
        }

        reader.Close();
        reader = null;

        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;


       


        return consulta;
    }




}




