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
using System.Linq;

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
            //i_Password.PasswordChar = '●';
            passWord = i_Password.Text;
            
        }

        private void b_SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isDigitPresent = i_Password.Text.ToString().Any(c => char.IsDigit(c));
                if (userName != "" && firstname != "" && lastName != "" && passWord != "") {
                    if (isDigitPresent == true && i_Password.Text.Length >= 6)
                    {
                        if (i_ConfirmPassword.Text.ToString().Equals(i_Password.Text.ToString())) {
                            create.CreateUser(userName, firstname, lastName, passWord);
                            userName = "";
                            firstname = "";
                            lastName = "";
                            passWord = "";
                            MessageBox.Show("Registered Successfully");
                            var log = new Login();
                            
                            var window = (Login)Application.Current.MainWindow;
                            log.Show();
                            window.Hide();
                            

                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Add a number or make your password 6 or more characters to make your password stronger");
                    }
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