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
using System.Windows.Navigation;
using PCBuilderProject;
using PCBuilderBusinessLayer;
using System.Windows.Shapes;

namespace PCBuilderGUI
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        string userName = "";
        string firstname = "";
        string lastName = "";
        string passWord = "";
        string confirmPassword = "";
        string alertMessage = "";
        bool usernameExist = false;
        public Register()
        {
            InitializeComponent();
        }
        CreateBusinessLayer create = new CreateBusinessLayer();

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = i_UserName.Text;

        }

        private void i_ConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void i_FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            firstname = i_FirstName.Text;
        }

        private void i_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lastName = i_LastName.Text;
        }

        private void i_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            passWord = i_Password.Text;
        }

        private void b_SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userName != "" && firstname != "" && lastName != "" && passWord != "") {
                    create.CreateUser(userName, firstname, lastName, passWord);
                }
                else
                {
                    MessageBox.Show("Please fill in all the data");
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}