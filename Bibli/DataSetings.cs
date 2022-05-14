using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Bibli
{
    public class DataSetings
    {
        public string path { get; private set; }
        Model1 db = new Model1();

        public DataSetings() { }
        public DataSetings(string path)
        {
            this.path = path;
        }


        public List<newEquipment> getListOfCar(DateTime from, DateTime to)
        {
            List<newEquipment> newEquipments = new List<newEquipment>();
            newEquipments = db.newEquipment.
                Where(w => w.CreateDate >= from && w.CreateDate <= to).ToList();

            return newEquipments;
        }

        public bool creatExel(List<newEquipment> newEquipments)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int k = 3;
                foreach (var elem in newEquipments)
                {
                    worksheet.Cells[k, 1].Value = elem.TablesModel.strName;
                    worksheet.Cells[k, 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    worksheet.Cells[k, 2].Value = "";
                    worksheet.Cells[k, 1].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    worksheet.Cells[k, 3].Value = elem.LastDate;
                    worksheet.Cells[k, 1].Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    worksheet.Cells[k, 4].Value = "";
                    worksheet.Cells[k, 1].Style.Font.Color.SetColor(System.Drawing.Color.Orange);
                    k++;
                }
                try
                {
                    package.SaveAs("Result_" + DateTime.Now.Year + ".xlsx");
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
