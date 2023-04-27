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
	public partial class CorrectAnswer : ContentPage
	{
		public CorrectAnswer ()
		{
			/*	CorrectMessage is a label that has a text attribute. This text attribute can be overwritten with a string. It is overwritten in this case
				with "Well done! That was the correct answer!" */
			InitializeComponent();
            CorrectMessage.Text = "Well done! That was the correct answer!";
		}

        private async void OnClick(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new QuestionsPageButtons());
        }
    }
}