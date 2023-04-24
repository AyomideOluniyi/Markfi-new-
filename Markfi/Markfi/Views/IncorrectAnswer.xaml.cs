using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Markfi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncorrectAnswer : ContentPage
	{
		public IncorrectAnswer ()
		{
			InitializeComponent ();
		}
        private async void OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsPageButtons());
        }
    }
}