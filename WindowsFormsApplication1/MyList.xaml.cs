using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WindowsFormsApplication1
{
    /// <summary>
    /// Interaction logic for MyList.xaml
    /// </summary>
    public partial class MyList : UserControl
    {
        KeyValuePairList myList = new KeyValuePairList();
        public MyList()
        {
            InitializeComponent();
            this.DataContext = myList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Key Value Files (*.xls, *.xlsm)|*.xls;*.xlsm";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                try
                {
                    myList.LoadExcel(ofd.FileName, "Keys");
                }
                catch
                {
                    MessageBox.Show("'Keys' worksheet not found in selected file");
                }
            }
        }
    }
}
