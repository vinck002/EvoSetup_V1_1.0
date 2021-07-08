
namespace EvoSetup_V_1._0
{
    partial class FrmSearchingMenu
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgSearching = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearching.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 36);
            this.panel1.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilter.Location = new System.Drawing.Point(50, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(236, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged_1);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.Location = new System.Drawing.Point(12, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(31, 18);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Filter";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgSearching);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 432);
            this.panel2.TabIndex = 0;
            // 
            // dtgSearching
            // 
            this.dtgSearching.BackColor = System.Drawing.SystemColors.Control;
            this.dtgSearching.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgSearching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSearching.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgSearching.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgSearching.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgSearching.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dtgSearching.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgSearching.MasterTemplate.AllowAddNewRow = false;
            this.dtgSearching.MasterTemplate.AllowColumnChooser = false;
            this.dtgSearching.MasterTemplate.AllowColumnReorder = false;
            this.dtgSearching.MasterTemplate.AllowDeleteRow = false;
            this.dtgSearching.MasterTemplate.AllowDragToGroup = false;
            this.dtgSearching.MasterTemplate.AllowEditRow = false;
            this.dtgSearching.MasterTemplate.AllowRowResize = false;
            this.dtgSearching.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "MenuItemID";
            gridViewTextBoxColumn1.HeaderText = "MenuItemID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "MenuItemID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Description";
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn2.Width = 262;
            this.dtgSearching.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.dtgSearching.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgSearching.Name = "dtgSearching";
            this.dtgSearching.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgSearching.ShowGroupPanel = false;
            this.dtgSearching.Size = new System.Drawing.Size(298, 432);
            this.dtgSearching.TabIndex = 0;
            this.dtgSearching.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dtgSearching_CellDoubleClick);
            this.dtgSearching.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgSearching_KeyDown);
            // 
            // FrmSearchingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSearchingMenu";
            this.Text = "FrmSearchingMenu";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearching.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSearching)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadTextBox txtFilter;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView dtgSearching;
    }
}