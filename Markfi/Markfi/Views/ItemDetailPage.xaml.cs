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
        async void OnClick(object sender, EventArgs e)
        {
            // Load questions from file / database
            await Navigation.PushAsync(new QuestionsPageButtons());
            // Make first question page
        }
    }
}