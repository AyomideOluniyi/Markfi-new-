using System;
using System.Collections.Generic;
using System.ComponentModel;
using Markfi.Models;
using Markfi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markfi.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}