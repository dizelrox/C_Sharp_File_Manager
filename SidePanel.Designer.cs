namespace FileManager
{
	partial class SidePanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SidePanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.upDirBtn = new System.Windows.Forms.ToolStripButton();
            this.rootDirBtn = new System.Windows.Forms.ToolStripButton();
            this.newDirBtn = new System.Windows.Forms.ToolStripButton();
            this.copyItemBtn = new System.Windows.Forms.ToolStripButton();
            this.moveItemBtn = new System.Windows.Forms.ToolStripButton();
            this.refreshListsBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteItemBtn = new System.Windows.Forms.ToolStripButton();
            this.compareDirsBtn = new System.Windows.Forms.ToolStripButton();
            this.compareFilesBtn = new System.Windows.Forms.ToolStripButton();
            this.txtEditorBtn = new System.Windows.Forms.ToolStripButton();
            this.searchBtn = new System.Windows.Forms.ToolStripButton();
            this.comboBoxDrives = new System.Windows.Forms.ToolStripComboBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upDirBtn,
            this.rootDirBtn,
            this.newDirBtn,
            this.copyItemBtn,
            this.moveItemBtn,
            this.refreshListsBtn,
            this.deleteItemBtn,
            this.compareDirsBtn,
            this.compareFilesBtn,
            this.txtEditorBtn,
            this.searchBtn,
            this.comboBoxDrives});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(528, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // upDirBtn
            // 
            this.upDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("upDirBtn.Image")));
            this.upDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upDirBtn.Name = "upDirBtn";
            this.upDirBtn.Size = new System.Drawing.Size(23, 25);
            this.upDirBtn.Text = "toolStripButton1";
            this.upDirBtn.ToolTipText = "Directory Up";
            this.upDirBtn.Click += new System.EventHandler(this.tsb_UpDir_Click);
            // 
            // rootDirBtn
            // 
            this.rootDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rootDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("rootDirBtn.Image")));
            this.rootDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rootDirBtn.Name = "rootDirBtn";
            this.rootDirBtn.Size = new System.Drawing.Size(23, 25);
            this.rootDirBtn.ToolTipText = "Root Directory";
            this.rootDirBtn.Click += new System.EventHandler(this.rootDirBtn_Click);
            // 
            // newDirBtn
            // 
            this.newDirBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("newDirBtn.Image")));
            this.newDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newDirBtn.Name = "newDirBtn";
            this.newDirBtn.Size = new System.Drawing.Size(23, 25);
            this.newDirBtn.ToolTipText = "New Folder";
            this.newDirBtn.Click += new System.EventHandler(this.newDirBtn_Click);
            // 
            // copyItemBtn
            // 
            this.copyItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("copyItemBtn.Image")));
            this.copyItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyItemBtn.Name = "copyItemBtn";
            this.copyItemBtn.Size = new System.Drawing.Size(23, 25);
            this.copyItemBtn.Text = "Copy File";
            this.copyItemBtn.Click += new System.EventHandler(this.copyItemBtn_Click);
            // 
            // moveItemBtn
            // 
            this.moveItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveItemBtn.Image")));
            this.moveItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveItemBtn.Name = "moveItemBtn";
            this.moveItemBtn.Size = new System.Drawing.Size(23, 25);
            this.moveItemBtn.Text = "Move";
            this.moveItemBtn.Click += new System.EventHandler(this.moveItemBtn_Click);
            // 
            // refreshListsBtn
            // 
            this.refreshListsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshListsBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshListsBtn.Image")));
            this.refreshListsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshListsBtn.Name = "refreshListsBtn";
            this.refreshListsBtn.Size = new System.Drawing.Size(23, 25);
            this.refreshListsBtn.Text = "Refresh Lists";
            this.refreshListsBtn.Click += new System.EventHandler(this.refreshListsBtn_Click);
            // 
            // deleteItemBtn
            // 
            this.deleteItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteItemBtn.Image")));
            this.deleteItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteItemBtn.Name = "deleteItemBtn";
            this.deleteItemBtn.Size = new System.Drawing.Size(23, 25);
            this.deleteItemBtn.Text = "Delete Item";
            this.deleteItemBtn.Click += new System.EventHandler(this.deleteItemBtn_Click);
            // 
            // compareDirsBtn
            // 
            this.compareDirsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compareDirsBtn.Image = ((System.Drawing.Image)(resources.GetObject("compareDirsBtn.Image")));
            this.compareDirsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compareDirsBtn.Name = "compareDirsBtn";
            this.compareDirsBtn.Size = new System.Drawing.Size(23, 25);
            this.compareDirsBtn.Text = "Compare Folders";
            this.compareDirsBtn.Click += new System.EventHandler(this.compareDirsBtn_Click);
            // 
            // compareFilesBtn
            // 
            this.compareFilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compareFilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("compareFilesBtn.Image")));
            this.compareFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compareFilesBtn.Name = "compareFilesBtn";
            this.compareFilesBtn.Size = new System.Drawing.Size(23, 25);
            this.compareFilesBtn.Text = "Compare Files Content";
            this.compareFilesBtn.Click += new System.EventHandler(this.compareFilesBtn_Click);
            // 
            // txtEditorBtn
            // 
            this.txtEditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.txtEditorBtn.Image = ((System.Drawing.Image)(resources.GetObject("txtEditorBtn.Image")));
            this.txtEditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtEditorBtn.Name = "txtEditorBtn";
            this.txtEditorBtn.Size = new System.Drawing.Size(23, 25);
            this.txtEditorBtn.Text = "toolStripButtom1";
            this.txtEditorBtn.ToolTipText = "Create Test File";
            this.txtEditorBtn.Click += new System.EventHandler(this.txtEditorBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchBtn.Image = global::FileManager.Properties.Resources.search_16x16;
            this.searchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(23, 25);
            this.searchBtn.Text = "toolStripButton1";
            this.searchBtn.ToolTipText = "Search";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(99, 28);
            this.comboBoxDrives.Sorted = true;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            // 
            // pathBox
            // 
            this.pathBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pathBox.Location = new System.Drawing.Point(0, 28);
            this.pathBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(528, 22);
            this.pathBox.TabIndex = 1;
            this.pathBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pathBox_KeyUp);
            this.pathBox.Leave += new System.EventHandler(this.pathBox_Leave);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 50);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(528, 511);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // SidePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SidePanel";
            this.Size = new System.Drawing.Size(528, 561);
            this.Load += new System.EventHandler(this.SidePanel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TextBox pathBox;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolStripButton upDirBtn;
        private System.Windows.Forms.ToolStripButton rootDirBtn;
        private System.Windows.Forms.ToolStripButton newDirBtn;
        private System.Windows.Forms.ToolStripButton copyItemBtn;
        private System.Windows.Forms.ToolStripButton moveItemBtn;
        private System.Windows.Forms.ToolStripButton refreshListsBtn;
        private System.Windows.Forms.ToolStripButton deleteItemBtn;
        private System.Windows.Forms.ToolStripButton compareDirsBtn;
        private System.Windows.Forms.ToolStripButton compareFilesBtn;
        private System.Windows.Forms.ToolStripButton txtEditorBtn;
        private System.Windows.Forms.ToolStripButton searchBtn;
        private System.Windows.Forms.ToolStripComboBox comboBoxDrives;
	}
}
