﻿using SPEEDYBLL;
using SPEEDYSOL.Screens;
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

namespace SPEEDYSOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            windowButtons.Visibility = Visibility.Hidden;
            
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username = txtbxUsername.Text;
            string password = txtbxPassword.Password;
            if (SSUsersLINQ.AuthenticateUser(username, password))
            {
                mainFrame.Navigate(new Dashboard(this));
            }
            else
            {
                MessageBox.Show(this, "User cannot be authenticated, credentials not correct !","",MessageBoxButton.OK);
            }
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Cant navigate backwards.");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
