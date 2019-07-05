using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTableStracture.Properties
{
    public partial class LikeTableForm : Form
    {
        String connString;
        public String OwnerName { get; set; }
        public LikeTableForm(String connString)
        {
            InitializeComponent();
            repositoryItemButtonEditTableINameLike.KeyDown += new KeyEventHandler(repositoryItemButtonEditTableINameLike_KeyDown);
            this.connString = connString;
            TableNames = new List<string>();
            ConfirmedTableNames = new List<string>();
        }

        

        public List<String> TableNames { get; set; }

        public List<String> ConfirmedTableNames { get; set; }

        private void simpleButtonLike_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = null;
            String ownerString="";
            if(!String.IsNullOrEmpty(OwnerName))
            {
                ownerString=String.Format(" AND OWNER='{0}'",OwnerName);
            }

            if (checkButtonSearchCondition.Text == "Table")
            {
                cmd = new OracleCommand(String.Format("SELECT TABLE_NAME,OWNER FROM ALL_TABLES WHERE TABLE_NAME LIKE2 '%" + textEditLikeName.Text + "%'" + ownerString), conn);
            }
            else
            {
                cmd = new OracleCommand("SELECT DISTINCT TABLE_NAME,OWNER FROM ALL_TAB_COLUMNS WHERE COLUMN_NAME LIKE2 '%" + textEditLikeName.Text + "%'" + ownerString, conn);
            }

           
            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        TableNames.Add(String.Format("{0} [{1}]",reader.GetString(0),reader.GetString(1)));
                    }
                } 
                TableNames.Sort();
                checkedListBoxControlResults.DataSource = TableNames;
            }
            catch (Exception ex)
            { }
            finally {

                conn.Close();
            }
            
        }

        private void simpleButtonConfirm_Click(object sender, EventArgs e)
        {
            foreach (object tableName in checkedListBoxControlResults.CheckedItems)
            {
                ConfirmedTableNames.Add(tableName.ToString().Split()[0]);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checkedListBoxControlResults.CheckSelectedItems();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checkedListBoxControlResults.UnCheckSelectedItems();
        }

        private void textEditLikeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButtonLike_Click(null, null);
 
            }
        }

        private void checkButtonSearchCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButtonSearchCondition.Text == "Table")
            {
                checkButtonSearchCondition.Text = "Column";
            }
            else
            {
                checkButtonSearchCondition.Text = "Table";
            }
        }



        private void repositoryItemButtonEditTableINameLike_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                if (String.IsNullOrEmpty(barEditItemTableNameLike.EditValue as String))
                {
                    checkedListBoxControlResults.DataSource = TableNames;
                }
                else
                {
                    checkedListBoxControlResults.DataSource = TableNames.Where(ta => ta.ToLower().Contains(barEditItemTableNameLike.EditValue.ToString())).ToList();
                    
                }
                checkedListBoxControlResults.Refresh();
                barEditItemTableNameLike.EditValue = null;
            }
        }

        void repositoryItemButtonEditTableINameLike_KeyDown(object sender, KeyEventArgs e)
        {
            repositoryItemButtonEditTableINameLike_ButtonPressed(null, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton() { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis }));
        }
    }
}
