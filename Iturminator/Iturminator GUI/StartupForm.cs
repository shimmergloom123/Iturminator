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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the file path in a TextBox or Label
                    txtMainFilePath.Text = openFileDialog.FileName;

                    // Optionally load the file into a DataTable or perform other actions
                    LoadMainFile(openFileDialog.FileName);
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
