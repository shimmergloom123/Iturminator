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
        private readonly List<string> _frozenColumns;
        private readonly List<string> _selectedColumns;


        public dataViewForm(List<string> selectedColumns, List<string> frozenColumns)
        {
            InitializeComponent();

            _frozenColumns = frozenColumns;
            _selectedColumns = selectedColumns;

            // Attach Load event to configure DataGridView
            this.Load += DataViewForm_Load;
        }

        private void ConfigureDataGridView()
        {
            // Calculate scrollable columns
            var scrollableColumns = _selectedColumns;

            // Bind frozen grid (right panel)
            if (_frozenColumns.Count > 0)
            {
                // Bind frozen columns if they exist
                var frozenTable = DataManager.Instance.FinalDataTable.DefaultView.ToTable(false, _frozenColumns.ToArray());
                dataGridViewFrozen.DataSource = frozenTable;

                foreach (DataGridViewColumn column in dataGridViewFrozen.Columns)
                {
                    column.Width = 150; // Set column width
                }
            }
            else
            {
                // Clear or hide the frozen grid if no frozen columns
                dataGridViewFrozen.DataSource = null;
            }

            // Bind scrollable grid (left panel)
            if (scrollableColumns.Count > 0)
            {
                var scrollableTable = DataManager.Instance.FinalDataTable.DefaultView.ToTable(false, scrollableColumns.ToArray());
                dataGridViewMain.DataSource = scrollableTable;

                foreach (DataGridViewColumn column in dataGridViewMain.Columns)
                {
                    column.Width = 150; // Set column width
                }
            }
            else
            {
                // Handle the edge case where there are no scrollable columns
                dataGridViewMain.DataSource = CreateEmptyTable();
            }

            // Adjust SplitContainer layout
            AdjustSplitterDistance();

            // Sync scrolling and selection
            if (dataGridViewFrozen.DataSource != null && dataGridViewMain.DataSource != null)
            {
                SyncScrolling();
                SyncRowSelection();

            }

            dataGridViewMain.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
            if (dataGridViewFrozen.DataSource != null)
            {
                dataGridViewFrozen.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;
            }

        }

        private DataTable CreateEmptyTable()
        {
            return new DataTable(); // Returns an empty table
        }


        private void AdjustSplitterDistance()
        {
            int frozenWidth = dataGridViewFrozen.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width);

            // Ensure the SplitterDistance is valid, even if no frozen columns exist
            if (frozenWidth <= 0)
            {
                splitContainer1.SplitterDistance = splitContainer1.Width - 10; // Default behavior when no frozen columns
            }
            else
            {
                splitContainer1.SplitterDistance = splitContainer1.Width - frozenWidth - 10; // Adjust based on frozen width
            }
        }



        private void DataViewForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
        }

        private void syncDataManager()
        {
            // Handle the frozen table conditionally
            DataTable frozenTable = null;
            if (dataGridViewFrozen.DataSource != null)
            {
                frozenTable = ((DataTable)dataGridViewFrozen.DataSource).Copy();
            }

            // Always get the scrollable table
            DataTable scrollableTable = ((DataTable)dataGridViewMain.DataSource).Copy();

            // Combine the two tables into one updated table
            DataTable updatedDataOrig = CombineFrozenAndScrollableColumns(frozenTable, scrollableTable);

            DataTable updatedData;
            if (chkSaveHiddenData.Checked)
            {
                // Combine with hidden columns if the checkbox is checked
                updatedData = CombineWithHiddenColumns(updatedDataOrig);
            }
            else
            {
                // Use only the visible columns' data
                updatedData = updatedDataOrig;
            }

            // Update the FinalDataTable in DataManager
            DataManager.Instance.FinalDataTable = updatedData;
        }

        private DataTable CombineFrozenAndScrollableColumns(DataTable frozenTable, DataTable scrollableTable)
        {
            DataTable combinedTable = new DataTable();
            if (frozenTable != null)
                {
                combinedTable = frozenTable.Clone(); // Clone structure of the frozen table

            }

            // Add columns from the scrollable table that are not in the frozen table
            foreach (DataColumn col in scrollableTable.Columns)
            {
                if (!combinedTable.Columns.Contains(col.ColumnName))
                {
                    combinedTable.Columns.Add(col.ColumnName, col.DataType);
                }
            }

            // Merge rows from both tables
            for (int i = 0; i < scrollableTable.Rows.Count; i++)
            {
                DataRow newRow = combinedTable.NewRow();

                if (frozenTable != null)
                {
                    // Copy frozen columns
                    foreach (DataColumn col in frozenTable.Columns)
                    {
                        newRow[col.ColumnName] = frozenTable.Rows[i][col.ColumnName];
                    }
                }
                

                // Copy scrollable columns
                foreach (DataColumn col in scrollableTable.Columns)
                {
                    newRow[col.ColumnName] = scrollableTable.Rows[i][col.ColumnName];
                }

                combinedTable.Rows.Add(newRow);
            }

            return combinedTable;
        }


        private void dataGridViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBackToStartup_Click(object sender, EventArgs e)
        {
            syncDataManager();

            if (!chkSaveHiddenData.Checked)
            {
                ClearHiddenColumnsFromSelection();
            }

            this.Close();
        }

        private void ClearHiddenColumnsFromSelection()
        {
            // Clear hidden columns in DataManager
            DataManager.Instance.HiddenColumns.Clear();

            // Refresh the Hidden Columns listbox in the selection screen
            if (Owner is StartupForm startupForm)
            {
                startupForm.RefreshHiddenColumnsList();
            }
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

        private void SyncScrolling()
        {
            // Synchronize vertical scrolling between the two grids
            dataGridViewMain.Scroll += (s, e) =>
            {
                if (dataGridViewFrozen.FirstDisplayedScrollingRowIndex != dataGridViewMain.FirstDisplayedScrollingRowIndex)
                {
                    dataGridViewFrozen.FirstDisplayedScrollingRowIndex = dataGridViewMain.FirstDisplayedScrollingRowIndex;
                }
            };

            dataGridViewFrozen.Scroll += (s, e) =>
            {
                if (dataGridViewMain.FirstDisplayedScrollingRowIndex != dataGridViewFrozen.FirstDisplayedScrollingRowIndex)
                {
                    dataGridViewMain.FirstDisplayedScrollingRowIndex = dataGridViewFrozen.FirstDisplayedScrollingRowIndex;
                }
            };
        }

        private void SyncRowSelection()
        {
            // Flag to suppress recursive events
            bool isSyncingSelection = false;

            dataGridViewMain.SelectionChanged += (s, e) =>
            {
                if (isSyncingSelection) return;

                if (dataGridViewMain.CurrentCell != null)
                {
                    int rowIndex = dataGridViewMain.CurrentCell.RowIndex;

                    // Suppress recursive event calls
                    isSyncingSelection = true;
                    dataGridViewFrozen.ClearSelection();

                    if (rowIndex < dataGridViewFrozen.Rows.Count)
                    {
                        dataGridViewFrozen.Rows[rowIndex].Selected = true;
                    }
                    isSyncingSelection = false;
                }
            };

            dataGridViewFrozen.SelectionChanged += (s, e) =>
            {
                if (isSyncingSelection) return;

                if (dataGridViewFrozen.CurrentCell != null)
                {
                    int rowIndex = dataGridViewFrozen.CurrentCell.RowIndex;

                    // Suppress recursive event calls
                    isSyncingSelection = true;
                    dataGridViewMain.ClearSelection();

                    if (rowIndex < dataGridViewMain.Rows.Count)
                    {
                        dataGridViewMain.Rows[rowIndex].Selected = true;
                    }
                    isSyncingSelection = false;
                }
            };
        }

        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null)
            {
                // Get the column name
                string columnName = grid.Columns[e.ColumnIndex].Name;

                // Determine the sort order (toggle ascending/descending)
                bool ascending = true;
                if (grid.Tag != null && grid.Tag.ToString() == columnName)
                {
                    // If already sorting by this column, toggle the order
                    ascending = false;
                    grid.Tag = null; // Clear the tag for next click
                }
                else
                {
                    grid.Tag = columnName; // Store column name in tag
                }

                // Call the custom sort function
                SortByColumn(columnName, ascending);

                // Rebind the grids
                RebindGrids();
            }
        }


        private void SortByColumn(string columnName, bool ascending)
        {
            // Define the sort direction
            string sortDirection = ascending ? "ASC" : "DESC";

            // Apply sorting to the DefaultView
            DataManager.Instance.FinalDataTable.DefaultView.Sort = $"{columnName} {sortDirection}";

            // Rebind both grids to reflect the sorted data
            RebindGrids();
        }

        private void FilterByColumn(string columnName, string filterValue)
        {
            // Apply filtering to the DefaultView
            DataManager.Instance.FinalDataTable.DefaultView.RowFilter = $"{columnName} LIKE '%{filterValue}%'";

            // Rebind both grids to show the filtered data
            RebindGrids();
        }

        private void ClearFilter()
        {
            // Clear the RowFilter
            DataManager.Instance.FinalDataTable.DefaultView.RowFilter = string.Empty;

            // Rebind both grids to show all data
            RebindGrids();
        }

        private void RebindGrids()
        {
            // Get the frozen and scrollable columns
            var frozenColumns = DataManager.Instance.FrozenColumns;
            var scrollableColumns = DataManager.Instance.SelectedColumns;

            // Rebind frozen grid
            var frozenTable = DataManager.Instance.FinalDataTable.DefaultView.ToTable(false, frozenColumns.ToArray());
            dataGridViewFrozen.DataSource = frozenTable;

            // Rebind scrollable grid
            var scrollableTable = DataManager.Instance.FinalDataTable.DefaultView.ToTable(false, scrollableColumns.ToArray());
            dataGridViewMain.DataSource = scrollableTable;
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
