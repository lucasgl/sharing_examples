using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class KeyValuePair : BaseNotify
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>

        
        private string _class;
        /// <summary>
        /// Gets and sets Class of KVP
        /// </summary>
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                this.OnPropertyChanged("Class");
            }
        }

        private string _displayName;
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                this.OnPropertyChanged("DisplayName");
            }
        }


        public enum DataTypeEnum
        {
            INT8,
            INT16,
            INT32,
            BOOLEAN,
            STRING
        }

        private DataTypeEnum _dataType;

        public string DataTypeString
        {
            get { return _dataType.ToString(); }
            set
            {
                _dataType = (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), value.ToUpper());
                this.OnPropertyChanged("DataTypeString");
                this.OnPropertyChanged("DataType");
            }
        }

        public DataTypeEnum DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                this.OnPropertyChanged("DataType");
                this.OnPropertyChanged("DataTypeString");
            }
        }

        private string _length;

        public string Length
        {
            get { return _length; }
            set
            {
                _length = value;
                this.OnPropertyChanged("Length");
            }
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                this.OnPropertyChanged("ID");
            }
        }

        private int _alternate = 0;
        /// <summary>
        /// Gets or sets the alternate.
        /// Used to alternate style between key value pairs with same alternate value in a row.
        /// </summary>
        /// <value>
        /// The alternate.
        /// </value>
        public int Alternate
        {
            get { return _alternate; }
            set
            {
                _alternate = value % MaxAlternate;
                this.OnPropertyChanged("Alternate");
            }
        }

        private int _maxAlternate = 2;
        /// <summary>
        /// Gets or sets the maximum alternate number.
        /// Set 2 by default (i.e. allows 0 and 1 on the Alternate property).
        /// </summary>
        /// <value>
        /// The maximum alternate.
        /// </value>
        public int MaxAlternate
        {
            get { return _maxAlternate; }
            set
            {
                _maxAlternate = value;
                this.OnPropertyChanged("MaxAlternate");
            }
        }


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

        public enum SettableEnum
        {
            GET,
            SET,
            BOTH,
            PUBLISH
        }

        private SettableEnum _settable;

        public string SettableString
        {
            get { return _settable.ToString(); }
            set
            {
                _settable = (SettableEnum)Enum.Parse(typeof(SettableEnum), value.ToUpper());
                this.OnPropertyChanged("SettableString");
                this.OnPropertyChanged("Settable");
            }
        }

        public SettableEnum Settable
        {
            get { return _settable; }
            set
            {
                _settable = value;
                this.OnPropertyChanged("Settable");
                this.OnPropertyChanged("SettableString");
            }
        }
    }
}
