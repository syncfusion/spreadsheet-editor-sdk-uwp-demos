﻿using Syncfusion.UI.Xaml.Spreadsheet.CellRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Grid.ScrollAxis;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.CellGrid.GridCellRenderer;

namespace SpreadsheetSamples
{
    class SpreadsheetTemplateCellRenderer : SpreadsheetVirtualizingCellRendererBase<ContentControl, ContentControl>
    {
        public SpreadsheetTemplateCellRenderer()
        {
            SupportDrawingOptimization = false;
        }
        protected override void OnUpdateCellStyle(RowColumnIndex cellRowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }
        protected override void OnUpdateEditCellStyle(RowColumnIndex cellRowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }
        protected override void OnInitializeDisplayElement(RowColumnIndex rowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }

        protected override void OnInitializeEditElement(RowColumnIndex rowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }
        private void UpdateTemplate(ContentControl uiElement, SpreadsheetColumn column)
        {
            var wrapper = (GridCellWrapper)uiElement.DataContext;
            var template = (column as SpreadsheetColumnExt).CellItemTemplate;
            if (template != uiElement.ContentTemplate)
                uiElement.ContentTemplate = template;
            uiElement.DataContext = null;
            if (wrapper == null)
                wrapper = new GridCellWrapper();
            uiElement.DataContext = wrapper;
            uiElement.Content = wrapper;
            wrapper.CellValue = column.ExcelRange.DisplayText;
        }
    }
}
