using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp1._0.sp;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApp1._0.sp
{
  public class Sp_Generic_Class
  {
    // DB connnection
      private static string ConnectionString = ConfigurationManager.ConnectionStrings["MSTORE_DBEntities"].ConnectionString;

    // Function to get all records -- Parameter -> procedure name
    public static DataTable GetMultipleRecord(string store_procedure_name)
    {
      SqlConnection con = new SqlConnection(ConnectionString);
      DataTable dt = new DataTable();
      SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
      cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
      using (con)
      {
        cmdLoadBillfrom.Connection = con;
        cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
        {
          sda.Fill(dt);
        }
      }
      return dt;
    }

    // Function to get all records based on some parameters -- Parameter -> Procedure name &  Array of condition / single also
    public static DataTable GetMultipleRecordByParam(string store_procedure_name, Dictionary<string, object> param)
    {
      SqlConnection con = new SqlConnection(ConnectionString);
      DataTable dt = new DataTable();
      SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
      cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
      if (param.Count() > 0)
      {
        foreach (var p in param)
        {
          cmdLoadBillfrom.Parameters.AddWithValue("@" + p.Key, p.Value);
        }
      }
      using (con)
      {
        cmdLoadBillfrom.Connection = con;
        cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
        {
          sda.Fill(dt);
        }
      }
      return dt;
    }

    // Function to get all records based on some parameters -- Parameter -> Procedure name &  Array of condition / single also
    public static DataSet GetMultipleDataSetsRecordByParam(string store_procedure_name, Dictionary<string, object> param)
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        DataSet dt = new DataSet();
        SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
        cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
        if (param.Count() > 0)
        {
            foreach (var p in param)
            {
                cmdLoadBillfrom.Parameters.AddWithValue("@" + p.Key, p.Value);
            }
        }
        using (con)
        {
            cmdLoadBillfrom.Connection = con;
            cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
            {
                sda.Fill(dt);
            }
        }
        return dt;
    }

    // Function to get all records based on some parameters -- Parameter -> Procedure name &  string as where clause
    public static DataTable GetMultipleRecordByStringParam(string store_procedure_name, string param)
    {
      SqlConnection con = new SqlConnection(ConnectionString);
      DataTable dt = new DataTable();
      SqlCommand cmdLoadBillfrom = new SqlCommand(store_procedure_name, con);
      cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
      cmdLoadBillfrom.Parameters.AddWithValue("@mywhere", param);
      using (con)
      {
        cmdLoadBillfrom.Connection = con;
        cmdLoadBillfrom.CommandType = CommandType.StoredProcedure;
        using (SqlDataAdapter sda = new SqlDataAdapter(cmdLoadBillfrom))
        {
          sda.Fill(dt);
        }
      }
      return dt;
    }
  }
}