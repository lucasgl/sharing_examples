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
    /// Interaction logic for EnumerationListView.xaml
    /// </summary>
    public partial class EnumerationListView : UserControl
    {
        EnumerationList enumList = new EnumerationList();
        public EnumerationListView()
        {
            InitializeComponent();
            this.DataContext = enumList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Key Value Files (*.xls, *.xlsm)|*.xls;*.xlsm";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                try
                {
                    if (enumList.LoadExcel(ofd.FileName, "Enumerations"))
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
