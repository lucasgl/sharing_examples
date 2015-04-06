using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class KeyValuePair : BaseNotify
    {

        private string _class;

        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                this.OnPropertyChanged("Class");
            }
        }

        private enum DisplayNameType
        {
            INT8,
            INT32
        }

        private DisplayNameType _displayName;

        public string DisplayName
        {
            get { return _displayName.ToString(); }
            set
            {
                _displayName = (DisplayNameType)Enum.Parse(typeof(DisplayNameType), value);
                this.OnPropertyChanged("DisplayName");
            }
        }

        public DisplayNameType DisplayNameEnum
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                this.OnPropertyChanged("DisplayNameEnum");
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

        private int _datatype;

        public int Datatype
        {
            get { return _datatype; }
            set
            {
                _datatype = value;
                this.OnPropertyChanged("Datatype");
            }
        }

        private string _settable;

        public string Settable
        {
            get { return _settable; }
            set
            {
                _settable = value;
                this.OnPropertyChanged("Settable");
            }
        }
    }
}
