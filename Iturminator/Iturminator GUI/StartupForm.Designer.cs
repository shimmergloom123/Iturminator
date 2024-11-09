namespace Iturminator_GUI
{
    partial class StartupForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            main_file_label = new Label();
            enriching_file_label = new Label();
            btn_choose_main_file = new Button();
            btn_choose_rch_file = new Button();
            main_clm_match = new TextBox();
            rch_clm_match = new TextBox();
            main_clm_label = new Label();
            rch_clm_label = new Label();
            CombineButton = new Button();
            SuspendLayout();
            // 
            // main_file_label
            // 
            main_file_label.AutoSize = true;
            main_file_label.Location = new Point(308, 127);
            main_file_label.Name = "main_file_label";
            main_file_label.Size = new Size(112, 32);
            main_file_label.TabIndex = 0;
            main_file_label.Text = "Main File";
            main_file_label.Click += main_file_label_Click;
            // 
            // enriching_file_label
            // 
            enriching_file_label.AutoSize = true;
            enriching_file_label.Location = new Point(1042, 127);
            enriching_file_label.Name = "enriching_file_label";
            enriching_file_label.Size = new Size(167, 32);
            enriching_file_label.TabIndex = 1;
            enriching_file_label.Text = "Enriching Files";
            enriching_file_label.Click += enriching_file_label_Click;
            // 
            // btn_choose_main_file
            // 
            btn_choose_main_file.Location = new Point(308, 175);
            btn_choose_main_file.Name = "btn_choose_main_file";
            btn_choose_main_file.Size = new Size(208, 78);
            btn_choose_main_file.TabIndex = 2;
            btn_choose_main_file.Text = "Choose main file";
            btn_choose_main_file.UseVisualStyleBackColor = true;
            btn_choose_main_file.Click += btn_chs_main_file_Click;
            // 
            // btn_choose_rch_file
            // 
            btn_choose_rch_file.Location = new Point(1042, 175);
            btn_choose_rch_file.Name = "btn_choose_rch_file";
            btn_choose_rch_file.Size = new Size(207, 78);
            btn_choose_rch_file.TabIndex = 3;
            btn_choose_rch_file.Text = "Choose enriching files";
            btn_choose_rch_file.UseVisualStyleBackColor = true;
            btn_choose_rch_file.Click += btn_choose_rch_file_Click;
            // 
            // main_clm_match
            // 
            main_clm_match.Location = new Point(522, 195);
            main_clm_match.Name = "main_clm_match";
            main_clm_match.Size = new Size(200, 39);
            main_clm_match.TabIndex = 4;
            main_clm_match.TextChanged += main_col_match_TextChanged;
            // 
            // rch_clm_match
            // 
            rch_clm_match.Location = new Point(1274, 195);
            rch_clm_match.Name = "rch_clm_match";
            rch_clm_match.Size = new Size(200, 39);
            rch_clm_match.TabIndex = 5;
            rch_clm_match.TextChanged += rch_clm_match_TextChanged;
            // 
            // main_clm_label
            // 
            main_clm_label.AutoSize = true;
            main_clm_label.Location = new Point(522, 127);
            main_clm_label.Name = "main_clm_label";
            main_clm_label.Size = new Size(228, 32);
            main_clm_label.TabIndex = 6;
            main_clm_label.Text = "Main column match";
            main_clm_label.Click += main_clm_label_Click;
            // 
            // rch_clm_label
            // 
            rch_clm_label.AutoSize = true;
            rch_clm_label.Location = new Point(1246, 127);
            rch_clm_label.Name = "rch_clm_label";
            rch_clm_label.Size = new Size(274, 32);
            rch_clm_label.TabIndex = 7;
            rch_clm_label.Text = "enriching column match";
            rch_clm_label.Click += rch_clm_label_Click;
            // 
            // CombineButton
            // 
            CombineButton.Location = new Point(710, 320);
            CombineButton.Name = "CombineButton";
            CombineButton.Size = new Size(204, 86);
            CombineButton.TabIndex = 8;
            CombineButton.Text = "Combine tables";
            CombineButton.UseVisualStyleBackColor = true;
            CombineButton.Click += CombineButton_Click;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1577, 744);
            Controls.Add(CombineButton);
            Controls.Add(rch_clm_label);
            Controls.Add(main_clm_label);
            Controls.Add(rch_clm_match);
            Controls.Add(main_clm_match);
            Controls.Add(btn_choose_rch_file);
            Controls.Add(btn_choose_main_file);
            Controls.Add(enriching_file_label);
            Controls.Add(main_file_label);
            Name = "StartupForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label main_file_label;
        private Label enriching_file_label;
        private Button btn_choose_main_file;
        private Button btn_choose_rch_file;
        private TextBox main_clm_match;
        private TextBox rch_clm_match;
        private Label main_clm_label;
        private Label rch_clm_label;
        private Button CombineButton;
    }
}
