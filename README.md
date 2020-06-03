# How to provide the decimal value to GridProgressBarColumn in Windows Form SfDataGrid
## About the sample
This example illustrates how to provide the decimal value to GridProgressBarColumn in Windows Form SfDataGrid. 

By default, GridProgressBarColumn shows only integer value in ProgressBar. Using the ProgressBar.CustomText property,  you can also show the decimal values in GridProgressBarColumn. You can achieve this by overriding the  GridProgressBarCellRenderer and you need to set the GridProgressBarColumn.ValueMode as None. 

```c#
 this.sfDataGrid1.Columns.Add(new GridProgressBarColumn() { MappingName = "Percentage", HeaderText = "Percentage", Maximum = 100, Minimum = 0, ValueMode =ProgressBarValueMode.None })

this.sfDataGrid1.CellRenderers.Remove("ProgressBar");
this.sfDataGrid1.CellRenderers.Add("ProgressBar", new GridProgressBarColumnExt(new ProgressBarAdv()));

public class GridProgressBarColumnExt : GridProgressBarCellRenderer
 {
     ProgressBarAdv ProgressBar;
     public GridProgressBarColumnExt(ProgressBarAdv progressBar) :base(progressBar)
     {
         ProgressBar = progressBar;
     }

     protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
     {
        
         ProgressBar.CustomText = cellValue + "%";
         ProgressBar.TextStyle = ProgressBarTextStyles.Custom;
         decimal decimalvalue = decimal.Parse(cellValue);
         var intvalue= decimal.ToInt32(decimalvalue);
         cellValue = intvalue.ToString();
         base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
     }
 }
```
## Requirements to run the demo
Visual Studio 2015 and above versions
