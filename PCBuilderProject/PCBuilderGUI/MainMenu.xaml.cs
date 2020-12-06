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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        

        bool CPUList = false;
        bool GPUList = false;
        bool MBList = false;
        bool RAMList = false;
        string userName = "";

        private CRUDManager crud = new CRUDManager();

        public MainMenu()
        {
            InitializeComponent();
            PopulateListBox();
            
        }
        public MainMenu(string userLogin) : this()
        {
            userName = userLogin;
        }
        private void PopulateListBox()
        {
            
            if (CPUList) {
                lb_List.ItemsSource = crud.RetrieveAllCPU();
            }
            if (GPUList)
            {
                lb_List.ItemsSource = crud.RetrieveAllGPU();
            }
            if (RAMList)
            {
                lb_List.ItemsSource = crud.RetrieveAllRAM();
            }
            if (MBList)
            {
                lb_List.ItemsSource = crud.RetrieveAllMB();
            }
        }

        private void b_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CPUList)
            {
                if (crud.SelectProcessor != null)
                {
                    crud.DeleteProcessor(crud.SelectProcessor.Cpuid);
                }
            }
            if (GPUList)
            {
                if (crud.SelectGraphicscard != null)
                {
                    crud.DeleteGraphicsCard(crud.SelectGraphicscard.Gcid);
                }
            }
            if (RAMList)
            {
                if (crud.SelectRAM != null)
                {
                    crud.DeleteRam(crud.SelectRAM.Ramid);
                }
            }
            if (MBList)
            {
                if (crud.SelectMotherboard != null)
                {
                    crud.DeleteMotherboard(crud.SelectMotherboard.Mbid);
                }
            }
        }

        private void b_Update_Click(object sender, RoutedEventArgs e)
        {
            if (CPUList)
            {
                UpdateCPU updateCPU = new UpdateCPU();
                updateCPU.Show();
                PopulateFields(updateCPU);
            }
            if (RAMList)
            {
                UpdateRAM updateRAM = new UpdateRAM();
                updateRAM.Show();
                PopulateFields(updateRAM);
            }
            if (GPUList)
            {
                UpdateGraphicsCard updateGPU = new UpdateGraphicsCard();
                updateGPU.Show();
                PopulateFields(updateGPU);
            }
            if (MBList)
            {
                UpdateMotherBoard updateMB = new UpdateMotherBoard();
                updateMB.Show();
                PopulateFields(updateMB);
            }
        }

        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            if (CPUList)
            {
                ComponentWindow addCPU = new ComponentWindow();
                addCPU.Show();
            }
            if (RAMList)
            {
                AddRAM addRAM = new AddRAM();
                addRAM.Show();
            }
            if (GPUList)
            {
                AddGraphicsCard addGraphicsCard = new AddGraphicsCard();
                addGraphicsCard.Show();
            }
            if (MBList)
            {
                AddMotherBoard addMB = new AddMotherBoard();
                addMB.Show();
            }
        }

        private void b_RAM_Click(object sender, RoutedEventArgs e)
        {
            RAMList = true;
            GPUList = false;
            MBList = false;
            CPUList = false;
            if (RAMList) {
                b_RAM.Background = Brushes.Gray;
                b_Processor.Background = Brushes.Black;
                b_Motherboard.Background = Brushes.Black;
                b_GraphicsCard.Background = Brushes.Black;
                lb_List.ItemsSource = crud.RetrieveAllRAM();
            }
            
        }

        private void b_Processor_Click(object sender, RoutedEventArgs e)
        {
            CPUList = true;
            GPUList = false;
            MBList = false;
            RAMList = false;
            if (CPUList)
            {
                b_Processor.Background = Brushes.Gray;
                b_Motherboard.Background = Brushes.Black;
                b_RAM.Background = Brushes.Black;
                b_GraphicsCard.Background = Brushes.Black;
                lb_List.ItemsSource = crud.RetrieveAllCPU();
            }
            
        }

        private void b_GraphicsCard_Click(object sender, RoutedEventArgs e)
        {
            GPUList = true;
            MBList = false;
            RAMList = false;
            CPUList = false;
            if (GPUList)
            {
                b_GraphicsCard.Background = Brushes.Gray;
                b_Processor.Background = Brushes.Black;
                b_Motherboard.Background = Brushes.Black;
                b_RAM.Background = Brushes.Black;
                lb_List.ItemsSource = crud.RetrieveAllGPU();
            }
            
        }

        private void b_Motherboard_Click(object sender, RoutedEventArgs e)
        {
            MBList = true;
            RAMList = false;
            GPUList = false;
            CPUList = false;
            if (MBList)
            {
                b_Motherboard.Background = Brushes.Gray;
                b_GraphicsCard.Background = Brushes.Black;
                b_RAM.Background = Brushes.Black;
                b_Processor.Background = Brushes.Black;
                lb_List.ItemsSource = crud.RetrieveAllMB();
            }
            
        }

        private void b_Components_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Logged in as: {userName} ");
        }
        public void PopulateFields (UpdateCPU updateCPU)
        {
            if (CPUList) {
                if (crud.SelectProcessor != null)
                {
                    if (crud.SelectProcessor.Manufacturer.Contains("AMD"))
                    {
                        updateCPU.Manufacturer_AMD.IsChecked = true;
                        updateCPU.Manufacturer_Intel.IsChecked = false;
                    }
                    else
                    {
                        updateCPU.Manufacturer_Intel.IsChecked = true;
                        updateCPU.Manufacturer_AMD.IsChecked = false;
                    }
                    updateCPU.i_CPUFamily.Text = crud.SelectProcessor.Cpufamily;
                    updateCPU.i_Core.Text = crud.SelectProcessor.Core.ToString();
                    updateCPU.i_Price.Text = crud.SelectProcessor.Price.ToString();
                }
            }
        }
        public void PopulateFields(UpdateGraphicsCard updateGPU)
        {
            if (GPUList)
            {
                if (crud.SelectGraphicscard != null)
                {
                    updateGPU.i_VRAM.Text = crud.SelectGraphicscard.Vram.ToString();
                    updateGPU.i_Manufacturer.Text = crud.SelectGraphicscard.Manufacturer;
                    updateGPU.i_Model.Text = crud.SelectGraphicscard.Model;
                    updateGPU.i_Price.Text = crud.SelectGraphicscard.Price.ToString();
                }
            }
        }
        public void PopulateFields(UpdateRAM updateRAM)
        {
            if (RAMList)
            {
                if (crud.SelectRAM != null)
                {
                    updateRAM.i_Capacity.Text = crud.SelectRAM.Capacity.ToString();
                    updateRAM.i_Manufacturer.Text = crud.SelectRAM.Manufacturer;
                    updateRAM.i_Model.Text = crud.SelectRAM.Model;
                    updateRAM.i_Price.Text = crud.SelectRAM.Price.ToString();
                    updateRAM.i_Speed.Text = crud.SelectRAM.Speed.ToString();
                }
            }
        }
        public void PopulateFields(UpdateMotherBoard updateMB)
        {
            if (MBList)
            {
                if (crud.SelectMotherboard != null)
                {
                    updateMB.i_Manufacturer.Text = crud.SelectMotherboard.Manufacturer;
                    updateMB.i_MbName.Text = crud.SelectMotherboard.Mbname;
                    updateMB.i_Price.Text = crud.SelectMotherboard.Price.ToString();
                }
            }
        }
        private void ListBoxComp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_List.SelectedItem != null)
            {
                if (CPUList) {
                    crud.SetSelectedProcessor(lb_List.SelectedItem);
                }
                if (RAMList)
                {
                    crud.SetSelectedRAM(lb_List.SelectedItem);
                }
                if (GPUList)
                {
                    crud.SetSelectedGraphicsCard(lb_List.SelectedItem);
                    
                }
                if (MBList)
                {
                    crud.SetSelectedMotherboard(lb_List.SelectedItem);
                }
            }
        }

        private void lb_MyComputer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void b_AddComputer_Click(object sender, RoutedEventArgs e)
        {
            if (CPUList)
            {
                //crud.RetrieveAllPCComponents("mvnsib").Add;
            }
        }

        private void b_RemoveComputer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
