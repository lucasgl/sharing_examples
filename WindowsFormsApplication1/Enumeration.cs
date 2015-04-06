using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Enumeration : BaseNotify
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

        private ObservableCollection<EnumerationItem> _items;
        /// <summary>
        /// Gets or sets the key value pair list.
        /// </summary>
        /// <value>
        /// The key value pair list.
        /// </value>
        public ObservableCollection<EnumerationItem> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollection<EnumerationItem>();
                }
                return _items;
            }
            set
            {
                _items = value;
                this.OnPropertyChanged("Items");
            }
        }

    }
}
