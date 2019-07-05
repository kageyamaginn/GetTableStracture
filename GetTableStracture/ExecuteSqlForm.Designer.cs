namespace GetTableStracture
{
    partial class ExecuteSqlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridViewTableCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTableCondition_Condition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditTableCondition = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnTableCondition_Column2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditColumns = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControlCondition = new DevExpress.XtraGrid.GridControl();
            this.gridViewValueCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridViewCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTable1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditTables = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItemRun = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddCondition = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRemoveCondition = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelConditions = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridViewColumnCondition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memoEditScript = new DevExpress.XtraEditors.MemoEdit();
            this.gridControlResults = new DevExpress.XtraGrid.GridControl();
            this.gridViewResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTableCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTableCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewValueCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelConditions.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditScript.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewTableCondition
            // 
            this.gridViewTableCondition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTableCondition_Condition,
            this.gridColumnTableCondition_Column2});
            this.gridViewTableCondition.GridControl = this.gridControlCondition;
            this.gridViewTableCondition.Name = "gridViewTableCondition";
            // 
            // gridColumnTableCondition_Condition
            // 
            this.gridColumnTableCondition_Condition.Caption = "Condition";
            this.gridColumnTableCondition_Condition.ColumnEdit = this.repositoryItemLookUpEditTableCondition;
            this.gridColumnTableCondition_Condition.FieldName = "CONDITION";
            this.gridColumnTableCondition_Condition.Name = "gridColumnTableCondition_Condition";
            this.gridColumnTableCondition_Condition.Visible = true;
            this.gridColumnTableCondition_Condition.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditTableCondition
            // 
            this.repositoryItemLookUpEditTableCondition.AutoHeight = false;
            this.repositoryItemLookUpEditTableCondition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTableCondition.Name = "repositoryItemLookUpEditTableCondition";
            // 
            // gridColumnTableCondition_Column2
            // 
            this.gridColumnTableCondition_Column2.Caption = "Column2";
            this.gridColumnTableCondition_Column2.ColumnEdit = this.repositoryItemLookUpEditColumns;
            this.gridColumnTableCondition_Column2.FieldName = "COLUMN2";
            this.gridColumnTableCondition_Column2.Name = "gridColumnTableCondition_Column2";
            this.gridColumnTableCondition_Column2.Visible = true;
            this.gridColumnTableCondition_Column2.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEditColumns
            // 
            this.repositoryItemLookUpEditColumns.AutoHeight = false;
            this.repositoryItemLookUpEditColumns.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditColumns.Name = "repositoryItemLookUpEditColumns";
            // 
            // gridControlCondition
            // 
            this.gridControlCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewTableCondition;
            gridLevelNode2.LevelTemplate = this.gridViewColumnCondition;
            gridLevelNode2.RelationName = "ColumnCondition";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "TableCondition";
            gridLevelNode3.LevelTemplate = this.gridViewValueCondition;
            gridLevelNode3.RelationName = "ValueCondition";
            this.gridControlCondition.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode3});
            this.gridControlCondition.Location = new System.Drawing.Point(0, 0);
            this.gridControlCondition.MainView = this.gridViewCondition;
            this.gridControlCondition.MenuManager = this.barManager1;
            this.gridControlCondition.Name = "gridControlCondition";
            this.gridControlCondition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditTables,
            this.repositoryItemLookUpEditColumns,
            this.repositoryItemLookUpEditTableCondition});
            this.gridControlCondition.Size = new System.Drawing.Size(477, 462);
            this.gridControlCondition.TabIndex = 0;
            this.gridControlCondition.UseEmbeddedNavigator = true;
            this.gridControlCondition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewValueCondition,
            this.gridViewCondition,
            this.gridViewColumnCondition,
            this.gridViewTableCondition});
            // 
            // gridViewValueCondition
            // 
            this.gridViewValueCondition.GridControl = this.gridControlCondition;
            this.gridViewValueCondition.Name = "gridViewValueCondition";
            // 
            // gridViewCondition
            // 
            this.gridViewCondition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnOrder,
            this.gridColumnTable1});
            this.gridViewCondition.GridControl = this.gridControlCondition;
            this.gridViewCondition.Name = "gridViewCondition";
            this.gridViewCondition.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnOrder
            // 
            this.gridColumnOrder.Caption = "ORDER";
            this.gridColumnOrder.FieldName = "ORDER";
            this.gridColumnOrder.Name = "gridColumnOrder";
            this.gridColumnOrder.Visible = true;
            this.gridColumnOrder.VisibleIndex = 0;
            // 
            // gridColumnTable1
            // 
            this.gridColumnTable1.Caption = "TABLE1";
            this.gridColumnTable1.ColumnEdit = this.repositoryItemLookUpEditTables;
            this.gridColumnTable1.FieldName = "TABLE1";
            this.gridColumnTable1.Name = "gridColumnTable1";
            this.gridColumnTable1.Visible = true;
            this.gridColumnTable1.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEditTables
            // 
            this.repositoryItemLookUpEditTables.AutoHeight = false;
            this.repositoryItemLookUpEditTables.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTables.Name = "repositoryItemLookUpEditTables";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemRun,
            this.barButtonItemAddCondition,
            this.barButtonItemRemoveCondition});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRun),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddCondition),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRemoveCondition)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItemRun
            // 
            this.barButtonItemRun.Caption = "Run";
            this.barButtonItemRun.Id = 0;
            this.barButtonItemRun.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barButtonItemRun.Name = "barButtonItemRun";
            this.barButtonItemRun.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRun_ItemClick);
            // 
            // barButtonItemAddCondition
            // 
            this.barButtonItemAddCondition.Caption = "Add Condition";
            this.barButtonItemAddCondition.Id = 1;
            this.barButtonItemAddCondition.Name = "barButtonItemAddCondition";
            // 
            // barButtonItemRemoveCondition
            // 
            this.barButtonItemRemoveCondition.Caption = "Remove Codition";
            this.barButtonItemRemoveCondition.Id = 3;
            this.barButtonItemRemoveCondition.Name = "barButtonItemRemoveCondition";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1210, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 518);
            this.barDockControlBottom.Size = new System.Drawing.Size(1210, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 489);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1210, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 489);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelConditions});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanelConditions
            // 
            this.dockPanelConditions.AutoScroll = true;
            this.dockPanelConditions.Controls.Add(this.dockPanel1_Container);
            this.dockPanelConditions.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelConditions.ID = new System.Guid("b2a155f0-4698-4ba7-923b-497ae02a5656");
            this.dockPanelConditions.Location = new System.Drawing.Point(0, 29);
            this.dockPanelConditions.Name = "dockPanelConditions";
            this.dockPanelConditions.OriginalSize = new System.Drawing.Size(485, 200);
            this.dockPanelConditions.Size = new System.Drawing.Size(485, 489);
            this.dockPanelConditions.Text = "conditions";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControlCondition);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(477, 462);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridViewColumnCondition
            // 
            this.gridViewColumnCondition.GridControl = this.gridControlCondition;
            this.gridViewColumnCondition.Name = "gridViewColumnCondition";
            // 
            // memoEditScript
            // 
            this.memoEditScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEditScript.Location = new System.Drawing.Point(0, 0);
            this.memoEditScript.MenuManager = this.barManager1;
            this.memoEditScript.Name = "memoEditScript";
            this.memoEditScript.Size = new System.Drawing.Size(725, 100);
            this.memoEditScript.TabIndex = 4;
            // 
            // gridControlResults
            // 
            this.gridControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlResults.Location = new System.Drawing.Point(0, 0);
            this.gridControlResults.MainView = this.gridViewResults;
            this.gridControlResults.MenuManager = this.barManager1;
            this.gridControlResults.Name = "gridControlResults";
            this.gridControlResults.Size = new System.Drawing.Size(725, 384);
            this.gridControlResults.TabIndex = 5;
            this.gridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResults});
            // 
            // gridViewResults
            // 
            this.gridViewResults.GridControl = this.gridControlResults;
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.OptionsSelection.MultiSelect = true;
            this.gridViewResults.OptionsView.ColumnAutoWidth = false;
            this.gridViewResults.OptionsView.ShowGroupPanel = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(485, 29);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.memoEditScript);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControlResults);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(725, 489);
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ExecuteSqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 541);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.dockPanelConditions);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ExecuteSqlForm";
            this.Text = "ExecuteSqlForm";
            this.Load += new System.EventHandler(this.ExecuteSqlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTableCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTableCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewValueCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelConditions.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditScript.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRun;
        private DevExpress.XtraGrid.GridControl gridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewResults;
        private DevExpress.XtraEditors.MemoEdit memoEditScript;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelConditions;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddCondition;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRemoveCondition;
        private DevExpress.XtraGrid.GridControl gridControlCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTableCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTableCondition_Condition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTableCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTableCondition_Column2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditColumns;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewColumnCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewValueCondition;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTable1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTables;
    }
}