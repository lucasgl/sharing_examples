using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Enumeration : BaseNotify
    {
        private string _enumName;

        public string EnumName
        {
            get { return _enumName; }
            set
            {
                _enumName = value;
                this.OnPropertyChanged("EnumName");
            }
        }

        private string _enumValue;

        public string EnumValue
        {
            get { return _enumValue; }
            set
            {
                _enumValue = value;
                this.OnPropertyChanged("EnumValue");
            }
        }

    }
}
