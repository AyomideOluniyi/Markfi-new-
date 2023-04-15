using System;
using System.ComponentModel;
using Markfi.ViewModels;
using Xamarin.Forms;

namespace Markfi.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
        void OnClick(object sender, EventArgs e)
        {
            // Show loading screen
            // Load questions from file / database
            // Make first question page
        }
    }
}