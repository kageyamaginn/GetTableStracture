using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GetTableStracture
{
    public partial class ExtractTableNameList : Form
    {
        Regex funtionRex=new Regex(@"\w+\([\s\w\,]+\)");
        Regex selectFieldReg = new Regex(@"select [\s\S]+ from", RegexOptions.IgnoreCase);

        public ExtractTableNameList()
        {
            InitializeComponent();
        }

        private void ExtractTableNameList_Load(object sender, EventArgs e)
        {

        }
        public Dictionary<String, String[]> tableList = new Dictionary<String, string[]>();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ExtractTableName();
            ExtractFields();
            BindTableList();
        }

        private void ExtractTableName()
        {
            Regex reg = new Regex(@"(from|join)\s{1}(\w+\.)?\w+", RegexOptions.IgnoreCase);
            foreach (Match m in reg.Matches(textBox1.Text))
            {
                String matchString = m.ToString().ToUpper();
                matchString = matchString.Replace("FROM", "").Replace("JOIN", "").Replace("  ", " ");
                if (matchString.Contains("."))
                {
                    String hashKey = matchString.Trim();
                    if (!tableList.ContainsKey(hashKey))
                    {
                        tableList.Add(hashKey, matchString.Split('.'));
                    }
                }
                else
                {
                    String hashKey = matchString.Trim();
                    if (!tableList.ContainsKey(hashKey))
                    {
                        tableList.Add(hashKey, new String[] { matchString });
                    }
                }
            }
        }

        public void CheckTableName(List<String> tableName)
        {
            
        }

        private void ExtractFields()
        {
            MatchCollection fieldsString = selectFieldReg.Matches(textBox1.Text);
            for (int matchIndex = 0; matchIndex < fieldsString.Count; matchIndex++)
            {
                if (matchIndex == 0)//非子查询中的select子句
                {
                    String matchedString = fieldsString[matchIndex].Value.ToUpper();

                    SplitToFields(matchedString);
                }
                else
                { 

                }
            }
        }

        private void SplitToFields(String selectCase)
        {
            selectCase = selectCase.Replace("FROM", "").Replace("SELECT", "");
        }

        private void BindTableList()
        {
            listBoxControlTableList.Items.Clear();
            foreach (String[] tableFullName in tableList.Values)
            {
                if(tableFullName.Length==1)
                {
                    listBoxControlTableList.Items.Add(tableFullName[0].Trim());
                }
                else
                {
                    listBoxControlTableList.Items.Add(String.Format("{0}.{1}", tableFullName[0].Trim(), tableFullName[1].Trim()));
                }

                
            }
        }

        private void listBoxControlTableList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tableList.Remove(listBoxControlTableList.SelectedItem.ToString());
            listBoxControlTableList.Items.RemoveAt(listBoxControlTableList.SelectedIndex);
           
        }

        private void barButtonItemCopyTableList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (String tableKey in tableList.Keys)
            {
                strBuilder.AppendLine(String.Format("{0}", tableKey));
            }
            Clipboard.SetText(strBuilder.ToString());
        }

        private void barButtonItemClearAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tableList.Clear();
            listBoxControlTableList.Items.Clear();
        }
    }
}
