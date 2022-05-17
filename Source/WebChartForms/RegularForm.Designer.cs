namespace WebChartForms
{
    partial class RegularForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegularForm));
            this.textBox_Regular = new System.Windows.Forms.TextBox();
            this.button17_OK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_Regular = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_Regular
            // 
            resources.ApplyResources(this.textBox_Regular, "textBox_Regular");
            this.textBox_Regular.Name = "textBox_Regular";
            // 
            // button17_OK
            // 
            this.button17_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button17_OK, "button17_OK");
            this.button17_OK.Name = "button17_OK";
            this.button17_OK.UseVisualStyleBackColor = true;
            this.button17_OK.Click += new System.EventHandler(this.button17_OK_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Regular
            // 
            this.comboBox_Regular.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_Regular, "comboBox_Regular");
            this.comboBox_Regular.Name = "comboBox_Regular";
            this.comboBox_Regular.SelectedIndexChanged += new System.EventHandler(this.comboBox_Regular_SelectedIndexChanged);
            // 
            // RegularForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_Regular);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button17_OK);
            this.Controls.Add(this.textBox_Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegularForm";
            this.Load += new System.EventHandler(this.RegularForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Regular;
        private System.Windows.Forms.Button button17_OK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_Regular;
    }
}