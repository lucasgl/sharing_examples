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
        KeyValuePairList mykvpList = new KeyValuePairList();
        EnumerationList enumList = new EnumerationList();

        private int cycleValue = 0;
        private int operationValue = 0;

        public MyList()
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
                    if ((mykvpList.LoadExcel(ofd.FileName, "Keys") && enumList.LoadExcel(ofd.FileName, "Enumerations")))
                    {
                        comboUpperLower.Items.Clear();
                        comboUpperLower.Items.Add("Upper");
                        comboUpperLower.Items.Add("Lower");
                        comboUpperLower.SelectedIndex = 0;

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

        private void comboUpperLower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<Enumeration> eList = new List<Enumeration>();
                eList.AddRange(enumList.Items);
                foreach (Enumeration Enum in eList)
                {
                    if (Enum.Name == "Cavity Mode Oven")
                    {
                        List<EnumerationItem> eItemList = new List<EnumerationItem>();
                        eItemList.AddRange(Enum.Items);

                        comboCycleSelect.Items.Clear();
                        foreach (EnumerationItem eItem in eItemList)
                        {
                            comboCycleSelect.Items.Add(eItem.Name);
                        }

                        comboCycleSelect.SelectedIndex = 0;
                    }

                    if (Enum.Name == "Cavity Operations")
                    {
                        List<EnumerationItem> eItemList = new List<EnumerationItem>();
                        eItemList.AddRange(Enum.Items);

                        comboOperation.Items.Clear();
                        foreach (EnumerationItem eItem in eItemList)
                        {
                            comboOperation.Items.Add(eItem.Name);
                        }

                        comboOperation.SelectedIndex = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void comboCycleSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cycleValue = comboCycleSelect.SelectedIndex;
        }

        private void comboOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operationValue = comboOperation.SelectedIndex;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            textBlockValues.Text = string.Format("Cycle: {0}, Operation: {1}", cycleValue.ToString("X2"), operationValue.ToString("X2"));
        }

    }
}
