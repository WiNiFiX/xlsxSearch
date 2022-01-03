using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.IO.Packaging;
using System.Windows.Forms;

namespace ExcelFinder
{
    /// <summary>
    /// Class to offer search in excel
    /// This class isn't generalized as plug-in concept
    /// This class shall inherit common interface to make this tool have more options
    /// </summary>
    class ExcelFind
    {
        /// <summary>
        /// Data class to store misc info and result
        /// path, file, location, content, etc..
        /// </summary>
        public class ExcelInfo
        {
            public string path { get; set; }
            public string fileName { get; set; }
            public string sheetName { get; set; }
            public UInt32Value row { get; set; }
            public UInt32Value column { get; set; }
            public string content { get; set; }
            public string error { get; set; }
        }
        public List<ExcelInfo> infoList { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ExcelFind()
        {
            infoList = new List<ExcelInfo>();
        }

        /// <summary>
        /// Method to execute seach
        /// 
        /// </summary>
        /// <param name="stringToSearch">string to search in xlsx files</param>
        /// <param name="pathToSearch">path to find xlsx files</param>
        public void FindTextInExcel(string stringToSearch, string pathToSearch, TextBox txtFileName, Label lblProgress)
        {
            // initialize before seaching
            infoList.Clear();

            // check folder existance first
            if (Directory.Exists(pathToSearch) == false)
            {
                string message = string.Format("Path {0} doesn't exist", pathToSearch);
                MessageBox.Show(message);
                return;
            }

            // then enumerate excel(.xlsx) files and search
            string[] files = Directory.GetFiles(pathToSearch, "*.xlsx", SearchOption.AllDirectories);
            int c = 0;

            foreach (var file in files)
            {
                c++;
                txtFileName.Text = Path.GetFileName(file);
                lblProgress.Text = $"Processing file: {c} of {files.Length}";

                // IO exception occurs when file is already opened by others
                Package spreadSheetPackage = null;
                try
                {
                    // open file
                    spreadSheetPackage = Package.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                catch (Exception e)
                {
                    ExcelInfo err = new ExcelInfo();
                    err.error = e.Message;
                    err.fileName = Path.GetFileName(file);
                    err.path = Path.GetDirectoryName(file);
                    err.content = e.Message;
                    infoList.Add(err);
                    continue;
                }

                using (SpreadsheetDocument document = SpreadsheetDocument.Open(spreadSheetPackage))
                {
                    var wbPart = document.WorkbookPart;
                    var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

                    // loop sheets in workbook
                    // this pyramid code shall be refactored, not nice.
                    foreach (var sheet in wbPart.Workbook.Descendants<Sheet>())
                    {
                        var wsheetPart = wbPart.GetPartById(sheet.Id) as WorksheetPart;
                        if (wsheetPart == null)
                        {
                            Console.WriteLine("WorksheetPart Not Found !!");
                            return;
                        }

                        var ws = wsheetPart.Worksheet;
                        foreach (var row in ws.Descendants<Row>())
                        {
                            var list = new List<string>();
                            UInt32Value colnum = 0;
                            foreach (Cell cell in row)
                            {
                                colnum++; // count up column number

                                string value = cell.InnerText;
                                if (cell.DataType != null)
                                {
                                    switch (cell.DataType.Value)
                                    {
                                        case CellValues.Boolean:
                                        case CellValues.Date:
                                        case CellValues.Error:
                                        case CellValues.InlineString:
                                        case CellValues.Number:
                                        case CellValues.String:
                                            value = cell.InnerText;
                                            break;
                                        case CellValues.SharedString:
                                            if (stringTable != null)
                                                value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                                            break;
                                        default:
                                            break;
                                    }
                                }


                                // check if value contains keyword to seach
                                if (!value.Contains(stringToSearch))
                                {
                                    continue;
                                }

                                // go on if keyword found
                                list.Add(value);

                                // construct data class and store int list
                                ExcelInfo data = new ExcelInfo();
                                data.content = value;
                                data.row = row.RowIndex;
                                data.column = colnum;
                                data.sheetName = sheet.Name;
                                data.fileName = Path.GetFileName(file);
                                data.content = value;
                                data.path = Path.GetDirectoryName(file);

                                infoList.Add(data);

                            }
                        }
                    }
                }
            }
        }
    }
}
