﻿namespace ExcelFinder
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
            this.txtProcessingFile = new System.Windows.Forms.TextBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Find
            // 
            resources.ApplyResources(this.button_Find, "button_Find");
            this.button_Find.Name = "button_Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // textBox_keyword
            // 
            resources.ApplyResources(this.textBox_keyword, "textBox_keyword");
            this.textBox_keyword.Name = "textBox_keyword";
            this.textBox_keyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_keyword_KeyDown);
            // 
            // label_keyword
            // 
            resources.ApplyResources(this.label_keyword, "label_keyword");
            this.label_keyword.Name = "label_keyword";
            // 
            // label_folder
            // 
            resources.ApplyResources(this.label_folder, "label_folder");
            this.label_folder.Name = "label_folder";
            // 
            // textBox_folder
            // 
            resources.ApplyResources(this.textBox_folder, "textBox_folder");
            this.textBox_folder.Name = "textBox_folder";
            // 
            // button_SelectFolder
            // 
            resources.ApplyResources(this.button_SelectFolder, "button_SelectFolder");
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.UseVisualStyleBackColor = true;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // listView_result
            // 
            resources.ApplyResources(this.listView_result, "listView_result");
            this.listView_result.FullRowSelect = true;
            this.listView_result.GridLines = true;
            this.listView_result.HideSelection = false;
            this.listView_result.Name = "listView_result";
            this.listView_result.OwnerDraw = true;
            this.listView_result.UseCompatibleStateImageBehavior = false;
            this.listView_result.View = System.Windows.Forms.View.Details;
            this.listView_result.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView_result_DrawColumnHeader);
            this.listView_result.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_result_DrawItem);
            this.listView_result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_keyword_KeyDown);
            this.listView_result.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_result_MouseDoubleClick);
            // 
            // txtProcessingFile
            // 
            resources.ApplyResources(this.txtProcessingFile, "txtProcessingFile");
            this.txtProcessingFile.Name = "txtProcessingFile";
            this.txtProcessingFile.ReadOnly = true;
            // 
            // lblProgress
            // 
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.Name = "lblProgress";
            // 
            // ExcelFinder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtProcessingFile);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.listView_result);
            this.Controls.Add(this.button_SelectFolder);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.label_folder);
            this.Controls.Add(this.label_keyword);
            this.Controls.Add(this.textBox_keyword);
            this.Controls.Add(this.button_Find);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelFinder";
            this.Load += new System.EventHandler(this.ExcelFinder_Load);
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
        private System.Windows.Forms.TextBox txtProcessingFile;
        private System.Windows.Forms.Label lblProgress;
    }
}

