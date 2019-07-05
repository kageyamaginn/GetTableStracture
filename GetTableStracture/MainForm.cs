using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using GetTableStracture.Properties;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraWaitForm;
using System.Threading.Tasks;

namespace GetTableStracture
{
    public partial class FormMain : Form
    {
        ProgressPanel progressPanel1 = new ProgressPanel();
        String connectionString = "data source=wwwtst;user id=plm;password=testuser1;";
        //String connectionString = "data source=wwwdev;user id=plm;password=testuser1;";
        Dictionary<String, String> connections = new Dictionary<string, string>();
        DataTable connectionsTable = new System.Data.DataTable();

        DataTable ownerSource, searchTable;

        public FormMain()
        {
            InitializeComponent();
            progressPanel1.Location = new Point(this.Width / 2 - progressPanel1.Width / 2, this.Height / 2 - progressPanel1.Height / 2);
            progressPanel1.Visible = true;
            progressPanel1.Top = 100;
            this.Controls.Add(progressPanel1);
            DBconnection.ConnectionString = connectionString;
            //repositoryItemComboBoxConnectionString.SelectedIndexChanged += repositoryItemComboBoxConnectionString_SelectedIndexChanged;
            repositoryItemButtonEdit1.ButtonPressed += repositoryItemButtonEdit1_ButtonPressed;
            barEditItem3.EditValue = 200;
        }

        void barEditItemConnectionString_EditValueChanged(object sender, EventArgs e)
        {
            DBconnection.ConnectionString = connections[barEditItemConnectionString.EditValue.ToString()];
            if (GetOwner != null && !GetOwner.IsBusy)
            {
                progressPanel1.Location = new Point(progressPanel1.Parent.Width / 2, progressPanel1.Parent.Height / 2);
                progressPanel1.Visible = true;
                this.Enabled = false;
                GetOwner.RunWorkerAsync();
            }
            else
            {

            }
        }

        void repositoryItemButtonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            //throw new NotImplementedException();

            DataRow row = gridViewTables.GetFocusedDataRow();

            DataRow[] columnRows = row.GetChildRows("TABLE_COLUMNS");
            String selectColumn = "";

            foreach (DataRow childRow in columnRows)
            {
                if (childRow["DATA_TYPE"].ToString() == "RAW")
                {
                    selectColumn += String.Format("RAWTOHEX({0}) as {0}, ", childRow["COLUMN_NAME"].ToString());
                }
                else
                {
                    selectColumn += String.Format("{0}, ", childRow["COLUMN_NAME"].ToString());
                }
            }
            selectColumn = selectColumn.Remove(selectColumn.Length - 2);

            this.Cursor = Cursors.Hand;
            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
            String owner = "";
            if (lookUpEditOwner.EditValue == null)
            {
                owner = "PLM";
            }
            else
            {
                owner = lookUpEditOwner.EditValue.ToString();
            }


            OracleDataAdapter dataAdapter = new OracleDataAdapter(String.Format("SELECT {0} FROM {1}.{2}", selectColumn, row["OWNER"].ToString(), row[0].ToString()), conn);
            DataTable table = new System.Data.DataTable();
            conn.Open();


            dataAdapter.SelectCommand.CommandText += " WHERE ROWNUM<=" + barEditItem3.EditValue.ToString();


            dataAdapter.Fill(table);

            conn.Close();
            gridControlTabelPreview.DataSource = table;
            gridView1.PopulateColumns();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.BestFitColumns();
            gridControlTabelPreview.Refresh();
            this.Cursor = Cursors.Default;
        }


        BackgroundWorker GetOwner = new BackgroundWorker();

        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshConnectionString();
            foreach (String key in connections.Keys)
                repositoryItemComboBoxConnectionString.Items.Add(key);
            barEditItemConnectionString.EditValue = connections.Keys.First();
            searchTable = new System.Data.DataTable();
            searchTable.Columns.Add("TABLE_NAME");
            searchTable.PrimaryKey = new DataColumn[] { searchTable.Columns["table_name"] };
            gridControlSearchTables.DataSource = searchTable;
            GetOwner.DoWork += new DoWorkEventHandler(GetOwner_DoWork);
            GetOwner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetOwner_RunWorkerCompleted);
            GetOwner.RunWorkerAsync();

            result = new System.Data.DataSet();
            tables = new System.Data.DataTable();
            tables.TableName = "tables";
            tables.Columns.AddRange(new DataColumn[] { new DataColumn("TABLE_NAME"), new DataColumn("OWNER"), new DataColumn("DATABASE") });
            columns = new System.Data.DataTable();
            columns.TableName = "columns";
            columns.Columns.AddRange(new DataColumn[] { new DataColumn("TABLE_NAME"), new DataColumn("COLUMN_NAME"), new DataColumn("DATA_TYPE"), new DataColumn("DATA_LENGTH"), new DataColumn("NULLABLE") });
            result.Tables.Add(tables);
            result.Tables.Add(columns);
            result.Relations.Add("TABLE_COLUMNS", tables.Columns["TABLE_NAME"], columns.Columns["TABLE_NAME"]);
            gridControlTableStructure.DataSource = result.Tables["tables"];
            barEditItemConnectionString.EditValueChanged += barEditItemConnectionString_EditValueChanged;

        }

        void GetOwner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ownerSource = (DataTable)e.Result;
            if (ownerSource != null)
            {
                lookUpEditOwner.Properties.DataSource = ownerSource;
                lookUpEditOwner.Properties.DisplayMember = "OWNER";
                lookUpEditOwner.Properties.ValueMember = "OWNER";

                lookUpEditOwner.Properties.ShowHeader = false;
                lookUpEditOwner.Properties.ShowFooter = false;

                progressPanel1.Visible = false;
                this.Enabled = true;
            }
        }

        void GetOwner_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = GetAllOwners();
        }

        void RefreshConnectionString()
        {
            connectionsTable.Columns.AddRange(new DataColumn[] { new DataColumn("NAME"), new DataColumn("CONNECTION_STRING"), new DataColumn("GROUP", typeof(int)) });

            FileStream fs = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextScript", "Connections.txt"));
            StreamReader reader = new StreamReader(fs);
            String connectionScriptsContent = reader.ReadToEnd();
            fs.Close();
            reader.Dispose();

            String[] connItems = connectionScriptsContent.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String connItem in connItems)
            {
                String[] connKeyAndValue = connItem.Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                connections.Add(connKeyAndValue[0], connKeyAndValue[1]);
                DataRow evaRow = connectionsTable.NewRow();
                evaRow["NAME"] = connKeyAndValue[0];
                evaRow["CONNECTION_STRING"] = connKeyAndValue[1];
                evaRow["GROUP"] = connKeyAndValue[2];
                connectionsTable.Rows.Add(evaRow);
            }
        }

        DataTable GetAllOwners()
        {
            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
            OracleCommand cmd = new OracleCommand("SELECT OWNER FROM ALL_TABLES GROUP BY OWNER order by owner", conn);
            cmd.BindByName = true;
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable ownerSource = new System.Data.DataTable();
            ownerSource.Columns.Add("OWNER");
            try
            {
                conn.Open();
                adapter.Fill(ownerSource);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally
            {
                conn.Close();
            }
            return ownerSource;
        }

        DataSet result;

        DataTable tables, columns;

        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {

            foreach (DataRow searchRow in searchTable.Rows)
            {
                tables.Merge(GetTables(lookUpEditOwner.EditValue as String, searchRow["TABLE_NAME"] as String));
                columns.Merge(GetColumns(lookUpEditOwner.EditValue as String, searchRow["TABLE_NAME"] as String));
            }

            gridControlTableStructure.DataSource = result.Tables["tables"];
            gridViewTables.ExpandAllGroups();
        }

        DataTable GetTables(String owner, String table_name)
        {
            DataTable tables = new System.Data.DataTable();
            tables.TableName = "tables";
            tables.Columns.AddRange(new DataColumn[] { new DataColumn("TABLE_NAME"), new DataColumn("OWNER"), new DataColumn("DATABASE") });

            String groupNumber = connectionsTable.Select(String.Format("NAME='{0}'", barEditItemConnectionString.EditValue.ToString()))[0]["GROUP"].ToString();

            foreach (DataRow cr in connectionsTable.Select(String.Format("GROUP={0}", groupNumber)))
            {
                if (String.IsNullOrEmpty(owner))
                {
                    owner = "PLM";
                }
                OracleConnection conn = new OracleConnection(cr["CONNECTION_STRING"].ToString());
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT TABLE_NAME,OWNER FROM ALL_TABLES WHERE OWNER=:OWNER AND TABLE_NAME=:TABLE_NAME UNION SELECT VIEW_NAME AS TABLE_NAME,OWNER FROM ALL_VIEWS WHERE OWNER=:OWNER AND VIEW_NAME=:TABLE_NAME", conn);
                adapter.SelectCommand.Parameters.Add("OWNER", owner.Trim());
                adapter.SelectCommand.Parameters.Add("TABLE_NAME", table_name.Trim());
                OracleCommand cmd = new OracleCommand(String.Format("SELECT TABLE_NAME,OWNER FROM ALL_TABLES WHERE OWNER='{0}' AND TABLE_NAME='{1}' UNION SELECT VIEW_NAME AS TABLE_NAME,OWNER FROM ALL_VIEWS WHERE OWNER='{0}' AND VIEW_NAME='{1}'", owner, table_name), conn);
                try
                {
                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DataRow evaRow = tables.NewRow();
                        if (!reader.IsDBNull(0))
                        {
                            evaRow[0] = reader.GetString(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            evaRow[1] = reader.GetString(1);
                        }
                        evaRow[2] = cr["NAME"].ToString();
                        tables.Rows.Add(evaRow);
                    }
                }
                finally { conn.Close(); }
            }
            return tables;
        }

        DataTable GetColumns(String owner, String table_name, String database = "")
        {
            string connString = "";
            if (!String.IsNullOrEmpty(database))
            {
                connString = connections[database];
            }
            else
            {
                connString = connections[barEditItemConnectionString.EditValue.ToString()];
            }


            if (String.IsNullOrEmpty(owner))
            {
                owner = "PLM";
            }
            DataTable columns = new System.Data.DataTable();
            columns.TableName = "columns";
            columns.Columns.AddRange(new DataColumn[] { new DataColumn("TABLE_NAME"), new DataColumn("COLUMN_NAME"), new DataColumn("DATA_TYPE"), new DataColumn("DATA_LENGTH"), new DataColumn("NULLABLE") });
            OracleConnection conn = new OracleConnection(connString);
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT TABLE_NAME,COLUMN_NAME,DATA_TYPE,DATA_LENGTH,NULLABLE FROM ALL_TAB_COLUMNS WHERE OWNER=:OWNER AND TABLE_NAME=:TABLE_NAME ORDER BY COLUMN_ID", conn);
            adapter.SelectCommand.Parameters.Add("OWNER", owner);
            adapter.SelectCommand.Parameters.Add("TABLE_NAME", table_name);
            try
            {
                conn.Open();
                adapter.Fill(columns);
            }
            finally
            {
                conn.Close();
            }
            return columns;
        }

        private void barButtonItemExportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (result == null) return;
            Report r = new Report(result);


        }

        private void simpleButtonClearSearch_Click(object sender, EventArgs e)
        {
            while (gridViewSearchTable.RowCount != 0)
                gridViewSearchTable.DeleteRow(0);
        }

        bool CheckTableExist(String owner, String tableName)
        {
            return GetTables(owner, tableName).Rows.Count != 0;
        }

        private void gridViewSearchTable_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < gridViewSearchTable.RowCount; rowIndex++)
            {
                if (gridViewSearchTable.GetRowCellValue(rowIndex, "TABLE_NAME").Equals(gridViewSearchTable.GetRowCellValue(e.RowHandle, "TABLE_NAME")))
                {
                    e.Valid = false;
                    e.ErrorText = "Table name you typed has already exsit.";
                    return;
                }
            }
            if (CheckTableExist(lookUpEditOwner.EditValue as String, gridViewSearchTable.GetRowCellValue(e.RowHandle, "TABLE_NAME") as String))
            {
                tables.Merge(GetTables(lookUpEditOwner.EditValue as String, gridViewSearchTable.GetRowCellValue(e.RowHandle, "TABLE_NAME") as String));
                columns.Merge(GetColumns(lookUpEditOwner.EditValue as String, gridViewSearchTable.GetRowCellValue(e.RowHandle, "TABLE_NAME") as String));
                gridControlTableStructure.RefreshDataSource();
            }
            else
            {

                e.Valid = false;
                e.ErrorText = "Table name dose not in database.";
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void gridControlSearchTables_MouseEnter(object sender, EventArgs e)
        {
            if (!barCheckItemQuickAdd.Checked) return;
            if (!String.IsNullOrEmpty(Clipboard.GetText()))
            {
                for (int rowIndex = 0; rowIndex < gridViewSearchTable.RowCount; rowIndex++)
                {
                    if (gridViewSearchTable.GetRowCellValue(rowIndex, "TABLE_NAME").Equals(Clipboard.GetText().ToUpper().Trim()))
                    {

                        return;
                    }
                }

                if (Clipboard.GetText().Contains("."))
                {
                    String owner = Clipboard.GetText().Split('.')[0].Trim();
                    String table = Clipboard.GetText().Split('.')[1].Trim();

                    if (CheckTableExist(owner, table))
                    {
                        DataRow row = searchTable.NewRow();
                        row["TABLE_NAME"] = Clipboard.GetText().ToUpper().Trim();
                        searchTable.Rows.Add(row);
                        searchTable.AcceptChanges();
                        tables.Merge(GetTables(owner, table));
                        columns.Merge(GetColumns(owner, table));
                        gridControlTableStructure.RefreshDataSource();
                    }
                }
                else
                {
                    if (CheckTableExist(lookUpEditOwner.EditValue as String, Clipboard.GetText().ToUpper().Trim()))
                    {
                        DataRow row = searchTable.NewRow();
                        row["TABLE_NAME"] = Clipboard.GetText().ToUpper().Trim();
                        searchTable.Rows.Add(row);
                        searchTable.AcceptChanges();
                        tables.Merge(GetTables(lookUpEditOwner.EditValue as String, Clipboard.GetText().ToUpper().Trim()));
                        columns.Merge(GetColumns(lookUpEditOwner.EditValue as String, Clipboard.GetText().ToUpper().Trim()));
                        gridControlTableStructure.RefreshDataSource();
                    }
                    else
                    {
                        Clipboard.Clear();
                    }
                }

                // gridControlSearchTables.RefreshDataSource();
            }
            //gridViewSearchTable.SetRowCellValue();
        }

        private void gridViewSearchTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                popupMenuTableMenu.ShowPopup(new Point(this.Location.X + gridControlSearchTables.Location.X + e.X, this.Location.Y + gridControlSearchTables.Location.Y + e.Y));
            }
        }

        private void barButtonItemCreateEntityCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String tableName = gridViewSearchTable.GetFocusedDataRow()["TABLE_NAME"] as String;
            StringBuilder entityString = new StringBuilder();
            String entityName = String.Empty;
            String[] entitiesName = tableName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < entitiesName.Length; i++)
            {
                entitiesName[i] = entitiesName[i].ToLower();

                entitiesName[i] = entitiesName[i].Remove(0, 1).Insert(0, entitiesName[0][0].ToString().ToUpper());

                entityName += entitiesName[i];
            }
            //entityString.AppendLine(String.Format("[TableNameAttribute(\"{0}\")]", tableName));
            entityString.AppendLine(String.Format("public class {0}", GetEntityName(tableName)));

            entityString.AppendLine("{");

            DataRow[] selectColumns = columns.Select(String.Format("TABLE_NAME='{0}'", tableName));
            foreach (DataRow r in selectColumns)
            {
                //entityString.AppendLine(String.Format("\t[Column(\"{2}\")]\r\n", r["COLUMN_NAME"]));
                entityString.AppendLine(String.Format("\tpublic {0} {1}", GetTypeString(DatabaseType.Oracle, r["DATA_TYPE"] as String), GetEntityName(r["COLUMN_NAME"] as String)) + " { get; set; }");
            }

            entityString.AppendLine("}");

            Clipboard.SetText(entityString.ToString());
        }

        private String GetEntityName(string dbname)
        {
            String[] words = dbname.Split(new char[] { '_' });
            StringBuilder sb = new StringBuilder();
            foreach (string w in words)
            {
                string lower_w = w.ToLower();

                sb.Append(lower_w.First().ToString().ToUpper());
                sb.Append(lower_w.Substring(1));
            }
            return sb.ToString();
        }

        public enum DatabaseType
        {
            Sql = 0,
            Oracle = 1
        }

        String GetTypeString(DatabaseType databaseType, String fieldType)
        {
            String typeString = String.Empty;
            switch (databaseType)
            {
                case DatabaseType.Oracle:
                    {
                        switch (fieldType)
                        {
                            case "NVARCHAR2":
                                {
                                    return "String";
                                }
                            case "NUMBER":
                                {
                                    return "Decimal";
                                }
                            case "RAW":
                                {
                                    return "byte[]";
                                }
                            case "BLOB":
                                {
                                    return "byte[]";
                                }
                            case "LONG":
                                {
                                    return "long";
                                }
                            case "CHAR":
                                {
                                    return "String";
                                }
                            case "DATE":
                                {
                                    return "DateTime";
                                }
                            case "DECIMAL":
                                {
                                    return "Decimal";
                                }
                            case "DOUBLE":
                                {
                                    return "Decimal";
                                }
                            case "INT32":
                                {
                                    return "int";
                                }
                            case "VARCHAR2":
                                {
                                    return "String";
                                }
                            case "CLOB":
                                {
                                    return "String";
                                }
                        }
                        break;
                    }
                case DatabaseType.Sql:
                    {
                        switch (fieldType)
                        {
                            case "Char":
                                {
                                    return "String";
                                }
                            case "Date":
                                {
                                    return "DateTime";
                                }
                            case "DateTime":
                                {
                                    return "DateTime";
                                }
                            case "Decimal":
                                {
                                    return "decimal";
                                }
                            case "Float":
                                {
                                    return "float";
                                }
                            case "Text":
                                {
                                    break;
                                }
                            case "NVarChar":
                                {
                                    return "String";
                                }
                            case "NChar":
                                {
                                    return "String";
                                }
                        }
                        break;
                    }
            }
            return typeString;
        }

        private void barButtonItemCreateDataTableCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItemConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfigueForm cf = new ConfigueForm();
            if (cf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void barButtonItemReportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.FileName = "Get Table Stra.xlsx";
            savefileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            savefileDialog.ShowDialog();


            Excel.Application app = new Excel.Application();
            app.Visible = false;
            app.AlertBeforeOverwriting = false;
            app.DisplayAlerts = false;
            Excel.Workbook book = app.Workbooks.Add();
            book.Styles.Add("TableTile").Interior.Color = Color.FromArgb(217, 232, 253);
            book.Styles["TableTile"].Font.Bold = true;
            book.Styles["TableTile"].Font.Size = 12;
            // Excel.Worksheet sheet = book.Worksheets[1];
            int tableStart = 1;
            foreach (DataRow tableRow in tables.Rows)
            {
                Excel.Worksheet sheet = book.Worksheets.Add(Before: book.Worksheets[1]);
                sheet.Name = tableRow["TABLE_NAME"] as String;
                DataRow[] cols = columns.Select("TABLE_NAME='" + sheet.Name + "'");
                sheet.Range[sheet.Cells[tableStart, 1], sheet.Cells[tableStart, 4]].Merge();
                sheet.Range["A1"].Value = String.Format("Table Name: {0}", sheet.Name);

                sheet.Cells[3, 1] = "Column Name";
                sheet.Cells[3, 2] = "Data Type";
                sheet.Cells[3, 3] = "Data Length";
                sheet.Cells[3, 4] = "Nullable";

                ((Excel.Range)sheet.Rows[RowIndex: 3]).Style = book.Styles["TableTile"];
                int lineCount = 0;
                for (int i = 4; i < cols.Count() + 4; i++)
                {
                    sheet.Cells[i, 1] = cols[i - 4]["COLUMN_NAME"]; ;
                    sheet.Cells[i, 2] = cols[i - 4]["DATA_TYPE"];
                    sheet.Cells[i, 3] = cols[i - 4]["DATA_LENGTH"];
                    sheet.Cells[i, 4] = cols[i - 4]["NULLABLE"];
                    lineCount = i;
                }
                ((Excel.Borders)sheet.Range[Cell1: sheet.Cells[1, 1], Cell2: sheet.Cells[lineCount, 4]].Borders).Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDashDotDot;
                ((Excel.Borders)sheet.Range[Cell1: sheet.Cells[1, 1], Cell2: sheet.Cells[lineCount, 4]].Borders).Item[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDashDotDot;
                ((Excel.Borders)sheet.Range[Cell1: sheet.Cells[1, 1], Cell2: sheet.Cells[lineCount, 4]].Borders).Item[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDashDotDot;
                ((Excel.Borders)sheet.Range[Cell1: sheet.Cells[1, 1], Cell2: sheet.Cells[lineCount, 4]].Borders).Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDashDotDot;
                //((Excel.Borders)sheet.Range[Cell1: sheet.Cells[1, 1], Cell2: sheet.Cells[lineCount, 4]].Borders)

                sheet.Columns[1].AutoFit();
                sheet.Columns[2].AutoFit();
                sheet.Columns[3].AutoFit();
                sheet.Columns[4].AutoFit();
                sheet.Columns[5].AutoFit();


            }

            book.SaveAs(savefileDialog.FileName);
            book.Close();
            Marshal.FinalReleaseComObject(book);
            app.Quit();
            Marshal.FinalReleaseComObject(app);
            if (MessageBox.Show("Wether open file?", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo(savefileDialog.FileName));
            }

        }

        private void gridViewTables_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (!barCheckItemGetData.Checked) return;
            DataRow row = gridViewTables.GetDataRow(e.RowHandle);

            this.Cursor = Cursors.Hand;
            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);

            OracleCommand cmd = new OracleCommand(String.Format("SELECT COUNT(*) FROM {0}", row[0].ToString()), conn);

            OracleDataAdapter dataAdapter = new OracleDataAdapter(String.Format("SELECT * FROM {0}", row[0].ToString()), conn);
            DataTable table = new System.Data.DataTable();
            conn.Open();

            if (Convert.ToInt32(cmd.ExecuteScalar()) > 10000)
            {
                dataAdapter.SelectCommand.CommandText += " WHERE ROWNUM<=10000";
            }

            dataAdapter.Fill(table);
            conn.Close();
            gridControlTabelPreview.DataSource = table;
            gridView1.PopulateColumns();
            gridControlTabelPreview.Refresh();
            this.Cursor = Cursors.Default;
        }

        DataTable findResutlTable = null;

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            OracleConnection conn = new OracleConnection();


            XtraForm1 xf = new XtraForm1();
            // xf.Text = tableRow[0].ToString();
            xf.Source = findResutlTable;
            xf.Show();
        }

        private void gridViewSearchTable_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow currentRow = gridViewSearchTable.GetFocusedDataRow();
        }

        BackgroundWorker GetTableInfoWorker;

        private void barButtonItemLikeTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            LikeTableForm lt = new LikeTableForm(connections[barEditItemConnectionString.EditValue.ToString()]);
            lt.OwnerName = lookUpEditOwner.EditValue as String;
            lt.ShowDialog();
            if (lt.ConfirmedTableNames == null) return;
            if (GetTableInfoWorker == null)
            {
                GetTableInfoWorker = new BackgroundWorker();
                GetTableInfoWorker.DoWork += GetTableInfoWorker_DoWork;
                GetTableInfoWorker.WorkerReportsProgress = true;
                GetTableInfoWorker.RunWorkerCompleted += GetTableInfoWorker_RunWorkerCompleted;
                GetTableInfoWorker.ProgressChanged += GetTableInfoWorker_ProgressChanged;
            }

            progressPanel1.Location = new Point(progressPanel1.Parent.Width / 2, progressPanel1.Parent.Height / 2);
            progressPanel1.Visible = true;
            this.Enabled = false;
            GetTableInfoWorker.RunWorkerAsync(lt.ConfirmedTableNames);


        }

        void GetTableInfoWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            KeyValuePair<DataTable, DataTable> t = (KeyValuePair<DataTable, DataTable>)e.UserState;
            tables.Merge(t.Key);
            columns.Merge(t.Value);
            gridControlTableStructure.RefreshDataSource();
        }

        void GetTableInfoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressPanel1.Visible = false;
            this.Enabled = true;
        }

        void GetTableInfoWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<String> tableNames = (List<String>)e.Argument;
            foreach (String tableName in tableNames)
            {
                String owner = "";
                if (lookUpEditOwner.EditValue == null)
                {
                    owner = "PLM";
                }
                else
                {
                    owner = lookUpEditOwner.EditValue.ToString();
                }
                GetTableInfoWorker.ReportProgress(0, new KeyValuePair<DataTable, DataTable>(GetTables(owner, tableName), GetColumns(owner, tableName)));

            }
        }

        private void gridViewTables_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            ((GridView)gridViewTables.GetDetailView(e.RowHandle, e.RelationIndex)).Columns["TABLE_NAME"].Visible = false;
        }

        private void gridViewTables_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                popupMenu1.ShowPopup(new Point(this.Location.X + splitContainerControl1.Location.X + e.X + gridControlTableStructure.Location.X, e.Y + splitContainerControl1.Location.Y + this.Location.Y + gridControlTableStructure.Location.Y));
            }
        }

        private void barButtonItemExpandAllRows_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int rowHandle = 0; rowHandle < gridViewTables.RowCount; rowHandle++)
            {
                gridViewTables.ExpandMasterRow(rowHandle, 0);
            }
        }

        private void barButtonItemOpenSolution_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Process.Start(new ProcessStartInfo(@"d:\TestProject\GetTableStracture\GetTableStracture.sln"));
            Application.Exit();
        }

        private void barButtonItemCopyTableName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int rowIndex in gridViewTables.GetSelectedRows())
            {
                sb.AppendLine(gridViewTables.GetRowCellValue(rowIndex, "TABLE_NAME").ToString());
            }

            Clipboard.SetText(sb.ToString());
        }

        private void barButtonItemCopyColumnName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String columnName = "";
            String tableAlias = "";
            OneTextInputForm o = new OneTextInputForm("Table Alias");
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tableAlias = o.Result + ".";

            int[] selectedRows = ((GridView)gridViewTables.GetDetailView(gridViewTables.FocusedRowHandle, 0)).GetSelectedRows();
            if (gridControlTableStructure.FocusedView.Name != "gridViewColumns")
            {
                MessageBox.Show("Please select column and press copy column button to copy column names");
            }

            GridView columnTable = (GridView)((GridView)gridViewTables.GetDetailView(gridViewTables.FocusedRowHandle, 0));
            foreach (int rowHandle in selectedRows)
            {
                columnName += (tableAlias == "." ? "" : tableAlias) + columnTable.GetDataRow(rowHandle)["COLUMN_NAME"].ToString() + ",\r\n";
            }

            columnName = columnName.Remove(columnName.Count() - 3);
            Clipboard.SetText(columnName);
        }

        private void gridViewColumns_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridControlTableStructure.FocusedView.Name == "gridViewColumns" && (((DataTable)gridControlTabelPreview.DataSource)) != null)
            {
                String focuedColumn = ((GridView)gridControlTableStructure.FocusedView).GetFocusedDataRow()["COLUMN_NAME"].ToString();
                if (((DataTable)gridControlTabelPreview.DataSource).Columns.Contains(focuedColumn))
                {
                    ((GridView)gridControlTabelPreview.MainView).FocusedColumn = ((GridView)gridControlTabelPreview.MainView).Columns[focuedColumn];
                }
            }
        }

        private void barButtonItemRestart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void barButtonItemCollepseAllRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int rowHandle = 0; rowHandle < gridViewTables.RowCount; rowHandle++)
            {
                gridViewTables.CollapseMasterRow(rowHandle, 0);
            }
        }

        private void barButtonItemExcuteSqlScript_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteSqlForm exForm = new ExecuteSqlForm(connections[barEditItemConnectionString.EditValue.ToString()]);
            exForm.Show();
        }

        private void barButtonItemSearchThisTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteSqlForm exForm = new ExecuteSqlForm(connections[barEditItemConnectionString.EditValue.ToString()], String.Format("SELECT * FROM {0}.{1}", gridViewTables.GetFocusedDataRow()["OWNER"].ToString(), gridViewTables.GetFocusedDataRow()["TABLE_NAME"].ToString()));
            exForm.Show();
        }

        private void barButtonItemGroupColumn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable table = new System.Data.DataTable();
            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
            OracleDataAdapter cmd = new OracleDataAdapter(String.Format("SELECT {0},COUNT(*) AS COUNT FROM {1}.{2} GrouP BY {0}", ((GridView)gridControlTableStructure.FocusedView).GetFocusedDataRow()["COLUMN_NAME"].ToString(),
                gridViewTables.GetFocusedDataRow()["OWNER"].ToString(), gridViewTables.GetFocusedDataRow()["TABLE_NAME"].ToString()), conn);
            try
            {
                DataTable temp = new System.Data.DataTable();
                temp.TableName = "FromDatabase";
                conn.Open();
                cmd.Fill(temp);

                if (temp.Columns[0].DataType == typeof(byte[]))
                {
                    table.Columns.Add(temp.Columns[0].ColumnName, typeof(string));
                    table.Columns.Add(temp.Columns[1].ColumnName, temp.Columns[1].DataType);
                    foreach (DataRow row in temp.Rows)
                    {
                        DataRow tem = table.NewRow();
                        tem[temp.Columns[0].ColumnName] = new Guid((byte[])row[temp.Columns[0].ColumnName]).ToString();
                        tem[temp.Columns[1].ColumnName] = row[temp.Columns[1].ColumnName];
                        table.Rows.Add(tem);
                    }
                }
                else
                {
                    table = temp;
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }

            GroupColumnForm gcForm = new GroupColumnForm(table);
            gcForm.Location = new Point(this.Location.X + gridControlTableStructure.Location.X, this.Location.Y + gridControlTableStructure.Location.Y);
            gcForm.Show();
        }

        private void barButtonItemTableProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable results = GetTableKeys(gridViewTables.GetFocusedDataRow()["TABLE_NAME"].ToString());
            TableProperty tp = new TableProperty(results);
            tp.ShowDialog();
        }

        DataTable GetTableKeys(String tableName)
        {
            DataTable results = new System.Data.DataTable();
            results.Columns.Add("OWNER");
            results.Columns.Add("CONSTRAINT_NAME");
            results.Columns.Add("CONSTRAINT_TYPE");
            results.Columns.Add("STATUS");
            results.Columns.Add("COLUMN_NAME");
            results.Columns.Add("POSITION");
            results.Columns.Add("SEARCH_CONDITION");

            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
            OracleCommand cmd = new OracleCommand(String.Format("SELECT C.OWNER,C.CONSTRAINT_NAME,C.CONSTRAINT_TYPE,C.STATUS, CC.COLUMN_NAME, CC.POSITION,C.SEARCH_CONDITION FROM ALL_CONSTRAINTS C JOIN ALL_CONS_COLUMNS CC ON C.OWNER=CC.OWNER AND C.TABLE_NAME=CC.TABLE_NAME AND C.CONSTRAINT_NAME=CC.CONSTRAINT_NAME WHERE CC.TABLE_NAME='{0}'", tableName), conn);
            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataRow keyRow = results.NewRow();
                    if (!reader.IsDBNull(0))
                        keyRow["OWNER"] = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        keyRow["CONSTRAINT_NAME"] = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        keyRow["CONSTRAINT_TYPE"] = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        keyRow["STATUS"] = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        keyRow["COLUMN_NAME"] = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        keyRow["POSITION"] = reader.GetDecimal(5);
                    if (!reader.IsDBNull(6))
                        keyRow["SEARCH_CONDITION"] = reader.GetString(6);

                    results.Rows.Add(keyRow);
                }
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            return results;
        }

        private void gridViewColumns_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

        }

        private void barButtonItemSelecteCommand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dictionary<String, string> selctedTables = new Dictionary<string, string>();
            String[] selectedTable = new String[gridViewTables.SelectedRowsCount];
            int fillIndex = 0;
            foreach (int rowHandle in gridViewTables.GetSelectedRows())
            {
                selectedTable[fillIndex++] = gridViewTables.GetRowCellValue(rowHandle, "TABLE_NAME").ToString();
                selctedTables.Add(gridViewTables.GetRowCellValue(rowHandle, "TABLE_NAME").ToString(), gridViewTables.GetRowCellValue(rowHandle, "OWNER").ToString());
            }

            if (gridViewTables.SelectedRowsCount == 1)
            {
                String cmdString = "SELECT\r\n{0}FROM {1}.{2}";
                String columnString = "";
                String tableName = gridViewTables.GetRowCellValue(gridViewTables.GetSelectedRows()[0], "TABLE_NAME").ToString();
                String ownerName = gridViewTables.GetRowCellValue(gridViewTables.GetSelectedRows()[0], "OWNER").ToString();
                DataRow[] allColumnRows = columns.Select(String.Format("TABLE_NAME='{0}'", gridViewTables.GetRowCellValue(gridViewTables.GetSelectedRows()[0], "TABLE_NAME").ToString()));
                for (int crIndex = 0; crIndex < allColumnRows.Length; crIndex++)
                {
                    columnString += String.Format("{0}{1}\r\n", allColumnRows[crIndex]["COLUMN_NAME"].ToString(), crIndex == allColumnRows.Length - 1 ? "" : ",");
                }
                Clipboard.SetText(String.Format(cmdString, columnString, ownerName, tableName));
            }
            else if (gridViewTables.SelectedRowsCount == 0)
            { }
            else
            {
                MultiTableCommandCreate(selctedTables);
            }



        }

        private void MultiTableCommandCreate(Dictionary<String, String> tables)
        {
            DataTable t = DBconnection.GetTablePKFK(tables);
        }

        private void barButtonItemCheckIndexes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable results = new System.Data.DataTable();
            OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
            OracleDataAdapter adapter = new OracleDataAdapter(String.Format(@"SELECT FROM ALL_INDEXED IND LEFT JOIN ALL_IND_COLUMNS IND_C ON IND.INDEX_NAME=IND_C.INDEX_NAME AND
IND.INDEX_OWNER = IND_C.INDEX_OWNER AND IND.TABLE_NAME=IND_C.TABLE_NAME WHERE IND.TABLE_NAME='{0}'", gridViewTables.GetFocusedRowCellValue("TABLE_NAME").ToString()), conn);
            try
            {
                conn.Open();
                adapter.Fill(results);
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            TableProperty tp = new TableProperty(results);
            tp.ShowDialog();
        }

        private void barButtonItemClearResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            columns.Clear();
            tables.Clear();
            while (gridViewSearchTable.RowCount != 0)
                gridViewSearchTable.DeleteRow(0);

        }

        private void barButtonItemExtractTableName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExtractTableNameList xtrTableFrom = new ExtractTableNameList();
            xtrTableFrom.ShowDialog();
            if (xtrTableFrom.tableList.Count > 0)
            {
                foreach (String[] allTabName in xtrTableFrom.tableList.Values)
                {
                    DataTable tempTable = GetTables(allTabName[0].Trim(), allTabName[1].Trim());
                    tables.Merge(tempTable);
                    DataRow[] tr = tempTable.Select(String.Format("TABLE_NAME='{1}' AND OWNER='{0}' ", allTabName[0].Trim(), allTabName[1].Trim()));
                    if (tr != null && tr.Length > 0)
                    {
                        columns.Merge(GetColumns(allTabName[0].Trim(), allTabName[1].Trim(), tr[0]["DATABASE"].ToString().Trim()));
                    }

                    gridControlTableStructure.RefreshDataSource();
                }

                gridControlSearchTables_MouseEnter(null, null);
            }
        }

        private void gridControlTableStructure_Click(object sender, EventArgs e)
        {

        }
        public class EntityTable
        {
            public string Owner { get; set; }
            public string TableName { get; set; }
            public List<EntityColumn> Columns { get; set; }
            public string EntityName { get { return GetPropertyName(TableName); } }
            public EntityTable()
            {
                Columns = new List<EntityColumn>();
            }
            public string ToString(String nsName, bool needField = false,bool useAnnotation=false)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.ComponentModel.DataAnnotations;");

                sb.AppendLine("namespace " + nsName);
                sb.AppendLine("{");
                //print comment
                sb.AppendLine(String.Format("\t//this entity is abstract from {0}.{1}", Owner, TableName));

                //print col
                StringBuilder columnPrint = new StringBuilder();
                foreach (EntityColumn col in Columns)
                {
                    columnPrint.AppendLine(String.Format("{0}", col.ToString(tab: 2,useFeild:needField,useAnnotation:useAnnotation)));
                }
                //create entity
                sb.AppendLine(String.Format("\tpublic class {0}\r\n\t{{\r\n\t{1}\r\n\t}}", GetPropertyName(TableName), columnPrint.ToString()));
                sb.AppendLine("}");
                return sb.ToString();
            }

            private String GetPropertyName(string columnName)
            {
                string[] words = columnName.ToLower().Split('_');
                string result = "";
                for (int index = 0; index < words.Length; index++)
                {
                    result += words[index][0].ToString().ToUpper();
                    result += words[index].Remove(0, 1);
                }
                return result;
            }
        }
        public class EntityColumn
        {
            public EntityColumn()
            {
                this.Cons = new List<EntityConstraint>();
            }
            /// <summary>
            /// 
            /// </summary>

            public string Owner { get; set; }
            public String TableName { get; set; }
            public decimal Length { get; set; }
            public decimal ColumnId { get; set; }
            public string ColumnName { get; set; }
            public String DataType { get; set; }
            public bool Nullable { get; set; }

            public bool IsPK { get; set; }
           

            public List<EntityConstraint> Cons { get; set; }

            public string ToString(int tab = 0, bool useFeild = false,bool useAnnotation=false)
            {
                StringBuilder sb = new StringBuilder();
                string tabContent = "";
                for (int ti = 0; ti < tab; ti++) { tabContent += "\t"; }
                //annotation & comments from constraints info

                foreach (EntityFKCons fk in Cons.FindAll(c => c is EntityFKCons))
                {
                    sb.AppendLine(String.Format(tabContent + "//FK[{3}], reference {0}.{1}.{2}", fk.RefColumns.First().Owner,
                        fk.RefColumns.First().TableName, fk.RefColumns.First().ColumnName, fk.Name));
                }
                if (IsPK)
                {
                    sb.AppendLine(String.Format(tabContent + "[Key]"));
                }
                if (!Nullable)
                {
                    sb.AppendLine(tabContent + "[Required]");
                }
                sb.AppendLine(String.Format(tabContent + (useAnnotation?"":"//")+"[System.ComponentModel.DataAnnotations.MaxLength({0})]", Length));
                foreach (EntityChkCons chk in Cons.FindAll(c => c is EntityChkCons))
                {
                    if (chk.Condition.Contains("IS NOT NULL"))
                    { continue; }


                }
                if (useFeild)
                {
                    //column field
                    sb.AppendLine(String.Format(tabContent + "private {0} {1};", ConvertOracleType(DataType), GetFieldName(ColumnName)));
                    //column Property
                    sb.AppendLine(String.Format(tabContent + "public {0} {1}{{get=>{2};set=>{2}}}", ConvertOracleType(DataType), GetPropertyName(ColumnName), GetFieldName(ColumnName)));
                }
                else
                {
                    sb.AppendLine(String.Format(tabContent + "public {0} {1}{{get;set;}}", ConvertOracleType(DataType), GetPropertyName(ColumnName)));
                    return sb.ToString();
                }


                return sb.ToString();
            }

            private String GetPropertyName(string columnName)
            {
                string[] words = columnName.ToLower().Split('_');
                string result = "";
                for (int index = 0; index < words.Length; index++)
                {
                    result += words[index][0].ToString().ToUpper();
                    result += words[index].Remove(0, 1);
                }
                return result;
            }

            private String GetFieldName(string columnName)
            {
                string[] words = ColumnName.ToLower().Split('_');
                string result = "";
                for (int index = 0; index < words.Length; index++)
                {
                    if (index == 0)
                    {
                        result = words[0];
                    }
                    else
                    {
                        result += words[index][0].ToString().ToUpper();
                        result += words[index].Remove(0, 1);
                    }
                }
                return result;
            }

            private object ConvertOracleType(string dataType)
            {
                switch (dataType)
                {
                    case "RAW":
                    case "BLOB":
                        return "byte[]";
                    case "NUMBER":
                        return "decimal";
                    case "VARCHAR2":
                    case "CHAR":
                    case "VARCHAR":
                    case "NVARCHAR":
                    case "CLOB":
                        return "String";
                    case "DATE":
                        return "DateTime";
                }
                return "Unknown";
            }
        }

        public class EntityConstraint
        {
            public String Owner { get; set; }
            public string TableName { get; set; }
            public String Name { get; set; }
            public String Type { get; set; }

        }
        public class EntityPKCons : EntityConstraint
        {
            public EntityPKCons() : base()
            {
                RefColumns = new List<EntityColumn>();
            }
            public List<EntityColumn> RefColumns { get; set; }
        }

        public class EntityFKCons : EntityPKCons
        {

        }

        public class EntityChkCons : EntityConstraint
        {
            public String Condition { get; set; }
        }


        private void BarButtonItemCreateEntityClass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dictionary<String, EntityTable> results = new Dictionary<string, EntityTable>();
  OracleConnection conn = new OracleConnection(connections[barEditItemConnectionString.EditValue.ToString()]);
                conn.Open();
            Task t = new Task(()=> {
              
                


                foreach (int rowIndex in gridViewTables.GetSelectedRows())
                {
                    String selectedTable = gridViewTables.GetDataRow(rowIndex)["TABLE_NAME"].ToString();
                    String owner = gridViewTables.GetDataRow(rowIndex)["OWNER"].ToString();
                    EntityTable table = new EntityTable()
                    {
                        Owner = owner,
                        TableName = selectedTable
                    };


                    //get columns
                    OracleCommand cmdColumns = new OracleCommand(String.Format("select column_name,DATA_TYPE, data_length, nullable,DATA_DEFAULT,column_id from all_tab_columns where owner='{0}' and table_name='{1}'", owner, selectedTable), conn);
                    cmdColumns.InitialLONGFetchSize = 1;
                    OracleDataReader readCols = cmdColumns.ExecuteReader();
                    List<EntityColumn> columns = new List<EntityColumn>();

                    while (readCols.Read())
                    {

                        String colname = readCols.GetString(0);
                        string datatype = readCols.GetString(1);
                        decimal length = readCols.GetDecimal(2);
                        bool nullable = readCols.GetString(3) == "Y";
                        string defaultVal = readCols.IsDBNull(4) ? "" : readCols.GetString(4);
                        decimal colId = readCols.GetDecimal(5);
                        columns.Add(new EntityColumn()
                        {
                            Owner = owner,
                            ColumnId = colId,
                            ColumnName = colname,
                            Length = length,
                            TableName = selectedTable,
                            DataType = datatype,
                            Nullable = nullable
                        });
                    }
                    table.Columns = columns;


                    //get constaints
                    OracleCommand
                        cmdCons = new OracleCommand(String.Format("select CONSTRAINT_NAME,CONSTRAINT_TYPE,R_OWNER, R_CONSTRAINT_NAME,SEARCH_CONDITION from all_constraints where owner='{0}' and table_name='{1}' and constRaint_type in('P','R','C')", owner, selectedTable), conn);
                    OracleDataReader readCons = cmdCons.ExecuteReader();
                    while (readCons.Read())
                    {
                        string consName = readCons.GetString(0);
                        string consType = readCons.GetString(1);
                        String rowner = readCons.IsDBNull(2) ? "" : readCons.GetString(2);
                        string rtable = readCons.IsDBNull(3) ? "" : readCons.GetString(3);
                        string condition = readCons.IsDBNull(4) ? "" : readCons.GetString(4);

                        OracleCommand cmdConsCols = new OracleCommand(String.Format("SELECT COLUMN_NAME,POSITION FROM ALL_CONS_COLUMNS WHERE OWNER='{0}' AND CONSTRAINT_NAME='{1}' ORDER BY POSITION", owner, consName), conn);
                        switch (consType)
                        {
                            case "P":
                                EntityPKCons pkcons = new EntityPKCons()
                                {
                                    Owner = owner,
                                    Name = consName,
                                    Type = consType,
                                    TableName = selectedTable
                                };

                                OracleDataReader readPKCols = cmdConsCols.ExecuteReader();
                                while (readPKCols.Read())
                                {
                                    EntityColumn refcol = table.Columns.Find(c => c.ColumnName == readPKCols.GetString(0));
                                    pkcons.RefColumns.Add(refcol);
                                    refcol.Cons.Add(pkcons);
                                    refcol.IsPK = true;
                                }

                                break;
                            case "R":
                                EntityFKCons fkcons = new EntityFKCons()
                                {
                                    Owner = owner,
                                    Name = consName,
                                    Type = consType,
                                    TableName = selectedTable
                                };

                                OracleDataReader readFKCols = cmdConsCols.ExecuteReader();
                                while (readFKCols.Read())
                                {
                                    fkcons.RefColumns.Add(new EntityColumn() { TableName = rtable, Owner = rowner, ColumnName = readFKCols.GetString(0), ColumnId = readFKCols.GetDecimal(1) });
                                    table.Columns.Find(c => c.ColumnName == readFKCols.GetString(0)).Cons.Add(fkcons);
                                }
                                break;
                            case "C":
                                EntityChkCons chkcons = new EntityChkCons()
                                {
                                    Owner = owner,
                                    Name = consName,
                                    Type = consType,
                                    TableName = selectedTable,
                                    Condition = condition
                                };
                                OracleDataReader readCHKCols = cmdConsCols.ExecuteReader();
                                while (readCHKCols.Read())
                                {
                                    table.Columns.Find(c => c.ColumnName == readCHKCols.GetString(0)).Cons.Add(chkcons);
                                }
                                break;
                        }


                    }
                    results.Add(table.EntityName, table);
                    
                }
            });
            t.Start();
            ExportEntityConfigForm form = new ExportEntityConfigForm();
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                //conn.Close();
                return;
            }

            FolderBrowserDialog savedialog = new FolderBrowserDialog();
            
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DefaultFolder))
            {
                savedialog.SelectedPath=Properties.Settings.Default.DefaultFolder;
                
            }

            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.DefaultFolder = savedialog.SelectedPath;
                Properties.Settings.Default.Save();
                t.Wait();
                foreach (String entityName in results.Keys)
                {
                    File.WriteAllText(Path.Combine(savedialog.SelectedPath, string.Format("{0}.cs", entityName)), results[entityName].ToString(form.Ns,form.Fields,form.UseAnnotation));
                }
                conn.Close(); Process.Start(savedialog.SelectedPath);
            }
     
            
            // Clipboard.SetText(table.ToString());

        }


       
        private void barButtonItemUpdateCommand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridView columnView = gridViewTables.GetDetailView(gridViewTables.FocusedRowHandle, 0) as GridView;
            String tableName = gridViewTables.GetFocusedDataRow()["TABLE_NAME"].ToString();
            String owner = gridViewTables.GetFocusedDataRow()["OWNER"].ToString();
            List<String> columns = new List<string>();
            foreach (DataRowView rowView in (columnView.DataSource as DataView))
            {
                columns.Add(rowView.Row["COLUMN_NAME"].ToString());
            }

            ColumnSelectingForm columnSfrom = new ColumnSelectingForm();
            Dictionary<String, String[]> columnSFromParameter = new Dictionary<string, string[]>();
            columnSFromParameter.Add("Set", columns.ToArray());
            columnSFromParameter.Add("Where", columns.ToArray());
            columnSfrom.InitialForm(columnSFromParameter);
            columnSfrom.ShowDialog();
            String updateText = "UPDATE {0}.{1} SET {2} WHERE {3}";
            String setText = "";
            String whereText = "";
            foreach (String SetColumn in columnSfrom.ListChecked["Set"])
            {
                setText += String.Format("\r\n{0}=:{0},", SetColumn);
            }
            setText = setText.Remove(setText.Length - 1);

            foreach (String where in columnSfrom.ListChecked["Where"])
            {
                whereText += String.Format("{0}=:{0} AND ", where);
            }
            whereText = whereText.Remove(whereText.LastIndexOf("AND"));
            updateText = String.Format(updateText, owner, tableName, setText, whereText);
            Clipboard.SetText(updateText);
        }

        private void barButtonItemFFk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindFKReference form = new FindFKReference();
            if (gridViewTables.SelectedRowsCount == 1)
            {
                foreach (int rowHandle in gridViewTables.GetSelectedRows())
                {
                    String tableName = gridViewTables.GetRowCellValue(rowHandle, "TABLE_NAME") as String;
                    String towner = gridViewTables.GetRowCellValue(rowHandle, "OWNER") as String;

                    form.TableName = tableName;
                    form.Owner1 = towner;
                }
            }
            form.ShowDialog();
        }

    }
}
