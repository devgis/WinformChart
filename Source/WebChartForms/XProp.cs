using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebChartForms
{
    public class MultiLangDesc
    {
        private string _ID = "";
        private string _language = "";
        private string _descTxt="";
        public string ID
        {
            get { return _ID; }

            set { _ID = value; }
        }

        public string language
        {
            get { return _language; }

            set { _language = value; }
        }
        public string descTxt
        {
            get { return _descTxt; }

            set { _descTxt = value; }
        }
    }

    public class XProp
    {
        private string theID = ""; //行编号

        private string theDisplayName = ""; //属性名称
        private List<MultiLangDesc> _MuliLangDisplayName;

        private string theCategory = ""; //属性所属类别
        private List<MultiLangDesc> _MuliLangeCategory;

        private string theName = "";     //属性正则

        private bool theReadOnly = false;  //属性的只读性，true为只读

        private string theDescription = ""; //属性的描述内容
        private List<MultiLangDesc> _MuliLangeDescription;

        private object theValue = null;    //值

        private System.Type theType = null; //类型

        TypeConverter theConverter = null;  //类型转换

        public List<MultiLangDesc> MuliLangDisplayName
        {
            get { return _MuliLangDisplayName; }

            set { _MuliLangDisplayName = value; }
        }

        public List<MultiLangDesc> MuliLangeCategory
        {
            get { return _MuliLangeCategory; }

            set { _MuliLangeCategory = value; }
        }

        public List<MultiLangDesc> MuliLangeDescription
        {
            get { return _MuliLangeDescription; }

            set { _MuliLangeDescription = value; }
        }
        public string DisplayName
        {
            get { return theDisplayName; }

            set { theDisplayName = value; }
        }

        public string ID
        {
            get { return theID; }

            set { theID = value; }
        }
        public string Category
        {
            get { return theCategory; }

            set { theCategory = value; }
        }

        public bool ReadOnly
        {
            get { return theReadOnly; }

            set { theReadOnly = value; }
        }
        public string Name
        {
            get { return this.theName; }

            set { this.theName = value; }
        }
        public object Value
        {
            get { return this.theValue; }

            set
            {
                this.theValue = value;
            }
        }
        public string Description
        {
            get { return theDescription; }

            set { theDescription = value; }
        }

        public System.Type ProType
        {
            get { return theType; }

            set { theType = value; }
        }


        public virtual TypeConverter Converter
        {
            get { return theConverter; }
            set { theConverter = value; }
        }

        //copy数据
        public static XProp Copy(XProp xProp)
        {
            XProp _XProp = new XProp();
            _XProp.ID = xProp.ID;
            _XProp.DisplayName = xProp.DisplayName;
            _XProp.Category = xProp.Category;
            _XProp.Converter = xProp.Converter;
            _XProp.Description = xProp.Description;
            _XProp.ProType = xProp.ProType;
            _XProp.Value = xProp.Value;
            _XProp.Name = xProp.Name;
            _XProp.MuliLangDisplayName = xProp.MuliLangDisplayName;
            _XProp.MuliLangeCategory = xProp.MuliLangeCategory;
            _XProp.MuliLangeDescription = xProp.MuliLangeDescription;
            return _XProp;
        }
    }
}
