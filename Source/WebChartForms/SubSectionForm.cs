using WebChartForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebChartForms
{
    public partial class SubSectionForm : Form
    {
        /// <summary>
        /// 接收传入的RegularString数据
        /// </summary>
        public RegularString rs;

        public SubSectionForm(RegularString regularString)
        {
            InitializeComponent();
            rs=regularString;
        }

        private void SubSectionForm_Load(object sender, EventArgs e)
        {
            //获取对应的属性名数据
            this.textBox_SubSection.Text = rs.Value;

            //添加空的文本编辑
            this.dataGridView_SubSection.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView_SubSection.Rows.Add(new DataGridViewRow());
        }

        /// <summary>
        /// 清空dataGridView_SubSection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            this.dataGridView_SubSection.DataSource = dt;
           
        }

        /// <summary>
        /// 确认按钮，保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            rs.Value = this.textBox_SubSection.Text;
            rs.ls = new List<string>();
            if (this.dataGridView_SubSection.DataSource!=null)
            {
                for (int i = 0; i < this.dataGridView_SubSection.Rows.Count - 1; i++)
                {
                    rs.ls.Add(this.dataGridView_SubSection.Rows[i].Cells[0].Value.ToString());
                }
            }
            
            this.Close();
        }
    }
}
