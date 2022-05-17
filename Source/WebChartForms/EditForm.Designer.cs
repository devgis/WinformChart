namespace WebChartForms
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.propertyGrid_property = new System.Windows.Forms.PropertyGrid();
            this.button_Emty = new System.Windows.Forms.Button();
            this.button_Preservation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid_property
            // 
            this.propertyGrid_property.CommandsBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.propertyGrid_property.HelpBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.propertyGrid_property.LineColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.propertyGrid_property, "propertyGrid_property");
            this.propertyGrid_property.Name = "propertyGrid_property";
            this.propertyGrid_property.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_property_PropertyValueChanged);
            // 
            // button_Emty
            // 
            resources.ApplyResources(this.button_Emty, "button_Emty");
            this.button_Emty.Name = "button_Emty";
            this.button_Emty.UseVisualStyleBackColor = true;
            this.button_Emty.Click += new System.EventHandler(this.button_Emty_Click);
            // 
            // button_Preservation
            // 
            resources.ApplyResources(this.button_Preservation, "button_Preservation");
            this.button_Preservation.Name = "button_Preservation";
            this.button_Preservation.UseVisualStyleBackColor = true;
            this.button_Preservation.Click += new System.EventHandler(this.button3_Click);
            // 
            // EditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Preservation);
            this.Controls.Add(this.button_Emty);
            this.Controls.Add(this.propertyGrid_property);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid_property;
        private System.Windows.Forms.Button button_Emty;
        private System.Windows.Forms.Button button_Preservation;
    }
}