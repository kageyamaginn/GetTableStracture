using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;


namespace GetTableStracture
{
    public partial class ColumnSelectingForm : Form
    {
        public ColumnSelectingForm()
        {
            InitializeComponent();
            this.FormClosing += ColumnSelectingForm_FormClosing;
        }

        void ColumnSelectingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetCheckList();
        }

        public void InitialForm(Dictionary<String, String[]> initialParam)
        {
            foreach (String tabKey in initialParam.Keys)
            {
                XtraTabPage page= xtraTabControl1.TabPages.Add(tabKey);
                page.Name = tabKey;
                CheckedListBox columnList = new CheckedListBox();
                columnList.Name = "columnList";
                columnList.Dock = DockStyle.Fill;
                foreach (String columnName in initialParam[tabKey])
                {
                    columnList.Items.Add(columnName);
                }
                page.Controls.Add(columnList);
            }
        }
       public Dictionary<String, String[]> ListChecked;
        public void GetCheckList()
        {
            ListChecked = new Dictionary<string, string[]>();
            foreach (XtraTabPage page in xtraTabControl1.TabPages)
            {
                Control[] controlListIndex= page.Controls.Find("columnList",false);
                List<string> values = new List<string>();
                foreach (object item in (controlListIndex[0] as CheckedListBox).CheckedItems)
                {
                    values.Add(item.ToString());
                }
                ListChecked.Add(page.Name, values.ToArray());
            }
        }
    }
}
