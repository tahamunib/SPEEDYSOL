namespace SPEEDYAPPWIN.Forms.Accounting.AccountGroup
{
    partial class AccountGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountGroupForm));
            this.AccountGroupsTab = new System.Windows.Forms.TabControl();
            this.Add = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAccGrpName = new System.Windows.Forms.Label();
            this.tbAccGrpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.List = new System.Windows.Forms.TabPage();
            this.datagridAccGrpNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridAccGrp = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.AccountGroupsTab.SuspendLayout();
            this.Add.SuspendLayout();
            this.List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAccGrpNavigator)).BeginInit();
            this.datagridAccGrpNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccGrp)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountGroupsTab
            // 
            this.AccountGroupsTab.Controls.Add(this.Add);
            this.AccountGroupsTab.Controls.Add(this.List);
            this.AccountGroupsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountGroupsTab.ItemSize = new System.Drawing.Size(30, 18);
            this.AccountGroupsTab.Location = new System.Drawing.Point(0, 0);
            this.AccountGroupsTab.Multiline = true;
            this.AccountGroupsTab.Name = "AccountGroupsTab";
            this.AccountGroupsTab.SelectedIndex = 0;
            this.AccountGroupsTab.Size = new System.Drawing.Size(1072, 589);
            this.AccountGroupsTab.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.Window;
            this.Add.Controls.Add(this.btnCancel);
            this.Add.Controls.Add(this.btnSave);
            this.Add.Controls.Add(this.lblAccGrpName);
            this.Add.Controls.Add(this.tbAccGrpName);
            this.Add.Controls.Add(this.label1);
            this.Add.Location = new System.Drawing.Point(4, 22);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(3);
            this.Add.Size = new System.Drawing.Size(1064, 563);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(241, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(131, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAccGrpName
            // 
            this.lblAccGrpName.AutoSize = true;
            this.lblAccGrpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccGrpName.Location = new System.Drawing.Point(52, 132);
            this.lblAccGrpName.Name = "lblAccGrpName";
            this.lblAccGrpName.Size = new System.Drawing.Size(57, 22);
            this.lblAccGrpName.TabIndex = 6;
            this.lblAccGrpName.Text = "Name";
            // 
            // tbAccGrpName
            // 
            this.tbAccGrpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccGrpName.Location = new System.Drawing.Point(115, 129);
            this.tbAccGrpName.Name = "tbAccGrpName";
            this.tbAccGrpName.Size = new System.Drawing.Size(201, 27);
            this.tbAccGrpName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1058, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Account Group";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.SystemColors.Window;
            this.List.Controls.Add(this.datagridAccGrpNavigator);
            this.List.Controls.Add(this.dataGridAccGrp);
            this.List.Controls.Add(this.label2);
            this.List.Location = new System.Drawing.Point(4, 22);
            this.List.Name = "List";
            this.List.Padding = new System.Windows.Forms.Padding(3);
            this.List.Size = new System.Drawing.Size(1064, 563);
            this.List.TabIndex = 1;
            this.List.Text = "List";
            this.List.Enter += new System.EventHandler(this.List_Enter);
            // 
            // datagridAccGrpNavigator
            // 
            this.datagridAccGrpNavigator.AddNewItem = null;
            this.datagridAccGrpNavigator.CountItem = this.bindingNavigatorCountItem;
            this.datagridAccGrpNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.datagridAccGrpNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datagridAccGrpNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.datagridAccGrpNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.datagridAccGrpNavigator.Location = new System.Drawing.Point(3, 535);
            this.datagridAccGrpNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.datagridAccGrpNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.datagridAccGrpNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.datagridAccGrpNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.datagridAccGrpNavigator.Name = "datagridAccGrpNavigator";
            this.datagridAccGrpNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.datagridAccGrpNavigator.Size = new System.Drawing.Size(1058, 25);
            this.datagridAccGrpNavigator.TabIndex = 7;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // dataGridAccGrp
            // 
            this.dataGridAccGrp.AllowUserToAddRows = false;
            this.dataGridAccGrp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAccGrp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAccGrp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAccGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAccGrp.Location = new System.Drawing.Point(3, 50);
            this.dataGridAccGrp.Name = "dataGridAccGrp";
            this.dataGridAccGrp.Size = new System.Drawing.Size(1058, 510);
            this.dataGridAccGrp.TabIndex = 6;
            this.dataGridAccGrp.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridAccGrp_DataBindingComplete);
            this.dataGridAccGrp.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridAccGrp_DefaultValuesNeeded);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1058, 47);
            this.label2.TabIndex = 5;
            this.label2.Text = "Account Groups";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // AccountGroupForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 589);
            this.Controls.Add(this.AccountGroupsTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountGroupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Account Group";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AccountGroupForm_Load);
            this.AccountGroupsTab.ResumeLayout(false);
            this.Add.ResumeLayout(false);
            this.Add.PerformLayout();
            this.List.ResumeLayout(false);
            this.List.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAccGrpNavigator)).EndInit();
            this.datagridAccGrpNavigator.ResumeLayout(false);
            this.datagridAccGrpNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAccGrp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AccountGroupsTab;
        private System.Windows.Forms.TabPage Add;
        private System.Windows.Forms.TabPage List;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAccGrpName;
        private System.Windows.Forms.TextBox tbAccGrpName;
        private System.Windows.Forms.DataGridView dataGridAccGrp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator datagridAccGrpNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
    }
}