namespace Iturminator_GUI
{
    partial class dataViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewData = new DataGridView();
            chkSaveHiddenData = new CheckBox();
            btnBackToStartup = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Dock = DockStyle.Bottom;
            dataGridViewData.Location = new Point(0, 136);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.RowHeadersWidth = 82;
            dataGridViewData.Size = new Size(1588, 668);
            dataGridViewData.TabIndex = 0;
            dataGridViewData.CellContentClick += dataGridViewData_CellContentClick;
            // 
            // chkSaveHiddenData
            // 
            chkSaveHiddenData.AutoSize = true;
            chkSaveHiddenData.Location = new Point(12, 23);
            chkSaveHiddenData.Name = "chkSaveHiddenData";
            chkSaveHiddenData.Size = new Size(237, 36);
            chkSaveHiddenData.TabIndex = 1;
            chkSaveHiddenData.Text = "Save Hidden Data";
            chkSaveHiddenData.UseVisualStyleBackColor = true;
            // 
            // btnBackToStartup
            // 
            btnBackToStartup.Location = new Point(351, 17);
            btnBackToStartup.Name = "btnBackToStartup";
            btnBackToStartup.Size = new Size(150, 46);
            btnBackToStartup.TabIndex = 2;
            btnBackToStartup.Text = "Back";
            btnBackToStartup.UseVisualStyleBackColor = true;
            btnBackToStartup.Click += btnBackToStartup_Click;
            // 
            // dataViewForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1588, 804);
            Controls.Add(btnBackToStartup);
            Controls.Add(chkSaveHiddenData);
            Controls.Add(dataGridViewData);
            Name = "dataViewForm";
            Text = "dataViewForm";
            Load += DataViewForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewData;
        private CheckBox chkSaveHiddenData;
        private Button btnBackToStartup;
    }
}