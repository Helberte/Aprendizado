﻿namespace MauiFlayoutPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlayoutPageMenu();
        }
    }
}
