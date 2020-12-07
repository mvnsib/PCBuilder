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

        string userName = "";
        string passWord = "";
        public Login()
        {
            InitializeComponent();
        }
        CRUDManager crud = new CRUDManager();
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = i_Login.Text;
        }

        private void b_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Content = reg;

        }

        private void i_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            passWord = i_Password.Text;
        }

        private void b_SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (userName != "" && passWord != "")
                {
                    bool access = crud.ReadUsernameAndPassword(userName, passWord);
                    if (access)
                    {
                        crud.SetSelectedUser("mvnsib");
                        MainMenu m = new MainMenu(userName);
                        m.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Please input your username or password");
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
