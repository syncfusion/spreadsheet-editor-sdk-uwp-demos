﻿using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;

namespace SpreadsheetSamples
{
    class SpreadsheetColumnExt : SpreadsheetColumn
    {
        SpreadsheetGrid grid;
        SfSpreadsheet spreadsheet;
        public SpreadsheetColumnExt(SpreadsheetGrid grid, SfSpreadsheet spreadsheet) : base(grid)
        {
            this.grid = grid;
            this.spreadsheet = spreadsheet;
        }
        public DataTemplate CellItemTemplate
        {
            get;
            set;
        }
        public DataTemplate CellEditTemplate
        {
            get;
            set;
        }
        protected override void OnUpdateColumn(out FrameworkElement oldElement)
        {
            var outlineWrappers = (spreadsheet.ActiveSheet as WorksheetImpl).OutlineWrappers;
            foreach(var item in outlineWrappers)
            {
                if (RowIndex.Equals(item.FirstIndex - 1))
                {
                    this.CellItemTemplate = spreadsheet.Resources["CellTemplateKey"] as DataTemplate;
                    //this.CellEditTemplate = Application.Current.Resources["CellTemplateKey"] as DataTemplate;
                }
            }
            base.OnUpdateColumn(out oldElement);
        }
    }
}
