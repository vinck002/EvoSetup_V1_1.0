
namespace EvoSetup_V_1._0
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.MainMenu = new Telerik.WinControls.UI.RadMenu();
            this.Roles = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.FrmRoleTab = new Telerik.WinControls.UI.RadMenuItem();
            this.FrmDepartmentMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.FrmUsersMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.FrmOptionMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuSpecialPermit = new Telerik.WinControls.UI.RadMenuItem();
            this.frmPermisionByProfile = new Telerik.WinControls.UI.RadMenuItem();
            this.FrmSpecialPermitByUser = new Telerik.WinControls.UI.RadMenuItem();
            this.MainFormPanel = new System.Windows.Forms.Panel();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.MainMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 55);
            this.panel1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImage = global::EvoSetup_V_1._0.Properties.Resources.file_add_1144791;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(873, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(31, 29);
            this.btnNew.TabIndex = 29;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::EvoSetup_V_1._0.Properties.Resources.find_search_locate_6312;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(910, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 29);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.Roles});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(953, 20);
            this.MainMenu.TabIndex = 30;
            // 
            // Roles
            // 
            this.Roles.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.Roles.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuSeparatorItem1,
            this.FrmRoleTab,
            this.FrmDepartmentMenu,
            this.FrmUsersMenu,
            this.FrmOptionMenu,
            this.MenuSpecialPermit,
            this.frmPermisionByProfile,
            this.FrmSpecialPermitByUser});
            this.Roles.Name = "Roles";
            this.Roles.Text = "Main";
            this.Roles.Click += new System.EventHandler(this.Roles_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmRoleTab
            // 
            this.FrmRoleTab.Name = "FrmRoleTab";
            this.FrmRoleTab.Text = "Roles";
            this.FrmRoleTab.Click += new System.EventHandler(this.FrmRoleTab_Click);
            // 
            // FrmDepartmentMenu
            // 
            this.FrmDepartmentMenu.Name = "FrmDepartmentMenu";
            this.FrmDepartmentMenu.Text = "Department";
            this.FrmDepartmentMenu.Click += new System.EventHandler(this.FrmDepartmentMenu_Click);
            // 
            // FrmUsersMenu
            // 
            this.FrmUsersMenu.Name = "FrmUsersMenu";
            this.FrmUsersMenu.Text = "Users";
            this.FrmUsersMenu.Click += new System.EventHandler(this.FrmUsersMenu_Click);
            // 
            // FrmOptionMenu
            // 
            this.FrmOptionMenu.Name = "FrmOptionMenu";
            this.FrmOptionMenu.Text = "Option Menu";
            this.FrmOptionMenu.Click += new System.EventHandler(this.FrmOptionMenu_Click);
            // 
            // MenuSpecialPermit
            // 
            this.MenuSpecialPermit.Name = "MenuSpecialPermit";
            this.MenuSpecialPermit.Text = "Special Permit";
            this.MenuSpecialPermit.Click += new System.EventHandler(this.MenuSpecialPermit_Click);
            // 
            // frmPermisionByProfile
            // 
            this.frmPermisionByProfile.Name = "frmPermisionByProfile";
            this.frmPermisionByProfile.Text = "User Profile";
            this.frmPermisionByProfile.Click += new System.EventHandler(this.frmPermisionByProfile_Click);
            // 
            // FrmSpecialPermitByUser
            // 
            this.FrmSpecialPermitByUser.Name = "FrmSpecialPermitByUser";
            this.FrmSpecialPermitByUser.Text = "User Special Permit";
            this.FrmSpecialPermitByUser.UseCompatibleTextRendering = false;
            this.FrmSpecialPermitByUser.Click += new System.EventHandler(this.FrmSpecialPermitByUser_Click);
            // 
            // MainFormPanel
            // 
            this.MainFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormPanel.Location = new System.Drawing.Point(0, 55);
            this.MainFormPanel.Name = "MainFormPanel";
            this.MainFormPanel.Size = new System.Drawing.Size(953, 537);
            this.MainFormPanel.TabIndex = 1;
            this.MainFormPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.MainFormPanel_Layout);
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "radMenuItem2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 592);
            this.Controls.Add(this.MainFormPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel MainFormPanel;
        private Telerik.WinControls.UI.RadMenuItem Roles;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem FrmRoleTab;
        private Telerik.WinControls.UI.RadMenu MainMenu;
        private Telerik.WinControls.UI.RadMenuItem FrmDepartmentMenu;
        private Telerik.WinControls.UI.RadMenuItem FrmUsersMenu;
        private Telerik.WinControls.UI.RadMenuItem FrmOptionMenu;
        private Telerik.WinControls.UI.RadMenuItem MenuSpecialPermit;
        private Telerik.WinControls.UI.RadMenuItem frmPermisionByProfile;
        private Telerik.WinControls.UI.RadMenuItem FrmSpecialPermitByUser;
    }
}