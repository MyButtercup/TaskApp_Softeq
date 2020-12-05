using System;
using System.Collections.Generic;
using TaskApp.ViewModels;
using TaskApp.Views;
using Xamarin.Forms;

namespace TaskApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
