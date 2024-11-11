using Iturminator.Data;

namespace Iturminator_GUI
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
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
        }
    }
}
