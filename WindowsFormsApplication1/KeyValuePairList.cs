using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class KeyValuePairList : BaseNotify
    {
        private ObservableCollection<KeyValuePair> _myKeys;
        /// <summary>
        /// Gets or sets the key value pair list.
        /// </summary>
        /// <value>
        /// The key value pair list.
        /// </value>
        public ObservableCollection<KeyValuePair> Items
        {
            get {
                if(_myKeys == null)
                {
                    _myKeys = new ObservableCollection<KeyValuePair>();
                }
                return _myKeys; }
            set
            {
                _myKeys = value;
                this.OnPropertyChanged("Items");
            }
        }

    }
}
