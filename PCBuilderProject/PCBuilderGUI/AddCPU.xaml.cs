﻿using System;
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
using System.Text.RegularExpressions;
using PCBuilderProject;

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for ComponentWindow.xaml
    /// </summary>
    public partial class ComponentWindow : Window
    {

        string manufacturer = "";
        string cpuFamily = "";
        int core = 0;
        int price = 0;
        string userName;
        CRUDManager addCPU = new CRUDManager();



        public ComponentWindow()
        {
            InitializeComponent();

        }
        public ComponentWindow(string _userName):this()
        {
            userName = _userName;
            addCPU.SetSelectedUser(userName);
        }
        

        

        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            int uID = 0;
            if (manufacturer != "" && cpuFamily != "" && core != 0 && price != 0) {
                    addCPU.CreateProcessor(manufacturer, cpuFamily, core, price, addCPU.findUserID(userName));
                    MessageBox.Show("Added CPU Successfully");
                }
        }


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

        private void Manufacturer_AMD_Checked(object sender, RoutedEventArgs e)
        {
            manufacturer = "AMD";
        }

        private void Manufacturer_Intel_Checked(object sender, RoutedEventArgs e)
        {
            manufacturer = "Intel";
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
