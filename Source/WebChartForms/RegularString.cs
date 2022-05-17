using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChartForms
{
    public class RegularString
    {
        private string _value;

        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Language { get; set; }
        public List<string> ls { get; set; }
    }
}
