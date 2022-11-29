# How to customize the ProgressBarColumn text in WinForms DataGrid (SfDataGrid)

By default, [SfDataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid?_ga=2.73707355.890501811.1599449517-1942950702.1567054426) [GridProgressBarColumn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.GridProgressBarColumn.html?_gl=1*1fhohfg*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2OTM3NjkwOS4zMTQuMS4xNjY5MzgxNDk1LjAuMC4w&_ga=2.80345431.1315379768.1669285137-766490130.1650530957) have maximum value as 100, you can change the this by overriding the OnRender method in [GridProgressBarColumnCellRenderer](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Grid.GridProgressBarCellRenderer.html?_gl=1*1fhohfg*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2OTM3NjkwOS4zMTQuMS4xNjY5MzgxNDk1LjAuMC4w&_ga=2.80345431.1315379768.1669285137-766490130.1650530957) class.

```
this.sfDataGrid.CellRenderers.Remove("ProgressBar");
this.sfDataGrid.CellRenderers.Add("ProgressBar", new GridProgressBarColumnExt(new ProgressBarAdv()));public class GridProgressBarColumnExt : GridProgressBarCellRenderer
{
    ProgressBarAdv ProgressBar;
    public GridProgressBarColumnExt(ProgressBarAdv progressBar) : base(progressBar)
    {
        ProgressBar = progressBar;
    }
 
    protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
    {
        ProgressBar.CustomText = cellValue + "%";
        ProgressBar.TextStyle = ProgressBarTextStyles.Custom;
        decimal decimalvalue = decimal.Parse(cellValue);
        var intvalue = decimal.ToInt32(decimalvalue);
        cellValue = intvalue.ToString();
        base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
    }
}
```