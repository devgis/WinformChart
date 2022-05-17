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
    

    public partial class RegularForm : Form
    {
        /// <summary>
        /// 定义窗体关闭
        /// </summary>
        //public event dt toclose;

        private RegularString _regularString;

        public RegularForm(RegularString regularString)
        {
            InitializeComponent();
            this._regularString = regularString;
            this.textBox_Regular.Text = regularString.Value;
        }
        private void RegularForm_Load(object sender, EventArgs e)
        {
            IList<RegularString> RegularList = new List<RegularString>();
            RegularString info1 = new RegularString() { Id = "[\u4e00-\u9fa5]", Name = "Chinese" };
            RegularString info2 = new RegularString() { Id = @"\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}", Name = "Email" };
            RegularString info3 = new RegularString() { Id = @"^((https|http|ftp|rtsp|mms)?:\/\/)[^\s]+", Name = "URL" };
            RegularString info4 = new RegularString() { Id = "0?(13|14|15|17|18|19)[0-9]{9}", Name = "Phone" };
            RegularString info5 = new RegularString() { Id = "[0-9-()（）]{7,18}", Name = "TelePhone" };
            RegularString info6 = new RegularString() { Id = "[1-9]([0-9]{5,11})", Name = "QQ" };
            RegularString info7 = new RegularString() { Id = @"\d{6}", Name = "AmE" };
            RegularString info8 = new RegularString() { Id = @"(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)", Name = "IP" };
            RegularString info9 = new RegularString() { Id = @"\d{17}[\d|x]|\d{15}", Name = "ID" };
            RegularString info10 = new RegularString() { Id = @"\d{4}(\-|\/|.)\d{1,2}\1\d{1,2}", Name = "Date" };
            RegularList.Add(info1);
            RegularList.Add(info2);
            RegularList.Add(info3);
            RegularList.Add(info4);
            RegularList.Add(info5);
            RegularList.Add(info6);
            RegularList.Add(info7);
            RegularList.Add(info8);
            RegularList.Add(info9);
            RegularList.Add(info10);

            this.comboBox_Regular.DataSource = RegularList;
            this.comboBox_Regular.ValueMember = "id";
            this.comboBox_Regular.DisplayMember = "name";
        }
        /// <summary>
        /// 关闭窗体并返回正则数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_OK_Click(object sender, EventArgs e)
        {
            this._regularString.Value=this.textBox_Regular.Text;
            this.Close();  
        }

        private void comboBox_Regular_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox_Regular.Text = this.comboBox_Regular.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox_Regular.Text = "";
        }
        
    }
}
