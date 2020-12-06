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
    /// Interaction logic for UpdateRAM.xaml
    /// </summary>
    public partial class UpdateRAM : Window
    {
        public UpdateRAM()
        {
            InitializeComponent();
        }

        int capacity = 0;
        string manufacturer = "";
        string model = "";
        int speed = 0;
        int price = 0;

        CRUDManager updateRAM = new CRUDManager();
        private void b_Update_Click(object sender, RoutedEventArgs e)
        {
            if (capacity != 0 && manufacturer != "" && model != "" && price != 0 && speed != 0)
            {
                updateRAM.UpdateRAM(capacity, manufacturer, model, speed, price);
                MessageBox.Show("Updated RAM Successfully");
            }
        }

        private void Capacity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                capacity = Int32.Parse(i_Capacity.Text);
            }
            catch
            {
                MessageBox.Show("Please input an integer value");
            }
        }

        private void Manufacturer_TextChanged(object sender, TextChangedEventArgs e)
        {
            manufacturer = i_Manufacturer.Text;
        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            model = i_Model.Text;
        }

        private void Speed_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                speed = Int32.Parse(i_Speed.Text);
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
    }
}
