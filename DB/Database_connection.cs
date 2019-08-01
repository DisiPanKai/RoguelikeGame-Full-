using UnityEngine;
using System.Collections;

using Mono.Data.Sqlite;
using System.Data;
using System;
//using Mono.Data.SqliteClient;

public class Database_connection
{
    public string database_name = "Roguelike.db";
    public string database_address = "/Database/";

    private string connection_address;

    private string sql_text;

    private IDbConnection dbconnection;
    private IDbCommand dbcommand;
    private IDataReader sql_data;

    private bool dbcommand_exist = false;

    public void Connection()
    {
        connection_address = "URI=file:" + Application.dataPath + database_address + database_name;

        dbconnection = (IDbConnection)new SqliteConnection(connection_address);
        dbconnection.Open(); //Open connection to the database.
    }

    public IDataReader SQL_Query(string text)
    {
        if (dbcommand_exist)
        {
            dbcommand_exist = false;

            dbcommand.Dispose();
            dbcommand = null;

            sql_data.Close();
            sql_data = null;
        }

        dbcommand_exist = true;

        dbcommand = dbconnection.CreateCommand();

        sql_text = text;

        dbcommand.CommandText = sql_text;

        sql_data = dbcommand.ExecuteReader();
        return sql_data;
    }

    public void Connection_close()
    {
        if (dbcommand_exist == true)
        {
            dbcommand_exist = false;

            sql_data.Close();
            sql_data = null;

            dbcommand.Dispose();
            dbcommand = null;
        }

        dbconnection.Close();
        dbconnection = null;
    }
}
