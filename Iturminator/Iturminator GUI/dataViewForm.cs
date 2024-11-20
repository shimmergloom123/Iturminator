using Iturminator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iturminator_GUI
{
    public partial class dataViewForm : Form
    {
        private readonly List<string> _selectedColumns;
        private readonly List<string> _frozenColumns;
        private readonly List<string> _selectedAndFrozenColumns;


        public dataViewForm(List<string> selectedColumns, List<string> frozenColumns)
        {
            InitializeComponent();
            _selectedColumns = selectedColumns;
            _frozenColumns = frozenColumns;
            // Combine selected and frozen columns, avoiding duplicates
            _selectedAndFrozenColumns = selectedColumns
                .Union(frozenColumns)
                .ToList();

        }

        private void DataViewForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            

            // Get the filtered data based on selected columns
            var filteredTable = DataManager.Instance.FinalDataTable.DefaultView.ToTable(false, _selectedAndFrozenColumns.ToArray());
            dataGridViewData.DataSource = filteredTable;

            

            int displayIndex = 0;
            // Apply frozen columns
            foreach (var columnName in _frozenColumns)
            {
                if (dataGridViewData.Columns[columnName] != null)
                {
                    var column = dataGridViewData.Columns[columnName];
                    column.Frozen = true;
                    column.DisplayIndex = displayIndex++; // Increment display index for each frozen column
                    column.Width = 150; // Ensure reasonable width
                }
            }
            dataGridViewData.ScrollBars = ScrollBars.Both;
            
        }



        private void syncDataManager()
        {
            // Get the current data source from the DataGridView
            DataTable updatedDataOrig = ((DataTable)dataGridViewData.DataSource).Copy();
            DataTable updatedData = new DataTable();

            if (chkSaveHiddenData.Checked)
            {
                // Combine the hidden columns with the current DataGridView data
                updatedData = CombineWithHiddenColumns(updatedDataOrig);
            }
            else
            {
                // Replace the MainDataTable in DataManager with the current DataGridView data only
                updatedData = updatedDataOrig;
            }
            DataManager.Instance.FinalDataTable = updatedData;
        }

        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBackToStartup_Click(object sender, EventArgs e)
        {
            syncDataManager();

            this.Close();
        }


        private DataTable CombineWithHiddenColumns(DataTable updatedData)
        {
            // Get the hidden columns from DataManager
            var hiddenColumns = DataManager.Instance.HiddenColumns;

            // Loop through hidden columns and add them back to the updated data
            foreach (var columnName in hiddenColumns)
            {
                if (!updatedData.Columns.Contains(columnName))
                {
                    // Add the hidden column to the updatedData table
                    updatedData.Columns.Add(columnName, DataManager.Instance.FinalDataTable.Columns[columnName].DataType);
                }

                // Populate the hidden column data from the MainDataTable
                for (int i = 0; i < updatedData.Rows.Count; i++)
                {
                    updatedData.Rows[i][columnName] = DataManager.Instance.FinalDataTable.Rows[i][columnName];
                }
            }

            // Return the updated data
            return updatedData;
        }

    }

    public class CustomDataGridView : DataGridView
    {
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            // Force the horizontal scrollbar to be visible
            if (this.HorizontalScrollBar.Visible == false)
            {
                this.HorizontalScrollBar.Visible = true;
            }
        }
    }


}
