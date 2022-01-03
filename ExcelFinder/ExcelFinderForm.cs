using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.IO.Packaging;
using System.Threading;

namespace ExcelFinder
{
    public partial class ExcelFinder : Form
    {
        private System.Drawing.Color[] stripColors = new System.Drawing.Color[] { SystemColors.ButtonFace, SystemColors.Window };

        public ExcelFinder()
        {
            InitializeComponent();

            InitializeUIs();
            InitializeList();
            InitializeEventHandlers();
        }

        private void InitializeUIs()
        {
            label_keyword.Text = Properties.Resources.LabelKeywordToSearch;
            label_folder.Text = Properties.Resources.LabelFolderToSearch;
            button_Find.Text = Properties.Resources.ButtonFind;
        }


        private void InitializeList()
        {
            listView_result.Columns.Add("Path");
            listView_result.Columns.Add("File");
            listView_result.Columns.Add("Sheet");
            listView_result.Columns.Add("Location(row:column)");
            listView_result.Columns.Add("Content");
            listView_result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void InitializeEventHandlers()
        {

        }

        private void button_SelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_folder.Text = folderBrowserDialog.SelectedPath;
            }
        }

 

        private void textBox_keyword_KeyDown(object sender, KeyEventArgs e)
        {
            // handle enter key on keyword text box,
            //  start searching on pressing enter key
            if (e.KeyCode == Keys.Enter)
            {

                button_Find_Click(sender, e);
            }
        }

        private void listView_keyword_KeyDown(object sender, KeyEventArgs e)
        {

            // handle Ctrl+c, copying selected items to clipboard
            if ((e.KeyCode == Keys.C) &&
                (e.Control))
            {
                string selectedString = "";
                foreach (ListViewItem item in listView_result.SelectedItems)
                {
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        selectedString += "\"";
                        selectedString += subItem.Text;
                        selectedString += "\"";
                        selectedString += ",";
                    }

                    selectedString += "\r\n";
                }

                Clipboard.SetText(selectedString);
            }
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            // sanity checks
            if ((textBox_folder.Text.Equals("")) ||
                (textBox_keyword.Text.Equals("")))
            {
                return; // can't process
            }

            // start finding
            UseWaitCursor = true;
            listView_result.Items.Clear(); // initialize

            Thread th = new Thread(delegate ()
            {
                ExcelFind finder = new ExcelFind();
                finder.FindTextInExcel(textBox_keyword.Text, textBox_folder.Text, txtProcessingFile, lblProgress);

                int count = 0;
                foreach (ExcelFind.ExcelInfo info in finder.infoList)
                {
                    count++;
                    if (count > 15) break;

                    ListViewItem item = listView_result.Items.Add(info.path);
                    item.SubItems.Add(info.fileName);
                    item.SubItems.Add(info.sheetName);
                    item.SubItems.Add(info.row + ":" + info.column);
                    item.SubItems.Add(info.content);
                }

                listView_result.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                txtProcessingFile.Text = "Done.";

                UseWaitCursor = false;
            });
            th.IsBackground = true;
            th.Start();
        }

        private void listView_result_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // open folder of selected item when double click
            var selected =  listView_result.SelectedItems;
            string path = selected[0].SubItems[0].Text;

            System.Diagnostics.Process.Start(path);
        }

        private void listView_result_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // color rows stripes
            if (e.Item.ListView.View == View.Details)
            {
                e.Item.BackColor = stripColors[e.Item.Index % stripColors.Length];
            }

            e.DrawDefault = true;
        }

        private void listView_result_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ExcelFinder_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
