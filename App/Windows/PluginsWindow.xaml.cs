﻿using System;
using System.Windows;
using TranslatorApk.Logic.ViewModels.Windows;

namespace TranslatorApk.Windows
{
    public partial class PluginsWindow
    {
        public PluginsWindow()
        {
            InitializeComponent();

            ViewModel = new PluginsWindowViewModel();
        }

        internal PluginsWindowViewModel ViewModel
        {
            get => DataContext as PluginsWindowViewModel;
            private set => DataContext = value;
        }

        private async void PluginsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadItems();
        }

        private void PluginsWindow_OnClosed(object sender, EventArgs e)
        {
            ViewModel.Dispose();
        }
    }
}
