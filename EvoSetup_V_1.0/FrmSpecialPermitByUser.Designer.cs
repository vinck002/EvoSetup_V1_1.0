
namespace EvoSetup_V_1._0
{
    partial class FrmSpecialPermitByUser
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            this.dtgSpecialPMenu = new Telerik.WinControls.UI.RadGridView();
            this.MenuTree = new Telerik.WinControls.UI.RadTreeView();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnA = new Telerik.WinControls.UI.RadButton();
            this.cbUsers = new Telerik.WinControls.UI.RadDropDownList();
            this.lblMensajes = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPMenu.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(441, -63);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(58, 21);
            this.lblMensaje.TabIndex = 1015;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.Visible = false;
            // 
            // dtgSpecialPMenu
            // 
            this.dtgSpecialPMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgSpecialPMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgSpecialPMenu.EnableCustomDrawing = true;
            this.dtgSpecialPMenu.EnableTheming = false;
            this.dtgSpecialPMenu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgSpecialPMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgSpecialPMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgSpecialPMenu.Location = new System.Drawing.Point(239, 29);
            // 
            // 
            // 
            this.dtgSpecialPMenu.MasterTemplate.AllowAddNewRow = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowCellContextMenu = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowColumnReorder = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowDeleteRow = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowDragToGroup = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowEditRow = false;
            this.dtgSpecialPMenu.MasterTemplate.AllowRowResize = false;
            this.dtgSpecialPMenu.MasterTemplate.AutoGenerateColumns = false;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Checked";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Checked";
            gridViewCheckBoxColumn1.Width = 27;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SpecialPermitID";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "SpecialPermitID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Special Permit Description";
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 197;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FormIconTag";
            gridViewTextBoxColumn3.HeaderText = "Tag";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "FormIconTag";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "UserProfileStatus";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "UserProfileStatus";
            gridViewTextBoxColumn4.ReadOnly = true;
            this.dtgSpecialPMenu.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dtgSpecialPMenu.MasterTemplate.EnableGrouping = false;
            this.dtgSpecialPMenu.MasterTemplate.ShowRowHeaderColumn = false;
            this.dtgSpecialPMenu.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgSpecialPMenu.Name = "dtgSpecialPMenu";
            this.dtgSpecialPMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgSpecialPMenu.ShowCellErrors = false;
            this.dtgSpecialPMenu.ShowGroupPanel = false;
            this.dtgSpecialPMenu.ShowGroupPanelScrollbars = false;
            this.dtgSpecialPMenu.ShowRowErrors = false;
            this.dtgSpecialPMenu.Size = new System.Drawing.Size(232, 392);
            this.dtgSpecialPMenu.TabIndex = 1010;
            this.dtgSpecialPMenu.RowPaint += new Telerik.WinControls.UI.GridViewRowPaintEventHandler(this.dtgSpecialPMenu_RowPaint);
            this.dtgSpecialPMenu.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgSpecialPMenu_RowFormatting);
            this.dtgSpecialPMenu.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dtgSpecialPMenu_CellFormatting);
            this.dtgSpecialPMenu.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dtgSpecialPMenu_CellClick);
            this.dtgSpecialPMenu.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dtgSpecialPMenu_CellValueChanged);
            // 
            // MenuTree
            // 
            this.MenuTree.Location = new System.Drawing.Point(18, 55);
            this.MenuTree.Name = "MenuTree";
            this.MenuTree.Size = new System.Drawing.Size(215, 366);
            this.MenuTree.SpacingBetweenNodes = -1;
            this.MenuTree.TabIndex = 1009;
            this.MenuTree.NodeMouseClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.MenuTree_NodeMouseClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(373, 427);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 24);
            this.btnExit.TabIndex = 1018;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(265, 427);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(98, 24);
            this.btnA.TabIndex = 1017;
            this.btnA.Text = "Ok";
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // cbUsers
            // 
            this.cbUsers.Location = new System.Drawing.Point(18, 29);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.NullText = "Select";
            this.cbUsers.Size = new System.Drawing.Size(215, 20);
            this.cbUsers.TabIndex = 1019;
            this.cbUsers.TextChanged += new System.EventHandler(this.cbUsers_TextChanged);
            this.cbUsers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbUsers_KeyDown);
            this.cbUsers.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbUsers_SelectedIndexChanged);
            this.cbUsers.Click += new System.EventHandler(this.cbUsers_Click);
            // 
            // lblMensajes
            // 
            this.lblMensajes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajes.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMensajes.Location = new System.Drawing.Point(18, 5);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(67, 22);
            this.lblMensajes.TabIndex = 1020;
            this.lblMensajes.Text = "Mensaje";
            this.lblMensajes.Visible = false;
            // 
            // FrmSpecialPermitByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 458);
            this.Controls.Add(this.lblMensajes);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dtgSpecialPMenu);
            this.Controls.Add(this.MenuTree);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSpecialPermitByUser";
            this.Text = "FrmSpecialPermitByUser";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSpecialPermitByUser_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPMenu.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblMensaje;
        public Telerik.WinControls.UI.RadGridView dtgSpecialPMenu;
        private Telerik.WinControls.UI.RadTreeView MenuTree;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnA;
        private Telerik.WinControls.UI.RadDropDownList cbUsers;
        private Telerik.WinControls.UI.RadLabel lblMensajes;
    }
}