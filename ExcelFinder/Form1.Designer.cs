namespace ExcelFinder
{
    partial class ExcelFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelFinder));
            this.button_Find = new System.Windows.Forms.Button();
            this.textBox_keyword = new System.Windows.Forms.TextBox();
            this.label_keyword = new System.Windows.Forms.Label();
            this.label_folder = new System.Windows.Forms.Label();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.button_SelectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listView_result = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button_Find
            // 
            this.button_Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Find.Location = new System.Drawing.Point(311, 112);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(75, 23);
            this.button_Find.TabIndex = 0;
            this.button_Find.Text = "Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // textBox_keyword
            // 
            this.textBox_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_keyword.Location = new System.Drawing.Point(12, 29);
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.Size = new System.Drawing.Size(374, 20);
            this.textBox_keyword.TabIndex = 1;
            this.textBox_keyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_keyword_KeyDown);
            // 
            // label_keyword
            // 
            this.label_keyword.AutoSize = true;
            this.label_keyword.Location = new System.Drawing.Point(12, 13);
            this.label_keyword.Name = "label_keyword";
            this.label_keyword.Size = new System.Drawing.Size(95, 13);
            this.label_keyword.TabIndex = 2;
            this.label_keyword.Text = "Keyword to search";
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.Location = new System.Drawing.Point(9, 67);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(83, 13);
            this.label_folder.TabIndex = 3;
            this.label_folder.Text = "Folder to search";
            // 
            // textBox_folder
            // 
            this.textBox_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_folder.Location = new System.Drawing.Point(12, 83);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(344, 20);
            this.textBox_folder.TabIndex = 4;
            // 
            // button_SelectFolder
            // 
            this.button_SelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFolder.Location = new System.Drawing.Point(362, 83);
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.Size = new System.Drawing.Size(24, 23);
            this.button_SelectFolder.TabIndex = 5;
            this.button_SelectFolder.Text = "...";
            this.button_SelectFolder.UseVisualStyleBackColor = true;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // listView_result
            // 
            this.listView_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_result.FullRowSelect = true;
            this.listView_result.GridLines = true;
            this.listView_result.Location = new System.Drawing.Point(15, 139);
            this.listView_result.Name = "listView_result";
            this.listView_result.Size = new System.Drawing.Size(371, 138);
            this.listView_result.TabIndex = 6;
            this.listView_result.UseCompatibleStateImageBehavior = false;
            this.listView_result.View = System.Windows.Forms.View.Details;
            this.listView_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_keyword_KeyDown);
            this.listView_result.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_result_MouseDoubleClick);
            // 
            // ExcelFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 289);
            this.Controls.Add(this.listView_result);
            this.Controls.Add(this.button_SelectFolder);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.label_keyword);
            this.Controls.Add(this.textBox_keyword);
            this.Controls.Add(this.button_Find);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelFinder";
            this.Text = "ExcelFinder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.TextBox textBox_keyword;
        private System.Windows.Forms.Label label_keyword;
        private System.Windows.Forms.Label label_folder;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.Button button_SelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListView listView_result;
    }
}

