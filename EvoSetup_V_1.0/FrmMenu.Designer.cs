
namespace EvoSetup_V_1._0
{
    partial class FrmMenu
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
            this.txtFormName = new Telerik.WinControls.UI.RadTextBox();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.lblFormName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnExit = new Telerik.WinControls.UI.RadButton();
            this.btnA = new Telerik.WinControls.UI.RadButton();
            this.lblHeader = new Telerik.WinControls.UI.RadLabel();
            this.chActive = new Telerik.WinControls.UI.RadCheckBox();
            this.lblSubHeader = new Telerik.WinControls.UI.RadLabel();
            this.lblMensaje = new Telerik.WinControls.UI.RadLabel();
            this.cbGrpOption = new Telerik.WinControls.UI.RadDropDownList();
            this.cbSubHeader = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrpOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFormName
            // 
            this.txtFormName.Location = new System.Drawing.Point(86, 113);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(286, 20);
            this.txtFormName.TabIndex = 4;
            this.txtFormName.Tag = "";
            this.txtFormName.Visible = false;
            this.txtFormName.TextChanged += new System.EventHandler(this.txtFormName_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(86, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(286, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Tag = "1";
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            // 
            // lblFormName
            // 
            this.lblFormName.Location = new System.Drawing.Point(17, 114);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(65, 18);
            this.lblFormName.TabIndex = 1;
            this.lblFormName.Text = "Form Name";
            this.lblFormName.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(17, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Description";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(274, 122);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 24);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnA
            // 
            this.btnA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnA.Location = new System.Drawing.Point(166, 122);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(98, 24);
            this.btnA.TabIndex = 6;
            this.btnA.Text = "OK";
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Location = new System.Drawing.Point(38, 64);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(42, 18);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Header";
            // 
            // chActive
            // 
            this.chActive.Location = new System.Drawing.Point(319, 12);
            this.chActive.Name = "chActive";
            this.chActive.Size = new System.Drawing.Size(51, 18);
            this.chActive.TabIndex = 5;
            this.chActive.Text = "Active";
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.Location = new System.Drawing.Point(2, 88);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(80, 18);
            this.lblSubHeader.TabIndex = 8;
            this.lblSubHeader.Text = "Group Options";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(87, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(58, 21);
            this.lblMensaje.TabIndex = 9;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.Visible = false;
            // 
            // cbGrpOption
            // 
            this.cbGrpOption.Location = new System.Drawing.Point(87, 62);
            this.cbGrpOption.Name = "cbGrpOption";
            this.cbGrpOption.NullText = "Select";
            this.cbGrpOption.Size = new System.Drawing.Size(285, 20);
            this.cbGrpOption.TabIndex = 2;
            this.cbGrpOption.TextChanged += new System.EventHandler(this.cbGrpOption_TextChanged);
            this.cbGrpOption.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbGrpOption_SelectedIndexChanged_1);
            // 
            // cbSubHeader
            // 
            this.cbSubHeader.Enabled = false;
            this.cbSubHeader.Location = new System.Drawing.Point(87, 87);
            this.cbSubHeader.Name = "cbSubHeader";
            this.cbSubHeader.NullText = "Select";
            this.cbSubHeader.Size = new System.Drawing.Size(285, 20);
            this.cbSubHeader.TabIndex = 3;
            this.cbSubHeader.TextChanged += new System.EventHandler(this.cbSubHeader_TextChanged);
            this.cbSubHeader.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbSubHeader_SelectedIndexChanged);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 158);
            this.Controls.Add(this.cbSubHeader);
            this.Controls.Add(this.cbGrpOption);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.chActive);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtFormName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.lblSubHeader);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMenu_KeyDown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FrmMenu_Layout);
            this.Resize += new System.EventHandler(this.FrmMenu_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFormName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMensaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrpOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtFormName;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadLabel lblFormName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnExit;
        private Telerik.WinControls.UI.RadButton btnA;
        private Telerik.WinControls.UI.RadLabel lblHeader;
        private Telerik.WinControls.UI.RadCheckBox chActive;
        private Telerik.WinControls.UI.RadLabel lblSubHeader;
        private Telerik.WinControls.UI.RadLabel lblMensaje;
        private Telerik.WinControls.UI.RadDropDownList cbGrpOption;
        private Telerik.WinControls.UI.RadDropDownList cbSubHeader;
    }
}