﻿using System.Windows;

namespace GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new BookModel();
            DataContext = new DashboardViewModel();
            

        }
    }
}
