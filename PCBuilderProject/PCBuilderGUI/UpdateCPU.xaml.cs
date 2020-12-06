using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PCBuilderBusinessLayer;
using System.Linq;

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for UpdateCPU.xaml
    /// </summary>
    public partial class UpdateCPU : Window
    {
        public UpdateCPU()
        {
            InitializeComponent();
        }
        CRUDManager crud = new CRUDManager();

        string manufacturer = "";
        string cpuFamily = "";
        int core = 0;
        int price = 0;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            cpuFamily = i_CPUFamily.Text;
        }

        private void Core_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                core = Int32.Parse(i_Core.Text);
            }
            catch
            {
                MessageBox.Show("Please input an integer value");
            }
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                price = Int32.Parse(i_Price.Text);
            }
            catch
            {
                MessageBox.Show("Please input an integer value");
            }
        }


        private void Manufacturer_AMD_Checked(object sender, RoutedEventArgs e)
        {
            manufacturer = "AMD";
        }

        private void Manufacturer_Intel_Checked(object sender, RoutedEventArgs e)
        {
            manufacturer = "Intel";
        }

        private void b_Update_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturer != "" && cpuFamily != "" && core != 0 && price != 0)
            {
                crud.UpdateCPU(manufacturer, cpuFamily, core, price);
                MessageBox.Show("Updated CPU Successfully");
            }
            
        }
    }
}
