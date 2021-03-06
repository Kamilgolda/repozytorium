﻿using Acr.UserDialogs;
using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Chat" },
                new HomeMenuItem {Id = MenuItemType.About, Title="Mój profil" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                if (e.SelectedItem == menuItems[1])
                {
                    if (BaseViewModel.zalogowany.IdUser == 0)
                    {
                        await UserDialogs.Instance.AlertAsync("Aby przeglądać swój profil musisz się zalogować", "Zaloguj się", "OK");
                        ListViewMenu.SelectedItem = menuItems[0];
                        await RootPage.NavigateFromMenu(0);
                        return;
                    }
                }
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}