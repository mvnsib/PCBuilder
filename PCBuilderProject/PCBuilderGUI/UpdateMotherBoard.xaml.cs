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

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for UpdateMotherBoard.xaml
    /// </summary>
    public partial class UpdateMotherBoard : Window
    {
        CRUDManager updateMB = new CRUDManager();
        string manufacturer = "";
        string mbName = "";
        int price = 0;

        public UpdateMotherBoard()
        {
            InitializeComponent();
        }

        private void Manufacturer_TextChanged(object sender, TextChangedEventArgs e)
        {
            manufacturer = i_Manufacturer.Text;
        }

        private void MbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            mbName = i_MbName.Text;
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

        private void b_Update_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturer != "" && mbName != "" && price != 0)
            {
                updateMB.UpdateMotherboard(manufacturer, mbName, price);
                MessageBox.Show("Updated Mother Board successfully");
            }
        }
    }
}
