using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelExporter
{
    public class ExcelReporting
    {
        public string TemplatePath { private get; set; }
        public string ExportFilePath { private get; set; }
        public string SheetName { private get; set; }
        public DataTable DataToExport { private get; set; }
        public DateTime ExportStartTime { get; private set; }
        public DateTime ExportEndTime { get; private set; }

        private bool _ExportHeaders = false;
        public bool ExportHeaders { private get { return _ExportHeaders; } set { _ExportHeaders = value; } }

        private int _StartRow = 2;
        public int StartRow { private get { return _StartRow; } set { _StartRow = value; } }

        public ExcelReporting(DataTable dataToExport, string exportFilePath, string templatePath = null, string sheetName = "Sheet1")
        {
            ExportFilePath = exportFilePath;
            TemplatePath = templatePath;
            SheetName = sheetName;
            DataToExport = dataToExport;
        }

        private void StartExportingViaTemplate()
        {
            FileInfo newFile = new FileInfo(ExportFilePath);
            FileInfo template = new FileInfo(TemplatePath);

            if(!newFile.Exists)
            {
                newFile.Create();
            }

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                foreach (ExcelWorksheet aworksheet in xlPackage.Workbook.Worksheets)
                {
                    aworksheet.Cell(1, 1).Value = aworksheet.Cell(1, 1).Value;
                }
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[SheetName];
                if (worksheet == null)
                {
                    xlPackage.Workbook.Worksheets.Add(SheetName);
                    worksheet = xlPackage.Workbook.Worksheets[SheetName];
                }

                int startrow = 2;
                int row = 0;
                int col = 0;


                foreach (DataColumn column in DataToExport.Columns)
                {
                    col++;
                    ExcelCell cell = worksheet.Cell(1, col);
                    cell.Value = column.ColumnName;
                    xlPackage.Save();
                }

                col = 0;
                for (int j = 0; j < DataToExport.Columns.Count; j++)
                {
                    col++;
                    for (int i = 0; i < DataToExport.Rows.Count; i++)
                    {
                        row = startrow + i;
                        ExcelCell cell = worksheet.Cell(row, col);
                        cell.Value = DataToExport.Rows[i][j].ToString();
                        xlPackage.Save();
                    }
                }
            }

            ExportEndTime = DateTime.Now;
        }

        public void Export()
        {
            ExportStartTime = DateTime.Now;

            if (TemplatePath != null)
            {
                StartExportingViaTemplate();
                return;
            }

            FileInfo newFile = new FileInfo(ExportFilePath);

            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                foreach (ExcelWorksheet aworksheet in xlPackage.Workbook.Worksheets)
                {
                    aworksheet.Cell(1, 1).Value = aworksheet.Cell(1, 1).Value;
                }

                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[SheetName];
                if(worksheet == null)
                {
                    xlPackage.Workbook.Worksheets.Add(SheetName);
                    worksheet = xlPackage.Workbook.Worksheets[SheetName];
                }

                int startrow = 2;
                int row = 0;
                int col = 0;

                foreach (DataColumn column in DataToExport.Columns)
                {
                    col++;
                    ExcelCell cell = worksheet.Cell(1, col);
                    cell.Value = column.ColumnName;
                    xlPackage.Save();
                }

                col = 0;
                for (int j = 0; j < DataToExport.Columns.Count; j++)
                {
                    col++;
                    for (int i = 0; i < DataToExport.Rows.Count; i++)
                    {
                        row = startrow + i;
                        ExcelCell cell = worksheet.Cell(row, col);
                        cell.Value = DataToExport.Rows[i][j].ToString();
                        xlPackage.Save();
                    }
                }
            }

            ExportEndTime = DateTime.Now;
        }
    }
}
