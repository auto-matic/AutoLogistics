using System;
using System.Collections.Generic;
using System.Linq;
namespace Automatic
{
    public class Table
    {
        public int columns { get; private set; }
        public int columnWidth { get; private set; }

        public List<string> header { get; private set; }
        public List<List<string>> rows { get; private set; }

        public Table(List<string> columns, int columnWidth)
        {
            this.columns = columns.Count;
            this.columnWidth = columnWidth;
            this.rows = new List<List<string>>();
            SetHeader(columns);
        }

        public void SetHeader(List<string> header)
        {
           this.header = (from cell in header where header.IndexOf(cell) < columns select cell).ToList();
        }

        public void AddRow(List<string> row)
        {
            rows.Add((from cell in row where row.IndexOf(cell) < columns select cell).ToList());
        }

        public void Print()
        {
            string header = "|";

            foreach(string str in this.header)
            {
                header += Misc.FitString(str, columnWidth) + "|";
            }
            Console.WriteLine(header);

            string separator = String.Empty;

            for (int i = 0; i < this.header.Count * columnWidth + this.header.Count + 1; i++)
            {
                separator += "-";
            }
            Console.WriteLine(separator);

            foreach (var row in this.rows)
            {
                string _row = "|";

                foreach (var cell in row)
                {
                    _row += Misc.FitString(cell, columnWidth) + "|";
                }
                Console.WriteLine(_row);
            }
        }
    }
}
