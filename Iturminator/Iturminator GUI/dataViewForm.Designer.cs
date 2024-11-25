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
            chkSaveHiddenData = new CheckBox();
            btnBackToStartup = new Button();
            splitContainer1 = new SplitContainer();
            dataGridViewMain = new DataGridView();
            dataGridViewFrozen = new DataGridView();
            panel1 = new Panel();
            btnAdjustRowHeight = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFrozen).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // chkSaveHiddenData
            // 
            chkSaveHiddenData.AutoSize = true;
            chkSaveHiddenData.Location = new Point(12, 27);
            chkSaveHiddenData.Name = "chkSaveHiddenData";
            chkSaveHiddenData.Size = new Size(237, 36);
            chkSaveHiddenData.TabIndex = 1;
            chkSaveHiddenData.Text = "Save Hidden Data";
            chkSaveHiddenData.UseVisualStyleBackColor = true;
            // 
            // btnBackToStartup
            // 
            btnBackToStartup.Location = new Point(348, 27);
            btnBackToStartup.Name = "btnBackToStartup";
            btnBackToStartup.Size = new Size(150, 46);
            btnBackToStartup.TabIndex = 2;
            btnBackToStartup.Text = "Back";
            btnBackToStartup.UseVisualStyleBackColor = true;
            btnBackToStartup.Click += btnBackToStartup_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 98);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewMain);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewFrozen);
            splitContainer1.Size = new Size(1588, 706);
            splitContainer1.SplitterDistance = 1234;
            splitContainer1.TabIndex = 3;
            // 
            // dataGridViewMain
            // 
            dataGridViewMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMain.Dock = DockStyle.Fill;
            dataGridViewMain.Location = new Point(0, 0);
            dataGridViewMain.Name = "dataGridViewMain";
            dataGridViewMain.RowHeadersWidth = 82;
            dataGridViewMain.Size = new Size(1234, 706);
            dataGridViewMain.TabIndex = 0;
            // 
            // dataGridViewFrozen
            // 
            dataGridViewFrozen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFrozen.Dock = DockStyle.Fill;
            dataGridViewFrozen.Location = new Point(0, 0);
            dataGridViewFrozen.Name = "dataGridViewFrozen";
            dataGridViewFrozen.RowHeadersWidth = 82;
            dataGridViewFrozen.Size = new Size(350, 706);
            dataGridViewFrozen.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdjustRowHeight);
            panel1.Controls.Add(chkSaveHiddenData);
            panel1.Controls.Add(btnBackToStartup);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1588, 98);
            panel1.TabIndex = 4;
            // 
            // btnAdjustRowHeight
            // 
            btnAdjustRowHeight.Location = new Point(614, 27);
            btnAdjustRowHeight.Name = "btnAdjustRowHeight";
            btnAdjustRowHeight.Size = new Size(150, 46);
            btnAdjustRowHeight.TabIndex = 3;
            btnAdjustRowHeight.Text = "Adjust Rows";
            btnAdjustRowHeight.UseVisualStyleBackColor = true;
            btnAdjustRowHeight.Click += btnAdjustRowHeight_Click;
            // 
            // dataViewForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1588, 804);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "dataViewForm";
            Text = "dataViewForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFrozen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CheckBox chkSaveHiddenData;
        private Button btnBackToStartup;
        private SplitContainer splitContainer1;
        private DataGridView dataGridViewMain;
        private DataGridView dataGridViewFrozen;
        private Panel panel1;
        private Button btnAdjustRowHeight;
    }
}