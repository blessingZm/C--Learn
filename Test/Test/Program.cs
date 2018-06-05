using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Cells;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Console.WriteLine(wb.Worksheets.Count);
            Worksheet ws_one = wb.Worksheets.Add("one");
            ws_one.Cells[0, 0].Value = "ceshi";
            Console.WriteLine(wb.Worksheets.Count);
            wb.Save("11.xlsx");

            Console.ReadKey();
        }
    }
}
