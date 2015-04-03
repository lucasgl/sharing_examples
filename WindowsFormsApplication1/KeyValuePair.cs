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
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public int Key
        {
            get { return _key; }
            set 
            { 
                _key = value;
                OnPropertyChanged("Key");
            }
        }

        private double _value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value
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
