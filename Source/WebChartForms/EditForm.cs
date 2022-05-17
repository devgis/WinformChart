using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WebChartForms.Properties;

namespace WebChartForms
{
    public partial class EditForm : Form
    {

        /// <summary>
        /// 用以接受传入数据和propertygrid的绑定
        /// </summary>
        private XProps xp;

        /// <summary>
        /// 保存的原始数据，用以还原数据
        /// </summary>
        private XProps _xprsResult;
        
        /// <summary>
        /// 获取传入的数据
        /// </summary>
        /// <param name="aaa"></param>
        public EditForm(XProps xprs, XProps xprsResult)
        {
            InitializeComponent();
            xp = xprs;
            _xprsResult=xprsResult;
            this.propertyGrid_property.SelectedObject = _xprsResult;
        }
        
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///保存数据并关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 把值返回初始状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Emty_Click(object sender, EventArgs e)
        {
            this._xprsResult = XProps.CopyXProps(xp);
            this.propertyGrid_property.SelectedObject = _xprsResult;
        }

        /// <summary>
        /// 输入值更改时验证正则是否通过
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propertyGrid_property_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            XProp xpr = new XProp();

            //有变更的行的变更值
            xpr.Value= e.ChangedItem.Value.ToString();

            if (xpr.Value == null)
            {
                return;
            }

            //获取自定义的正则
            string pattern = e.ChangedItem.PropertyDescriptor.Name.ToString();

            if (pattern=="null")
            {
                return;
            }

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(xpr.Value.ToString()))
            {
                
            }
            else
            {
                MessageBox.Show(e.ChangedItem.PropertyDescriptor.DisplayName + Resources.Editt1 + e.ChangedItem.PropertyDescriptor.Name + Resources.Editt2);
                return;
            }
            
        }

    }
}
