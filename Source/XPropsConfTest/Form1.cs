using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebChartForms;
using System.Globalization;
using System.IO;

namespace XPropsConfTest
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 用来传入下个窗体绑定的数据，
        /// </summary>
        private XProps _xprops;

        /// <summary>
        /// 用来接收传入数据，
        /// </summary>
        private XProps _xpropsfirst;

        /// <summary>
        /// 用来保存copy的数据，传入下窗体的原数据数据
        /// </summary>
        private XProps _xPropsReslut;
        
        public Form1()
        {
            InitializeComponent();

            int count = 3;
            this._xpropsfirst = new XProps();

            for (int i = 0; i < count; i++)
            {
                XProp xprop = new XProp();
                xprop.ID = i.ToString();
                xprop.Category = i + 1 + "Category";
                xprop.DisplayName = i + 2 + "显示名";
                xprop.Value = i + 1 + "Value";
                xprop.Name = i + 4 + "名";
                xprop.Description = i + 5 + "描述";
                //xprop.Converter = new propertyinfo();
                xprop.ProType = typeof(string);
                this._xpropsfirst.Add(xprop);
            }
            this._xPropsReslut = null;

        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DesignForm aaa = new DesignForm(this._xpropsfirst);
            aaa.ShowDialog();
            this.textBox1.Text = this._xpropsfirst.ToJson();
            
        }

        /// <summary>
        /// 跳转到配置页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this._xprops = XProps.CopyXProps(this._xpropsfirst);

            string lan = this.comboBox1.Text;

            bool aa =false;
            //遍历是否有此语言的数据
            foreach (var item in _xpropsfirst)
            {
                if (item.MuliLangeCategory!=null)
                {
                    foreach (var it in item.MuliLangeCategory)
                    {
                        if (it.language == lan)
                        {
                            aa = true;
                        }
                    }
                }

                if (item.MuliLangDisplayName != null)
                {
                    foreach (var it in item.MuliLangDisplayName)
                    {
                        if (it.language == lan)
                        {
                            aa = true;
                        }
                    }
                }

                if (item.MuliLangeDescription != null)
                {
                    foreach (var it in item.MuliLangeDescription)
                    {
                        if (it.language == lan)
                        {
                            aa = true;
                        }
                    }
                }
            }
            //如果不存在，则查询默认系统语言数据
            if (aa)
            {
                //查询语言并赋给_xprops
                for (int i = 0; i < _xprops.Count; i++)
                {
                    for (int j = 0; j < _xprops[i].MuliLangeCategory.Count; j++)
                    {
                        if (_xprops[i].MuliLangeCategory[j].language == lan && _xprops[i].MuliLangeCategory[j].ID == i.ToString())
                        {
                            _xprops[i].Category = _xprops[i].MuliLangeCategory[j].descTxt;
                        }
                    }
                    for (int j = 0; j < _xprops[i].MuliLangDisplayName.Count; j++)
                    {
                        if (_xprops[i].MuliLangDisplayName[j].language == lan && _xprops[i].MuliLangDisplayName[j].ID == i.ToString())
                        {
                            _xprops[i].DisplayName = _xprops[i].MuliLangDisplayName[j].descTxt;
                        }
                    }
                    for (int j = 0; j < _xprops[i].MuliLangeDescription.Count; j++)
                    {
                        if (_xprops[i].MuliLangeDescription[j].language == lan && _xprops[i].MuliLangeDescription[j].ID == i.ToString())
                        {
                            _xprops[i].Description = _xprops[i].MuliLangeDescription[j].descTxt;
                        }
                    }
                }

                this._xPropsReslut = XProps.CopyXProps(this._xprops);
                EditForm A = new EditForm(this._xprops, this._xPropsReslut);
                A.Show();
            }
            else
            {
                //跳转默认语言数据
                this._xPropsReslut = XProps.CopyXProps(this._xprops);
                EditForm A = new EditForm(this._xprops, this._xPropsReslut);
                A.Show();
            }
            
            string bbb = this._xPropsReslut.ToJson();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //给comboBox1绑定数据
            this.comboBox1.DataSource = CultureInfo.GetCultures(CultureTypes.AllCultures);
            this.comboBox1.DisplayMember = "DisplayName";
            this.comboBox1.ValueMember = "Name";
            this.comboBox1.SelectedItem = CultureInfo.CurrentUICulture;
        }
    }
}
