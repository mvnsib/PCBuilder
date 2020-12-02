using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PCBuilderBusinessLayer;

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Uri Source { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void b_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Content = reg;

        }

        private void i_Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
