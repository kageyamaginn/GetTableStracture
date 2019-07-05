using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraTreeList.Nodes;

namespace GetTableStracture
{
    public partial class FindFKReference : Form
    {
        public FindFKReference()
        {
            InitializeComponent();
        }

        private String _tableName;

        public String TableName
        {
            get { return _tableName; }
            set { _tableName = value; textEditTableName.Text = value; }
        }
        private String _owner;

        public String Owner1
        {
            get { return _owner; }
            set { _owner = value; textEditOwner.Text = value; }
        }

        public String GetPKName(String owner, String tableName)
        {
            String result = "";
            OracleConnection conn = new OracleConnection(DBconnection.ConnectionString);
            OracleCommand cmd = new OracleCommand(String.Format("SELECT CONSTRAINT_NAME FROM ALL_CONSTRAINTS WHERE TABLE_NAME='{0}' AND OWNER='{1}' AND CONSTRAINT_TYPE='P'", tableName, owner), conn);
            try
            {
                conn.Open();
                result = cmd.ExecuteScalar() as String;
            }
            finally { conn.Close(); }
            return result;
        }

        public DataTable GetReferenceTable(String pkName,String owner)
        {
            DataTable results = new DataTable();
            OracleConnection conn = new OracleConnection(DBconnection.ConnectionString);
            OracleDataAdapter adapter = new OracleDataAdapter(String.Format("SELECT DISTINCT TABLE_NAME,OWNER,'FK' RELATION_TYPE  FROM ALL_CONSTRAINTS WHERE R_CONSTRAINT_NAME='{0}' AND R_OWNER='{1}'", pkName, owner), conn);

            try
            {
                conn.Open();
                adapter.Fill(results);
            }
            catch { }
            finally
            {
                conn.Close();
            }

            return results;
        }

        public DataTable GetRecessiveRelation(DataTable primaryKeyColumns)
        {
            DataTable results = new DataTable();
            String columnConditionString = "";
            foreach (DataRow cr in primaryKeyColumns.Rows)
            {
                if (!String.IsNullOrEmpty(columnConditionString))
                {
                    columnConditionString += "\r\nUNION\r\n";
                }
                columnConditionString += String.Format("SELECT TABLE_NAME,OWNER,COLUMN_NAME FROM ALL_TAB_COLUMNS WHERE COLUMN_NAME='{0}' AND DATA_TYPE='{1}'", cr["COLUMN_NAME"], cr["DATA_TYPE"]);
            }
            OracleConnection conn = new OracleConnection(DBconnection.ConnectionString);
            OracleCommand cmd = new OracleCommand(String.Format("SELECT OWNER,TABLE_NAME,'RECESSIVE' RELATION_TYPE  FROM ({1}) GROUP BY OWNER,TABLE_NAME HAVING COUNT(1)={0} ORDER BY OWNER,TABLE_NAME", primaryKeyColumns.Rows.Count, columnConditionString), conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            try
            {
                conn.Open();
                adapter.Fill(results);
            }
            catch { }
            finally 
            {
                conn.Close();
            }
            return results;
        }

        public DataTable GetPrimaryKeyColumns(String pkName)
        {
            DataTable results = new DataTable();

            OracleConnection conn = new OracleConnection(DBconnection.ConnectionString);
            OracleCommand cmd = new OracleCommand(String.Format(@"SELECT TC.COLUMN_NAME, TC.DATA_TYPE, TC.DATA_LENGTH
                                                      FROM ALL_CONSTRAINTS C
                                                      LEFT JOIN ALL_CONS_COLUMNS CC
                                                        ON C.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
                                                      LEFT JOIN ALL_TAB_COLUMNS TC
                                                        ON TC.COLUMN_NAME = CC.COLUMN_NAME
                                                       AND TC.OWNER = CC.OWNER
                                                       AND TC.TABLE_NAME = CC.TABLE_NAME
                                                     WHERE CC.CONSTRAINT_NAME = '{0}'
                                                    ",pkName), conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            try
            {
                conn.Open();
                adapter.Fill(results);
            }
            catch { }
            finally
            {
                conn.Close();
            }

            return results;
        }

        private void simpleButtonFind_Click(object sender, EventArgs e)
        {
            String owner = textEditOwner.Text.ToUpper() ;
            string table = textEditTableName.Text.ToUpper();
            SetNode(owner, table);
        }

        private void SetNode(String owner, String table)
        {
            treeList1.BeginUnboundLoad();
            TreeListNode currNode;
            if (treeList1.FocusedNode == null)
            {
                currNode =treeList1.AppendNode(new object[]{"ROOT",owner,table,""},null);
            }
            else
            {
                currNode = treeList1.FocusedNode;
            }
            String pkname = GetPKName(owner, table);
            currNode.SetValue("treeListColumnpk", pkname);
            DataTable referenceTables = GetReferenceTable(pkname, owner);
            referenceTables.Merge(GetRecessiveRelation(GetPrimaryKeyColumns(pkname)));
            if (referenceTables.Rows.Count == 0) MessageBox.Show("没有其他数据表格应用这张表啦");

            currNode.Nodes.Clear();
            foreach (DataRow row in referenceTables.Rows)
            {
                TreeListNode tableNode = treeList1.AppendNode(new object[] {row["RELATION_TYPE"], row["OWNER"] ,row["TABLE_NAME"],""}, currNode);
            }
            currNode.ExpandAll();
            treeList1.EndUnboundLoad();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
            {
                MessageBox.Show("select one", "error");
            }

            TreeListNode node = treeList1.FocusedNode;
            String table = node.GetValue("treeListColumn2") as String;
            String owner = node.GetValue("treeListColumn1") as String;
            SetNode(owner, table);
        }

       
    }
}
