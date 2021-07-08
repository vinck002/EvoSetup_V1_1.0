
namespace EvoSetup_V_1._0
{
    partial class frmCloneUserProfile
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.chActive = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnA = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Enabled = false;
            this.radLabel1.Location = new System.Drawing.Point(48, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(37, 18);
            this.radLabel1.TabIndex = 1008;
            this.radLabel1.Text = "Active";
            // 
            // chActive
            // 
            this.chActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chActive.Location = new System.Drawing.Point(87, 14);
            this.chActive.Name = "chActive";
            this.chActive.Size = new System.Drawing.Size(15, 15);
            this.chActive.TabIndex = 1006;
            this.chActive.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(19, 33);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(63, 18);
            this.radLabel3.TabIndex = 1007;
            this.radLabel3.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(88, 32);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(284, 20);
            this.txtDescription.TabIndex = 1005;
            this.txtDescription.Tag = "1";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(274, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 24);
            this.btnCancel.TabIndex = 1010;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnA
            // 
            this.btnA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnA.Location = new System.Drawing.Point(162, 58);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(98, 24);
            this.btnA.TabIndex = 1009;
            this.btnA.Text = "Save";
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // frmCloneUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 94);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.chActive);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtDescription);
            this.Name = "frmCloneUserProfile";
            this.Text = "frmCloneUserProfile";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadCheckBox chActive;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnA;
    }
}