using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraGrid.Columns;

namespace GetTableStracture
{
    public partial class ExecuteSqlForm : Form
    {
        public String connString;
        public String InitializeCommand;

        public ExecuteSqlForm(String connString)
        {
            InitializeComponent();
            this.connString = connString;
        }

        public ExecuteSqlForm(String connString, String InitializeCommand):this(connString)
        {
            this.InitializeCommand = InitializeCommand;
        }

        private void ExecuteSqlForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(InitializeCommand))
            {
                memoEditScript.Text = InitializeCommand;
            }
        }

        private void barButtonItemRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable table = new DataTable();
            OracleConnection conn = new OracleConnection(connString);
            OracleDataAdapter adapter = new OracleDataAdapter(memoEditScript.Text,conn);
            try
            {
                conn.Open();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            gridControlResults.DataSource = table;
            gridViewResults.PopulateColumns();
            foreach (GridColumn column in gridViewResults.Columns)
            {
             column.Width=   gridViewResults.CalcColumnBestWidth(column);
            }
            gridControlResults.Refresh();
        }

        
    }
}
