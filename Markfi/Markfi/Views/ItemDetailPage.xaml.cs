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
    }
}