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
    public partial class KeyValuePairView : UserControl
    {
        KeyValuePairList mykvpList = new KeyValuePairList();

        private int cycleValue = 0;
        private int operationValue = 0;

        public KeyValuePairView()
        {
            InitializeComponent();
            this.DataContext = mykvpList;
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
                    if ((mykvpList.LoadExcel(ofd.FileName, "Keys")))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Error Loading Sheet");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
        }

    }
}
