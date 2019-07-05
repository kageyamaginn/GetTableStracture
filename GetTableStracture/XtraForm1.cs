using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GetTableStracture
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        DataTable source;
        public DataTable Source { set { source = value; gridControl1.DataSource = source; gridView1.PopulateColumns(); gridView1.RefreshData(); } }
    }
}