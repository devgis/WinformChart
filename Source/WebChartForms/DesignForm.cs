using WebChartForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebChartForms
{
    public partial class DesignForm : Form
    {
        /// <summary>
        /// 接收传入值
        /// </summary>
        private XProps _XProps;

        /// <summary>
        /// 实例化RegularString类
        /// </summary>
        private RegularString RS = new RegularString();

        public DesignForm(XProps xProps)
        {
            InitializeComponent();

            this._XProps = xProps;
            
        }
        
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesignForm_Load(object sender, EventArgs e)
        {

            //绑定comboBox_Language的数据
            this.comboBox_Language.DataSource = CultureInfo.GetCultures(CultureTypes.AllCultures);
            this.comboBox_Language.DisplayMember = "DisplayName";
            this.comboBox_Language.ValueMember = "Name";
            this.comboBox_Language.SelectedItem = CultureInfo.CurrentUICulture;

            RS.Language = this.comboBox_Language.Text;

            //绑定dataGridView_property
            datatable(_XProps);

            if (_XProps != null)
            {
                //初始化保存多语言数据的字段集合
                foreach (var item in _XProps)
                {
                    if (item.MuliLangeCategory == null)
                    {
                        item.MuliLangeCategory = new List<MultiLangDesc>();
                    }
                    if (item.MuliLangDisplayName == null)
                    {
                        item.MuliLangDisplayName = new List<MultiLangDesc>();
                    }
                    if (item.MuliLangeDescription == null)
                    {
                        item.MuliLangeDescription = new List<MultiLangDesc>();
                    }

                }
            }

            if (RS.Language != CultureInfo.InstalledUICulture.NativeName && this.dataGridView_property.ColumnCount > 0)
            {
                //几列数据不可编辑
                this.dataGridView_property.Columns[2].ReadOnly = true;
                this.dataGridView_property.Columns[3].ReadOnly = true;
                this.dataGridView_property.Columns[4].ReadOnly = true;
            }
        }

        /// <summary>
        /// 右键删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView_property.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dataGridView_property.Rows.Remove(r);
                    for (int i = 0; i < this._XProps.Count; i++)
                    {
                        if (int.Parse(this._XProps[i].ID) == this.dataGridView_property.CurrentCell.RowIndex)
                        {
                            this._XProps.Remove(this._XProps[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView_property.SelectedRows)
            {
                if (!r.IsNewRow && this.dataGridView_property.SelectedRows.Count > 0)
                {
                        DataRowView drv = dataGridView_property.SelectedRows[0].DataBoundItem as DataRowView;
                        drv.Delete();
                        for (int i = 0; i < this._XProps.Count; i++)
                        {
                            if (int.Parse(this._XProps[i].ID) == this.dataGridView_property.CurrentCell.RowIndex)
                            {
                                this._XProps.Remove(this._XProps[i]);
                            }
                        }
                }
            }
            
        }

        /// <summary>
        /// 给dataGridView_property绑定数据源
        /// </summary>
        /// <param name="a"></param>
        public void datatable(XProps xpr)
        {
            this.dataGridView_property.DataSource = null;

            //添加下拉框列
            DataTable stu = new DataTable();
            DataTable dept = new DataTable();
            DataColumn col1 = new DataColumn("_id", Type.GetType("System.String")) { Unique = true };//编号
            dept.Columns.Add(col1);
            col1 = new DataColumn("_name", Type.GetType("System.String"));//类型名
            dept.Columns.Add(col1);
            dept.Rows.Add("0", "int");
            dept.Rows.Add("1", "string");
            dept.Rows.Add("2", "Font");
            dept.Rows.Add("3", "Color");
            dept.Rows.Add("4", "bool");
            dept.Rows.Add("5", "Point");
            dept.Rows.Add("6", "Size");
            dept.Rows.Add("7", "Custom");


            DataGridViewComboBoxColumn cbxCol = new DataGridViewComboBoxColumn
            {
                Name = "Type",
                DataSource = dept,
                DisplayMember = "_name",//DataGridViewComboBoxColumn数据源中的列
                ValueMember = "_id",
                DataPropertyName = "Type",//注意，DataGridView数据源中的列
                HeaderText = Resources.Designl4,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton//这里设置为DropDownButton
            };
            dataGridView_property.Columns.Add(cbxCol);

            DataColumn col = new DataColumn(Resources.Designl2, Type.GetType("System.String"));//类别
            stu.Columns.Add(col);
            col = new DataColumn(Resources.Designl3, Type.GetType("System.String"));//属性名
            stu.Columns.Add(col);
            col = new DataColumn("Type", Type.GetType("System.String"));//类型
            stu.Columns.Add(col);
            col = new DataColumn(Resources.Designl5, Type.GetType("System.String"));//值
            stu.Columns.Add(col);
            col = new DataColumn(Resources.Designl6, Type.GetType("System.String"));//正则
            stu.Columns.Add(col);
            col = new DataColumn(Resources.Designl7, Type.GetType("System.String"));//描述
            stu.Columns.Add(col);
            string num="";
            if (xpr == null)
            {
                stu.Rows.Add("", "", "0", "0", "^[0-9]*$", "");   
            }
            else
            {
                //System.Drawing.p
                foreach (XProp oXProp in xpr)
                {
                    switch (oXProp.ProType.ToString())
                    {
                            
                        case "System.Int32":
                            num = "0";
                            break;
                        case "System.String":
                            num = "1";
                            break;
                        case "System.Drawing.Font":
                            num = "2";
                            break;
                        case "System.Drawing.Color":
                            num = "3";
                            break;
                        case "WebChartForms.propertyinfo+MyComboItemConvert":
                            num = "4";
                            break;
                        case "System.Drawing.Point":
                            num = "5";
                            break;
                        case "System.Drawing.Size":
                            num = "6";
                            break;
                        case "Custom":
                            num = "7";
                            break;
                        default:
                            break;
                    }
                    ////导入模板数据
                    stu.Rows.Add(oXProp.Category, oXProp.DisplayName, num, oXProp.Value, oXProp.Name, oXProp.Description);
                }
            }
            
            this.dataGridView_property.DataSource = stu;
        }

        /// <summary>
        /// 及时更新多语言数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_property_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                MultiLangDesc md = new MultiLangDesc();
                int _num = dataGridView_property.CurrentCell.RowIndex;
                foreach (var item in _XProps)
                {
                    //Category数据
                    if (dataGridView_property.CurrentCell.ColumnIndex == 0)
                    {
                        if (item.MuliLangeCategory != null)
                        {
                            for (int i = 0; i < item.MuliLangeCategory.Count; i++)
                            {
                                if (item.MuliLangeCategory[i].language == RS.Language && int.Parse(item.MuliLangeCategory[i].ID) == _num)
                                {
                                    item.MuliLangeCategory.Remove(item.MuliLangeCategory[i]);
                                }
                            }
                        }
                        else
                        {
                            item.MuliLangeCategory = new List<MultiLangDesc>();
                        }
                        md = new MultiLangDesc();
                        md.descTxt = this.dataGridView_property.Rows[_num].Cells[0].Value.ToString();
                        md.language = RS.Language;
                        md.ID = _num.ToString();
                        item.MuliLangeCategory.Add(md);
                        if (item.Category == "")
                        {
                            item.Category = this.dataGridView_property.Rows[_num].Cells[0].Value.ToString();
                        }
                    }
                    //DisplayName数据
                    if (dataGridView_property.CurrentCell.ColumnIndex == 1)
                    {
                        if (item.MuliLangDisplayName != null)
                        {
                            for (int i = 0; i < item.MuliLangDisplayName.Count; i++)
                            {
                                if (item.MuliLangDisplayName[i].language == RS.Language && item.MuliLangDisplayName[i].ID == _num.ToString())
                                {
                                    item.MuliLangDisplayName.Remove(item.MuliLangDisplayName[i]);
                                }
                            }
                        }
                        else
                        {
                            item.MuliLangDisplayName = new List<MultiLangDesc>();
                        }
                        md = new MultiLangDesc();
                        md.descTxt = this.dataGridView_property.Rows[_num].Cells[1].Value.ToString();
                        md.language = RS.Language;
                        md.ID = _num.ToString();
                        item.MuliLangDisplayName.Add(md);
                        if (item.DisplayName == "")
                        {
                            item.DisplayName = this.dataGridView_property.Rows[_num].Cells[1].Value.ToString();
                        }
                    }
                    if (dataGridView_property.CurrentCell.ColumnIndex == 3)
                    {
                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                    }
                    if (dataGridView_property.CurrentCell.ColumnIndex == 4)
                    {
                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                    }
                    //Description数据
                    if (dataGridView_property.CurrentCell.ColumnIndex == 5)
                    {
                        if (item.MuliLangeDescription != null)
                        {
                            for (int i = 0; i < item.MuliLangeDescription.Count; i++)
                            {
                                if (item.MuliLangeDescription[i].language == RS.Language && item.MuliLangeDescription[i].ID == _num.ToString())
                                {
                                    item.MuliLangeDescription.Remove(item.MuliLangeDescription[i]);
                                }
                            }
                        }
                        else
                        {
                            item.MuliLangeDescription = new List<MultiLangDesc>();
                        }
                        md = new MultiLangDesc();
                        md.descTxt = this.dataGridView_property.Rows[_num].Cells[5].Value.ToString();
                        md.language = RS.Language;
                        md.ID = _num.ToString();
                        item.MuliLangeDescription.Add(md);
                        if (item.Description == "")
                        {
                            item.Description = this.dataGridView_property.Rows[_num].Cells[5].Value.ToString();
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);//显示异常信息
            //}
        }
        

        /// <summary>
        /// 首先给这个DataGridView加上EditingControlShowing事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_property_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
             DataGridView dgv = sender as DataGridView;
             ComboBox combox=e.Control as ComboBox;
            //判断相应的列
             if (dgv.CurrentCell.GetType().Name == "DataGridViewComboBoxCell" && dgv.CurrentCell.RowIndex != -1)
             {

                 //给这个DataGridViewComboBoxCell加上下拉事件
                 (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
             }
        }

        /// <summary>
        /// 组合框事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox combox = sender as ComboBox;

            //这里比较重要
            combox.Leave += new EventHandler(combox_Leave);
            try
            {
                //在这里就可以做值是否改变判断
                if (combox.SelectedItem != null)
                {
                    if (this.dataGridView_property.Rows[dataGridView_property.Rows.Count-1].Cells[2].Value!=null)
                    {
                        XProp _xp = new XProp();
                        _xp.ID = (dataGridView_property.Rows.Count-1).ToString();
                        _XProps.Add(_xp);
                    }
                    foreach (var item in _XProps)
                    {
                        for (int i = 0; i < dataGridView_property.Rows.Count; i++)
                        {
                            if (dataGridView_property.CurrentCell.RowIndex ==i && i ==int.Parse(item.ID))
                            {
                                switch (combox.Text)
                                {
                                    case "int":
                                        item.ProType = typeof(int);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "0";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "^[0-9]*$";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "string":
                                        item.ProType = typeof(String);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "双击单元格编辑";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = null;
                                        break;
                                    case "Font":
                                        item.ProType = typeof(Font);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "宋体";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "null";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "Color":
                                        item.ProType = typeof(Color);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "white";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "null";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "bool":
                                        item.ProType = typeof(propertyinfo.enumType);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "True";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "null";
                                        item.Value = propertyinfo.enumType.True;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "Point":
                                        item.ProType = typeof(Point);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "（0,0）";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "null";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "Size":
                                        item.ProType = typeof(Size);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "（0,0）";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "null";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value.ToString();
                                        break;
                                    case "Custom":
                                        item.ProType = typeof(String);
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value = "";
                                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[4].Value = "双击单元格编辑";
                                        item.Value = this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[3].Value;
                                        item.Name = null;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 离开combox时，把事件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void combox_Leave(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            //做完处理，须撤销动态事件
            combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        }


        /// <summary>
        /// 双击打开弹窗，正则窗体弹出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_property_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_property.CurrentCell != null)
            {
                //判断是第几列，正则弹窗判断
                if (dataGridView_property.CurrentCell.ColumnIndex == 4&&this.dataGridView_property.Columns[4].ReadOnly ==false)
                {
                    RegularString regularString = new RegularString();
                    regularString.Value =this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[dataGridView_property.CurrentCell.ColumnIndex].Value.ToString();
                    RegularForm A = new RegularForm(regularString);
                   // A.toclose += new dt(form_toclose);
                    if (DialogResult.OK == A.ShowDialog())
                    {
                        this.dataGridView_property.Rows[dataGridView_property.CurrentCell.RowIndex].Cells[dataGridView_property.CurrentCell.ColumnIndex].Value = regularString.Value;
                        for (int i = 0; i < _XProps.Count; i++)
                        {
                            if (dataGridView_property.CurrentCell.RowIndex == i)
                            {
                                _XProps[i].Name=regularString.Value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 还原默认数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            RS.Language = this.comboBox_Language.Text;

            datatable(_XProps);

            if (RS.Language != CultureInfo.InstalledUICulture.NativeName && this.dataGridView_property.ColumnCount > 0)
            {
                //几列数据不可编辑
                this.dataGridView_property.Columns[2].ReadOnly = true;
                this.dataGridView_property.Columns[3].ReadOnly = true;
                this.dataGridView_property.Columns[4].ReadOnly = true;
            }

            //解除不可编辑状态
            if (RS.Language == CultureInfo.InstalledUICulture.NativeName && this.dataGridView_property.ColumnCount > 0)
            {
                this.dataGridView_property.Columns[2].ReadOnly = false;
                this.dataGridView_property.Columns[3].ReadOnly = false;
                this.dataGridView_property.Columns[4].ReadOnly = false;
            }

            for (int _num = 0; _num < _XProps.Count; _num++)
            {
                for (int i = 0; i < _XProps[_num].MuliLangeCategory.Count; i++)
                {
                    if (_XProps[_num].MuliLangeCategory[i].language == RS.Language && _XProps[_num].MuliLangeCategory[i].ID == _num.ToString())
                    {
                        _XProps[_num].MuliLangeCategory.Remove(_XProps[_num].MuliLangeCategory[i]);
                    }
                }
                for (int i = 0; i < _XProps[_num].MuliLangDisplayName.Count; i++)
                {
                    if (_XProps[_num].MuliLangDisplayName[i].language == RS.Language && _XProps[_num].MuliLangDisplayName[i].ID == _num.ToString())
                    {
                        _XProps[_num].MuliLangDisplayName.Remove(_XProps[_num].MuliLangDisplayName[i]);
                    }
                }
                for (int i = 0; i < _XProps[_num].MuliLangeDescription.Count; i++)
                {
                    if (_XProps[_num].MuliLangeDescription[i].language == RS.Language && _XProps[_num].MuliLangeDescription[i].ID == _num.ToString())
                    {
                        _XProps[_num].MuliLangeDescription.Remove(_XProps[_num].MuliLangeDescription[i]);
                    }
                }
            }
        }

        /// <summary>
        /// comboBox_Language语言改变时判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            //更新语言
            RS.Language =this.comboBox_Language.Text;

            datatable(_XProps);

            if (RS.Language != CultureInfo.InstalledUICulture.NativeName && this.dataGridView_property.ColumnCount > 0)
            {
                //几列数据不可编辑
                this.dataGridView_property.Columns[2].ReadOnly = true;
                this.dataGridView_property.Columns[3].ReadOnly = true;
                this.dataGridView_property.Columns[4].ReadOnly = true;
            }

            //解除不可编辑状态
            if (RS.Language == CultureInfo.InstalledUICulture.NativeName &&this.dataGridView_property.ColumnCount>0)
            {
                this.dataGridView_property.Columns[2].ReadOnly = false;
                this.dataGridView_property.Columns[3].ReadOnly = false;
                this.dataGridView_property.Columns[4].ReadOnly = false;
            }

            //把多语言数据重新填充到dataGridView_property
            if (RS.Language != ""&&_XProps!=null )
            {
                    for (int i = 0; i < dataGridView_property.Rows.Count-1; i++)
                    {
                        if (_XProps[i].MuliLangeCategory == null)
                        {
                            break;
                        }
                        if (_XProps[i].MuliLangeCategory !=null)
                        {
                            for (int j = 0; j < _XProps[i].MuliLangeCategory.Count; j++)
                            {
                                if (_XProps[i].MuliLangeCategory[j].language == RS.Language && _XProps[i].MuliLangeCategory[j].ID == i.ToString())
                                {
                                    this.dataGridView_property.Rows[i].Cells[0].Value = _XProps[i].MuliLangeCategory[j].descTxt;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < dataGridView_property.Rows.Count-1; i++)
                    {
                        if (_XProps[i].MuliLangDisplayName != null)
                        {
                            for (int j = 0; j < _XProps[i].MuliLangDisplayName.Count; j++)
                            {
                                if (_XProps[i].MuliLangDisplayName[j].language == RS.Language && _XProps[i].MuliLangDisplayName[j].ID == i.ToString())
                                {
                                    this.dataGridView_property.Rows[i].Cells[1].Value = _XProps[i].MuliLangDisplayName[j].descTxt;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < dataGridView_property.Rows.Count-1; i++)
                    {
                        if (_XProps[i].MuliLangeDescription != null)
                        {
                            for (int j = 0; j < _XProps[i].MuliLangeDescription.Count; j++)
                            {
                                if (_XProps[i].MuliLangeDescription[j].language == RS.Language && _XProps[i].MuliLangeDescription[j].ID == i.ToString())
                                {
                                    this.dataGridView_property.Rows[i].Cells[5].Value = _XProps[i].MuliLangeDescription[j].descTxt;
                                }
                            }
                        }
                    }
            }
            else if (RS.Language != CultureInfo.InstalledUICulture.NativeName)
            {
                datatable(_XProps);
            }
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Close_Click(object sender, EventArgs e)
        {
            XProps xaas = new XProps();
            xaas = this._XProps;
            //判断是否有空数据
            for (int i = 0; i < this.dataGridView_property.Rows.Count - 1; i++)
            {
                for (int j = 0; j < this.dataGridView_property.ColumnCount; j++)
                {
                    if (this.dataGridView_property.Rows[i].Cells[j].Value == null || this.dataGridView_property.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        MessageBox.Show(Resources.Designt1);
                        return;
                    }
                }
            }

            //判断是否只有一行
            if (this.dataGridView_property.Rows.Count - 1 == 0)
            {
                MessageBox.Show(Resources.Designt1);
                return;
            }
            this.Close();
        }
    }
}
