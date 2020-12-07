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
using PCBuilderProject;
using PCBuilderBusinessLayer;

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for AddComputer.xaml
    /// </summary>
    public partial class AddComputer : Window
    {
        
        CRUDManager crud = new CRUDManager();
        string userName = "";
        int cpuCost = 0;

        public AddComputer()
        {
            InitializeComponent();
            PopulateListBox();
        }
        public AddComputer(string _userName) : this()
        {
            userName = _userName;
            crud.SetSelectedUser(userName);
        }

        private void lb_CPU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_CPU.SelectedItem != null)
            {
                crud.SetSelectedProcessor(lb_CPU.SelectedItem);
            }
               
        }

        private void lb_MB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_MB.SelectedItem != null)
            {
                crud.SetSelectedMotherboard(lb_MB.SelectedItem);
            }
        }

        private void lb_RAM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_RAM.SelectedItem != null)
            {
                crud.SetSelectedRAM(lb_RAM.SelectedItem);
            }
        }

        private void lb_GPU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_GPU.SelectedItem != null)
            {
                crud.SetSelectedGraphicsCard(lb_GPU.SelectedItem);

            }
        }
        private void PopulateListBox()
        {
            lb_CPU.ItemsSource = crud.RetrieveAllCPU();
            lb_GPU.ItemsSource = crud.RetrieveAllGPU();
            lb_RAM.ItemsSource = crud.RetrieveAllRAM();
            lb_MB.ItemsSource = crud.RetrieveAllMB();
        }
        
        private void b_CreatePC_Click(object sender, RoutedEventArgs e)
        {
            if (crud.SelectProcessor != null && crud.SelectRAM != null && crud.SelectGraphicscard != null && crud.SelectMotherboard != null)
            {
                
                crud.AddPC(crud.SelectProcessor.Cpufamily, crud.SelectRAM.Model, crud.SelectRAM.Speed, crud.SelectGraphicscard.Model, crud.SelectMotherboard.Mbname);
                MessageBox.Show("Added to My Computer Successfully");
                this.Close();
            }
        }
    }
}
