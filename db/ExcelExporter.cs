﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoadBalanceProject.db
{
    class ExcelExporter
    {
        static public void ExportToExcel(List<KeyValuePair<int, double>> list, string FileName, string sheetName)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet1 = null;

            try
            {
                worksheet1 = workbook.ActiveSheet;
                worksheet1.Name = sheetName;

                // start form 1: the head
                worksheet1.Cells[1, 1] = "Po"; //PO
                worksheet1.Cells[1, 2] = "File Name"; // FILE NAME
                worksheet1.Cells[1, 3] = "Lang";// languages pair
                worksheet1.Cells[1, 4] = "Date"; // date
                worksheet1.Cells[1, 5] = "deadline";// deadline
                worksheet1.Cells[1, 6] = "rate";// rate
                worksheet1.Cells[1, 7] = "word";// words count
                worksheet1.Cells[1, 8] = "total";// total
                worksheet1.Cells[1, 9] = "project contact";// project contact

                // header
#pragma warning disable CS0219 // The variable 'rowIndex' is assigned but its value is never used
                int rowIndex = 2;
#pragma warning restore CS0219 // The variable 'rowIndex' is assigned but its value is never used
                foreach (KeyValuePair<int, double> row in list)
                {
                    /*
                    worksheet.Cells[rowIndex, 1] = row.PO;
                    worksheet.Cells[rowIndex, 2] = row.FileName;
                    worksheet.Cells[rowIndex, 3] = row.Language;
                    worksheet.Cells[rowIndex, 4] = row.Date;
                    worksheet.Cells[rowIndex, 5] = row.DueDate;
                    worksheet.Cells[rowIndex, 6] = row.Rate;
                    worksheet.Cells[rowIndex, 7] = row.wordCount;
                    worksheet.Cells[rowIndex, 8] = row.price;
                    worksheet.Cells[rowIndex, 9] = row.Contact;
                    rowIndex++;*/
                }



                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = FileName;
                if (saveDialog.ShowDialog() == true)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("deleted！");

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
    }
}

