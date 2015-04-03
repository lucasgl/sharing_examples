using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class KeyValuePair : BaseNotify
    {
        private int _key;

        public int Key
        {
            get { return _key; }
            set 
            { 
                _key = value;
                OnPropertyChanged("Key");
            }
        }

        private byte _value;

        public byte Value
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
