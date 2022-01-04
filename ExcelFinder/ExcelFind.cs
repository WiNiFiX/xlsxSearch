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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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

        static string Rewriter(Uri partUri, string id, string uri) => $"http://unknown?id={id}";

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
            string[] files1 = Directory.GetFiles(pathToSearch, "*.xlsx", SearchOption.AllDirectories);
            string[] files2 = Directory.GetFiles(pathToSearch, "*.xls", SearchOption.AllDirectories);
            int c = 0;

            var files = files1.Union(files2).ToArray();

            foreach (var file in files)
            {
                c++;
                txtFileName.Text = file;
                lblProgress.Text = $"Processing file [{Path.GetFileName(file)}]: {c} of {files.Length}";

                IWorkbook mWorkBook = null;                

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        if (Path.GetExtension(file).Equals(".xlsx"))
                        {
                            mWorkBook = new XSSFWorkbook(fs);
                        }
                        else // old XLS format, load and search it...
                        {
                            mWorkBook = new HSSFWorkbook(fs);
                        }

                        for (int sheetNo = 0; sheetNo < mWorkBook.NumberOfSheets; sheetNo++)
                        {
                            var sheet = mWorkBook.GetSheetAt(sheetNo);
                            for (int rowNo = 0; rowNo < sheet.LastRowNum; rowNo++)
                            {
                                var list = new List<string>();

                                var row = sheet.GetRow(rowNo);
                                if (row == null) continue;

                                for (int colNo = 0; colNo < row.LastCellNum; colNo++)
                                {
                                    var cell = row.GetCell(colNo);
                                    var value = CellValueAsString(cell, rowNo, colNo, sheet.SheetName, file);

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
                                    data.row = (uint)rowNo;
                                    data.column = (uint)colNo;
                                    data.sheetName = sheet.SheetName;
                                    data.fileName = Path.GetFileName(file);
                                    data.content = value;
                                    data.path = Path.GetDirectoryName(file);

                                    infoList.Add(data);
                                }
                            }
                        }
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
                }

            }
        }

        private string CellValueAsString(ICell cell, int row, int col, string sheetName, string fileName)
        {
            if (cell == null)
                return "";
            if (cell.CellType == NPOI.SS.UserModel.CellType.String)
                return cell.StringCellValue;
            if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                return cell.NumericCellValue.ToString();
            return "";
        }
    }
}
