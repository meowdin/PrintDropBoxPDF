namespace DropBoxPrint
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFileViews = new System.Windows.Forms.DataGridView();
            this.lblFileList = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetList = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFileViews)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1464, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrativeToolStripMenuItem,
            this.settingPasswordToolStripMenuItem,
            this.selectPrinterToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(124, 45);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // administrativeToolStripMenuItem
            // 
            this.administrativeToolStripMenuItem.Name = "administrativeToolStripMenuItem";
            this.administrativeToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.administrativeToolStripMenuItem.Text = "Administrative";
            this.administrativeToolStripMenuItem.Click += new System.EventHandler(this.administrativeToolStripMenuItem_Click);
            // 
            // settingPasswordToolStripMenuItem
            // 
            this.settingPasswordToolStripMenuItem.Name = "settingPasswordToolStripMenuItem";
            this.settingPasswordToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.settingPasswordToolStripMenuItem.Text = "Setting Password";
            this.settingPasswordToolStripMenuItem.Click += new System.EventHandler(this.settingPasswordToolStripMenuItem_Click);
            // 
            // dataFileViews
            // 
            this.dataFileViews.AllowUserToAddRows = false;
            this.dataFileViews.AllowUserToDeleteRows = false;
            this.dataFileViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataFileViews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFileViews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.PathLower});
            this.dataFileViews.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataFileViews.Location = new System.Drawing.Point(15, 183);
            this.dataFileViews.MultiSelect = false;
            this.dataFileViews.Name = "dataFileViews";
            this.dataFileViews.RowTemplate.Height = 40;
            this.dataFileViews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFileViews.Size = new System.Drawing.Size(1396, 539);
            this.dataFileViews.TabIndex = 1;
            // 
            // lblFileList
            // 
            this.lblFileList.AutoSize = true;
            this.lblFileList.Location = new System.Drawing.Point(35, 77);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(122, 32);
            this.lblFileList.TabIndex = 2;
            this.lblFileList.Text = "File List:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1133, 755);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(270, 76);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetList
            // 
            this.btnGetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetList.Location = new System.Drawing.Point(1153, 77);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(250, 64);
            this.btnGetList.TabIndex = 4;
            this.btnGetList.Text = "Get List";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(171, 123);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(114, 32);
            this.lblFolder.TabIndex = 5;
            this.lblFolder.Text = "{Folder}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Folder:";
            // 
            // selectPrinterToolStripMenuItem
            // 
            this.selectPrinterToolStripMenuItem.Name = "selectPrinterToolStripMenuItem";
            this.selectPrinterToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.selectPrinterToolStripMenuItem.Text = "Select Printer";
            this.selectPrinterToolStripMenuItem.Click += new System.EventHandler(this.selectPrinterToolStripMenuItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(15, 766);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(224, 65);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "Name";
            this.FileName.HeaderText = "Name";
            this.FileName.Name = "FileName";
            // 
            // PathLower
            // 
            this.PathLower.DataPropertyName = "PathLower";
            this.PathLower.HeaderText = "File";
            this.PathLower.Name = "PathLower";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 877);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFileList);
            this.Controls.Add(this.dataFileViews);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFileViews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingPasswordToolStripMenuItem;
        private System.Windows.Forms.Label lblFileList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetList;
        public System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem selectPrinterToolStripMenuItem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataFileViews;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathLower;
    }
}