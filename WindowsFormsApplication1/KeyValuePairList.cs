using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;

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

        public bool LoadExcel(string path, string sheet)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties=\"Excel 12.0 Macro;HDR=NO\"; ", path);
            string query = string.Format("SELECT * FROM [{0}$]", sheet);
            DataTable data = new DataTable();
            KeyValuePair kvp = new KeyValuePair();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(data);
                }

                bool start = false;
                this.Items.Clear();

                foreach (DataRow d in data.Rows)
                {
                    if (start && d[0].ToString() != "")
                    {
                        kvp = new KeyValuePair();
                        kvp.Class = d[0].ToString();
                        kvp.DisplayName = d[2].ToString();
                        kvp.Length = d[5].ToString();
                        kvp.ID = Convert.ToInt32(d[7].ToString(), 16);
                        kvp.Name = d[8].ToString();
                        kvp.DataTypeString = d[10].ToString();
                        kvp.SettableString = d[11].ToString();
                        this.Items.Add(kvp);

                    }
                    if (d[0].ToString() == "Class")
                    {
                        start = true;
                    }
                }
                return true;
            }

            catch (Exception ex) 
            { 
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}
