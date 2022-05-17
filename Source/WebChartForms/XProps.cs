using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;

namespace WebChartForms
{
    public class XProps : List<XProp>, ICustomTypeDescriptor
    {
        #region ICustomTypeDescriptor 成员

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(System.Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(System.Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(System.Attribute[] attributes)
        {
            PropertyDescriptor[] props = new PropertyDescriptor[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                props[i] = new XPropDescriptor(this[i], attributes);
            }
            return new PropertyDescriptorCollection(props);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append("[" + i + "] " + this[i].ToString() + System.Environment.NewLine);
            }
            return sb.ToString();
        }

        //ToJson
        public string ToJson()
        {

            return JsonConvert.SerializeObject(this);

        }


        //FromJson
        public XProps FromJson(string json)
        {

            return JsonConvert.DeserializeObject<XProps>(json);

        }

        public static XProps CopyXProps(XProps xprops)
        {
            XProps xprs = new XProps();

            //把数据Copy到一个新的XProps类里
            foreach (XProp item in xprops)
            {
                xprs.Add(XProp.Copy(item));
            }
            return xprs;
        }
    }
}
