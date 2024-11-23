using Iturminator.Data;
using System.Data;

namespace Iturminator_GUI
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }
        private void PopulateListBoxes(DataTable dataTable)
        {
            listBoxFrozen.Items.Clear();
            listBoxSelected.Items.Clear();
            listBoxHidden.Items.Clear();

            foreach (DataColumn column in dataTable.Columns)
            {
                listBoxSelected.Items.Add(column.ColumnName); // All columns start as selected
            }
        }
        private List<string> GetSelectedColumns()
        {
            return listBoxSelected.Items.Cast<string>().ToList();
        }

        private List<string> GetHiddenColumns()
        {
            return listBoxHidden.Items.Cast<string>().ToList();
        }

        private List<string> GetFrozenColumns()
        {
            return listBoxFrozen.Items.Cast<string>().ToList();
        }

        public void RefreshHiddenColumnsList()
        {
            // Assuming listBoxHidden is the ListBox for hidden columns
            listBoxHidden.Items.Clear();
            listBoxHidden.Refresh();


            // Optionally, add a message or placeholder if needed
            //listBoxHidden.Items.Add("No hidden columns available.");
        }


        private void main_file_label_Click(object sender, EventArgs e)
        {

        }

        private void btn_chs_main_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Select Main Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path (optional)
                    //txtMainFilePath.Text = openFileDialog.FileName;

                    // Load the main data file into DataManager
                    DataManager.Instance.MainDataTable = DataManager.Instance.LoadDataFromExcel(openFileDialog.FileName);

                    //Optional - display results to the user
                    MessageBox.Show("Main file loaded successfully.");
                }
            }
        }

        private void btn_choose_rch_file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Select Enriching Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path (optional)
                    //txtMainFilePath.Text = openFileDialog.FileName;

                    // Load the main data file into DataManager
                    DataManager.Instance.EnrichingDataTable = DataManager.Instance.LoadDataFromExcel(openFileDialog.FileName);

                    //Optional - display results to the user
                    MessageBox.Show("Enriching file loaded successfully.");
                }
            }
        }

        private void main_col_match_TextChanged(object sender, EventArgs e)
        {

        }

        private void rch_clm_label_Click(object sender, EventArgs e)
        {

        }

        private void main_clm_label_Click(object sender, EventArgs e)
        {

        }

        private void rch_clm_match_TextChanged(object sender, EventArgs e)
        {

        }

        private void enriching_file_label_Click(object sender, EventArgs e)
        {

        }

        private void CombineButton_Click(object sender, EventArgs e)
        {
            // Get the column names from the TextBox controls
            string mainColumn = main_clm_match.Text;
            string enrichingColumn = rch_clm_match.Text;

            // Optional: Check if values are entered before proceeding
            if (string.IsNullOrEmpty(mainColumn) || string.IsNullOrEmpty(enrichingColumn))
            {
                MessageBox.Show("Please enter column names for both main and enriching files.");
                return;
            }

            // Call DataManager to combine data based on the input columns
            var combinedData = DataManager.Instance.CombineData(mainColumn, enrichingColumn);
            DataManager.Instance.FinalDataTable = combinedData;

            //Temporary listboxes call here. Should be removed in the future.
            PopulateListBoxes(combinedData);
        }

        private void btnMoveFrozenToSelected_Click(object sender, EventArgs e)
        {
            if (listBoxFrozen.SelectedItem != null)
            {
                string columnName = listBoxFrozen.SelectedItem.ToString();
                listBoxFrozen.Items.Remove(columnName);
                listBoxSelected.Items.Add(columnName);
            }
        }

        private void btnMoveSelectedToFrozen_Click(object sender, EventArgs e)
        {
            if (listBoxSelected.SelectedItem != null)
            {
                string columnName = listBoxSelected.SelectedItem.ToString();
                listBoxSelected.Items.Remove(columnName);
                listBoxFrozen.Items.Add(columnName);
            }
        }

        private void btnMoveSelectedToHidden_Click(object sender, EventArgs e)
        {
            if (listBoxSelected.SelectedItem != null)
            {
                string columnName = listBoxSelected.SelectedItem.ToString();
                listBoxSelected.Items.Remove(columnName);
                listBoxHidden.Items.Add(columnName);
            }
        }

        private void btnMoveHiddenToSelected_Click(object sender, EventArgs e)
        {
            if (listBoxHidden.SelectedItem != null)
            {
                string columnName = listBoxHidden.SelectedItem.ToString();
                listBoxHidden.Items.Remove(columnName);
                listBoxSelected.Items.Add(columnName);
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            // Retrieve the latest column selections
            var selectedColumns = GetSelectedColumns(); // From the listboxes
            var frozenColumns = GetFrozenColumns();     // From the listboxes
            var hiddenColumns = GetHiddenColumns();     // From the listboxes

            DataManager.Instance.SelectedColumns = selectedColumns;
            DataManager.Instance.HiddenColumns = hiddenColumns;
            DataManager.Instance.FrozenColumns = frozenColumns;

            // Open DataViewForm with updated parameters
            var dataViewForm = new dataViewForm(selectedColumns, frozenColumns);
            dataViewForm.Owner = this;
            this.Hide();
            dataViewForm.ShowDialog();
            this.Show();
        }

    }
}
