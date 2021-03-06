﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        private async void Send_Clicked(object sender, EventArgs e)
        {

            var item = viewModel.Item;
            await Navigation.PushAsync(new MessagePage(new MessagePageViewModel(item)));
        }
    }
}