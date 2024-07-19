using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

public class Trade
{
    public static void Main(string[] args)
    {

        Excel.Application xlApp = new Excel.Application();
        string filePath = @"C:\Users\vedat\source\repos\Trade\1 Aylık Döviz Alış ve Satış Dokümanı.xlsx";
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;

        int maxRow = xlRange.Rows.Count;
        int maxColumn = xlRange.Columns.Count;

        string alis = "Alış";
        string satis = "Satış";

        int AlisColumn = -1;
        int SatisColumn = -1;

        for (int col = 1; col <= maxColumn; col++)
        {
            if ((xlRange.Cells[1, col] as Excel.Range).Value2 != null)
            {
                if ((xlRange.Cells[1, col] as Excel.Range).Value2.ToString().Contains(alis))
                {
                    AlisColumn = col;
                }
                if ((xlRange.Cells[1, col] as Excel.Range).Value2.ToString().Contains(satis))
                {
                    SatisColumn = col;
                }
            }
        }

        List<(DateTime date, double rate)> alisList = new List<(DateTime, double)>();
        List<(DateTime date, double rate)> satisList = new List<(DateTime, double)>();


        for (int row = 2; row <= maxRow; row++)
        {
            DateTime date = DateTime.FromOADate((xlRange.Cells[row, 1] as Excel.Range).Value2);

            var alisValue = (xlRange.Cells[row, AlisColumn] as Excel.Range).Value2;
            var satisValue = (xlRange.Cells[row, SatisColumn] as Excel.Range).Value2;

            if (alisValue != null)
            {
                alisList.Add((date, alisValue));
            }

            if (satisValue != null)
            {
                satisList.Add((date, satisValue));
            }
        }

        alisList.Sort((a, b) => a.date.CompareTo(b.date));
        satisList.Sort((a, b) => a.date.CompareTo(b.date));

        double maxProfit = 0;
        DateTime bestBuyDate = DateTime.MinValue;
        DateTime bestSellDate = DateTime.MinValue;
        int alisCount = alisList.Count;
        int satisCount = satisList.Count;

        for (int i = 0; i < alisCount; i++)
        {
            for (int j = i + 1; j < satisCount; j++)
            {
                if (satisList[j].date > alisList[i].date)
                {
                    double profit = satisList[j].rate - alisList[i].rate;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                        bestBuyDate = alisList[i].date;
                        bestSellDate = satisList[j].date;
                    }
                }
            }
        }

        Console.WriteLine($"Best day to buy: {bestBuyDate.ToShortDateString()} at rate {alisList.Find(a => a.date == bestBuyDate).rate}");
        Console.WriteLine($"Best day to sell: {bestSellDate.ToShortDateString()} at rate {satisList.Find(s => s.date == bestSellDate).rate}");
        Console.WriteLine($"Maximum profit: {maxProfit}");  
        Console.WriteLine("Time Complexity: O(n^2)");


    }
}