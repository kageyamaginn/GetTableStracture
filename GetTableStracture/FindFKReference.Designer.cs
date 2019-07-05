namespace GetTableStracture
{
    partial class FindFKReference
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditOwner = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTableName = new DevExpress.XtraEditors.TextEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnRELATION_TYPE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnowner = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumntable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnpk = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonFind = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOwner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
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
            this.barDockControlTop.Size = new System.Drawing.Size(643, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 563);
            this.barDockControlBottom.Size = new System.Drawing.Size(643, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(643, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Owner";
            // 
            // textEditOwner
            // 
            this.textEditOwner.Location = new System.Drawing.Point(79, 11);
            this.textEditOwner.MenuManager = this.barManager1;
            this.textEditOwner.Name = "textEditOwner";
            this.textEditOwner.Size = new System.Drawing.Size(206, 20);
            this.textEditOwner.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Table Name";
            // 
            // textEditTableName
            // 
            this.textEditTableName.Location = new System.Drawing.Point(79, 37);
            this.textEditTableName.Name = "textEditTableName";
            this.textEditTableName.Size = new System.Drawing.Size(206, 20);
            this.textEditTableName.TabIndex = 5;
            // 
            // treeList1
            // 
            this.treeList1.Appearance.Empty.BackColor = System.Drawing.Color.DimGray;
            this.treeList1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.treeList1.Appearance.Empty.Options.UseBackColor = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray;
            this.treeList1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.treeList1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeList1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray;
            this.treeList1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.treeList1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray;
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.treeList1.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeList1.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeList1.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList1.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.treeList1.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray;
            this.treeList1.Appearance.Preview.Options.UseBackColor = true;
            this.treeList1.Appearance.Preview.Options.UseForeColor = true;
            this.treeList1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.Row.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.treeList1.Appearance.VertLine.Options.UseBackColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnRELATION_TYPE,
            this.treeListColumnowner,
            this.treeListColumntable,
            this.treeListColumnpk});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 72);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.EnableAppearanceOddRow = true;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.Size = new System.Drawing.Size(643, 491);
            this.treeList1.TabIndex = 6;
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            // 
            // treeListColumnRELATION_TYPE
            // 
            this.treeListColumnRELATION_TYPE.Caption = "Relation Type";
            this.treeListColumnRELATION_TYPE.FieldName = "treeListColumnRELATION_TYPE";
            this.treeListColumnRELATION_TYPE.Name = "treeListColumnRELATION_TYPE";
            this.treeListColumnRELATION_TYPE.Visible = true;
            this.treeListColumnRELATION_TYPE.VisibleIndex = 0;
            // 
            // treeListColumnowner
            // 
            this.treeListColumnowner.Caption = "OWNER";
            this.treeListColumnowner.FieldName = "treeListColumnowner";
            this.treeListColumnowner.MinWidth = 34;
            this.treeListColumnowner.Name = "treeListColumnowner";
            this.treeListColumnowner.Visible = true;
            this.treeListColumnowner.VisibleIndex = 1;
            this.treeListColumnowner.Width = 135;
            // 
            // treeListColumntable
            // 
            this.treeListColumntable.Caption = "TABLE NAME";
            this.treeListColumntable.FieldName = "treeListColumntable";
            this.treeListColumntable.Name = "treeListColumntable";
            this.treeListColumntable.Visible = true;
            this.treeListColumntable.VisibleIndex = 2;
            this.treeListColumntable.Width = 135;
            // 
            // treeListColumnpk
            // 
            this.treeListColumnpk.Caption = "PRIMARY KEY NAME";
            this.treeListColumnpk.FieldName = "treeListColumnpk";
            this.treeListColumnpk.Name = "treeListColumnpk";
            this.treeListColumnpk.Visible = true;
            this.treeListColumnpk.VisibleIndex = 3;
            this.treeListColumnpk.Width = 135;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonFind);
            this.panelControl1.Controls.Add(this.textEditOwner);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.textEditTableName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(643, 72);
            this.panelControl1.TabIndex = 7;
            // 
            // simpleButtonFind
            // 
            this.simpleButtonFind.Location = new System.Drawing.Point(291, 12);
            this.simpleButtonFind.Name = "simpleButtonFind";
            this.simpleButtonFind.Size = new System.Drawing.Size(120, 45);
            this.simpleButtonFind.TabIndex = 6;
            this.simpleButtonFind.Text = "Find";
            this.simpleButtonFind.Click += new System.EventHandler(this.simpleButtonFind_Click);
            // 
            // FindFKReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 586);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FindFKReference";
            this.Text = "FindFKReference";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOwner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonFind;
        private DevExpress.XtraEditors.TextEdit textEditOwner;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditTableName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnowner;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumntable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnpk;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnRELATION_TYPE;
    }
}