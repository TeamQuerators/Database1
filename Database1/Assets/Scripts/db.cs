using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;


public class db : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/Plugins/UsersInfo.db" //Path to database.
		IDbConnection = dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		String sqlQuery = "Select ' " + "FROM UsersInformation";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		while (reader.Read())
		{
			int userid = reader.GetInt32(0);
			String username = reader.GetString(1);

			Debug.Log( "userid =" +userid+ "username =" +username);
		}

		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
