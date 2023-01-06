using ApiCatalago.Models;
using OfficeOpenXml;
using System.Data;

namespace ApiCatalago.Services
{
    public class ExportarRelatorios
    {
        public static void ExportaExcel(List<Produtos> listaProdutos, string saida, FileInfo fi, string nome)
        {
            string nomeShet = "Lista Produtos";

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(ExcelPackage pck = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[nomeShet];

                if(ws != null)
                   pck.Workbook.Worksheets.Delete(nomeShet);

                ws = pck.Workbook.Worksheets.Add(nome);
                ws.Cells[1, 1].LoadFromCollection(listaProdutos, true, OfficeOpenXml.Table.TableStyles.Medium1);
                
                ExcelAddressBase address = ws.Dimension;
                using(ExcelRange rng = ws.Cells[address.ToString()])
                {
                    rng.Style.Font.Size = 8;
                }
                ws.Columns.AutoFit();
                pck.SaveAs(nome);
            }
        }
    }
}
