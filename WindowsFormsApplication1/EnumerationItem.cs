using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class EnumerationItem : BaseNotify
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.OnPropertyChanged("Name");
            }
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.OnPropertyChanged("Value");
            }
        }

    }
}
