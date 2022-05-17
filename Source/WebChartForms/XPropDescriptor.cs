using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChartForms
{
    public class XPropDescriptor : PropertyDescriptor
    {

        XProp theProp;

        public XPropDescriptor(XProp prop, Attribute[] attrs)
            : base(prop.DisplayName.ToString(), attrs)
        {

            theProp = prop;

        }



        public override bool CanResetValue(object component)
        {

            return false;

        }

        public override string Category
        {

            get { return theProp.Category; }

        }

        public override string DisplayName
        {

            get { return theProp.DisplayName.ToString(); }

        }

        public override string Name
        {

            get { return theProp.Name; }

        }
        public override string Description
        {

            get { return theProp.Description; }

        }


        public override TypeConverter Converter
        {

            get { return theProp.Converter; }

        }



        public override System.Type ComponentType
        {

            get { return this.GetType(); }

        }



        public override object GetValue(object component)
        {

            return theProp.Value;

        }



        public override bool IsReadOnly
        {

            get { return theProp.ReadOnly; }

        }



        public override System.Type PropertyType
        {

            get { return theProp.ProType; }

        }



        public override void ResetValue(object component)
        {

        }



        public override void SetValue(object component, object value)
        {

            theProp.Value = value.ToString();

        }



        public override bool ShouldSerializeValue(object component)
        {

            return false;

        }
    }
}
