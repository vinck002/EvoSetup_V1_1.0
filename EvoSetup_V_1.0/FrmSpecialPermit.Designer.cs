
namespace EvoSetup_V_1._0
{
    partial class FrmSpecialPermit
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpecialPermit));
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnA = new Telerik.WinControls.UI.RadButton();
            this.cbFormOption = new Telerik.WinControls.UI.RadDropDownList();
            this.dtgSpecialPermit = new Telerik.WinControls.UI.RadGridView();
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPermit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPermit.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(198, 362);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 24);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(87, 362);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(98, 24);
            this.btnA.TabIndex = 8;
            this.btnA.Text = "OK";
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // cbFormOption
            // 
            this.cbFormOption.Location = new System.Drawing.Point(10, 36);
            this.cbFormOption.Name = "cbFormOption";
            this.cbFormOption.NullText = "Select";
            this.cbFormOption.Size = new System.Drawing.Size(286, 20);
            this.cbFormOption.TabIndex = 14;
            this.cbFormOption.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbFormOption_SelectedIndexChanged);
            // 
            // dtgSpecialPermit
            // 
            this.dtgSpecialPermit.BackColor = System.Drawing.SystemColors.Control;
            this.dtgSpecialPermit.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgSpecialPermit.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgSpecialPermit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgSpecialPermit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgSpecialPermit.Location = new System.Drawing.Point(10, 62);
            // 
            // 
            // 
            this.dtgSpecialPermit.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgSpecialPermit.MasterTemplate.AllowColumnChooser = false;
            this.dtgSpecialPermit.MasterTemplate.AllowColumnReorder = false;
            this.dtgSpecialPermit.MasterTemplate.AllowDeleteRow = false;
            this.dtgSpecialPermit.MasterTemplate.AllowDragToGroup = false;
            this.dtgSpecialPermit.MasterTemplate.AllowRowResize = false;
            this.dtgSpecialPermit.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SpecialPermitiD";
            gridViewTextBoxColumn1.HeaderText = "SpecialPermitId";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "SpecialPermitiD";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Description of Menu Option";
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 262;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Code";
            gridViewTextBoxColumn3.HeaderText = "Code";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "Code";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "FormIconTag";
            gridViewTextBoxColumn4.HeaderText = "FormIconTag";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "FormIconTag";
            this.dtgSpecialPermit.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            sortDescriptor1.PropertyName = "Description";
            this.dtgSpecialPermit.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgSpecialPermit.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgSpecialPermit.Name = "dtgSpecialPermit";
            this.dtgSpecialPermit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgSpecialPermit.ShowGroupPanel = false;
            this.dtgSpecialPermit.Size = new System.Drawing.Size(286, 294);
            this.dtgSpecialPermit.TabIndex = 19;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(10, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(58, 21);
            this.lblMensaje.TabIndex = 10;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.Visible = false;
            // 
            // FrmSpecialPermit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 398);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dtgSpecialPermit);
            this.Controls.Add(this.cbFormOption);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSpecialPermit";
            this.Text = "Special Permit";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSpecialPermit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPermit.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialPermit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnA;
        private Telerik.WinControls.UI.RadDropDownList cbFormOption;
        private Telerik.WinControls.UI.RadGridView dtgSpecialPermit;
        private Telerik.WinControls.UI.RadLabel lblMensaje;
    }
}