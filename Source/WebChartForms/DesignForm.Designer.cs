namespace WebChartForms
{
    partial class DesignForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignForm));
            this.dataGridView_property = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_property = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Template = new System.Windows.Forms.Button();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.button_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_property)).BeginInit();
            this.contextMenuStrip_property.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_property
            // 
            resources.ApplyResources(this.dataGridView_property, "dataGridView_property");
            this.dataGridView_property.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_property.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_property.ContextMenuStrip = this.contextMenuStrip_property;
            this.dataGridView_property.Name = "dataGridView_property";
            this.dataGridView_property.RowTemplate.Height = 23;
            this.dataGridView_property.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_property.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_property_CellMouseDoubleClick);
            this.dataGridView_property.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_property_CellValueChanged);
            this.dataGridView_property.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_property_EditingControlShowing);
            // 
            // contextMenuStrip_property
            // 
            resources.ApplyResources(this.contextMenuStrip_property, "contextMenuStrip_property");
            this.contextMenuStrip_property.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip_property.Name = "contextMenuStrip1";
            this.contextMenuStrip_property.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            // 
            // button_Template
            // 
            resources.ApplyResources(this.button_Template, "button_Template");
            this.button_Template.Name = "button_Template";
            this.button_Template.UseVisualStyleBackColor = true;
            this.button_Template.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Language
            // 
            resources.ApplyResources(this.comboBox_Language, "comboBox_Language");
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);
            // 
            // button_Close
            // 
            resources.ApplyResources(this.button_Close, "button_Close");
            this.button_Close.Name = "button_Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // DesignForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.comboBox_Language);
            this.Controls.Add(this.button_Template);
            this.Controls.Add(this.dataGridView_property);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DesignForm";
            this.Load += new System.EventHandler(this.DesignForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_property)).EndInit();
            this.contextMenuStrip_property.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Template;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_property;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView_property;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.Button button_Close;
    }
}

