using Excell = Microsoft.Office.Interop.Excel;
namespace ExcellReports
{
    public class Price_list
    {
        Excell.Application ExcellApp;

        public string Header_StartCell = "A1";
        public string Body_StartCell = "A2";

        public Price_list() 
        {
            ExcellApp = new Excell.Application();
        }

        public void CreateExcellDocument(string templatePath,  string[,] reportData, string reportName) 
        {
            Excell.Workbook workbook;
            Excell.Workbook template;
            Excell.Worksheet worksheet;
            Excell.Range templateHeader;
            Excell.Range reportHeader;
            Excell.Range reportBody;

            ExcellApp.DisplayAlerts = false;

            template = ExcellApp.Workbooks.Open(templatePath, ReadOnly: true);
            worksheet= serchWks(template, "Report");
            templateHeader = serchTbl(worksheet, "ReportTable");

            if (templateHeader == null)
            {
                template.Close();
                ExcellApp.Quit();
                return;
            }
            templateHeader.Copy();

            // создаем отчет

            workbook = ExcellApp.Workbooks.Add();
            worksheet = (Excell.Worksheet)workbook.ActiveSheet;
            worksheet.Name = reportName;

            reportHeader = (Excell.Range)worksheet.Range[Header_StartCell].Resize[1, templateHeader.Columns.Count];
            reportHeader.PasteSpecial(Excell.XlPasteType.xlPasteColumnWidths);
            reportHeader.PasteSpecial(Excell.XlPasteType.xlPasteAll);
            reportHeader.PasteSpecial(Excell.XlPasteType.xlPasteAllExceptBorders);

            reportBody= worksheet.Range[Body_StartCell].Resize[reportData.GetUpperBound(0) + 1, reportData.GetUpperBound(1) + 1];
            reportBody.Value = reportData;

            ExcellApp.Visible = true;

            reportBody = serchTbl(worksheet, "ReportTable");

            if (reportBody == null)
            {
                template.Close();
                workbook.Close();
                ExcellApp.Quit();
                return;
            }

            reportBody.Borders.LineStyle = 1;

            reportBody = worksheet.Range["A1:Z1000"];
            reportBody.Font.Name = "Arial";
            reportBody.Font.Size = 14;
            reportBody.WrapText = 1;

            template.Close();
            ExcellApp.Visible = true;

        }

        private Excell.Worksheet serchWks(Excell.Workbook ExcellWbk, string nameList)
        {
            foreach (Excell.Worksheet ExcellWks in ExcellWbk.Worksheets)
            {
                string nameWks = ExcellWks.Name;
                if (nameWks == nameList)
                {
                    return (Excell.Worksheet)ExcellWks;
                }
            }
            return null;
        }

        public Excell.Range serchTbl(Excell.Worksheet ExcellWks, string nameLObj)
        {
            foreach (Excell.ListObject tbl in ExcellWks.ListObjects)
            {
                string nameTbl = tbl.Name;
                if (nameTbl.Substring(0, nameLObj.Length) == nameLObj)
                {
                    return tbl.Range;
                }
            }
            return null;
        }
    }
}
