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
                    DataManager.Instance.LoadMainData(openFileDialog.FileName);

                    MessageBox.Show("Main file loaded successfully.");
                }
            }
        }

        private void btn_choose_rch_file_Click(object sender, EventArgs e)
        {

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

        }
    }
}
