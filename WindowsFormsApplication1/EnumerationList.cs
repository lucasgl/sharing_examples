using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class EnumerationList : BaseNotify
    {
        private ObservableCollection<Enumeration> _items;
        /// <summary>
        /// Gets or sets the key value pair list.
        /// </summary>
        /// <value>
        /// The key value pair list.
        /// </value>
        public ObservableCollection<Enumeration> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollection<Enumeration>();
                }
                return _items;
            }
            set
            {
                _items = value;
                this.OnPropertyChanged("Items");
            }
        }


        public bool LoadExcel(string path, string sheet)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties=\"Excel 12.0 Macro;HDR=NO\"; ", path);
            string query = string.Format("SELECT * FROM [{0}$]", sheet);
            DataTable data2 = new DataTable();
            Enumeration e = new Enumeration();

            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                    adapter.Fill(data2);
                }

                bool start = false;
                this.Items.Clear();

                for (int col = 0; col < data2.Columns.Count; col += 3)
                {
                    e = new Enumeration();
                    start = true;
                    for (int row = 0; row < data2.Rows.Count; row++)
                    {
                        if (data2.Rows[row][col].ToString() == "")
                        {
                            start = true;
                            if (e.Items.Count > 0 && e.Name != null)
                            {
                                this.Items.Add(e);
                            }
                            e = new Enumeration();
                        }
                        else
                        {
                            if (start)
                            {
                                e.Name = data2.Rows[row][col].ToString();
                                start = false;
                            }
                            else
                            {
                                EnumerationItem eItem = new EnumerationItem();
                                eItem.Value = Convert.ToInt32((data2.Rows[row][col]).ToString(), 16);
                                eItem.Name = data2.Rows[row][col + 1].ToString();
                                e.Items.Add(eItem);
                                if (row == data2.Rows.Count - 1)// if this enumeration goes to the bottom of the file
                                {
                                    this.Items.Add(e);
                                }
                            }
                        }
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
