
namespace EvoSetup_V_1._0
{
    partial class FrmSearchinRoles
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgData = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 51);
            this.panel1.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(47, 25);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(348, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(9, 25);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Filter";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 399);
            this.panel2.TabIndex = 0;
            // 
            // dtgData
            // 
            this.dtgData.BackColor = System.Drawing.SystemColors.Control;
            this.dtgData.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgData.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgData.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dtgData.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgData.MasterTemplate.AllowAddNewRow = false;
            this.dtgData.MasterTemplate.AllowColumnReorder = false;
            this.dtgData.MasterTemplate.AllowDeleteRow = false;
            this.dtgData.MasterTemplate.AllowEditRow = false;
            this.dtgData.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Code";
            gridViewTextBoxColumn2.HeaderText = "Code";
            gridViewTextBoxColumn2.Name = "Code";
            gridViewTextBoxColumn2.Width = 36;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "GrpRoleId";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "GrpRoleId";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Descri";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Descri";
            gridViewTextBoxColumn4.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn4.Width = 319;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Group";
            gridViewTextBoxColumn5.HeaderText = "Group";
            gridViewTextBoxColumn5.Name = "Group";
            this.dtgData.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dtgData.MasterTemplate.EnableGrouping = false;
            this.dtgData.MasterTemplate.ShowFilteringRow = false;
            sortDescriptor1.PropertyName = "Descri";
            this.dtgData.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgData.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgData.Name = "dtgData";
            this.dtgData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgData.ShowGroupPanel = false;
            this.dtgData.ShowGroupPanelScrollbars = false;
            this.dtgData.ShowItemToolTips = false;
            this.dtgData.Size = new System.Drawing.Size(426, 399);
            this.dtgData.TabIndex = 1;
            this.dtgData.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dtgData_CellDoubleClick);
            this.dtgData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgData_KeyDown);
            // 
            // FrmSearchinRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FrmSearchinRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role List";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSearchinRoles_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadGridView dtgData;
        private Telerik.WinControls.UI.RadTextBox txtFilter;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}