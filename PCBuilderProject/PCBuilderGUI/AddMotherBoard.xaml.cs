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
    /// Interaction logic for AddMotherBoard.xaml
    /// </summary>
    public partial class AddMotherBoard : Window
    {
        CRUDManager addMB = new CRUDManager();

        string manufacturer = "";
        string mbName = "";
        int price = 0;

        public AddMotherBoard()
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

        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturer != "" && mbName != "" && price != 0)
            {
                addMB.CreateMotherBoard(manufacturer, mbName, price);
                MessageBox.Show("Added Mother Board successfully");
            }
        }
    }
}
