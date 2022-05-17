namespace WebChartForms
{
    partial class SubSectionForm
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
            this.dataGridView_SubSection = new System.Windows.Forms.DataGridView();
            this.button_Clean = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_SubSection = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubSection)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_SubSection
            // 
            this.dataGridView_SubSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_SubSection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_SubSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubSection.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_SubSection.Name = "dataGridView_SubSection";
            this.dataGridView_SubSection.RowTemplate.Height = 23;
            this.dataGridView_SubSection.Size = new System.Drawing.Size(143, 293);
            this.dataGridView_SubSection.TabIndex = 0;
            // 
            // button_Clean
            // 
            this.button_Clean.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_Clean.Location = new System.Drawing.Point(191, 137);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(75, 23);
            this.button_Clean.TabIndex = 1;
            this.button_Clean.Text = "&Clean";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(191, 282);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "&OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_SubSection
            // 
            this.textBox_SubSection.Location = new System.Drawing.Point(191, 13);
            this.textBox_SubSection.Name = "textBox_SubSection";
            this.textBox_SubSection.Size = new System.Drawing.Size(75, 21);
            this.textBox_SubSection.TabIndex = 3;
            // 
            // SubSectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 325);
            this.Controls.Add(this.textBox_SubSection);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Clean);
            this.Controls.Add(this.dataGridView_SubSection);
            this.Name = "SubSectionForm";
            this.Text = "SubSectionForm";
            this.Load += new System.EventHandler(this.SubSectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_SubSection;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_SubSection;
    }
}