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
    /// Interaction logic for UpdateGraphicsCard.xaml
    /// </summary>
    public partial class UpdateGraphicsCard : Window
    {
        int vRAM = 0;
        string manufacturer = "";
        string model = "";
        int price = 0;

        CRUDManager updateGPU = new CRUDManager();

        public UpdateGraphicsCard()
        {
            InitializeComponent();
        }

        private void VRAM_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                vRAM = Int32.Parse(i_VRAM.Text);
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
            if (manufacturer != "" && model != "" && price != 0 && vRAM != 0)
            {
                updateGPU.UpdateGraphicsCard(vRAM, manufacturer, model, price);
                MessageBox.Show("Updated GPU Successfully");
            }
        }
    }
}
