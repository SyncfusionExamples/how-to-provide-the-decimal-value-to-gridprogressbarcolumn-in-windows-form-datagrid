using Syncfusion.Data;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid_WF
{
    public partial class Form1 : Form
    {
        ObservableCollection<OrderInfo> list = new ObservableCollection<OrderInfo>();       
        public Form1()
        {
            InitializeComponent();

            list.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", new DateTime(2020, 06, 12), 25.20));
            list.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.", null, 45.30));
            list.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", new DateTime(2020, 06, 12), 52.13));
            list.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", new DateTime(2020, 06, 12), 75.60));
            list.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", new DateTime(2020, 06, 12), 34.27));
            list.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", new DateTime(2020, 06, 12), 85.30));
            list.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", new DateTime(2020, 06, 12), 15.02));
            list.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid", null, 65.45));
            list.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille", null, 95.70));
            list.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", new DateTime(2020, 06, 12), 82.73));

            this.sfDataGrid1.AutoGenerateColumns = false;

           
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "Country" });
            this.sfDataGrid1.Columns.Add(new GridProgressBarColumn() { MappingName = "Percentage", HeaderText = "Percentage", Maximum = 100, Minimum = 0, ValueMode =ProgressBarValueMode.None });
            this.sfDataGrid1.DataSource = list;

            this.sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
          
            this.sfDataGrid1.CellRenderers.Remove("ProgressBar");
            this.sfDataGrid1.CellRenderers.Add("ProgressBar", new GridProgressBarColumnExt(new ProgressBarAdv()));
            
        }
    }

   
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

}


