using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace GetTableStracture
{
    public class DBconnection
    {
        public static String ConnectionString { get; set; }

        public static DataTable GetTablePKFK(Dictionary<String,string> tableNames)
        {
            String cmdFormatter = "SELECT * FROM ALL_CONSTRAINTS C LEFT JOIN ALL_CONS_COLUMNS CC ON C.CONSTRAINT_NAME=CC.CONSTRAINT_NAME {0}";
            OracleConnection conn = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.BindByName = true;
            String where = " WHERE 1=1 AND C.CONSTRAINT_TYPE IN ('P','F') AND (";
            int filledIndex=1;
            foreach (String key in tableNames.Keys)
            {
                where += String.Format("\r\n (C.TABLE_NAME='{0}' AND C.OWNER='{1}'){2}", tableNames[key], key,filledIndex==tableNames.Keys.Count?"":" OR ");
            }
            where += " )";
            DataTable result = new DataTable();
            try
            {
                conn.Open();
                cmd.CommandText = String.Format(cmdFormatter, where);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(result);
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            return result;

        }
    }
}
